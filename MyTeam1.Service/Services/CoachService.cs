using MyTeam_1.Interface;
using MyTeam1.Service;
using System.Runtime.InteropServices;

namespace MyTeam_1.Services
{
    public class CoachService : ICoachService
    {
        #region DI
        private readonly ICoachRepository _coachRepository;
        private readonly IEmailService _emailService;

        public CoachService(ICoachRepository coachRepository, IEmailService emailService)
        {
            _coachRepository = coachRepository;
            _emailService = emailService;
        }
        #endregion

        #region  Enumvalue

        int UserRole = (int)Roles.User;
        int CoachRole = (int)Roles.Coach;
        int CaptainRole = (int)Roles.Captain;
        int PlayerRole = (int)Roles.Player;

        #endregion

        #region GetRegisterUser
        public async Task<List<string>> GetPlayers()
        {
            var playersWithEmails = await _coachRepository.GetPlayers(UserRole);
            return playersWithEmails;
        }
        #endregion

        #region AddPlayer
        public async Task<string> AddPlayer(string email)
        {
            try
            {
                bool isPlayerRegister = await _coachRepository.IsPlayerRegister(email);
                if (!isPlayerRegister)
                {
                    return "Player is Not Register yet.";
                }

                int limitofplayer = await _coachRepository.IsPlayerLimit();
                if(limitofplayer >= 15) {
                    return "Maximum Limit Is 15 Player";
                }

                bool isPlayerAdded = await _coachRepository.IsPlayerAdded(email,CaptainRole,CoachRole);
                if (isPlayerAdded)
                {
                    return "Player is already added.";
                }

                await _coachRepository.AddPlayerToSquad(email);
                await _emailService.SendEmailAsync("jenishdevmurari77@gmail.com", email, "Welcome to Team Squad", "You are successfully added to the squad. Best of luck!");

                return "Player added successfully.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return ex.Message;
            }
        }
        #endregion

        #region AddCaptain Method
        public async Task<string> AddCaptain(string email)
        {
            try
            {
                bool isCaptainAdded = await _coachRepository.IsCaptainAdded();
                if (isCaptainAdded)
                {
                    return "Captain is already added. You Can Not Add Two Captain Into One Team";
                }

                bool isPlayerInSquad = await _coachRepository.IsPlayerInSquad(email,PlayerRole);
                if (isPlayerInSquad == false)
                {
                    return $"{email} Not Added Into Squad By Coach You can not add as Captain ";
                }

                await _coachRepository.AddCaptain(email);

                await _emailService.SendEmailAsync("jenishdevmurari77@gmail.com", email, "Congratulations!", "You have been appointed as the team captain. Best of luck!");

                return "Captain appointed successfully.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return ex.Message;
            }
        }
        #endregion

        #region ModifyCaptain Method
        public async Task<string> ModifyCaptain(string email)
        {
            try
            {

                bool isPlayerRegistered = await _coachRepository.IsPlayerRegister(email);
                if (!isPlayerRegistered)
                {
                    return "Player is not registered.";
                }

                bool isPlayerInSquad = await _coachRepository.IsPlayerInSquad(email,PlayerRole);
                if (!isPlayerInSquad)
                {
                    return "Player is not added to the squad.";
                }

            

                string oldCaptainEmail = await _coachRepository.ModifyCaptain(email);

                if(oldCaptainEmail == email)
                {
                    return "Are You Trying To Modify Exiting Captain";
                }

                if (!string.IsNullOrEmpty(oldCaptainEmail))
                {
                    await _emailService.SendEmailAsync("jenishdevmurari77@gmail.com",oldCaptainEmail, "Team Captain Change", "You have been removed as the team captain.Best of luck!");
                    await _emailService.SendEmailAsync("jenishdevmurari77@gmail.com", email, "Congratulations!", "You have been appointed as the team captain. Best of luck!");
                }

                return "Captain modified successfully.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return ex.Message;
            }
        }
        #endregion


    }
}
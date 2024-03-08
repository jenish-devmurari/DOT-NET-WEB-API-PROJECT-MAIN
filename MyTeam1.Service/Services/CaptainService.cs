using MyTeam_1.Interface;
using MyTeam_1.Repository.Interface;
using MyTeam1.Service;

namespace MyTeam_1.Services
{
    public class CaptainService : ICaptainService
    {
        #region DI
        private readonly ICaptainRepository _captainRepository;
        private readonly IEmailService _emailservice;

        public CaptainService(ICaptainRepository captainRepository, IEmailService emailservice)
        {
            _captainRepository = captainRepository;
            _emailservice = emailservice;
        }
        #endregion

        #region  Enumvalue

        int UserRole = (int)Roles.User;
        int CoachRole = (int)Roles.Coach;
        int CaptainRole = (int)Roles.Captain;
        int PlayerRole = (int)Roles.Player;


        #endregion

        #region GetPlayerList Method
        public async Task<List<string>> GetPlayerList()
        {
            var playersWithEmails = await _captainRepository.GetAvailablePlayers(PlayerRole);
            return playersWithEmails;
        }
        #endregion

        #region AddPlyerIntoTeam Method
        public async Task<string> AddPlayerToTeam(string playerEmail)
        {
            try
            {
                // Check if the player is register or not
                bool isPlayerRegister = await _captainRepository.IsPlayerRegistered(playerEmail);
                if (!isPlayerRegister)
                {
                    return "Player is not registered yet.";
                }

                // Check if the player is already in the team
                bool isPlayerInTeam = await _captainRepository.IsPlayerInTeam(playerEmail);
                if (isPlayerInTeam)
                {
                    return "Player is already in the team.";
                }

                var teamplayer = await _captainRepository.IsPlayerLimit();
                // Add player to the team
                if(teamplayer >= 11) 
                {
                    return "You can Add upto 10 palyer into Team ";
                }
                await _captainRepository.AddPlayerToTeam(playerEmail);

                // Send email notification to the player
                await _emailservice.SendEmailAsync("jenishdevmurari77@gmail.com", playerEmail, "Team Formation", "Congratulations! You have been selected to join the team.");

                return "Player added to the team successfully.";
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

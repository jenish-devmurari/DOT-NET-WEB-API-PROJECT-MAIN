using MyTeam_1.Interface;
using MyTeam_1.Repository.Interface;

namespace MyTeam_1.Services
{
    public class CaptainService : ICaptainService
    {
        private readonly ICaptainRepository _captainRepository;
        private readonly IEmailService _emailservice;

        public CaptainService(ICaptainRepository captainRepository, IEmailService emailservice)
        {
            _captainRepository = captainRepository;
            _emailservice = emailservice;
        }

        public async Task<List<string>> GetPlayerList()
        {
            var playersWithEmails = await _captainRepository.GetAvailablePlayers();
            return playersWithEmails;
        }

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
    }
}

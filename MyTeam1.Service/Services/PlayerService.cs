using MyTeam.Interface;
using MyTeam_1.Interface;
using MyTeam_1.Repository.Interface;
using System;
using System.Threading.Tasks;

namespace MyTeam_1.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<string> GetDetails(string email,int userid)
        {
            try
            {
                var user = await _playerRepository.GetUserByEmail(email);

                if(user.UserID != userid)
                {
                    return "Are You Trying To See Another User Information";
                }

                if (user != null && user.IsPlaying)
                {
                    var coach = await _playerRepository.GetCoach();
                    var captain = await _playerRepository.GetCaptain();

                    var answer = $"Congratulations {user.Email}! You are in the team. Your Team:\n Coach: {coach.FirstName} {coach.LastName} (Email: {coach.Email})\nCaptain: {captain.FirstName} {captain.LastName} (Email: {captain.Email})";
                    return answer;
                }
                else if (user != null && user.RoleID == 0)
                {
                    var coach = await _playerRepository.GetCoach();
                    var captain = await _playerRepository.GetCaptain();

                    var answer = $"Sorry {user.Email}, you are not added by the coach into the squad. \n Coach: {coach.FirstName} {coach.LastName} (Email: {coach.Email})\nCaptain: {captain.FirstName} {captain.LastName} (Email: {captain.Email})";
                    return answer;
                }
                else if (user != null && !user.IsPlaying)
                {
                    var coach = await _playerRepository.GetCoach();
                    var captain = await _playerRepository.GetCaptain();

                    var answer = $"Sorry {user.Email}, you are not in the team. \nCoach: {coach.FirstName} {coach.LastName} (Email: {coach.Email})\nCaptain: {captain.FirstName} {captain.LastName} (Email: {captain.Email})";
                    return answer;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return "User is not registered.";
        }
    }
}

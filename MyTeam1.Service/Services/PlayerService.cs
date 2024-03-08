using MyTeam.Interface;
using MyTeam_1.Interface;
using MyTeam_1.Repository.Interface;
using MyTeam1.Service;
using System;
using System.Threading.Tasks;

namespace MyTeam_1.Services
{
    public class PlayerService : IPlayerService
    {
        #region DI
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        #endregion

        #region  Enumvalue

        int UserRole = (int)Roles.User;
        int CoachRole = (int)Roles.Coach;
        int CaptainRole = (int)Roles.Captain;
        int PlayerRole = (int)Roles.Player;


        #endregion

        #region GetDetails
        public async Task<string> GetDetails(string email,int userid)
        {
            try
            {
                var user = await _playerRepository.GetUserByEmail(email);


                if(user == null)
                {
                    return "User Not Found";
                }

                if(user.UserID != userid)
                {
                    return "Are You Trying To See Another User Information";
                }

                if (user != null && user.IsPlaying)
                {
                    var coach = await _playerRepository.GetCoach(CoachRole);
                    var captain = await _playerRepository.GetCaptain(CaptainRole);

                    var answer = $"Congratulations {user.Email}! You are in the team. Your Team:\n Coach: {coach.FirstName} {coach.LastName} (Email: {coach.Email})\nCaptain: {captain.FirstName} {captain.LastName} (Email: {captain.Email})";
                    return answer;
                }
                else if (user != null && user.RoleID == 0)
                {
                    var coach = await _playerRepository.GetCoach(CoachRole);
                    var captain = await _playerRepository.GetCaptain(CaptainRole);

                    var answer = $"Sorry {user.Email}, you are not added by the coach into the squad. \n Coach: {coach.FirstName} {coach.LastName} (Email: {coach.Email})\nCaptain: {captain.FirstName} {captain.LastName} (Email: {captain.Email})";
                    return answer;
                }
                else if (user != null && !user.IsPlaying)
                {
                    var coach = await _playerRepository.GetCoach(CoachRole);
                    var captain = await _playerRepository.GetCaptain(CaptainRole);

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
        #endregion 
    }
}

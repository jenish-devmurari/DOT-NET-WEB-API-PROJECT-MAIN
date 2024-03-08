
using MyTeam_1.DTO;
using MyTeam_1.Interface;
using MyTeam_1.Models;
using MyTeam_1.Repositories;
using MyTeam_1.Repository.Interface;
using System;
using System.Threading.Tasks;

namespace MyTeam_1.Services
{
    public class RegistrationService : IRegistrationService
    {
        #region DI
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher _passwordHasher;

        public RegistrationService(IRegistrationRepository registrationRepository, IEmailService emailService, IPasswordHasher passwordHasher)
        {
            _registrationRepository = registrationRepository;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
        }
        #endregion

        #region RegisterUser
        public async Task<string> RegisterUser(RegistrationDTO model)
        {
            try
            {
                var useremail = await _registrationRepository.GetUserByEmailAsync(model.Email);
                if(useremail != null) 
                {
                    return "Email is Already  Register";
                }

                model.Password = _passwordHasher.HashPassword(model.Password);
                // Create a new User instance
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    TotalMatchesPlayed = model.TotalMatchesPlayed,
                    ContactNumber = model.ContactNumber,
                    Email = model.Email,
                    Password = model.Password,
                    DateOfBirth = model.DateOfBirth,
                    Height = model.Height,
                    Weight = model.Weight
                };

                // Register the user
                await _registrationRepository.RegisterUser(user);

                //send th email for registration
                await _emailService.SendEmailAsync("jenishdevmurari77@gmail.com", model.Email, "Registration", $"Welcome {model.Email} \n \n Thank You For Registration \n \n We Will Notify You About Your Selction In Team Via Email \n Have Any Question? Kindy Send Email on support@myteam.com");

                return "User registered successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to register user", ex);
            }
        }
        #endregion
    }
}

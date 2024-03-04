// IRegistrationService.cs (Interface)
using MyTeam_1.DTO;
using System.Threading.Tasks;

namespace MyTeam_1.Interface
{
    public interface IRegistrationService
    {
        Task<string> RegisterUser(RegistrationDTO model);
    }
}

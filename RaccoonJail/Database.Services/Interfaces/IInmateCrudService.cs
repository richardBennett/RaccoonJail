using System.Threading.Tasks;
using Models;
using Models.Dtos;
using Models.Requests;

namespace Database.Services.Interfaces
{
    public interface IInmateCrudService
    {
        Task<long> AddInmateAndReturnId(string name, decimal size, ArrestLocation arrestLocation, HungerLevel hungerLevel, HappinessLevel happinessLevel);
        Task DeleteInmate(long inmateId);
        Task<InmateDto> ReadInmate(long inmateId);
        Task UpdateInmate(InmateUpdateRequest inmateUpdateRequest);
    }
}
using System.Threading.Tasks;
using Models;
using Models.Enums;

namespace Data.Services.Interfaces
{
    public interface IInmateCrudService
    {
        Task<long> AddInmateAndReturnId(string name, decimal size, ArrestLocation arrestLocation, HungerLevel hungerLevel, HappinessLevel happinessLevel);
        Task DeleteInmate(long inmateId);
        Task<InmateDto> ReadInmate(long inmateId);
        Task UpdateInmateHungerLevel(long inmateId, HungerLevel hungerLevel);
    }
}
using System.Threading.Tasks;
using Data.Services.Exceptions;
using Data.Services.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using ArrestLocation = Models.Enums.ArrestLocation;
using HappinessLevel = Models.Enums.HappinessLevel;
using HungerLevel = Models.Enums.HungerLevel;

namespace Data.Services
{
    public class InmateCrudService : IInmateCrudService
    {
        private readonly RaccoonJailContext _dbContext;

        public InmateCrudService(RaccoonJailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> AddInmateAndReturnId(string name, decimal size, ArrestLocation arrestLocation, HungerLevel hungerLevel, HappinessLevel happinessLevel)
        {
            var inmate = await _dbContext.Inmates.AddAsync(new Inmate
            {
                ArrestLocationId = (int)arrestLocation,
                HappinessLevelId = (int)happinessLevel,
                HungerLevelId = (int)hungerLevel,
                Name = name,
                Size = size
            });

            await _dbContext.SaveChangesAsync();

            return inmate.Entity.Id;
        }

        public async Task DeleteInmate(long inmateId)
        {
            var inmate = await _dbContext.Inmates
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == inmateId);

            if (inmate == null)
            {
                throw new InmateCrudException($"Inmate with Id {inmateId} could not be deleted because it was not found.");
            }

            _dbContext.Remove(inmate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<InmateDto> ReadInmate(long inmateId)
        {
            var inmate = await _dbContext.Inmates
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == inmateId);

            return new InmateDto
            {
                ArrestLocation = (ArrestLocation)inmate.ArrestLocationId,
                HappinessLevel = (HappinessLevel)inmate.HappinessLevelId,
                HungerLevel = (HungerLevel)inmate.HungerLevelId,
                Id = inmate.Id,
                Name = inmate.Name,
                Size = inmate.Size
            };
        }

        public async Task UpdateInmateHungerLevel(long inmateId, HungerLevel hungerLevel)
        {
            var inmate = await _dbContext.Inmates
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == inmateId);

            inmate.HungerLevelId = (int)hungerLevel;
            await _dbContext.SaveChangesAsync();
        }
    }
}
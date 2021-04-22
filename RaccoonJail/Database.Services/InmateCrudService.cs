using System.Threading.Tasks;
using Data.Services.Exceptions;
using Data.Services.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Requests;
using ArrestLocation = Models.ArrestLocation;
using HappinessLevel = Models.HappinessLevel;
using HungerLevel = Models.HungerLevel;

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
            var inmate = await GetInmate(inmateId);

            if (inmate == null)
            {
                throw new InmateCrudException($"Inmate with Id {inmateId} could not be deleted because it was not found.");
            }

            _dbContext.Remove(inmate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<InmateDto> ReadInmate(long inmateId)
        {
            var inmate = await GetInmate(inmateId);

            if (inmate == null)
            {
                throw new InmateCrudException($"Inmate with Id {inmateId} could not be read because it was not found.");
            }

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

        public async Task UpdateInmate(InmateUpdateRequest inmateUpdateRequest)
        {
            var inmate = await GetInmate(inmateUpdateRequest.Id);

            inmate.Name = inmateUpdateRequest.Name ?? inmate.Name;
            inmate.Size = inmateUpdateRequest.Size ?? inmate.Size;
            inmate.HappinessLevelId = inmateUpdateRequest.HappinessLevel != null ? (int)inmateUpdateRequest.HappinessLevel.Value : inmate.HappinessLevelId;
            inmate.HungerLevelId = inmateUpdateRequest.HungerLevel != null ? (int)inmateUpdateRequest.HungerLevel.Value : inmate.HungerLevelId;
            inmate.ArrestLocationId = inmateUpdateRequest.ArrestLocation != null ? (int)inmateUpdateRequest.ArrestLocation.Value : inmate.ArrestLocationId;

            _dbContext.Update(inmate);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Inmate> GetInmate(long inmateId)
        {
            return await _dbContext.Inmates
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == inmateId);
        }
    }
}
using System.Threading.Tasks;
using Database.Models;
using Database.Services.Exceptions;
using Database.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Requests;
using ArrestLocation = Models.ArrestLocation;
using HappinessLevel = Models.HappinessLevel;
using HungerLevel = Models.HungerLevel;

namespace Database.Services
{
    public class InmateCrudService : IInmateCrudService
    {
        private readonly RaccoonJailContext _dbContext;

        public InmateCrudService(RaccoonJailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> AddInmateAndReturnId(string name, decimal sizeInOz, ArrestLocation arrestLocationId, HungerLevel hungerLevelId, HappinessLevel happinessLevelId)
        {
            var inmate = await _dbContext.Inmates.AddAsync(new Inmate
            {
                ArrestLocationId = (int)arrestLocationId,
                HappinessLevelId = (int)happinessLevelId,
                HungerLevelId = (int)hungerLevelId,
                Name = name,
                SizeInOz = sizeInOz,
                TimeServedInMonths = 0
            });

            await _dbContext.SaveChangesAsync();

            return inmate.Entity.Id;
        }

        public async Task DeleteInmate(long inmateId)
        {
            var inmate = await GetInmate(inmateId);

            _dbContext.Remove(inmate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<InmateDto> ReadInmate(long inmateId)
        {
            var inmate = await _dbContext.Inmates
                .AsNoTracking()
                .Include(x => x.ArrestLocation)
                .Include(x => x.HungerLevel)
                .Include(x => x.HappinessLevel)
                .FirstOrDefaultAsync(x => x.Id == inmateId);

            if (inmate == null)
            {
                throw new InmateNotFoundException(inmateId);
            }

            return new InmateDto
            {
                ArrestLocation = inmate.ArrestLocation.Location,
                HappinessLevel = inmate.HappinessLevel.Description,
                HungerLevel = inmate.HungerLevel.Description,
                Id = inmate.Id,
                Name = inmate.Name,
                SizeInOz = inmate.SizeInOz,
                TimeServedInMonths = inmate.TimeServedInMonths
            };
        }

        public async Task UpdateInmate(InmateUpdateRequest inmateUpdateRequest)
        {
            var inmate = await GetInmate(inmateUpdateRequest.Id);

            inmate.Name = inmateUpdateRequest.Name ?? inmate.Name;
            inmate.SizeInOz = inmateUpdateRequest.SizeInOz ?? inmate.SizeInOz;
            inmate.HappinessLevelId = inmateUpdateRequest.HappinessLevel != null ? (int)inmateUpdateRequest.HappinessLevel.Value : inmate.HappinessLevelId;
            inmate.HungerLevelId = inmateUpdateRequest.HungerLevel != null ? (int)inmateUpdateRequest.HungerLevel.Value : inmate.HungerLevelId;
            inmate.ArrestLocationId = inmateUpdateRequest.ArrestLocation != null ? (int)inmateUpdateRequest.ArrestLocation.Value : inmate.ArrestLocationId;
            inmate.TimeServedInMonths = inmateUpdateRequest.TimeServedInMonths ?? inmate.TimeServedInMonths;

            _dbContext.Update(inmate);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Inmate> GetInmate(long inmateId)
        {
            var inmate = await _dbContext.Inmates
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == inmateId);

            if (inmate == null)
            {
                throw new InmateNotFoundException(inmateId);
            }

            return inmate;
        }
    }
}
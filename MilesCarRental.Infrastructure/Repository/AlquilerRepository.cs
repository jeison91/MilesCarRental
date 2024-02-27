using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.IRepository;
using MilesCarRental.Domain.Model;
using MilesCarRental.Infrastructure.Entities;
using MilesCarRental.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Infrastructure.Repository
{
    public class AlquilerRepository : IAlquilerRepository
    {
        private readonly CarRentalDbContext _dBContext;
        public AlquilerRepository(CarRentalDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<AlquilerModel> CreateRentalAsync(AlquilerModel alquilerModel)
        {
            var entity = alquilerModel.MapToEntity<AlquilerEntity>();
            _dBContext.Set<AlquilerEntity>().Add(entity);
            await _dBContext.SaveChangesAsync();

            var model = entity.MapToEntity<AlquilerModel>();
            return model;
        }
    }
}

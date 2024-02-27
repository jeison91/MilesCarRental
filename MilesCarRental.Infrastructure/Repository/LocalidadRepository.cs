using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.Model;
using MilesCarRental.Infrastructure.Entities;
using MilesCarRental.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Infrastructure.Repository
{
    public class LocalidadRepository
    {
        private readonly CarRentalDbContext _dBContext;
        public LocalidadRepository(CarRentalDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<LocalidadModel>> GetList()
        {
            var sectors = (await _dBContext.Localidades.ToListAsync()).MapToEntity<List<LocalidadModel>>();
            return sectors;
        }
    }
}

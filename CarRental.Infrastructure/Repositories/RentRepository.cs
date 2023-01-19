using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Repositories
{
    public class RentRepository : BaseRepository<Rent>, IRentRepository
    {
        public RentRepository(CarRentalContext dbContext) : base(dbContext)
        {
        }

        public async Task CompleteRent(int rentId)
        {
            var query = await _dbContext.Rents.FirstOrDefaultAsync(x => x.Id == rentId);
            if (query == null) throw new Exception("Recurso no encontrado");

            query.Returned = true;
        }

        public async Task<bool> IsAvailableForRent(int vehicleId, DateTime rentDate, DateTime returnDate)
        {
            // verificar si no hay rentas para ese vehiculo, en ese rango de fechas
            var takenSlot = await _dbContext.Rents
                                        .AnyAsync(x => x.VehicleId == vehicleId && x.Returned == false
                                                && (rentDate >= x.RentDate.Date && rentDate <= x.ReturnDate
                                                || returnDate >= x.RentDate && returnDate <= x.ReturnDate));                                  
            return !takenSlot;
        }
    }
}

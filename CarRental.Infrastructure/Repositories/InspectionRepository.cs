using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
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
    public class InspectionRepository : BaseRepository<Inspection>, IInspectionRepository
    {
        public InspectionRepository(CarRentalContext context): base(context)
        {

        }

        public async Task<bool> VehicleIsInspected(int idVehicle, int idClient, DateTime inspectionDate)
        {

            var exists = await _dbContext.Inspections
                            .FirstOrDefaultAsync(x => x.VehicleId == idVehicle && x.ClientId == idClient 
                                            && x.InspectionDate.Date == inspectionDate.Date);
            return exists != null;
        }
    }
}

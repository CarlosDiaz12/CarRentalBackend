using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface IInspectionRepository: IRepository<Inspection>
    {
        Task<bool> VehicleIsInspected(int idVehicle, int idClient, DateTime inspectionDate);
    }
}

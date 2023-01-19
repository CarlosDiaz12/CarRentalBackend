using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string IDCard { get; set; }
        public WorkShift WorkShift { get; set; }
        public double ComissionPercentage { get; set; }
        public DateTime HireDate { get; set; }
        public bool Status { get; set; }
    }
}

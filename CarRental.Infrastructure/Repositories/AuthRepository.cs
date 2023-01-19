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
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        public AuthRepository(CarRentalContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> Login(string userName, string password)
        {
            // agregar comparacion de hash del password
            // agregar creacion del token y devolverlo al frontend
            var query = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            return query;
        }
    }
}

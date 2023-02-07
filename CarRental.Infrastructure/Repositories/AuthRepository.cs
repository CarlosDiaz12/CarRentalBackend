using CarRental.Domain.DTOs;
using CarRental.Domain.Entities;
using CarRental.Domain.Exceptions;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Repositories
{
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        private readonly IConfiguration _config;
        public AuthRepository(CarRentalContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _config = configuration;
        }

        public async Task<LoginUserResponseDto> Login(string userName, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);

            if (user == null)
                throw new BusinessException("Las credenciales son incorrectas");

            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sid, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var token = CreateToken(claims);
            return new LoginUserResponseDto
            {
                Token = token,
                UserName = userName,
                Name = user.Name
            };
        }

        private string CreateToken(Claim[] claims = null)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Auth:Key")));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(signingCredentials);

            // generate payload
            var payload = new JwtPayload(
                _config.GetValue<string>("Auth:Issuer"),
                _config.GetValue<string>("Auth:Audience"),
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(60)
                );

            // generate token
            var jwtToken = new JwtSecurityToken(header, payload);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
    }
}

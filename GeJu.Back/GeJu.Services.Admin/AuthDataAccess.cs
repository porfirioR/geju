using Access.Contract.Request;
using Access.Contract.Response;
using Admin.Interfaces;
using AutoMapper;
using GeJu.Sql;
using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    internal class AuthDataAccess : IAuthDataAccess
    {
        private readonly IMapper _mapper;
        private readonly SymmetricSecurityKey _key;
        private readonly DataContext _context;

        public AuthDataAccess(IMapper mapper, IConfiguration configuration, DataContext context)
        {
            _mapper = mapper;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
            _context = context;
        }

        public string CreateToken(string name)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, name)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<AuthResponse> Login(LoginAccess loginAccess)
        {
            var user = await _context.Usuarios.FirstAsync(x => x.Correo == loginAccess.Email);
            if (user is null)
            {
                new KeyNotFoundException("Correo o contraseña es incorrecto");
            }

            using var hmac = new HMACSHA512(user.ContraseñaSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginAccess.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.ContraseñaHash[i])
                {
                    new KeyNotFoundException("Correo o contraseña es incorrecto");
                }
            }
            var token = CreateToken(user.Nombre);
            var userResponse = new AuthResponse { Name = user.Nombre, Token = token };
            return userResponse;
        }
    }
}

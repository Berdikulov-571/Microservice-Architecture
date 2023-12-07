using Autorization.Api.DataContexts;
using Autorization.Api.Interfaces;
using Autorization.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Autorization.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly SchoolDatabase _school;
        private readonly UniversityDatabase _univer;

        public AuthService(SchoolDatabase school, UniversityDatabase univer)
        {
            _school = school;
            _univer = univer;
        }
        public string GenerateToken(Login login)
        {
            List<Login> loginList = _school.Admins.Select(admin => new Login
            {
                Email = admin.Email,
                Password = admin.PasswordHash,
                Role = admin.Role
            }).ToList();


            loginList.AddRange(_school.Teachers.Select(teacher => new Login()
            {
                Email = teacher.Email,
                Role = teacher.Role,
                Password = teacher.PasswordHash,
            }));


            loginList.AddRange(_school.Students.Select(student => new Login()
            {
                Email = student.Email,
                Role = student.Role,
                Password = student.PasswordHash,
            }));



            loginList.AddRange(_univer.Admins.Select(teacher => new Login()
            {
                Email = teacher.Email,
                Role = teacher.Role,
                Password = teacher.PasswordHash,
            }));


            loginList.AddRange(_univer.Teachers.Select(teacher => new Login()
            {
                Email = teacher.Email,
                Role = teacher.Role,
                Password = teacher.PasswordHash,
            }));


            loginList.AddRange(_univer.Students.Select(student => new Login()
            {
                Email = student.Email,
                Role = student.Role,
                Password = student.PasswordHash,
            }));

            
            var res = loginList.FirstOrDefault(x => x.Email == login.Email && x.Password == Hash512.ComputeSHA512HashFromString(login.Password));

            if (res == null)
                throw new UserNotFound();


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mana-shu-security-key"));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, res.Email),
                new Claim(ClaimTypes.Role, res.Role.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
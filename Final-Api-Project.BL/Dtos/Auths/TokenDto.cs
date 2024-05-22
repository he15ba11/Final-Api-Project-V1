using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Dtos.Users
{
    public record TokenDto(string Token, DateTime Expiry);
}

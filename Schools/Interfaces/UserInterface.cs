using SchoolApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Interfaces
{
    interface UserInterface
    {
        public string GenerateJwtToken(User user);
    }
}

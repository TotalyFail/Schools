using SchoolApi.Data;
using SchoolApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Interfaces
{
    interface ParentInterface
    {
        List<int> GetParentsByName(string name);
    }
}

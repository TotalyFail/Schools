using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Interfaces
{
    interface SchoolInterface
    {
        List<string> GetSchoolByParentName(string name);
    }
}

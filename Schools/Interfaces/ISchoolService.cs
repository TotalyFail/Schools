using System.Collections.Generic;

namespace SchoolApi.Interfaces
{
    interface ISchoolService
    {
        List<string> GetSchoolByParentName(string Name);
    }
}

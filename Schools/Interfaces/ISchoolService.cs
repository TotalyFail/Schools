using System.Collections.Generic;

namespace SchoolApi.Interfaces
{
    internal interface ISchoolService
    {
        List<string> GetSchoolByParentName(string Name);
    }
}
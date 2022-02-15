using System.Collections.Generic;

namespace SchoolApi.Interfaces
{
    internal interface IParentService
    {
        List<int> GetParentsByName(string name);
    }
}
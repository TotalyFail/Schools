using System.Collections.Generic;

namespace SchoolApi.Interfaces
{
    interface IParentService
    {
        List<int> GetParentsByName(string Name);
    }
}

using System.Collections.Generic;

namespace SchoolApi.Interfaces
{
    interface IChildService
    {
        public List<int> getChildrenSchools(List<int> parentIds);
    }
}

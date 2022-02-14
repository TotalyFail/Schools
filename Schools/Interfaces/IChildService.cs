using System.Collections.Generic;

namespace SchoolApi.Interfaces
{
    interface IChildService
    {
        public List<int> GetChildrenSchools(List<int> ParentIds);
    }
}

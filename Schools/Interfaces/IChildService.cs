using System.Collections.Generic;

namespace SchoolApi.Interfaces
{
    internal interface IChildService
    {
        public List<int> GetChildrenSchools(List<int> ParentIds);
    }
}
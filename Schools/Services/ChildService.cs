using SchoolApi.Data;
using SchoolApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Services
{
    public class ChildService : IChildService
    {
        private SchoolApiContext _context;

        public ChildService(SchoolApiContext _context)
        {
            this._context = _context;
        }

        public List<int> GetChildrenSchools(List<int> parentIds)
        {
            return _context.Child.Where(ch => parentIds.Contains(ch.Parent_Id))
               .Select(ch => ch.School_Id)
               .ToList();
        }
    }
}
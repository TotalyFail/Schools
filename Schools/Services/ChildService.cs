using SchoolApi.Data;
using SchoolApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Services
{
    public class ChildService : IChildService
    {
        private SchoolApiContext _context;

        private ParentService _parentServiceImpl;

        public ChildService(SchoolApiContext _context, ParentService _parentServiceImpl)
        {
            this._context = _context;
            this._parentServiceImpl = _parentServiceImpl;
        }

        public List<int> GetChildrenSchools(List<int> ParentIds)
        {
            return _context.Child.Where(ch => ParentIds.Contains(ch.Parent_Id))
               .Select(ch => ch.School_Id)
               .ToList();
        }
    }
}

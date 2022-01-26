using SchoolApi.Data;
using SchoolApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Services
{
    public class ChildService : IChildService
    {
        SchoolApiContext _context;

        ParentService parentServiceImpl;

        public ChildService(SchoolApiContext _context, ParentService parentServiceImpl)
        {
            this._context = _context;
            this.parentServiceImpl = parentServiceImpl;
        }

        public List<int> getChildrenSchools(List<int> parentIds)
        {
            return _context.Child.Where(ch => parentIds.Contains(ch.parent_id))
               .Select(ch => ch.school_id)
               .ToList();
        }
    }
}

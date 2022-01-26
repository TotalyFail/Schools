using SchoolApi.Data;
using SchoolApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Services
{
    public class ParentService : IParentService
    {

        SchoolApiContext _context;

        public ParentService(SchoolApiContext _context)
        {
            this._context = _context;
        }

        public List<int> GetParentsByName(string name)
        {
            return _context.Parent.Where(par => par.Name == name)
                .Select(o => o.id)
                .ToList();
        }
    }
}

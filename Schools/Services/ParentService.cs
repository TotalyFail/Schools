using SchoolApi.Data;
using SchoolApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Services
{
    public class ParentService : IParentService
    {
        private SchoolApiContext _context;

        public ParentService(SchoolApiContext _context)
        {
            this._context = _context;
        }

        public List<int> GetParentsByName(string Name)
        {
            return _context.Parent.Where(par => par.Name == Name)
                .Select(o => o.Id)
                .ToList();
        }
    }
}
using SchoolApi.Data;
using SchoolApi.Interfaces;
using SchoolApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Services
{
    public class ParentServiceImpl : ParentInterface
    {

        SchoolApiContext _context;

        public ParentServiceImpl(SchoolApiContext _context)
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

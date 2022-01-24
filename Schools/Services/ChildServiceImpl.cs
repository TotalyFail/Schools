using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApi.Data;
using SchoolApi.Interfaces;
using SchoolApi.Models;

namespace SchoolApi.Services
{
    public class ChildServiceImpl : ChildInterface
    {
        SchoolApiContext _context;

        ParentServiceImpl parentServiceImpl;

        public ChildServiceImpl(SchoolApiContext _context, ParentServiceImpl parentServiceImpl)
        {
            this._context = _context;
            this.parentServiceImpl = parentServiceImpl;
        }

        public List<int> getChildFromParentId(List<int> parentIds)
        {
            return _context.Child.Where(ch => parentIds.Contains(ch.id))
               .Select(ch => ch.school_id)
               .ToList();
        }
    }
}

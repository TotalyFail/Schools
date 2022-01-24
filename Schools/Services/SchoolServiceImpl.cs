using SchoolApi.Data;
using SchoolApi.Interfaces;
using SchoolApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Services
{
    public class SchoolServiceImpl : SchoolInterface
    {
        SchoolApiContext _context;

        ParentServiceImpl parentService;

        ChildServiceImpl childService;
        public SchoolServiceImpl(SchoolApiContext _context, ParentServiceImpl parentService, ChildServiceImpl childService)
        {
            this._context = _context;
            this.parentService = parentService;
            this.childService = childService;
        }

        public List<string> GetSchoolByParentName(string name)
        {
            List<int> parents = parentService.GetParentsByName(name);
            List<int> children = childService.getChildFromParentId(parents);

            return _context.School.Where(sch => children.Contains(sch.id))
                .Select(sch => sch.Name)
                .ToList();
        }
    }
}

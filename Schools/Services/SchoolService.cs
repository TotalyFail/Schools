using SchoolApi.Data;
using SchoolApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Services
{
    public class SchoolService : ISchoolService
    {
        SchoolApiContext _context;

        ParentService parentService;

        ChildService childService;
        public SchoolService(SchoolApiContext _context, ParentService parentService, ChildService childService)
        {
            this._context = _context;
            this.parentService = parentService;
            this.childService = childService;
        }

        public List<string> GetSchoolByParentName(string name)
        {
            List<int> parents = parentService.GetParentsByName(name);
            List<int> children = childService.getChildrenSchools(parents);

            return _context.School.Where(sch => children.Contains(sch.id))
                .Select(sch => sch.Name)
                .ToList();
        }
    }
}

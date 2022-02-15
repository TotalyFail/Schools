using SchoolApi.Data;
using SchoolApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Services
{
    public class SchoolService : ISchoolService
    {
        private SchoolApiContext _context;

        private ParentService _parentService;

        private ChildService _childService;

        public SchoolService(SchoolApiContext _context, ParentService _parentService, ChildService _childService)
        {
            this._context = _context;
            this._parentService = _parentService;
            this._childService = _childService;
        }

        public List<string> GetSchoolByParentName(string name)
        {
            List<int> Parents = _parentService.GetParentsByName(name);
            List<int> Children = _childService.GetChildrenSchools(Parents);

            return _context.School.Where(sch => Children.Contains(sch.Id))
                .Select(sch => sch.Name)
                .ToList();
        }
    }
}
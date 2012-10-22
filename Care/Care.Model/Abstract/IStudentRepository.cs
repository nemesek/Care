using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Care.Domain;

namespace Care.Domain.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        //IQueryable<Test> GetTests();
        int GetRiskAssessment(int id);
    }
}

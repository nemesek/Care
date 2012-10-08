using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Care.Model;

namespace Care.Data.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        //IQueryable<Test> GetTests();
        int GetRiskAssessment(int id);
    }
}

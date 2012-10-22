using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Care.Domain;
using Care.Domain.Abstract;
using System.Data.Entity;

namespace Care.Data.Concrete
{
    public class StudentRepository : EFRepository<Student>, IStudentRepository
    {
        //public StudentRepository(DbContext context, IStudentRepository studentRepo) : base(context) { }

        public StudentRepository(DbContext context) : base(context) { }

        public int GetRiskAssessment(int id)
        {
            return 0;
        }
    }
}

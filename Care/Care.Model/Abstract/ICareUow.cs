using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Domain.Abstract
{
    public interface ICareUow
    {
        void Commit();

        //Repositories
        IRepository<Administrator> Administrators { get; }
        IStudentRepository Students { get; }
        IRepository<Answer> Answers { get; }
        IRepository<Test> Tests { get; }
        IRepository<Question> Questions { get; }
    }
}

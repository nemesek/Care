using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Care.Domain;
using Care.Data.Abstract;
using Care.Domain.Abstract;

namespace Care.Data.Concrete
{
    /// <summary>
    /// The Care "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Student"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext in Care).
    /// </remarks>
    public class CareUow : ICareUow, IDisposable
    {
        private CareDbContext DbContext { get; set; }
        protected IRepositoryProvider RepositoryProvider { get; set; }

        public CareUow(IRepositoryProvider repositoryProvider)
        {
            DbContext = new CareDbContext();
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRepository<Administrator> Administrators { get { return GetStandardRepo<Administrator>(); } }
        public IRepository<Test> Tests { get { return GetStandardRepo<Test>(); } }
        public IRepository<Answer> Answers { get { return GetStandardRepo<Answer>(); } }
        public IRepository<Question> Questions { get { return GetStandardRepo<Question>(); } }
        public IStudentRepository Students { get { return GetRepo<IStudentRepository>(); } }
       

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

    }
}

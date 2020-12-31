using System;
using Favor.Functions.context;

namespace Favor.Functions.Repositories
{
    public abstract class BaseRepository
    {
        private static object _contextLock = new object();

        public BaseRepository()
        {
            InitialiseContext();
        }

        public BaseRepository(MongoDbContext context)
        {
            Context = context;
        }

        protected static MongoDbContext Context { get; set; }

        private void InitialiseContext()
        {

            if (Context == null)
            {
                lock (_contextLock)
                {
                    if (Context == null)
                    {
                        Context = new MongoDbContext(
                            Environment.GetEnvironmentVariable("ConnectionString"),
                            Environment.GetEnvironmentVariable("DatabaseName"));
                    }
                }
            }
        }

    }


}

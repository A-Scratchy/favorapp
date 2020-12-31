using System;
using Favor.Functions.context;
using Favor.Functions.Interfaces;
using Microsoft.Extensions.Logging;

namespace Favor.Functions.Repositories
{
    public abstract class BaseRepository
    {
        private static object _contextLock = new object();
        private static object _loggerLock = new object();

        public BaseRepository()
        {
            InitialiseLogger();
            InitialiseContext();
        }

        public BaseRepository(MongoDbContext context)
        {
            Context = context;
            InitialiseLogger();
        }

        public ILogger QueryLogger { get; set; }
        protected static MongoDbContext Context { get; set; }

        protected static ILoggerFactory LoggerFactory { get; set; }


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
                            Environment.GetEnvironmentVariable("DatabaseName"),
                            LoggerFactory.CreateLogger<MongoDbContext>());
                    }
                }
            }
        }

        private void InitialiseLogger()
        {
            if (LoggerFactory == null)
            {
                lock (_loggerLock)
                {
                    if (LoggerFactory == null)
                    {
                        LoggerFactory = new LoggerFactory();
                    }
                }
            }
        }
    }


}

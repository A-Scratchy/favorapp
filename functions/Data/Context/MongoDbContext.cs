using System;
using Favor.Functions.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Favor.Functions.context
{

    public class MongoDbContext
    {

        private static ILogger<MongoDbContext> _logger;

        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public virtual MongoClient MongoClient { get; set; }
        public virtual IMongoDatabase Database { get; set; }

        public MongoDbContext()
        {

        }

        public MongoDbContext(string connectionString, string databaseName, ILogger<MongoDbContext> logger)
        {
            try
            {
                _logger = logger;
                ConnectionString = connectionString;
                DatabaseName = databaseName;

                _logger.LogDebug("==========================================================");
                _logger.LogDebug($"ConnectionString: { ConnectionString }");
                _logger.LogDebug($"DatabaseName: { DatabaseName }");

                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));

                MongoClient = new MongoClient(settings);
                Database = MongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception error)
            {
                _logger.LogError($"Error when trying to connect to DB: { error } ");
                throw new Exception("cannot access DB server", error);
            }

        }

        public virtual IMongoCollection<CandidateDbModel> Candidates => Database.GetCollection<CandidateDbModel>("Candidates");
    }
}

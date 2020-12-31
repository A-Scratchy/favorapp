using System;
using Favor.Functions.Models;
using MongoDB.Driver;

namespace Favor.Functions.context
{

    public class MongoDbContext
    {

        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public virtual MongoClient MongoClient { get; set; }
        public virtual IMongoDatabase Database { get; set; }

        public MongoDbContext() { }

        public MongoDbContext(string connectionString, string databaseName)
        {
            try
            {
                ConnectionString = connectionString;
                DatabaseName = databaseName;

                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));

                MongoClient = new MongoClient(settings);
                Database = MongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception error)
            {
                throw new Exception("cannot access DB server", error);
            }

        }

        public virtual IMongoCollection<CandidateDbModel> Candidates => Database.GetCollection<CandidateDbModel>("Candidates");
    }
}

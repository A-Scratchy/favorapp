namespace Favor.Functions.context
{
    using System;
    using Favor.Functions.Models;
    using MongoDB.Driver;

    public class MongoDbContext
    {

        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public virtual MongoClient MongoClient { get; set; }
        public virtual IMongoDatabase Database { get; set; }

        // Tries to establish a connection with the database
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

        // Candidate collection
        public virtual IMongoCollection<CandidateDto> Candidates => Database.GetCollection<CandidateDto>("Candidates");
    }
}

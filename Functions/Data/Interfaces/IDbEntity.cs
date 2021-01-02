using MongoDB.Bson;

namespace Functions.Interfaces
{
    public interface IDbEntity
    {

        ObjectId Id { get; set; }

        string PartitionKey { get; set; }

    }
}

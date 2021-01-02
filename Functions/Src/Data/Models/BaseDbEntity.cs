using System;
using Functions.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace Favor.Functions.Models
{

    public class BaseDbEntity : IDbEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public bool Enabled { get; set; } = true;

        public int Version { get; set; }

        public Guid ConcurrencyStamp { get; set; }

        public bool Deleted { get; set; }

        public string PartitionKey { get; set; }

    }
}

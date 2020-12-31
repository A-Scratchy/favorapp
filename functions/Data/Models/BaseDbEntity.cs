using System;
using MongoDB.Bson;

namespace Favor.Functions.Models
{

    public class BaseDbEntity
    {
        public ObjectId Id { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public bool Enabled { get; set; } = true;

        public int Version { get; set; }

        public Guid ConcurrencyStamp { get; set; }

        public bool Deleted { get; set; }

        public string PartitionKey { get; set; }

    }
}

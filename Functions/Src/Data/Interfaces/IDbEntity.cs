using System;

namespace Functions.Interfaces
{
    public interface IDbEntity
    {

        Guid Id { get; set; }

        string PartitionKey { get; set; }

    }
}

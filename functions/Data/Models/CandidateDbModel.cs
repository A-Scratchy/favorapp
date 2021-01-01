using MongoDB.Bson.Serialization.Attributes;

namespace Favor.Functions.Models
{
    public class CandidateDbModel : BaseDbEntity
    {
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("telephoneNumber")]
        public string TelephoneNumber { get; set; }

        [BsonElement("emailAddress")]
        public string EmailAddress { get; set; }

        [BsonElement("status")]
        public CandidateStatus Status { get; set; }

        [BsonElement("companyId")]
        public MongoDB.Bson.ObjectId CompanyId { get; set; }

        [BsonElement("remoteRegistrationRequested")]
        public System.DateTime? RemoteRegistrationRequested { get; set; }

    }

    public enum CandidateStatus
    {
        Unknown,
        Approved,
        Disabled
    }
}

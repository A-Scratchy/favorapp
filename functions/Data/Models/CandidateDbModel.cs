namespace Favor.Functions.Models
{
    public class CandidateDbModel : BaseDbEntity
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string TelephoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public CandidateStatus Status { get; set; }

        public MongoDB.Bson.ObjectId CompanyId { get; set; }

        //      public CandidateType Type { get; set; }

        //      public List<CandidateApplicationModel> CandidateApplications { get; set; }

        public System.DateTime? RemoteRegistrationRequested { get; set; }

    }

    public enum CandidateStatus
    {
        Unknown,
        Approved,
        Disabled
    }
}


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Favor.Functions.context;
using Favor.Functions.Interfaces;
using Favor.Functions.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Favor.Functions.Repositories
{

    public class CandidateRepository : BaseRepository, IRepository<CandidateDbModel>
    {

        public CandidateRepository() : base()
        {

        }

        public CandidateRepository(MongoDbContext context) : base(context)
        {

        }

        public virtual async Task<CandidateDbModel> AddAsync(CandidateDbModel candidate)
        {
            await Context.Candidates.InsertOneAsync(candidate);
            return candidate;
        }

        public virtual async Task<CandidateDbModel> DeleteAsync(CandidateDbModel candidate)
        {
            await Context.Candidates.DeleteOneAsync(c => c.Id == candidate.Id);
            return candidate;
        }

        public virtual async Task<bool> EditAsync(CandidateDbModel candidate)
        {
            var originalCandidate = (await Context.Candidates.FindAsync(c => c.Id == candidate.Id)).FirstOrDefault();
            if (originalCandidate == null)
            {
                throw new MongoException("Candidate with this ID does not exist");
            }

            //LATER FEATURE: check if no significant updates have been made, if so return early and do not increment version

            candidate.LastModified = DateTime.Now;
            candidate.LastModifiedBy = "API";
            candidate.Version = originalCandidate.Version + 1;

            var result = await Context.Candidates.ReplaceOneAsync(c => c.Id == candidate.Id, candidate);

            return result.UpsertedId == originalCandidate.Id ? true : false;
        }

        public virtual IEnumerable<CandidateDbModel> GetAll() =>
            Context.Candidates.AsQueryable().ToList();

        public virtual CandidateDbModel GetById(ObjectId id) =>
            Context.Candidates.Find(c => c.Id == id).FirstOrDefault();
    }
}

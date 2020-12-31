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

        // ======================= SETUP ===============================================
        
        public CandidateRepository(): base() {}

        public CandidateRepository(MongoDbContext context) : base(context)
        {

        }

        // ======================== CURD Operations =====================================

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

        public virtual async Task<CandidateDbModel> EditAsync(CandidateDbModel candidate)
        {
            await Context.Candidates.ReplaceOneAsync(c => c.Id == candidate.Id, candidate);
            return candidate;
        }

        public virtual IEnumerable<CandidateDbModel> GetAll() =>
            Context.Candidates.AsQueryable().ToList();

        public virtual CandidateDbModel GetById(ObjectId id) =>
            Context.Candidates.Find(c => c.Id == id).FirstOrDefault();
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Favor.Functions.context;
using Favor.Functions.Interfaces;
using Favor.Functions.Models;
using MongoDB.Driver;

namespace Favor.Functions.Repositories
{

    public class CandidateRepository : BaseRepository, IRepository<CandidateDto>
    {

        public CandidateRepository() : base()
        {

        }

        public CandidateRepository(MongoDbContext context) : base(context)
        {

        }


        public virtual async Task<bool> DeleteAsync(CandidateDto candidate)
        {
            try
            {
                var result = await Context.Candidates.DeleteOneAsync(c => c.Id == candidate.Id);
                return result.DeletedCount == 1;
            }
            catch (Exception error)
            {
                throw new Exception("Error deleting candidate: " + error.Message);
            }
        }

        public virtual async Task<ICollection<CandidateDto>> GetAsync()
        {
            try
            {
                return (await Context.Candidates.FindAsync(c => c.Enabled)).ToList();
            }
            catch (Exception error)
            {
                throw new Exception("Error getting candidates: " + error.Message);
            }
        }

        public virtual async Task<CandidateDto> GetAsync(Guid id)
        {
            try
            {
                return (await Context.Candidates.FindAsync(c => c.Enabled)).FirstOrDefault();
            }
            catch (Exception error)
            {
                throw new Exception("Error getting candidates: " + error.Message);
            }
        }

        public virtual async Task<CandidateDto> PostAsync(CandidateDto candidate)
        {
            try
            {
                await Context.Candidates.InsertOneAsync(candidate);
                return (await Context.Candidates.FindAsync(c => c.Id == candidate.Id)).FirstOrDefault();
            }
            catch (Exception error)
            {
                throw new Exception("Error adding candidate: " + error.Message);
            }
        }

        public virtual async Task<CandidateDto> PutAsync(CandidateDto candidate)
        {
            var originalCandidate = (await Context.Candidates.FindAsync(c => c.Id == candidate.Id)).FirstOrDefault();

            candidate.LastModified = DateTime.Now;
            candidate.LastModifiedBy = "API";
            candidate.Version = originalCandidate.Version + 1;

            try
            {
                var result = await Context.Candidates.ReplaceOneAsync(c => c.Id == candidate.Id, candidate);
                return candidate;
            }
            catch (Exception error)
            {
                throw new Exception("Error deleting candidate: " + error.Message);
            }
        }
    }
}

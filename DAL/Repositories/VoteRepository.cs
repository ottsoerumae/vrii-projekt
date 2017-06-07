using Domain;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        public VoteRepository(ICooperationContext dbContext) : base(dbContext)
        {
        }

        public bool VoteWithGivenChoiceTextExists(string voteChoice)
        {
            return RepositoryDbSet.Any(v => v.VoteChoice == voteChoice);
        }

        public Vote FindVoteByChoiceText(string voteChoice)
        {
            return RepositoryDbSet.Where(v => v.VoteChoice == voteChoice)
                                  .FirstOrDefault();
        }
    }
}

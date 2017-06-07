using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IVoteRepository : IRepository<Vote>
    {
        bool VoteWithGivenChoiceTextExists(string voteChoice);
        Vote FindVoteByChoiceText(string voteChoice);
    }
}

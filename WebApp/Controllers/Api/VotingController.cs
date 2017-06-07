using BL.DTOs.VoteDTOs;
using BL.Services.VotingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers.Api
{
    public class VotingController : ApiController
    {
        public readonly IVotingService _votingService;
        public VotingController(IVotingService votingService)
        {
            _votingService = votingService;
        }

        [HttpGet] //api/voting/(votingId)
        public IHttpActionResult GetVotingWithPossibleVotesByVotingId(int id)
        {
            return Ok(_votingService.GetVotingWithPossibleVotesByVotingId(id));
        }
        
        [HttpGet]
        [Route("api/voting/house/{houseId:int}")] // houseId:int--> kui ei sisesta int'i saab kohe vea.
        public IHttpActionResult GetRelevantVotingsByHouseId(int houseId)
        {
            return Ok(_votingService.GetRelevantVotingsByHouseId(houseId));
        }

        [HttpGet]
        [Route("api/voting/votes/{votingId:int}")]
        public IHttpActionResult GetPossibleVotesByVotingId(int votingId)
        {
            return Ok(_votingService.GetPossibleVotesByVotingId(votingId));
        }

        [HttpGet]
        [Route("api/voting/results/{votingId:int}")]
        public IHttpActionResult GetVotingResultsByVotingId(int votingId)
        {
            return Ok(_votingService.GetResultsByVotingId(votingId));
        }

        //[HttpPost]
        //public IHttpActionResult PostVoting([FromBody] VotingDTO votingDTO)
        //{
        //    var ret = _votingService.AddNewVoting(votingDTO);
        //    return CreatedAtRoute("DefaultApi", new { votingId = ret.VotingId }, ret);//Ei tea kas töötab ka see votingId, ei kujuta ette mis asi see üldse on :D
        //}

        [HttpPost]
        public IHttpActionResult PostVoting([FromBody] VotingDTO votingDTO)
        {
            var ret = _votingService.AddNewVoting(votingDTO);
            return CreatedAtRoute("DetaultApi", new { id = ret.VotingId }, ret);
        }

        [HttpPost]
        [Route("api/voting/vote")]
        public IHttpActionResult PostVote([FromBody] VoteDTO voteDTO)
        {
            var ret = _votingService.AddNewVote(voteDTO);
            return CreatedAtRoute("DefaultApi", new { id = ret.VoteId }, ret);
        }

        [HttpPost]
        [Route("api/voting/possibility")]
        public IHttpActionResult PostPossibleVote([FromBody] PossibleVoteDTO possibleVoteDTO)
        {
            var ret = _votingService.AddNewPossibleVote(possibleVoteDTO);
            return CreatedAtRoute("DefaultApi", new { id = ret.PossibleVoteId }, ret);
        }

        [HttpPost]
        [Route("api/voting/addresult")]
        public IHttpActionResult PostApartmentOwnersVote([FromBody] ApartmentOwnersVoteDTO aov)
        {
            var ret = _votingService.AddApartmentOwnersVote(aov);
            return CreatedAtRoute("DefaultApi", new { id = ret.ApartmentOwnersVoteId }, ret);
        }
    }
}

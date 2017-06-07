using ClientConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientConsole.Services;

namespace ClientConsole
{
    class Program
    {
        private static NoticeService _noticeService = new NoticeService();
        private static VotingService _votingService = new VotingService();
        static void Main(string[] args)
        {
            MainAsync().Wait();//Wait ootab ära väljakutsutava meetodi tulemuse
        }

        static async Task MainAsync()//See on meie main meetod
        {
            //_noticeService.GetAllNotices();
            await DoSimpleGetVote();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }


        static async Task DoSimpleGetVote()
        {
            Vote testVote1 = new Vote() { VoteChoice = "vote1" };
            Vote testVote2 = new Vote() { VoteChoice = "vote2" };
            Vote testVote3 = new Vote() { VoteChoice = "vote3" };

            List<Vote> testVotes = new List<Vote>();

            testVotes.Add(testVote1);
            testVotes.Add(testVote2);
            testVotes.Add(testVote3);

            Voting testVoting = new Voting()
            {
                HouseId = 1,
                Suggestion = "Lisatava hääletuse küsimus",
                FromDate = DateTime.Today.AddDays(-5),
                ToDate = DateTime.Today.AddMonths(2)
            };

            var addedVoting = await _votingService.AddNewVoting(testVoting);//tagasi tuleb (ilmselt lisatud) mudel Voting

            int votingId = addedVoting.VotingId;
            int houseId = addedVoting.HouseId;
            //Mait sai id kätte, ma ei saa :(
            //Console.WriteLine(addedVoting.VotingId);
            //Console.WriteLine(addedVoting.HouseId);
            List<Vote> addedVotesWithPrimaryKeys = new List<Vote>();
            foreach(var vote in testVotes)
            {
                var addedVote = await _votingService.AddNewVote(vote);
                addedVotesWithPrimaryKeys.Add(addedVote);
            }
            //Olemas peaks olema list häältest, millele on vaja viidata täites tabelit PossibleVote


            //Siia ei jõua paraku midagi asjalikku
            //Teeme listi võimalikest häältest, mis tuleb lisada PossibleVote tabelisse:
            List<PossibleVote> possibleVotes = _votingService.MakeListOfPossibleVotes(addedVotesWithPrimaryKeys, addedVoting);

            //List variantidest peaks olema olemas, saadame need ükshaaval veebiteenusele.
            List<PossibleVote> addedPossibleVotes = new List<PossibleVote>();
            foreach(var possibleVote in possibleVotes)
            {
                await _votingService.AddNewPossibleVote(possibleVote);
            }

            return; 
        }


        //See töötab
        static async Task DoSimpleGetAddResult()
        {
            ApartmentOwnersVote aov = new ApartmentOwnersVote()
            {
                OwnershipId = 1,
                VotingId = 2,
                VoteId = 3
            };

            var myOppinionAddResult = await _votingService.AddApartmentOwnersVote(aov);

            Console.WriteLine(myOppinionAddResult.ApartmentOwnersVoteId);
            Console.WriteLine(myOppinionAddResult.OwnershipId);
            Console.WriteLine(myOppinionAddResult.VotingId);
            Console.WriteLine(myOppinionAddResult.VoteId);
            return;
        }


        static async Task DoSimpleGet() //selleks vajame HttpClient'i
        {
            Notice testNotice = new Notice()
            {
                HouseId = 1,
                NoticeText = "Ja ülejärgmine teade",
                FromDate = DateTime.Today.AddMonths(-6),
                ToDate = DateTime.Today.AddMonths(-4)
            };
            var noteAddResult = await _noticeService.AddNewNotice(testNotice);

            //veider, et noteAddResult saab väärtuse aga nr on 0.
            int nr = noteAddResult.NoticeId;
            return;

            //var result = await _noticeService.GetAllNotices();
            //foreach (var notice in result)
            //{
            //    Console.WriteLine(notice.NoticeText);
            //}
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:9328/api/notices/");
            //var responseMessage = await client.GetAsync("");//GetAsync meetodile annab juurde lisada osa uri'st
            //var responseContent = await responseMessage.Content.ReadAsStringAsync();
            //var responseObject = await responseMessage.Content.ReadAsAsync<List<Notice>>(); //enne asyncina lugemist peame tegema mudeli
            //Console.WriteLine(responseContent);//Näis mida kirjutame
        }

        //static async Task GetNoticeById(int id)//Eksamil ka inimese otsimiseks on eraldi teenuse url, mitte ei tõmba kõiki inimesi alla ja siis ei hakka otsima.
        //{


        //    //HttpClient client = new HttpClient();
        //    //client.BaseAddress = new Uri("http://localhost:9328/api/notices/");
        //    //var responseMessage = await client.GetAsync(id.ToString());
        //    //var responseContent = await responseMessage.Content.ReadAsStringAsync();
        //    //var responseObject = await responseMessage.Content.ReadAsAsync<Notice>();//MITTE LIST!!!
        //    //Console.WriteLine(responseContent);
        //}

        //static async Task DoSimplePost()
        //{
        //    HttpClient client = new HttpClient();
        //    Notice testNotice = new Notice()
        //    {
        //        NoticeId = 10,
        //        HouseId = 3,
        //        NoticeText = "Minge kõik metsa",
        //        FromDate = DateTime.Today,
        //        ToDate = DateTime.Today.AddDays(7)
        //    };
        //    client.BaseAddress = new Uri("http://localhost:9328/api/notices/");
        //    var response = await client.PostAsJsonAsync<Notice>("", testNotice);
        //    response.EnsureSuccessStatusCode();//Kontrollib, kas server andis tagasi success'i status code'i, kui ei, antakse viga tagasi siin.
        //    var stringNewLocation = response.Headers.Location;//Lisades infot antakse siinkohal url, mille pealt saab kätte selle objekti info.
        //    var ret = await response.Content.ReadAsAsync<Notice>();
        //}

        //static async Task DoSimplePut()
        //{
        //    HttpClient client = new HttpClient();
        //    Notice testNotice = new Notice()
        //    {
        //        NoticeId = 10,
        //        HouseId = 3,
        //        NoticeText = "Testitav teade",
        //        FromDate = DateTime.Today,
        //        ToDate = DateTime.Today.AddDays(7)
        //    };
        //    client.BaseAddress = new Uri("http://localhost:9328/api/notices/");
        //    var response = await client.PutAsJsonAsync<Notice>("", testNotice);//Ainuke erinevus võrreldes postiga on meetodis, mida siin välja kutsutakse
        //    response.EnsureSuccessStatusCode();
        //    var ret = await response.Content.ReadAsAsync<Notice>();
        //}

        //static async Task DoSimpleDelete(int id)
        //{
        //    HttpClient client = new HttpClient();
        //    Notice testNotice = new Notice()
        //    {
        //        NoticeId = 10,
        //        HouseId = 3,
        //        NoticeText = "Testitav teade",
        //        FromDate = DateTime.Today,
        //        ToDate = DateTime.Today.AddDays(7)
        //    };
        //    client.BaseAddress = new Uri("http://localhost:9328/api/notices/");
        //    var response = await client.DeleteAsync(id.ToString());//Ainuke erinevus võrreldes postiga on meetodis, mida siin välja kutsutakse
        //    response.EnsureSuccessStatusCode();
        //}
    }
}

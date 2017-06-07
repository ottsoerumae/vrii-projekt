using ClientApp.Factories;
using ClientApp.Models;
using ClientApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModels
{
    public class UserHomeVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        NoticeService noticeService = new NoticeService();
        VotingService votingService = new VotingService();
        private List<Notice> _listOfNotices;
        public List<Notice> ListOfNotices
        {
            get { return _listOfNotices; }
            private set
            {
                _listOfNotices = value;
                NotifyPropertyChanged("ListOfNotices");
            }
        }

        private List<Voting> _listOfVotings;
        public List<Voting> ListOfVotings
        {
            get { return _listOfVotings; }
            private set
            {
                _listOfVotings = value;
                NotifyPropertyChanged("ListOfVotings");
            }
        }

        private List<Vote> _listOfPossibleVotes;
        public List<Vote> ListOfPossibleVotes
        {
            get { return _listOfPossibleVotes; }
            private set
            {
                _listOfPossibleVotes = value;
                NotifyPropertyChanged("ListOfPossibleVotes");
            }
        }
        private Voting _selectedVoting;
        public Voting SelectedVoting
        {
            get { return _selectedVoting; }
            set
            {
                _selectedVoting = value;
                NotifyPropertyChanged("SelectedVoting");
            }
        }

        //private Vote _selectedVote;

        //public Vote SelectedVote
        //{
        //    get { return _selectedVote; }
        //    set
        //    {
        //        _selectedVote = value;
        //        NotifyPropertyChanged("SelectedVote");
        //    }
        //}


        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Meetodi eesmärgiks on täita property, mida me vaates bindime vajalike andmetega.
        public async void GetNoticesByHouseId(int houseId)//signatuuri tuleks lisada kas ownership/house objekt või houseId. Selle saab lõplikult tööle panna alles peale autentimist.
        {
            ListOfNotices = await noticeService.GetRelevantNoticesByHouseId(houseId);
        }

        //public async Task AddApartmentOwnersVote(int votingId, int voteId)//ownership ka sisse!
        //{
        //    await votingService.PostApartmentOwnersVote(votingId, voteId);
        //    return;
        //}

        public async void GetVotingsByHouseId(int houseId)
        {
            ListOfVotings = await votingService.GetRelevantVotingsByHouseId(houseId);
        }

        public async void GetPossibleVotesByVotingId(int votingId)
        {
            ListOfPossibleVotes = await votingService.GetPossibleVotesByVotingId(votingId);
        }
    }
}

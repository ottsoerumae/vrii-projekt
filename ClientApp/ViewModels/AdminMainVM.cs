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
    public class AdminMainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        VotingService votingService = new VotingService();
        NoticeService noticeService = new NoticeService();

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

        private List<VotingResults> _votingResults;

        public List<VotingResults> VotingResults
        {
            get { return _votingResults; }
            set
            {
                _votingResults = value;
                NotifyPropertyChanged("VotingResults");
            }
        }


        public async void GetNoticesByHouseId(int houseId)//signatuuri tuleks lisada kas ownership/house objekt või houseId. Selle saab lõplikult tööle panna alles peale autentimist.
        {
            ListOfNotices = await noticeService.GetRelevantNoticesByHouseId(houseId);
        }

        public async void GetVotingsByHouseId(int houseId)
        {
            ListOfVotings = await votingService.GetRelevantVotingsByHouseId(houseId);
        }

        public async void GetResultsByVotingId(int votingId)
        {
            VotingResults = await votingService.GetResultsByVotingId(votingId);
        }

    }
}

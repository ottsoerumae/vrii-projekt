using ClientApp.Factories;
using ClientApp.Models;
using ClientApp.Services;
using ClientApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApp.Views
{
    /// <summary>
    /// Interaction logic for UserHome.xaml
    /// </summary>
    public partial class UserHome : UserControl
    {
        ApartmentOwnersVoteFactory aovFactory = new ApartmentOwnersVoteFactory();
        UserHomeVM userHomeVM = new UserHomeVM();
        VotingService votingService = new VotingService();
        public UserHome()
        {
            InitializeComponent();
            userHomeVM.GetNoticesByHouseId(1);
            userHomeVM.GetVotingsByHouseId(1);
            DataContext = userHomeVM;
        }

        private void MakeVotingVisibleButton_Click(object sender, RoutedEventArgs e)
        {
            VotingChoiceStackPanel.Visibility = Visibility.Visible;
        }

        private void VotingsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userHomeVM.SelectedVoting = VotingsListBox.SelectedItem as Voting;
            userHomeVM.GetPossibleVotesByVotingId(userHomeVM.SelectedVoting.VotingId);
        }

        private async void ButtonAddApartmentOwnersVote_Click(object sender, RoutedEventArgs e)
        {
            //int ownershipId = 1; //See muuda hiljem ära
            Voting voting = VotingsListBox.SelectedItem as Voting;
            Vote vote = ComboBoxVotingChoices.SelectedItem as Vote;
            var aov = aovFactory.CreateApartmentOwnersVote(4, voting.VotingId, vote.VoteId);
            await votingService.PostApartmentOwnersVote(aov);
            //await Task.Run(() => userHomeVM.AddApartmentOwnersVote(voting.VotingId, vote.VoteId));
            MessageBox.Show("Täname, et proovisite, aga teie häält ei edastatud.");
            //return;
        }
    }
}

using ClientApp.Models;
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
    /// Interaction logic for AdminMain.xaml
    /// </summary>
    public partial class AdminMain : UserControl
    {
        AdminMainVM adminMainVM = new AdminMainVM();
        public AdminMain()
        {
            InitializeComponent();
            adminMainVM.GetNoticesByHouseId(1);
            adminMainVM.GetVotingsByHouseId(1);
            DataContext = adminMainVM;
        }

        private void VotingsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            adminMainVM.SelectedVoting = VotingsListBox.SelectedItem as Voting;
            adminMainVM.GetResultsByVotingId(adminMainVM.SelectedVoting.VotingId);
        }
    }
}

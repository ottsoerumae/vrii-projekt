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
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();

        }

        private void ButtonAddNotice_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new Uri("tereUus.xaml", UriKind.Relative));
        }

        private void ButtonAdminMainView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AdminMainVM();
        }

        private void ButtonAdminAddNoticeView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddNoticeVM();
        }

        private void ButtonAdminAddVotingView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddVotingVM();
        }

        private void ButtonViewAndAddPeople_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ViewAndAddPeopleVM();
        }
    }
}

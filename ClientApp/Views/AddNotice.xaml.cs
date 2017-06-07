using ClientApp.Factories;
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
    /// Interaction logic for AddNotice.xaml
    /// </summary>
    public partial class AddNotice : UserControl
    {
        //See siin miskipärast töötab
        NoticeFactory noticeFactory = new NoticeFactory();
        NoticeService noticeService = new NoticeService();
        public AddNotice()
        {
            InitializeComponent();
        }

        private async void ButtonAddNotice_Click(object sender, RoutedEventArgs e)
        {                                     //See 1 muuda siin ära
            var notice = noticeFactory.CreateNotice(1, AddNoticeText.Text, DatePickerNoticeFromDate.SelectedDate, DatePickerNoticeToDate.SelectedDate);
            await noticeService.AddNewNotice(notice);
            MessageBox.Show("Teade on võib-olla edastatud, aga ei või iial teada.");
        }
    }
}

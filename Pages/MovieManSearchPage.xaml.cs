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

namespace MovieManageMent.Pages
{
    /// <summary>
    /// MovieManSearchPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MovieManSearchPage : Page
    {
        public MovieManSearchPage()
        {
            InitializeComponent();
            var obj = new MovieManSearchModelView();
            obj.SetUpDi();
            DataContext = obj;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
             await ((MovieManSearchModelView)DataContext).GetDatas();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

        }
    }
}

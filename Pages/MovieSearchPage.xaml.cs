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
    /// MovieSearchPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MovieSearchPage : Page
    {

        public MovieSearchPage()
        {
            DataContext = new MovieSearchModelView();
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await ((MovieSearchModelView)DataContext).GetMovie();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

        }
    }
}

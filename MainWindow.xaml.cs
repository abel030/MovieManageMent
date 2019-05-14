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
using MovieManageMent.WebUtil;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Serialization;
using MovieManageMent.Util;
using MovieManageMent.Model;
namespace MovieManageMent
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            YunWebRequest webRequest = new YunWebRequest();
            MovieSearchGetQueryUrl MovieSearchGetQueryUrl = new MovieSearchGetQueryUrl();
            var url= MovieSearchGetQueryUrl.MakeQueryUrl();
            var ret=  await webRequest.Request(url);

            MovieDtoFactory movieDtoFactory = new MovieDtoFactory();
            movieDtoFactory.Convert(movieDtoFactory.StringConvert(ret));

            MovieManSearchGetQueryUrl movieManSearchGetQueryUrl = new MovieManSearchGetQueryUrl();
            var url2 = movieManSearchGetQueryUrl.MakeQueryUrl();
            var ret2 = await webRequest.Request(url2);


            MovieManDtoFactory movieManDtoFactory = new MovieManDtoFactory();
            movieManDtoFactory.Convert(movieManDtoFactory.StringConvert(ret2));
            string rres = "ef";
            
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if ("영화명조회"== menuItem.Header.ToString())
            {
                y_frame.Source = new Uri(@"Pages\MovieSearchPage.xaml" ,UriKind.RelativeOrAbsolute);
            
            }
            if ("영화인조회" == menuItem.Header.ToString())
            {
                y_frame.Source = new Uri(@"Pages\MovieManSearchPage.xaml", UriKind.RelativeOrAbsolute);
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using MovieManageMent.Model;
using MovieManageMent.WebUtil;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MovieManageMent.Pages
{
    public class MovieManSearchModelView : AbsNotify
    {
        private MovieManSearchGetQueryUrl _MovieManSearchGetQueryUrl;
        private ObservableCollection<MovieManDto> _MovieMans = new ObservableCollection<MovieManDto>();
        private string _SearchUrl;
        private IYunWebRequest _IYunWebRequest;
        private IDtoFactory<MovieManDto> _IDtoFactory;

        public MovieManSearchModelView()
        {
            this.SetUpDi();
        }
        public IYunWebRequest IYunWebRequest { get => _IYunWebRequest; set => _IYunWebRequest = value; }
        public IDtoFactory<MovieManDto> IDtoFactory { get => _IDtoFactory; set => _IDtoFactory = value; }

        public MovieManSearchGetQueryUrl MovieManSearchGetQueryUrl { get => _MovieManSearchGetQueryUrl; set => _MovieManSearchGetQueryUrl = value; }

        public ObservableCollection<MovieManDto> MovieMans { get => _MovieMans;
            set
            {
                if (_MovieMans !=value )
                {
                    _MovieMans = value;
                    OnNotifiyed();
                }
            }
        }

        public string SearchUrl { get => _SearchUrl; set => _SearchUrl = value; }

        /// <summary>
        /// Url설정대로 api의 요청을 해서 데이터를 수집한후 반환한다.
        /// </summary>
        /// <returns></returns>
        public async Task GetDatas()
        {
            SearchUrl = MovieManSearchGetQueryUrl.MakeQueryUrl();
            var ret= await IYunWebRequest.Request(SearchUrl);

            MovieMans = new ObservableCollection<MovieManDto>(IDtoFactory.Convert(IDtoFactory.StringConvert(ret)));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManageMent.Model;
using MovieManageMent.WebUtil;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MovieManageMent.Pages
{
    public class MovieSearchModelView : AbsNotify
    {
        private MovieSearchGetQueryUrl _MovieSearchGetQueryUrl = new MovieSearchGetQueryUrl();
        private string _SearchUrl = "";
        private ObservableCollection<MovieDto> _Movies = new ObservableCollection<MovieDto>();
        private IYunWebRequest _IYunWebRequest;
        private IDtoFactory<MovieDto> _IDtoFactory;

        public MovieSearchGetQueryUrl MovieSearchGetQueryUrl { get => _MovieSearchGetQueryUrl;
            set
            {
                if (_MovieSearchGetQueryUrl != value)
                {
                    _MovieSearchGetQueryUrl = value;
                    OnNotifiyed();
                }
            }
        }
        public string SearchUrl { get => _SearchUrl;
            set
            {
                if (_SearchUrl != value)
                {
                    _SearchUrl = value;
                    OnNotifiyed();
                }
            }
        }

        public ObservableCollection<MovieDto> Movies { get => _Movies;
            set
            {
                if (_Movies != value)
                {
                    _Movies = value;
                    OnNotifiyed();
                }
            }
        }


        public IYunWebRequest IYunWebRequest { get => _IYunWebRequest; set => _IYunWebRequest = value; }
        public IDtoFactory<MovieDto> IDtoFactory { get => _IDtoFactory; set => _IDtoFactory = value; }
        public async Task GetMovie()
        {
            SearchUrl = MovieSearchGetQueryUrl.MakeQueryUrl();
            YunWebRequest yunWebRequest = new YunWebRequest();
            var ret = await yunWebRequest.Request(SearchUrl);
            MovieDtoFactory movieDtoFactory = new MovieDtoFactory();
            Movies = new ObservableCollection<MovieDto>(movieDtoFactory.Convert(movieDtoFactory.StringConvert(ret)));
        }

        /// <summary>
        /// Search Url로 만들어진 쿼리를 api에 전송해서 Movies에 데이터를 받는다.
        /// </summary>
        /// <returns></returns>
        public async Task GetDatas()
        {
            SearchUrl = MovieSearchGetQueryUrl.MakeQueryUrl();
            var ret = await IYunWebRequest.Request(SearchUrl);
            Movies = new ObservableCollection<MovieDto>(IDtoFactory.Convert(IDtoFactory.StringConvert(ret)));
        }

    }
}

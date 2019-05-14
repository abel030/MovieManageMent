using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MovieManageMent.Util;
using System.Collections.ObjectModel;
namespace MovieManageMent.Model
{
    [Serializable]
    public class MovieDto : AbsNotify
    {
        private string _MovieCd = "";
        private string _MovieNm = "";
        private string _MovieNmEn = "";
        private string _PrdtYear = "";
        private string _OpenDt = "";
        private string _TypeNm = "";
        private string _PrdtStatNm = "";
        private string _NationAlt = "";
        private string _GenreAlt = "";
        private string _RepNationNm = "";
        private string _RepGenreNm = "";
        private List<string> _Companys = new List<string>();
        private List<director> _Directors = new List<director>();

        public string movieCd
        {
            get => _MovieCd;
            set
            {
                if (_MovieCd !=value)
                {
                    _MovieCd = value;
                    OnNotifiyed();
                }
            }
        }
        public string movieNm { get => _MovieNm;
            set
            {
                if (_MovieNm != value)
                {
                    _MovieNm = value;
                    OnNotifiyed();
                }
            }
        }
        public string movieNmEn { get => _MovieNmEn;
            set
            {
                if (_MovieNmEn != value)
                {
                    _MovieNmEn = value;
                    OnNotifiyed();
                }
            }
        }
        public string prdtYear { get => _PrdtYear;
            set
            {
                if (_PrdtYear != value)
                {
                    _PrdtYear = value;
                    OnNotifiyed();
                }
            }
        }
        public string openDt { get => _OpenDt;
            set
            {
                if (_OpenDt != value)
                {
                    _OpenDt = value;
                    OnNotifiyed();
                }
            }
        }
        public string typeNm { get => _TypeNm;
            set
            {
                if (_TypeNm != value)
                {
                    _TypeNm = value;
                    OnNotifiyed();
                }
            }
        }

        public string prdtStatNm { get => _PrdtStatNm;
            set
            {
                if (_PrdtStatNm != value)
                {
                    _PrdtStatNm = value;
                    OnNotifiyed();
                }
            }
        }
        public string nationAlt { get => _NationAlt;
            set
            {
                if (_NationAlt != value)
                {
                    _NationAlt = value;
                    OnNotifiyed();
                }
            }
        }
        public string genreAlt { get => _GenreAlt;
            set
            {
                if (_GenreAlt != value)
                {
                    _GenreAlt = value;
                    OnNotifiyed();
                }
            }
        }
        public string repNationNm { get => _RepNationNm;
            set
            {
                if (_RepNationNm != value)
                {
                    _RepNationNm = value;
                    OnNotifiyed();
                }
            }
        }
        public string repGenreNm { get => _RepGenreNm;
            set
            {
                if (_RepGenreNm != value)
                {
                    _RepGenreNm = value;
                    OnNotifiyed();
                }
            }
        }
        public List<string> companys { get => _Companys;
            set
            {
                if (_Companys != value)
                {
                    _Companys = value;
                    OnNotifiyed();
                }
            }
        }

        public List<director> directors { get => _Directors;
            set
            {
                if (_Directors != value)
                {
                    _Directors = value;
                    OnNotifiyed();
                }
            }
        }

    }
    public struct director
    {
        public string peopleNm { get; set; }
    }


    public class MovieDtoFactory :  IDtoFactory<MovieDto>
    {
        public XDocument StringConvert(string xmlStr)
        {
            return YunXmlConverter.Convert(xmlStr);
        }
        public IEnumerable<MovieDto> Convert(XDocument xDocument)
        {
            var movies = xDocument.Descendants("movie");
            var convMovies = movies.Select(s => new MovieManageMent.Model.MovieDto()
            {

                movieCd = (string)s.Element("movieCd").Value,
                movieNm = (string)s.Element("movieNm").Value,
                movieNmEn = (string)s.Element("movieNmEn").Value,
                prdtYear = (string)s.Element("prdtYear").Value,
                openDt = (string)s.Element("openDt").Value,
                typeNm = (string)s.Element("typeNm").Value,
                prdtStatNm = (string)s.Element("prdtStatNm").Value,
                nationAlt = (string)s.Element("nationAlt").Value,
                genreAlt = (string)s.Element("genreAlt").Value,
                repNationNm = (string)s.Element("repNationNm").Value,
                repGenreNm = (string)s.Element("repGenreNm").Value,
                companys = new List<string>(s.Elements("companys").Select(s2 => (string)s2.Value)),
                directors = new List<Model.director>(s.Descendants("director").Elements("peopleNm").Select(s2 => new MovieManageMent.Model.director() { peopleNm = (string)s2.Value }))
            });
            return convMovies;
        }

    }
    public interface IDtoFactory<Z>
    {
        /// <summary>
        /// Xdocument
        /// </summary>
        /// <param name="xDocument"> xml을 문서를 parsing한객체</param>
        /// <see cref="YunXmlConverter"/>
        /// <returns></returns>
        IEnumerable<Z> Convert(XDocument xDocument);

        XDocument StringConvert(string xdoc);

    }

//    <movie>
//  <movieCd>20191581</movieCd>
//  <movieNm>나의 한국어 선생님</movieNm>
//  <movieNmEn>My Korean Teacher</movieNmEn>
//  <prdtYear>2016</prdtYear>
//  <openDt></openDt>
//  <typeNm>장편</typeNm>
//  <prdtStatNm>기타</prdtStatNm>
//  <nationAlt>일본</nationAlt>
//  <genreAlt>멜로/로맨스,코미디</genreAlt>
//  <repNationNm>일본</repNationNm>
//  <repGenreNm>멜로/로맨스</repGenreNm>
//  <directors>
//    <director>
//      <peopleNm>아사하라 유조</peopleNm>
//    </director>
//  </directors>
//  <companys />
//</movie>
}

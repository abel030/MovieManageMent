using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Serialization;
namespace MovieManageMent.WebUtil
{
    public class SearchApi
    {
        public static readonly string key = "3cd961102ed210d2a77f97de59c60bc5";
    }
    public class SearchMovie :ISearchList
    {
        public static readonly string BasicUrlXml = "http://www.kobis.or.kr/kobisopenapi/webservice/rest/movie/searchMovieList.xml";
        public static readonly string BasicUrlJson= "http://www.kobis.or.kr/kobisopenapi/webservice/rest/movie/searchMovieList.json";
        public static bool IsJson
        {
            get; set;
        } = true;
        
        public void SearchList()
        {

            GetQueryPageUrl.MakeQueryUrl();

        }
        
        public GetQueryPageUrl GetQueryPageUrl { get; set; }
        public SearchMovie()
        {
            GetQueryPageUrl = new MovieSearchGetQueryUrl();
        }
    }

    public interface IYunWebRequest
    {
        Task<string> Request(string url);
    }
    public class YunWebRequest: IYunWebRequest
    {
        Util.YunXmlConverter yunXmlConverter = new Util.YunXmlConverter();
        public async Task<string> Request(string url)
        {
            HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(url);
            httpWebRequest.Method = "GET";

            var reps= await httpWebRequest.GetResponseAsync();

            using (StreamReader sr = new StreamReader(reps.GetResponseStream()))
            {

                var ret=  sr.ReadToEndAsync();
                
                return ret.Result;

            }
            
        }
    }

    public interface ISearchList
    {
        void SearchList();
    }

    public abstract class GetQueryUrl
    {
        public string Key { get; set; } = SearchApi.key;
        public abstract string MakeQueryUrl();

    }
    public abstract class GetQueryPageUrl : GetQueryUrl
    {
        public string curPage { get; set; } = "1";
        protected string IsCanPage { get; set; } = "1";
        public string itemPerPage { get; set; } = "100";

        public void Nextpage()
        {
            IsCanPage = (Int32.Parse(curPage) + 1).ToString();
        }
    }
    public class MovieSearchGetQueryUrl : GetQueryPageUrl
    {

        public string movieNm { get; set; } = "";

        public string directorNm { get; set; } = "";
        public string openStartDt { get; set; } = "";
        public string openEndDt { get; set; } = "";
        public string prdtStartYear { get; set; } = "";
        public string prdtEndYear { get; set; } = "";
        public string repNationCd { get; set; } = "";
        public string movieTypeCd { get; set; } = "";

        /// <summary>
        /// 키값을 포함한 api에 기본 조회Url생성;
        /// </summary>
        /// <returns></returns>
        private string GetBasicUrl()
        {
            return $"{SearchMovie.BasicUrlXml}?key={Key}";
        }

        /// <summary>
        /// 객체 정보를 바탕으로 조회할데이터 쿼리를 만든다.
        /// </summary>
        /// <returns></returns>
        public override string MakeQueryUrl()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetBasicUrl());
       

            var tp = typeof(MovieSearchGetQueryUrl);
            var properties = tp.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(s => s.Name != "Key");
            ///key를 제외한 프로퍼티를 값들을 활용해서 조회 url을 만든다.

            foreach (var item in properties)
            {
                string itemValue=item.GetValue(this) as string;
                if ( ! String.IsNullOrWhiteSpace(itemValue))
                {
                    sb.Append($"&{item.Name}={itemValue}");
                }
            }
            return sb.ToString();
        }
    }
    public class SearchMovieMan : ISearchList
    {
        public static readonly string BasicUrlXml = "http://www.kobis.or.kr/kobisopenapi/webservice/rest/people/searchPeopleList.xml";
        public static readonly string BasicUrlJson = "http://www.kobis.or.kr/kobisopenapi/webservice/rest/people/searchPeopleList.json";
        public static bool IsJson
        {
            get; set;
        } = true;

        public void SearchList()
        {
            MovieManSearchGetQueryUrl queryUrl = new MovieManSearchGetQueryUrl();
            queryUrl.MakeQueryUrl();

        }

    }
    public class MovieManSearchGetQueryUrl : GetQueryPageUrl
    {
        public string peopleNm { get; set; }
        public string filmoNames { get; set; }
        private string GetBasicUrl()
        {
            return $"{SearchMovieMan.BasicUrlXml}?key={Key}";
        }
        /// <summary>
        /// 객체 정보를 바탕으로 조회할데이터 쿼리를 만든다.
        /// </summary>
        /// <returns></returns>
        public override string MakeQueryUrl()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetBasicUrl());


            var tp = typeof(MovieManSearchGetQueryUrl);
            var properties = tp.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(s => s.Name != "Key");
            ///key를 제외한 프로퍼티를 값들을 활용해서 조회 url을 만든다.

            foreach (var item in properties)
            {
                string itemValue = item.GetValue(this) as string;
                if (!String.IsNullOrWhiteSpace(itemValue))
                {
                    sb.Append($"&{item.Name}={itemValue}");
                }
            }
            return sb.ToString();
        }
    }

}

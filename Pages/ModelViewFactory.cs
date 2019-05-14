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
    /// <summary>
    /// dependency injection개념을
    /// </summary>
    public static class ModelViewFactory
    {
        /// <summary>
        /// view 컨트롤에 동작에 필요한 클래스들을 di개념으로 설정
        /// <see cref="MovieManDtoFactory"/>
        /// <see cref="YunWebRequest"/>
        /// </summary>
        /// <param name="view"></param>
        public static void SetUpDi(this MovieManSearchModelView view)
        {
            var cvfactory = new MovieManDtoFactory() as IDtoFactory<MovieManDto>;
            view.IDtoFactory = cvfactory;
            view.MovieManSearchGetQueryUrl = new MovieManSearchGetQueryUrl();
            view.IYunWebRequest = new YunWebRequest();
        }
        /// <summary>
        /// view 컨트롤에 동작에 필요한 클래스들을 di개념으로 설정
        /// <see cref="MovieManDtoFactory"/>
        /// <see cref="YunWebRequest"/>
        /// </summary>
        public static void SetUpDi(this MovieSearchModelView view)
        {
            var cvfactory = new MovieDtoFactory() as IDtoFactory<MovieDto>;
            view.IDtoFactory = cvfactory;
            view.IYunWebRequest = new YunWebRequest();
        }
    }
}

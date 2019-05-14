using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Xml.Serialization;
using System.Xml.Linq;
using MovieManageMent.Model;
namespace MovieManageMent.Util
{
    /// <summary>
    /// Xml문서 변환기
    /// </summary>
    public class YunXmlConverter
    {
        /// <summary>
        /// Xml문을 parsing해서 xDocument로 전환한다.
        /// </summary>
        /// <param name="xmlStr">xml문</param>
        /// <returns></returns>
        public static XDocument Convert(string xmlStr)
        {
            return XDocument.Load(GetTextReader(xmlStr));
        }
        /// <summary>
        /// 문자열을  TextReader객체로 전환한다.
        /// </summary>
        /// <param name="str">문자열</param>
        /// <returns></returns>
        public static TextReader GetTextReader(string str)
        {
            StringReader stringReader = new StringReader(str);
            return stringReader;
            
        }
    }
}

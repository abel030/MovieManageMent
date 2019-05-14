using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MovieManageMent.Util;
namespace MovieManageMent.Model
{
    [Serializable]
    public class MovieManDto : AbsNotify
    {
        private string _PeopelCd;
        private string _PeopleNm;
        private string _PeopleNmEn;
        private string _RepRoleNm;
        private List<string> _FilmoNames;

        public string peopelCd { get => _PeopelCd;
            set
            {
                if (_PeopelCd != value)
                {
                    _PeopelCd = value;
                    OnNotifiyed();
                }
            }
        }
        public string peopleNm { get => _PeopleNm;
            set
            {
                if (_PeopleNm != value)
                {
                    _PeopleNm = value;
                    OnNotifiyed();
                }
            }
        }


        public string peopleNmEn { get => _PeopleNmEn;
            set
            {
                if (_PeopleNmEn != value)
                {
                    _PeopleNmEn = value;
                    OnNotifiyed();
                }
            }
        }

        public string repRoleNm { get => _RepRoleNm;
            set
            {
                if (_RepRoleNm != value)
                {
                    _RepRoleNm = value;
                    OnNotifiyed();
                }
            }
        }
        public List<string> filmoNames { get => _FilmoNames;
            set
            {
                if (_FilmoNames != value)
                {
                    _FilmoNames = value;
                    OnNotifiyed();
                }
            }
        }
    }
    public class MovieManDtoFactory :  IDtoFactory<MovieManDto>
    {
        public XDocument StringConvert(string xmlStr)
        {
            return YunXmlConverter.Convert(xmlStr);
        }
        public IEnumerable<MovieManDto> Convert(XDocument xDocument)
        {
            var peoples= xDocument.Descendants("people");
            List<MovieManDto> rets = new List<MovieManDto>();
            int cnt1 = 0;
            foreach (var item in peoples)
            {
                cnt1 += 1;
                Console.WriteLine(cnt1);
                rets.Add(
                new MovieManDto()
                {
                    peopelCd = (string)item.Element("peopleCd").Value,
                    peopleNm = (String)item.Element("peopleNm").Value,
                    peopleNmEn = (string)item.Element("peopleNmEn").Value,
                    repRoleNm = (string)item.Element("repRoleNm").Value,
                    filmoNames = new List<string>(item.Elements("filmoNames").Select(s2 => (string)s2.Value))
                });
            }

            return rets;
        }
    }


}

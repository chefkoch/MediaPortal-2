using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MediaPortal.Extensions.OnlineLibraries.Libraries.Trakt.Data
{
    [DataContract]
    public class TraktCalendar : TraktResponse
    {
        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "episodes")]
        public List<TraktEpisodes> Episodes { get; set; }

        [DataContract]
        public class TraktEpisodes
        {
            [DataMember(Name = "show")]
            public TraktShow Show { get; set; }

            [DataMember(Name = "episode")]
            public TraktEpisode Episode { get; set; }

            public string Date { get; set; }
            public string SelectedIndex { get; set; }

            public override string ToString()
            {
                return string.Format("{0} - {1}x{2}{3}", Show.Title, Episode.Season.ToString(), Episode.Number.ToString(), string.IsNullOrEmpty(Episode.Title) ? string.Empty : " - " + Episode.Title);
            }
        }

        public override string ToString()
        {
            return Date;
        }
    }
}

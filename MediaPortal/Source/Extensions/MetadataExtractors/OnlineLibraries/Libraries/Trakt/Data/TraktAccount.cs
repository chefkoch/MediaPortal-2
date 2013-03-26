using System.Runtime.Serialization;

namespace MediaPortal.Extensions.OnlineLibraries.Libraries.Trakt.Data
{
    [DataContract]
    public class TraktAccount : TraktAuthentication
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}

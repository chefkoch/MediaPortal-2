﻿using System.Runtime.Serialization;

namespace MediaPortal.Extensions.OnlineLibraries.Libraries.Trakt.Data
{
    [DataContract]
    public class TraktWatchListShow : TraktShow
    {
        [DataMember(Name = "inserted")]
        public long Inserted { get; set; }
    }
}

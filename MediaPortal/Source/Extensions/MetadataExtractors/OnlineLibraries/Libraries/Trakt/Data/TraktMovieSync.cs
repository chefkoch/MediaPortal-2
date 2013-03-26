﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MediaPortal.Extensions.OnlineLibraries.Libraries.Trakt.Data
{
    /// <summary>
    /// Data structure for Syncing to Trakt
    /// </summary>
    [DataContract]
    public class TraktMovieSync
    {
        [DataMember(Name = "username")]
        public string UserName { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "movies")]
        public List<Movie> MovieList { get; set; }

        [DataContract]
        public class Movie : TraktMovieBase, IEquatable<Movie>
        {
            #region IEquatable
            public bool Equals(Movie other)
            {
                bool result = false;
                if (other != null)
                {
                    if (this.Title.Equals(other.Title) && this.Year.Equals(other.Year) && this.IMDBID.Equals(other.IMDBID))
                    {
                        result = true;
                    }
                }
                return result;
            }
            #endregion
        }
    }
}

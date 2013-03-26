﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MediaPortal.Extensions.OnlineLibraries.Libraries.Trakt.Data
{
    [DataContract]
    public class TraktMovie :TraktMovieBase
    {
        [DataMember(Name = "certification")]
        public string Certification { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }

        [DataMember(Name = "released")]
        public long Released { get; set; }

        [DataMember(Name = "runtime")]
        public int Runtime { get; set; }

        [DataMember(Name = "tagline")]
        public string Tagline { get; set; }

        [DataMember(Name = "rt_id")]
        public string RtId { get; set; }

        [DataMember(Name = "trailer")]
        public string Trailer { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "plays")]
        public int Plays { get; set; }

        [DataMember(Name = "watched")]
        public bool Watched { get; set; }

        [DataMember(Name = "in_collection")]
        public bool InCollection { get; set; }

        [DataMember(Name = "in_watchlist")]
        public bool InWatchList { get; set; }

        [DataMember(Name = "rating")]
        public string Rating { get; set; }

        [DataMember(Name = "rating_advanced")]
        public int RatingAdvanced { get; set; }
        
        [DataMember(Name = "ratings")]
        public TraktRatings Ratings { get; set; }

        [DataMember(Name = "genres")]
        public List<string> Genres { get; set; }

        [DataMember(Name = "images")]
        public MovieImages Images { get; set; }

        [DataContract]
        public class MovieImages : INotifyPropertyChanged
        {
            [DataMember(Name = "fanart")]
            public string Fanart
            {
                get
                {
                    if (TraktSettings.DownloadFullSizeFanart)
                        return _fanart;

                    if (_fanart != null && !_fanart.EndsWith("-940.jpg"))
                        return _fanart.Replace(".jpg", "-940.jpg");
                    
                    return _fanart;
                }
                set
                {
                    _fanart = value;
                }
            }
            string _fanart = string.Empty;

            [DataMember(Name = "poster")]
            public string Poster
            { 
                get
                {
                    if (_poster != null && !_poster.EndsWith("-300.jpg"))
                        return _poster.Replace(".jpg","-300.jpg");
                    return _poster;
                }
                set
                {
                    _poster = value;
                }
            }
            string _poster = string.Empty;

            #region INotifyPropertyChanged

            /// <summary>
            /// Path to local poster image
            /// </summary>
            public string PosterImageFilename
            {
                get
                {
                    string filename = string.Empty;
                    if (!string.IsNullOrEmpty(Poster))
                    {
                        string folder = MediaPortal.Configuration.Config.GetSubFolder(MediaPortal.Configuration.Config.Dir.Thumbs, @"Trakt\Movies\Posters");
                        Uri uri = new Uri(Poster);
                        filename = System.IO.Path.Combine(folder, System.IO.Path.GetFileName(uri.LocalPath));
                    }
                    return filename;
                }
                set
                {
                    _PosterImageFilename = value;
                }
            }
            string _PosterImageFilename = string.Empty;

            public string FanartImageFilename
            {
                get
                {
                    string filename = string.Empty;
                    if (!string.IsNullOrEmpty(Fanart))
                    {
                        string folder = MediaPortal.Configuration.Config.GetSubFolder(MediaPortal.Configuration.Config.Dir.Thumbs, @"Trakt\Movies\Fanart");
                        Uri uri = new Uri(Fanart);
                        filename = System.IO.Path.Combine(folder, System.IO.Path.GetFileName(uri.LocalPath));
                    }
                    return filename;
                }
                set
                {
                    _FanartImageFilename = value;
                }
            }
            string _FanartImageFilename = string.Empty;

            /// <summary>
            /// Notify image property change during async image downloading
            /// Sends messages to facade to update image
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion
        }
    }
}
﻿using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MediaPortal.Extensions.OnlineLibraries.Libraries.Trakt.Data
{
    [DataContract]
    public class TraktShowSeason
    {
        [DataMember(Name = "season")]
        public int Season { get; set; }

        [DataMember(Name = "episodes")]
        public int EpisodeCount { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "images")]
        public SeasonImages Images { get; set; }

        [DataContract]
        public class SeasonImages : INotifyPropertyChanged
        {
            [DataMember(Name = "poster")]
            public string Poster { get; set; }

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
                        string folder = MediaPortal.Configuration.Config.GetSubFolder(MediaPortal.Configuration.Config.Dir.Thumbs, @"Trakt\Shows\Seasons");
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

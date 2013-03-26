#region Copyright (C) 2007-2013 Team MediaPortal

/*
    Copyright (C) 2007-2013 Team MediaPortal
    http://www.team-mediaportal.com

    This file is part of MediaPortal 2

    MediaPortal 2 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal 2 is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal 2. If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MediaPortal.Extensions.OnlineLibraries.Libraries.FanartTv.Data
{
  //{
  //  "tmdb_id": "120",
  //  "imdb_id": "tt0120737",
  //  "movielogo": [
  //    {
  //      "id": "1613",
  //      "url": "http://assets.fanart.tv/fanart/movies/120/movielogo/the-lord-of-the-rings-the-fellowship-of-the-ring-4f78564165f48.png",
  //      "lang": "en",
  //      "likes": "4"
  //    }
  //  ],
  //  "moviedisc": [
  //    {
  //      "id": "101",
  //      "url": "http://assets.fanart.tv/fanart/movies/120/moviedisc/the-lord-of-the-rings-the-fellowship-of-the-ring-4eea008189187.png",
  //      "lang": "en",
  //      "likes": "1",
  //      "disc": "1",
  //      "disc_type": "bluray"
  //    }
  //  ],
  //  "movieart": [
  //    {
  //      "id": "1140",
  //      "url": "http://assets.fanart.tv/fanart/movies/120/movieart/the-lord-of-the-rings-the-fellowship-of-the-ring-4f6c938a134a1.png",
  //      "lang": "en",
  //      "likes": "1"
  //    }
  //  ],
  //  "moviebackground": [
  //    {
  //      "id": "5300",
  //      "url": "http://assets.fanart.tv/fanart/movies/120/moviebackground/the-lord-of-the-rings-the-fellowship-of-the-ring-4fdb8b38d794e.jpg",
  //      "lang": "en",
  //      "likes": "1"
  //    }
  //  ],
  //  "hdmovielogo": [
  //    {
  //      "id": "23444",
  //      "url": "http://assets.fanart.tv/fanart/movies/120/hdmovielogo/the-lord-of-the-rings-the-fellowship-of-the-ring-5110756b12ca1.png",
  //      "lang": "en",
  //      "likes": "1"
  //    }
  //  ],
  //  "moviebanner": [
  //    {
  //      "id": "12355",
  //      "url": "http://assets.fanart.tv/fanart/movies/120/moviebanner/the-lord-of-the-rings-the-fellowship-of-the-ring-50485f0da465c.jpg",
  //      "lang": "en",
  //      "likes": "0"
  //    }
  //  ]
  //}
  [DataContract]
  public class Movie
  {
    [DataMember(Name = "tmdb_id")]
    public int TMDB_ID { get; set; }

    [DataMember(Name = "imdb_id")]
    public int IMDB_ID { get; set; }

    [DataMember(Name = "movielogo")]
    public List<LocalizedImage> MovieLogos { get; set; }

    [DataMember(Name = "moviedisc")]
    public List<MovieDiscImage> MovieDiscs { get; set; }

    [DataMember(Name = "movieart")]
    public List<LocalizedImage> MovieArts { get; set; }

    [DataMember(Name = "moviebackground")]
    public List<LocalizedImage> MovieBackgrounds { get; set; }

    [DataMember(Name = "hdmovielogo")]
    public List<LocalizedImage> HdMovieLogos { get; set; }

    [DataMember(Name = "moviebanner")]
    public List<LocalizedImage> MovieBanners { get; set; }

    public void SetIds()
    {
      string category = ImageCategory.Series.ToString().ToLower();
      string id = TMDB_ID.ToString();
      Image.SetIds(MovieLogos, category, id, "movielogo");
      Image.SetIds(MovieDiscs, category, id, "moviedisc");
      Image.SetIds(MovieArts, category, id, "movieart");
      Image.SetIds(MovieBackgrounds, category, id, "moviebackground");
      Image.SetIds(HdMovieLogos, category, id, "hdmovielogo");
      Image.SetIds(MovieBanners, category, id, "moviebanner");
    }
  }
}

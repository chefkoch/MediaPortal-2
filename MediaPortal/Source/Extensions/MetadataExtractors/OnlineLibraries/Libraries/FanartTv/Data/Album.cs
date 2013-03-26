﻿#region Copyright (C) 2007-2013 Team MediaPortal

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

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MediaPortal.Extensions.OnlineLibraries.Libraries.FanartTv.Data
{
  //{
  //  "albumcover": [
  //    {
  //      "id": "43",
  //      "url": "http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/albumcover/fallen-4dc8683fa58fe.jpg",
  //      "likes": "0"
  //    }
  //  ],
  //  "cdart": [
  //    {
  //      "id": "17739",
  //      "url": "http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/cdart/fallen-4f133f8a16d25.png",
  //      "likes": "0",
  //      "disc": "1",
  //      "size": "1000"
  //    }
  //  ]
  //}
  [DataContract]
  public class Album
  {
    [DataMember(Name = "albumcover")]
    public List<Image> Covers { get; set; }

    [DataMember(Name = "cdart")]
    public List<DiscImage> DiscArts { get; set; }

    public static void SetIds(Dictionary<string,Album> albums)
    {
      if (albums == null) return;

      string category = ImageCategory.Album.ToString().ToLower();
      foreach (var album in albums)
      {
        Image.SetIds(album.Value.Covers, category, album.Key, "albumcover");
        Image.SetIds(album.Value.DiscArts, category, album.Key, "cdart");
      }
    }
  }
}

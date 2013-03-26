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
  //  "Evanescence": {
  //    "mbid_id": "f4a31f0a-51dd-4fa7-986d-3095c40c5ed9",
  //    "musiclogo": [
  //      {
  //        "id": "5474",
  //        "url": "http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/musiclogo/evanescence-4df95bceb4b1c.png",
  //        "likes": "2"
  //      }
  //    ],
  //    "artistbackground": [
  //      {
  //        "id": "6",
  //        "url": "http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/artistbackground/evanescence-4dc7198199ccd.jpg",
  //        "likes": "1"
  //      }
  //    ],
  //    "artistthumb": [
  //      {
  //        "id": "33339",
  //        "url": "http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/artistthumb/evanescence-4fc7468829e99.jpg",
  //        "likes": "1"
  //      }
  //    ],
  //    "albums": {
  //      "2187d248-1a3b-35d0-a4ec-bead586ff547": {
  //        "albumcover": [
  //          {
  //            "id": "43",
  //            "url": "http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/albumcover/fallen-4dc8683fa58fe.jpg",
  //            "likes": "0"
  //          }
  //        ],
  //        "cdart": [
  //          {
  //            "id": "17739",
  //            "url": "http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/cdart/fallen-4f133f8a16d25.png",
  //            "likes": "0",
  //            "disc": "1",
  //            "size": "1000"
  //          }
  //        ]
  //      }
  //    },
  //    "hdmusiclogo": [
  //      {
  //        "id": "50850",
  //        "url": "http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/hdmusiclogo/evanescence-5049ce8bbe373.png",
  //        "likes": "0"
  //      }
  //    ],
  //    "musicbanner": [
  //      {
  //        "id": "56733",
  //        "url": "http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/musicbanner/evanescence-507beae754bf6.jpg",
  //        "likes": "0"
  //      }
  //    ]
  //  }
  //}
  [DataContract]
  public class ArtistResult : Dictionary<string, Artist>
  {
  }
}

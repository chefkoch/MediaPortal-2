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
  //  "Bones": {
  //    "thetvdb_id": "75682",
  //    "clearlogo": [
  //      {
  //        "id": "2112",
  //        "url": "http://assets.fanart.tv/fanart/tv/75682/clearlogo/Bones-75682.png",
  //        "lang": "en",
  //        "likes": "6"
  //      }
  //    ],
  //    "clearart": [
  //      {
  //        "id": "4301",
  //        "url": "http://assets.fanart.tv/fanart/tv/75682/clearart/B_75682 (3).png",
  //        "lang": "en",
  //        "likes": "2"
  //      }
  //    ],
  //    "tvthumb": [
  //      {
  //        "id": "21765",
  //        "url": "http://assets.fanart.tv/fanart/tv/75682/tvthumb/bones-5070c96416c4e.jpg",
  //        "lang": "en",
  //        "likes": "2"
  //      }
  //    ],
  //    "seasonthumb": [
  //      {
  //        "id": "4311",
  //        "url": "http://assets.fanart.tv/fanart/tv/75682/seasonthumb/Bones (5).jpg",
  //        "lang": "en",
  //        "likes": "1",
  //        "season": "5"
  //      }
  //    ],
  //    "showbackground": [
  //      {
  //        "id": "19374",
  //        "url": "http://assets.fanart.tv/fanart/tv/75682/showbackground/bones-500994f33356b.jpg",
  //        "lang": "en",
  //        "likes": "1",
  //        "season": "7"
  //      }
  //    ],
  //    "hdtvlogo": [
  //      {
  //        "id": "20329",
  //        "url": "http://assets.fanart.tv/fanart/tv/75682/hdtvlogo/bones-503e7abe533b1.png",
  //        "lang": "en",
  //        "likes": "1"
  //      }
  //    ],
  //    "hdclearart": [
  //      {
  //        "id": "22607",
  //        "url": "http://assets.fanart.tv/fanart/tv/75682/hdclearart/bones-508c48fd9ca6d.png",
  //        "lang": "en",
  //        "likes": "1"
  //      }
  //    ],
  //    "characterart": [
  //      {
  //        "id": "18513",
  //        "url": "http://assets.fanart.tv/fanart/tv/75682/characterart/bones-4fc8e8b0d3490.png",
  //        "lang": "en",
  //        "likes": "0"
  //      }
  //    ]
  //  }
  //}
  [DataContract]
  public class SeriesResult : Dictionary<string, Series>
  {
  }
}

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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MediaPortal.Extensions.OnlineLibraries.Libraries.Common;
using MediaPortal.Extensions.OnlineLibraries.Libraries.FanartTv.Data;
using Newtonsoft.Json;

namespace MediaPortal.Extensions.OnlineLibraries.Libraries.FanartTv
{
  internal class FanartTvApi
  {
    #region Constants

    public const string DefaultLanguage = "en";

    private const string URL_API_BASE =   "http://api.fanart.tv/webservice/";
    private const string URL_GET_ARTIST =   URL_API_BASE + "artist/";
    private const string URL_GET_ALBUM = URL_API_BASE + "album/";
    private const string URL_GET_LABEL =  URL_API_BASE + "label/";
    private const string URL_GET_MOVIE =  URL_API_BASE + "movie/";
    private const string URL_GET_SERIES =  URL_API_BASE + "series/";

    #endregion

    #region Fields

    private readonly string _apiKey;
    private readonly string _cachePath;
    //private Configuration _configuration;
    private readonly Downloader _downloader;

    #endregion

    #region Properties

    //public Configuration Configuration
    //{
    //  get
    //  {
    //    if (_configuration != null)
    //      return _configuration;
    //    _configuration = GetImageConfiguration();
    //    return _configuration;
    //  }
    //}

    #endregion

    #region Constructor

    public FanartTvApi(string apiKey, string cachePath)
    {
      _apiKey = apiKey;
      _cachePath = cachePath;
      _downloader = new Downloader { EnableCompression = true };
      _downloader.Headers["Accept"] = "application/json";
    }

    #endregion

    #region Public members

    /// <summary>
    /// Returns a collection of available fanart for a single <see cref="ArtistResult"/> with given <paramref name="mbid">MusicBrainz Identifier</paramref>. This method caches request
    /// to same artists and albums using the cache path given in <see cref="FanartTvApi"/> constructor.
    /// </summary>
    /// <param name="mbid">MusicBrainzIdentifier of artist</param>
    /// <param name="type">Defines whether only a specific image type should be downloaded.</param>
    /// <param name="sort">Defines the sorting of the images results.</param>
    /// <param name="limit">Allows to limit the image result to one per imagetype.</param>
    /// <returns>Artist fanart collection</returns>
    public ArtistResult GetArtist(string mbid, MusicImageType type = MusicImageType.All, Sort sort = Sort.MostPopularThenNewest, Limit limit = Limit.AllImages)
    {
      string cache = CreateAndGetCacheName(ImageCategory.Artist, mbid);
      if (!string.IsNullOrEmpty(cache) && File.Exists(cache))
      {
        string json = File.ReadAllText(cache);
        return JsonConvert.DeserializeObject<ArtistResult>(json);
      }
      string url = GetUrl(URL_GET_ARTIST, mbid, type.ToString().ToLower(), sort, limit);

      // todo: cache only if full details were selected
      ArtistResult result = _downloader.Download<ArtistResult>(url, cache);
      CacheAlbumsOfArtist(result);
      return result;
    }

    /// <summary>
    /// Returns a collection of available fanart for a single Album with given <paramref name="mbid">MusicBrainz Identifier</paramref>. This method caches request
    /// to same albums using the cache path given in <see cref="FanartTvApi"/> constructor.
    /// </summary>
    /// <param name="mbid">MusicBrainzIdentifier of album</param>
    /// <param name="type">Defines whether only a specific image type should be downloaded.</param>
    /// <param name="sort">Defines the sorting of the images results.</param>
    /// <param name="limit">Allows to limit the image result to one per imagetype.</param>
    /// <returns>Artist fanart collection</returns>
    public ArtistResult GetAlbum(string mbid, MusicImageType type = MusicImageType.All, Sort sort = Sort.MostPopularThenNewest, Limit limit = Limit.AllImages)
    {
      string cache = CreateAndGetCacheName(ImageCategory.Album, mbid);
      if (!string.IsNullOrEmpty(cache) && File.Exists(cache))
      {
        string json = File.ReadAllText(cache);
        return JsonConvert.DeserializeObject<ArtistResult>(json);
      }
      string url = GetUrl(URL_GET_ALBUM, mbid, type.ToString().ToLower(), sort, limit);
      // todo: cache only if full details were selected
      return _downloader.Download<ArtistResult>(url, cache);
    }

    ///// <summary>
    ///// Returns a collection of available fanart for a single <see cref="ArtistResult"/> with given <paramref name="mbid">MusicBrainz Identifier</paramref>. This method caches request
    ///// to same labels using the cache path given in <see cref="FanartTvApi"/> constructor.
    ///// </summary>
    ///// <param name="mbid">MusicBrainzIdentifier of label</param>
    ///// <param name="type">Defines whether only a specific image type should be downloaded.</param>
    ///// <param name="sort">Defines the sorting of the images results.</param>
    ///// <param name="limit">Allows to limit the image result to one per imagetype.</param>
    ///// <returns>Artist fanart collection</returns>
    //public ArtistResult GetLabel(string mbid, MusicImageType type = MusicImageType.All, Sort sort = Sort.MostPopularThenNewest, Limit limit = Limit.AllImages)
    //{
    //  string cache = CreateAndGetCacheName(ImageCategory.Album, mbid);
    //  if (!string.IsNullOrEmpty(cache) && File.Exists(cache))
    //  {
    //    string json = File.ReadAllText(cache);
    //    return JsonConvert.DeserializeObject<ArtistResult>(json);
    //  }
    //  string url = GetUrl(URL_GET_ALBUM, mbid, type.ToString().ToLower(), sort, limit);
    //// todo: cache only if full details were selected
    //  return _downloader.Download<ArtistResult>(url, cache);
    //}

    /// <summary>
    /// Returns a collection of available fanart for a single <see cref="Movie"/> with given <paramref name="movieid"/> This method caches request
    /// to same movie using the cache path given in <see cref="FanartTvApi"/> constructor.
    /// </summary>
    /// <param name="movieid">Could either be an IMDB or a TMDB id</param>
    /// <param name="type">Defines whether only a specific image type should be downloaded.</param>
    /// <param name="sort">Defines the sorting of the images results.</param>
    /// <param name="limit">Allows to limit the image result to one per imagetype.</param>
    /// <returns>Artist fanart collection</returns>
    public Movie GetMovie(string movieid, MovieImageType type = MovieImageType.All, Sort sort = Sort.MostPopularThenNewest, Limit limit = Limit.AllImages)
    {
      string cache = CreateAndGetCacheName(ImageCategory.Movie, movieid);
      if (!string.IsNullOrEmpty(cache) && File.Exists(cache))
      {
        string json = File.ReadAllText(cache);
        return JsonConvert.DeserializeObject<Movie>(json);
      }
      string url = GetUrl(URL_GET_MOVIE, movieid, type.ToString().ToLower(), sort, limit);
      // todo: cache only if full details were selected
      return _downloader.Download<Movie>(url, cache);
    }

    /// <summary>
    /// Returns a collection of available fanart for a single <see cref="Series"/> with given <paramref name="imdbid">IMDB id</paramref>. This method caches request
    /// to same movie using the cache path given in <see cref="FanartTvApi"/> constructor.
    /// </summary>
    /// <param name="mbid">MusicBrainzIdentifier of artist</param>
    /// <param name="type">Defines whether only a specific image type should be downloaded.</param>
    /// <param name="sort">Defines the sorting of the images results.</param>
    /// <param name="limit">Allows to limit the image result to one per imagetype.</param>
    /// <returns>Artist fanart collection</returns>
    public Series GetSeries(string mbid, SeriesImageType type = SeriesImageType.All, Sort sort = Sort.MostPopularThenNewest, Limit limit = Limit.AllImages)
    {
      string cache = CreateAndGetCacheName(ImageCategory.Album, mbid);
      if (!string.IsNullOrEmpty(cache) && File.Exists(cache))
      {
        string json = File.ReadAllText(cache);
        return JsonConvert.DeserializeObject<Series>(json);
      }
      string url = GetUrl(URL_GET_SERIES, mbid, type.ToString().ToLower(), sort, limit);
      // todo: cache only if full details were selected
      return _downloader.Download<Series>(url, cache);
    }

    /// <summary>
    /// Downloads images in "original" size and saves them to cache.
    /// </summary>
    /// <param name="image">Image to download</param>
    /// <returns><c>true</c> if successful</returns>
    public bool DownloadImage(Image image)
    {
      string cacheFileName = CreateAndGetCacheName(image);
      if (string.IsNullOrEmpty(cacheFileName))
        return false;

      _downloader.DownloadFile(image.Url, cacheFileName);
      return true;
    }

    #endregion

    #region Protected members

    /// <summary>
    /// Builds and returns the full request url.
    /// </summary>
    /// <returns>Complete url</returns>
    protected string GetUrl(string urlBase, string identifier, string type, Sort sort, Limit limit)
    {
      return string.Format("{0}/{1}/{2}/json/{3}/{4}/{5}/", urlBase, _apiKey, identifier, type, (int) sort, (int) limit);
    }

    /// <summary>
    /// Creates a local file name for loading and saving details.
    /// </summary>
    /// <param name="category"></param>
    /// <param name="identifier"></param>
    /// <returns>Cache file name or <c>null</c> if directory could not be created</returns>
    protected string CreateAndGetCacheName(ImageCategory category, string identifier)
    {
      string categoryLower = category.ToString().ToLower();
      try
      {
        string folder = Path.Combine(_cachePath, categoryLower, identifier);
        if (!Directory.Exists(folder))
          Directory.CreateDirectory(folder);
        return Path.Combine(folder, string.Format("{0}.json", categoryLower));
      }
      catch
      {
        // TODO: logging
        return null;
      }
    }

    /// <summary>
    /// Creates a local file name for loading and saving <see cref="Image"/>s.
    /// </summary>
    /// <param name="image"></param>
    /// <param name="category"></param>
    /// <returns>Cache file name or <c>null</c> if directory could not be created</returns>
    protected string CreateAndGetCacheName(Image image)
    {
      try
      {
        string folder = Path.Combine(_cachePath, image.Category, image.ParentId, image.SubCategory);
        if (!Directory.Exists(folder))
          Directory.CreateDirectory(folder);
        return Path.Combine(folder, image.Id + Path.GetExtension(image.Url));
      }
      catch
      {
        // TODO: logging
        return null;
      }
    }

    #endregion

    #region Cache Helper

    /// <summary>
    /// If all images of an artist are retrieved, the albums can be cached separately, because the result will be exactly the same like the album lookup.
    /// </summary>
    /// <param name="artistResult"></param>
    private void CacheAlbumsOfArtist(ArtistResult artistResult)
    {
      if (artistResult == null) return;
      if (artistResult.Count == 0) return;

      string name = artistResult.First().Key;
      Artist artist = artistResult.First().Value;

      if (artist.Albums == null) return;

      foreach (KeyValuePair<string, Album> pair in artist.Albums)
      {
        // Create a new artist
        Artist newArtist = new Artist();
        // Add the same MBID
        newArtist.MBID_ID = artist.MBID_ID;
        // Add only one album
        newArtist.Albums = new Dictionary<string, Album> {{pair.Key, pair.Value}};

        // Create a new ArtistResult
        ArtistResult newResult = new ArtistResult();
        newResult.Add(name, newArtist);

        // Get CacheFilename for current album
        string cacheFileName = CreateAndGetCacheName(ImageCategory.Album, pair.Key);
        _downloader.WriteCache(newResult, cacheFileName);
      }
    }

    #endregion
  }
}

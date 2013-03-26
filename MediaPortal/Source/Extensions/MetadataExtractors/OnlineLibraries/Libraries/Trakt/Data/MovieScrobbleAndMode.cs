namespace MediaPortal.Extensions.OnlineLibraries.Libraries.Trakt.Data
{
  /// <summary>
  /// Class to pass scrobbling data and state to background worker
  /// </summary>
  internal class MovieScrobbleAndMode
  {
    public TraktMovieScrobble MovieScrobble { get; set; }
    public TraktScrobbleStates ScrobbleState { get; set; }
  }
}
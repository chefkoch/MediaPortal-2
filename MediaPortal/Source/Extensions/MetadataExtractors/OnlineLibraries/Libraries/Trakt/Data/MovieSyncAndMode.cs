namespace MediaPortal.Extensions.OnlineLibraries.Libraries.Trakt.Data
{
  /// <summary>
  /// Class used to pass syncdata and sync mode to background worker
  /// </summary>
  internal class MovieSyncAndMode
  {
    public TraktMovieSync SyncData { get; set; }
    public TraktSyncModes Mode { get; set; }
  }
}
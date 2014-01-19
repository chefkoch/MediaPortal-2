namespace MediaPortal.InstallerUI.Enums
{
  public enum FeatureState
  {
    Unknown = -1,

    /// <summary>
    /// Feature was installed as Advertised.
    /// </summary>
    Advertised = 1,

    /// <summary>
    /// Feature or component was Absent (not installed).
    /// </summary>
    Absent = 2,

    /// <summary>
    /// Feature or component was installed Local, to the hard disk.
    /// </summary>
    Local = 3,

    /// <summary>
    /// Feature or component was installed to Source.
    /// </summary>
    Source = 4,
  }
}
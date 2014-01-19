namespace MediaPortal.InstallerUI.Enums
{
  public enum FeatureAction
  {
    /// <summary>
    /// This indicates that the state is not known, usually because costing
    /// has not taken place. No action will be taken on the component or feature.
    /// </summary>
    Unknown = -1,

    /// <summary>
    /// This indicates that the feature will be installed as advertised,
    /// meaning install on demand. This doesn't exist for components.
    /// </summary>
    Advertised = 1,

    /// <summary>
    /// This indicates that the feature or component will not be installed.
    /// </summary>
    Absent = 2,

    /// <summary>
    /// This indicates that the feature or component will be installed to the
    /// local hard disk.
    /// </summary>
    Local = 3,

    /// <summary>
    /// This indicates that the feature or component will be run from source,
    /// such as from a network share.
    /// </summary>
    Source = 4,
  }
}
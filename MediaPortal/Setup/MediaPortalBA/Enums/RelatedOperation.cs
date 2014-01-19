namespace MediaPortal.InstallerUI.Enums
{
  public enum RelatedOperation
  {
    None,

    /// <summary>
    /// The related bundle or package will be downgraded.
    /// </summary>
    Downgrade,

    ///<summary>
    /// The related package will be upgraded as a minor revision.
    ///</summary>
    MinorUpdate,

    ///<summary>
    /// The related bundle or package will be upgraded as a major revision.
    ///</summary>
    MajorUpgrade,

    ///<summary>
    /// The related bundle will be removed.
    ///</summary>
    Remove,

    ///<summary>
    /// The related bundle will be installed.
    ///</summary>
    Install,

    ///<summary>
    /// The related bundle will be repaired.
    ///</summary>
    Repair,
  };
}
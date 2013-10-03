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
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace MediaPortal.Common.MediaManagement.Helpers
{
  /// <summary>
  /// 
  /// </summary>
  /// <remarks>
  /// Code initially based on TinyMediaManager 
  /// Thanks to: Manuel Laggner / Myron Boyle
  /// </remarks>
  public sealed class Certification
  {
    #region Certifications

    public static readonly Certification US_G = new Certification("US", "G", new[] { "G", "Rated G" });
    public static readonly Certification US_PG = new Certification("US", "PG", new[] { "PG", "Rated PG" });
    public static readonly Certification US_PG13 = new Certification("US", "PG-13", new[] { "PG-13", "Rated PG-13" });
    public static readonly Certification US_R = new Certification("US", "R", new[] { "R", "Rated R" });
    public static readonly Certification US_NC17 = new Certification("US", "NC-17", new[] { "NC-17", "Rated NC-17" });

    public static readonly Certification US_TVY = new Certification("US", "TV-Y", new[] { "TV-Y" });
    public static readonly Certification US_TVY7 = new Certification("US", "TV-Y7", new[] { "TV-Y7" });
    public static readonly Certification US_TVG = new Certification("US", "TV-G", new[] { "TV-G" });
    public static readonly Certification US_TVPG = new Certification("US", "TV-PG", new[] { "TV-PG" });
    public static readonly Certification US_TV14 = new Certification("US", "TV-14", new[] { "TV-14" });
    public static readonly Certification US_TVMA = new Certification("US", "TV-MA", new[] { "TV-MA" });

    public static readonly Certification DE_FSK0 = new Certification("DE", "FSK 0", new[] { "FSK 0", "FSK0", "0" });
    public static readonly Certification DE_FSK6 = new Certification("DE", "FSK 6", new[] { "FSK 6", "FSK6", "6", "ab 6" });
    public static readonly Certification DE_FSK12 = new Certification("DE", "FSK 12", new[] { "FSK 12", "FSK12", "12", "ab 12" });
    public static readonly Certification DE_FSK16 = new Certification("DE", "FSK 16", new[] { "FSK 16", "FSK16", "16", "ab 16" });
    public static readonly Certification DE_FSK18 = new Certification("DE", "FSK 18", new[] { "FSK 18", "FSK18", "18", "ab 18" });

    public static readonly Certification GB_UC = new Certification("GB", "UC", new[] { "UC" });
    public static readonly Certification GB_U = new Certification("GB", "U", new[] { "U" });
    public static readonly Certification GB_PG = new Certification("GB", "PG", new[] { "PG" });
    public static readonly Certification GB_12A = new Certification("GB", "12A", new[] { "12A" });
    public static readonly Certification GB_12 = new Certification("GB", "12", new[] { "12" });
    public static readonly Certification GB_15 = new Certification("GB", "15", new[] { "15" });
    public static readonly Certification GB_18 = new Certification("GB", "18", new[] { "18" });
    public static readonly Certification GB_R18 = new Certification("GB", "R18", new[] { "R18" });

    public static readonly Certification RU_Y = new Certification("RU", "Y", new[] { "Y" });
    public static readonly Certification RU_6 = new Certification("RU", "6+", new[] { "6+" });
    public static readonly Certification RU_12 = new Certification("RU", "12+", new[] { "12+" });
    public static readonly Certification RU_14 = new Certification("RU", "14+", new[] { "14+" });
    public static readonly Certification RU_16 = new Certification("RU", "16+", new[] { "16+" });
    public static readonly Certification RU_18 = new Certification("RU", "18+", new[] { "18+" });

    public static readonly Certification NL_AL = new Certification("NL", "AL", new[] { "AL" });
    public static readonly Certification NL_6 = new Certification("NL", "6", new[] { "6" });
    public static readonly Certification NL_9 = new Certification("NL", "9", new[] { "9" });
    public static readonly Certification NL_12 = new Certification("NL", "12", new[] { "12" });
    public static readonly Certification NL_16 = new Certification("NL", "16", new[] { "16" });

    public static readonly Certification JP_G = new Certification("JP", "G", new[] { "G" });
    public static readonly Certification JP_PG12 = new Certification("JP", "PG-12", new[] { "PG-12" });
    public static readonly Certification JP_R15 = new Certification("JP", "R15+", new[] { "R15+" });
    public static readonly Certification JP_R18 = new Certification("JP", "R18+", new[] { "R18+" });

    public static readonly Certification IT_T = new Certification("IT", "T", new[] { "T" });
    public static readonly Certification IT_VM14 = new Certification("IT", "V.M.14", new[] { "V.M.14", "VM14" });
    public static readonly Certification IT_VM18 = new Certification("IT", "V.M.18", new[] { "V.M.18", "VM18" });

    public static readonly Certification IN_U = new Certification("IN", "U", new[] { "U" });
    public static readonly Certification IN_UA = new Certification("IN", "UA", new[] { "UA" });
    public static readonly Certification IN_A = new Certification("IN", "A", new[] { "A" });
    public static readonly Certification IN_S = new Certification("IN", "S", new[] { "S" });

    public static readonly Certification GR_K = new Certification("GR", "K", new[] { "K" });
    public static readonly Certification GR_K13 = new Certification("GR", "K-13", new[] { "K-13", "K13" });
    public static readonly Certification GR_K17 = new Certification("GR", "K-17", new[] { "K-17", "K17" });
    public static readonly Certification GR_E = new Certification("GR", "E", new[] { "E" });

    public static readonly Certification FR_U = new Certification("FR", "U", new[] { "U" });
    public static readonly Certification FR_10 = new Certification("FR", "10", new[] { "10" });
    public static readonly Certification FR_12 = new Certification("FR", "12", new[] { "12" });
    public static readonly Certification FR_16 = new Certification("FR", "16", new[] { "16" });
    public static readonly Certification FR_18 = new Certification("FR", "18", new[] { "18" });

    public static readonly Certification CA_G = new Certification("CA", "G", new[] { "G" });
    public static readonly Certification CA_PG = new Certification("CA", "PG", new[] { "PG" });
    public static readonly Certification CA_14A = new Certification("CA", "14A", new[] { "14A" });
    public static readonly Certification CA_18A = new Certification("CA", "18A", new[] { "18A" });
    public static readonly Certification CA_R = new Certification("CA", "R", new[] { "R" });
    public static readonly Certification CA_A = new Certification("CA", "A", new[] { "A" });

    public static readonly Certification AU_E = new Certification("AU", "E", new[] { "E" });
    public static readonly Certification AU_G = new Certification("AU", "G", new[] { "G" });
    public static readonly Certification AU_PG = new Certification("AU", "PG", new[] { "PG" });
    public static readonly Certification AU_M = new Certification("AU", "M", new[] { "M" });
    public static readonly Certification AU_MA15 = new Certification("AU", "MA15+", new[] { "MA15+" });
    public static readonly Certification AU_R18 = new Certification("AU", "R18+", new[] { "R18+" });
    public static readonly Certification AU_X18 = new Certification("AU", "X18+", new[] { "X18+" });
    public static readonly Certification AU_RC = new Certification("AU", "RC", new[] { "RC" });

    public static readonly Certification CZ_U = new Certification("CZ", "U", new[] { "U" });
    public static readonly Certification CZ_PG = new Certification("CZ", "PG", new[] { "PG" });
    public static readonly Certification CZ_12 = new Certification("CZ", "12", new[] { "12" });
    public static readonly Certification CZ_15 = new Certification("CZ", "15", new[] { "15" });
    public static readonly Certification CZ_18 = new Certification("CZ", "18", new[] { "18" });
    public static readonly Certification CZ_E = new Certification("CZ", "E", new[] { "E" });

    public static readonly Certification DK_A = new Certification("DK", "A", new[] { "A" });
    public static readonly Certification DK_7 = new Certification("DK", "7", new[] { "7" });
    public static readonly Certification DK_11 = new Certification("DK", "11", new[] { "11" });
    public static readonly Certification DK_15 = new Certification("DK", "15", new[] { "15" });
    public static readonly Certification DK_F = new Certification("DK", "F", new[] { "F" });

    public static readonly Certification EE_PERE = new Certification("EE", "PERE", new[] { "PERE" });
    public static readonly Certification EE_L = new Certification("EE", "L", new[] { "L" });
    public static readonly Certification EE_MS6 = new Certification("EE", "MS-6", new[] { "MS-6" });
    public static readonly Certification EE_MS12 = new Certification("EE", "MS-12", new[] { "MS-12" });
    public static readonly Certification EE_K12 = new Certification("EE", "K-12", new[] { "K-12" });
    public static readonly Certification EE_K14 = new Certification("EE", "K-14", new[] { "K-14" });
    public static readonly Certification EE_K16 = new Certification("EE", "K-16", new[] { "K-16" });

    public static readonly Certification FI_S = new Certification("FI", "S", new[] { "S" });
    public static readonly Certification FI_K7 = new Certification("FI", "K-7", new[] { "K-7" });
    public static readonly Certification FI_K12 = new Certification("FI", "K-12", new[] { "K-12" });
    public static readonly Certification FI_K16 = new Certification("FI", "K-16", new[] { "K-16" });
    public static readonly Certification FI_K18 = new Certification("FI", "K-18", new[] { "K-18" });
    public static readonly Certification FI_KE = new Certification("FI", "K-E", new[] { "K-E" });

    public static readonly Certification HU_KN = new Certification("HU", "KN", new[] { "KN" });
    public static readonly Certification HU_6 = new Certification("HU", "6", new[] { "6" });
    public static readonly Certification HU_12 = new Certification("HU", "12", new[] { "12" });
    public static readonly Certification HU_16 = new Certification("HU", "16", new[] { "16" });
    public static readonly Certification HU_18 = new Certification("HU", "18", new[] { "18" });
    public static readonly Certification HU_X = new Certification("HU", "X", new[] { "X" });

    public static readonly Certification IS_L = new Certification("IS", "L", new[] { "L" });
    public static readonly Certification IS_7 = new Certification("IS", "7", new[] { "7" });
    public static readonly Certification IS_10 = new Certification("IS", "10", new[] { "10" });
    public static readonly Certification IS_12 = new Certification("IS", "12", new[] { "12" });
    public static readonly Certification IS_14 = new Certification("IS", "14", new[] { "14" });
    public static readonly Certification IS_16 = new Certification("IS", "16", new[] { "16" });
    public static readonly Certification IS_18 = new Certification("IS", "18", new[] { "18" });

    public static readonly Certification IE_G = new Certification("IE", "G", new[] { "G" });
    public static readonly Certification IE_PG = new Certification("IE", "PG", new[] { "PG" });
    public static readonly Certification IE_12A = new Certification("IE", "12A", new[] { "12A" });
    public static readonly Certification IE_15A = new Certification("IE", "15A", new[] { "15A" });
    public static readonly Certification IE_16 = new Certification("IE", "16", new[] { "16" });
    public static readonly Certification IE_18 = new Certification("IE", "18", new[] { "18" });

    public static readonly Certification NZ_G = new Certification("NZ", "G", new[] { "G" });
    public static readonly Certification NZ_PG = new Certification("NZ", "PG", new[] { "PG" });

    public static readonly Certification NZ_M = new Certification("NZ", "M", new[] { "M" });
    public static readonly Certification NZ_R13 = new Certification("NZ", "R13", new[] { "R13" });
    public static readonly Certification NZ_R16 = new Certification("NZ", "R16", new[] { "R16" });
    public static readonly Certification NZ_R18 = new Certification("NZ", "R18", new[] { "R18" });
    public static readonly Certification NZ_R15 = new Certification("NZ", "R15", new[] { "R15" });
    public static readonly Certification NZ_RP13 = new Certification("NZ", "RP13", new[] { "RP13" });
    public static readonly Certification NZ_RP16 = new Certification("NZ", "RP16", new[] { "RP16" });
    public static readonly Certification NZ_R = new Certification("NZ", "R", new[] { "R" });

    public static readonly Certification NO_A = new Certification("NO", "A", new[] { "A" });
    public static readonly Certification NO_7 = new Certification("NO", "7", new[] { "7" });
    public static readonly Certification NO_11 = new Certification("NO", "11", new[] { "11" });
    public static readonly Certification NO_15 = new Certification("NO", "15", new[] { "15" });
    public static readonly Certification NO_18 = new Certification("NO", "18", new[] { "18" });

    public static readonly Certification PL_AL = new Certification("PL", "AL", new[] { "AL" });
    public static readonly Certification PL_7 = new Certification("PL", "7", new[] { "7" });
    public static readonly Certification PL_12 = new Certification("PL", "12", new[] { "12" });
    public static readonly Certification PL_15 = new Certification("PL", "15", new[] { "15" });
    public static readonly Certification PL_AP = new Certification("PL", "AP", new[] { "AP" });
    public static readonly Certification PL_21 = new Certification("PL", "21", new[] { "21" });

    public static readonly Certification RO_AP = new Certification("RO", "A.P.", new[] { "A.P.", "AP" });
    public static readonly Certification RO_12 = new Certification("RO", "12", new[] { "12" });
    public static readonly Certification RO_15 = new Certification("RO", "15", new[] { "15" });
    public static readonly Certification RO_18 = new Certification("RO", "18", new[] { "18" });
    public static readonly Certification RO_18X = new Certification("RO", "18*", new[] { "18*" });

    public static readonly Certification ES_APTA = new Certification("ES", "APTA", new[] { "APTA" });
    public static readonly Certification ES_ER = new Certification("ES", "ER", new[] { "ER" });
    public static readonly Certification ES_7 = new Certification("ES", "7", new[] { "7" });
    public static readonly Certification ES_12 = new Certification("ES", "12", new[] { "12" });
    public static readonly Certification ES_16 = new Certification("ES", "16", new[] { "16" });
    public static readonly Certification ES_18 = new Certification("ES", "18", new[] { "18" });
    public static readonly Certification ES_PX = new Certification("ES", "PX", new[] { "PX" });

    public static readonly Certification SE_BTL = new Certification("SE", "BTL", new[] { "BTL" });
    public static readonly Certification SE_7 = new Certification("SE", "7", new[] { "7" });
    public static readonly Certification SE_11 = new Certification("SE", "11", new[] { "11" });
    public static readonly Certification SE_15 = new Certification("SE", "15", new[] { "15" });

    public static readonly Certification CH_0 = new Certification("CH", "0", new[] { "0" });
    public static readonly Certification CH_7 = new Certification("CH", "7", new[] { "7" });
    public static readonly Certification CH_10 = new Certification("CH", "10", new[] { "10" });
    public static readonly Certification CH_12 = new Certification("CH", "12", new[] { "12" });
    public static readonly Certification CH_14 = new Certification("CH", "14", new[] { "14" });
    public static readonly Certification CH_16 = new Certification("CH", "16", new[] { "16" });
    public static readonly Certification CH_18 = new Certification("CH", "18", new[] { "18" });

    public static readonly Certification TH_P = new Certification("TH", "P", new[] { "P" });
    public static readonly Certification TH_G = new Certification("TH", "G", new[] { "G" });
    public static readonly Certification TH_13 = new Certification("TH", "13+", new[] { "13+" });
    public static readonly Certification TH_15 = new Certification("TH", "15+", new[] { "15+" });
    public static readonly Certification TH_18 = new Certification("TH", "18+", new[] { "18+" });
    public static readonly Certification TH_20 = new Certification("TH", "20+", new[] { "20+" });
    public static readonly Certification TH_Banned = new Certification("TH", "Banned", new[] { "Banned" });

    /// <summary>
    /// initial value
    /// </summary>
    public static readonly Certification NOT_RATED = new Certification("US", "not rated", new[] { "not rated" });

    #endregion

    #region Constructor

    /// <summary>
    /// Instantiates a new certification.
    /// </summary>
    /// <param name="region">The TwoLetter region code.</param>
    /// <param name="name">The name.</param>
    /// <param name="possibleNotations">The possible notations.</param>
    private Certification(string region, string name, string[] possibleNotations)
      : this(new RegionInfo(region), name, possibleNotations)
    {
    }

    /// <summary>
    /// Instantiates a new certification.
    /// </summary>
    /// <param name="region">The region.</param>
    /// <param name="name">The name.</param>
    /// <param name="possibleNotations">The possible notations.</param>
    private Certification(RegionInfo region, string name, string[] possibleNotations)
    {
      Region = region;
      Name = name;
      PossibleNotations = possibleNotations;
    }

    #endregion

    #region Properties

    /// <summary>
    /// The region.
    /// </summary>
    public RegionInfo Region { get; private set; }

    /// <summary>
    /// The name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// The possible notations.
    /// </summary>
    public string[] PossibleNotations { get; private set; }

    #endregion

    #region Implementation

    /// <summary>
    /// Gets all known certifications.
    /// </summary>
    public static List<Certification> GetCertifications()
    {
      return typeof(Certification)
        .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
        .Where(f => f.FieldType == typeof(Certification))
        .Select(f => f.GetValue(null) as Certification).ToList();
    }

    /// <summary>
    /// Gets the certifications for the given region.
    /// </summary>
    public static List<Certification> GetCertificationsForRegion(RegionInfo region)
    {
      List<Certification> list = GetCertifications().Where(c => Equals(c.Region, region)).ToList();

      // At last: Add NOT_RATED
      if (!list.Contains(NOT_RATED))
        list.Add(NOT_RATED);

      return list;
    }

    /// <summary>
    /// Gets the certification for the given parameters.
    /// </summary>
    public static Certification GetCertification(string region, string name)
    {
      RegionInfo regionCode = new RegionInfo(region);
      return GetCertification(regionCode, name);
    }

    /// <summary>
    /// Gets the certification for the given parameters.
    /// </summary>
    public static Certification GetCertification(RegionInfo region, string name)
    {
      foreach (Certification certification in GetCertificationsForRegion(region))
      {
        // Check if the name matches
        if (certification.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
          return certification;

        // Check if one of the possible notations matches
        foreach (string notation in certification.PossibleNotations)
          if (notation.Equals(name, StringComparison.InvariantCultureIgnoreCase))
            return certification;
      }

      return NOT_RATED;
    }

    /// <summary>
    /// Generates a certification string from certs list, region alpha2.
    /// </summary>
    /// <param name="certifications">list of certifications</param>
    /// <returns>certification string like "US:R / UK:15 / SW:15"</returns>
    public static string GenerateCertificationStringFromList(IList<Certification> certifications)
    {
      if (certifications == null || certifications.Count == 0)
        return "";

      string certificationString = "";
      foreach (Certification c in certifications)
      {
        certificationString += " / " + c.Region.TwoLetterISORegionName + ":" + c.Name;
        if (c.Region.TwoLetterISORegionName == "GB")
        {
          // GB is official, but skins often parse UK
          certificationString += " / UK:" + c.Name;
        }
      }

      return certificationString.Substring(3).Trim(); // strip off first slash
    }

    /// <summary>
    /// Generates a certification string for region alpha2 (including all different variants)
    /// </summary>
    /// <param name="certification">the certification</param>
    /// <returns>certification string like "DE:FSK 16 / DE:FSK16 / DE:16 / DE:ab 16"</returns>
    public static string GenerateCertificationStringWithAlternateNames(Certification certification)
    {
      if (certification == null)
        return "";

      string certificationString = "";
      foreach (string notation in certification.PossibleNotations)
      {
        certificationString += " / " + certification.Region.TwoLetterISORegionName + ":" + notation;
        if (certification.Region.TwoLetterISORegionName == "GB")
        {
          certificationString += " / UK:" + notation;
        }
      }

      return certificationString.Substring(3).Trim(); // Strip off first slash
    }

    /// <summary>
    /// Parses a given certification string for the localized region setup in setting.
    /// </summary>
    /// <param name="certificationString">certification string like "USA:R / UK:15 / Sweden:15"</param>
    /// <param name="userRegion">This region has been configured by the user within the application settings.</param>
    /// <returns>the localized certification if found, else *ANY* language cert found</returns>
    // <certification>USA:R / UK:15 / Sweden:15 / Spain:18 / South Korea:15 /
    // Singapore:NC-16 / Portugal:M/16 / Philippines:R-18 / Norway:15 / New
    // Zealand:M / Netherlands:16 / Malaysia:U / Malaysia:18PL / Ireland:18 /
    // Iceland:16 / Hungary:18 / Germany:16 / Finland:K-15 / Canada:18A /
    // Canada:18+ / Brazil:16 / Australia:M / Argentina:16</certification>
    public static Certification ParseCertificationStringForUsersRegion(string certificationString, RegionInfo userRegion)
    {
      Certification certification = NOT_RATED;
      certificationString = certificationString.Trim();

      if (certificationString.Contains("/"))
      {
        // Multiple countries
        string[] countries = certificationString.Split('/');

        // First try to find by userRegion
        foreach (string c in countries)
        {
          string d = c.Trim();
          if (d.Contains(":"))
          {
            string[] cs = c.Split(':');
            certification = GetCertification(userRegion, cs[1]);
            if (certification != NOT_RATED)
              return certification;
          }
          else
          {
            certification = GetCertification(userRegion, c);
            if (certification != NOT_RATED)
              return certification;
          }
        }

        // Still not found localized cert? Parse the name to find *ANY* certificate
        foreach (string c in countries)
        {
          string d = c.Trim();
          if (d.Contains(":"))
          {
            string[] cs = c.Split(':');
            certification = FindCertification(cs[1]);
            if (certification != NOT_RATED)
            {
              return certification;
            }
          }
          else
          {
            certification = FindCertification(c);
            if (certification != NOT_RATED)
            {
              return certification;
            }
          }
        }
      }
      else
      {
        // No slash, so only one region
        if (certificationString.Contains(":"))
        {
          string[] cs = certificationString.Split(':');
          certification = GetCertification(userRegion, cs[1]);
        }
        else
        {
          // No region? try to find only by name
          certification = GetCertification(userRegion, certificationString);
        }
      }

      // Still not found localized cert? Parse the name to find *ANY* certificate
      if (certification == NOT_RATED)
        certification = FindCertification(certificationString);

      return certification;
    }

    /// <summary>
    /// Find certification.
    /// </summary>
    public static Certification FindCertification(string certificationString)
    {
      foreach (Certification certification in GetCertifications())
      {
        // Check if the name matches
        if (certification.Name.Equals(certificationString, StringComparison.InvariantCultureIgnoreCase))
          return certification;

        // Check if one of the possible notations matches
        foreach (string notation in certification.PossibleNotations)
          if (notation.Equals(certificationString, StringComparison.InvariantCultureIgnoreCase))
            return certification;
      }

      return NOT_RATED;
    }

    #endregion

    #region Overrides of Object

    public override string ToString()
    {
      return Name;
    }

    #endregion
  }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameInverter.cs" company="bah">
//   bah
// </copyright>
// <summary>
//   The name inverter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TDDNameInverter.Date20130612
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The name inverter.
    /// </summary>
    public class NameInverter
    {
        /// <summary>
        /// The honorifics.
        /// </summary>
        private static readonly string[] Honorifics = new[] { "Mr.", "Ms.", "Miss.", "Mrs." };

        /// <summary>
        /// The post nominals.
        /// </summary>
        private static readonly string[] PostNominals = new[] { "MD.", "PHD." };

        /// <summary>
        /// The invert name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string InvertName(string name)
        {
            return GetInvertedName(SplitName(name));
        }

        /// <summary>
        /// The get inverted name.
        /// </summary>
        /// <param name="names">
        /// The names.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetInvertedName(List<string> names)
        {
            var honorific = GetHonorific(names);
            var postNominals = GetPostNominals(names);

            var lastName = GetLastName(names);
            var firstName = GetFirstName(names);
            var middleNames = GetMiddleNames(names);

            return honorific + 
                lastName + 
                firstName + 
                middleNames + 
                postNominals;
        }

        /// <summary>
        /// The get middle names.
        /// </summary>
        /// <param name="names">
        /// The names.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetMiddleNames(List<string> names)
        {
            if (names.Any())
            {
                return " " + string.Join(" ", names);
            }

            return string.Empty;
        }

        /// <summary>
        /// The get last name.
        /// </summary>
        /// <param name="names">
        /// The names.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetLastName(List<string> names)
        {
            if (names.Count > 1)
            {
                var lastName = names.Last();
                names.Remove(lastName);
                return lastName + ", ";
            }

            return string.Empty;
        }

        /// <summary>
        /// The get first name.
        /// </summary>
        /// <param name="names">
        /// The names.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetFirstName(List<string> names)
        {
            if (names.Any())
            {
                var firstName = names.First();
                names.Remove(firstName);
                return firstName;
            }

            return string.Empty;
        }

        /// <summary>
        /// The is name null or empty.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsNameNullOrEmpty(string name)
        {
            return string.IsNullOrEmpty(name);
        }

        /// <summary>
        /// The split name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// A <see cref="List"/> of the name parts.
        /// </returns>
        private static List<string> SplitName(string name)
        {
            if (IsNameNullOrEmpty(name))
            {
                return new List<string>();
            }

            return Regex.Split(name.Trim(), "\\s+").ToList();
        }

        /// <summary>
        /// The get honorific.
        /// </summary>
        /// <param name="names">
        /// The names.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetHonorific(List<string> names)
        {
            var honorificInName = names.Intersect(Honorifics).ToArray();
            
            if (honorificInName.Any())
            {
                RemoveHonorificFromNames(names, honorificInName);
                return string.Join(string.Empty, honorificInName) + " ";
            }

            return string.Empty;
        }

        /// <summary>
        /// The remove honorific from names.
        /// </summary>
        /// <param name="names">
        /// The names.
        /// </param>
        /// <param name="honorificInName">
        /// The honorific in name.
        /// </param>
        private static void RemoveHonorificFromNames(List<string> names, IEnumerable<string> honorificInName)
        {
            foreach (var h in honorificInName)
            {
                names.Remove(h);
            }
        }

        /// <summary>
        /// The get post nomals.
        /// </summary>
        /// <param name="names">
        /// The names.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetPostNominals(List<string> names)
        {
            var postNominalsInName = names.Intersect(PostNominals).ToArray();
            
            if (postNominalsInName.Any())
            {
                RemovePostNominalsFromNames(names, postNominalsInName);
                return " " + string.Join(" ", postNominalsInName);
            }

            return string.Empty;
        }

        /// <summary>
        /// The remove post nominals from names.
        /// </summary>
        /// <param name="names">
        /// The names.
        /// </param>
        /// <param name="postNominalsInName">
        /// The post nominals in name.
        /// </param>
        private static void RemovePostNominalsFromNames(List<string> names, IEnumerable<string> postNominalsInName)
        {
            foreach (var h in postNominalsInName)
            {
                names.Remove(h);
            }
        }
    }
}
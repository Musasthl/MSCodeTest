// Author: Musa Simphiwe Sithole
// Email: Musasthl@yahoo.com
// Phone: 0837477313

using MSCodeTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSCodeTest.Common.Utilities
{
    public static class WordFrequency
    {
        public static List<NameCount> GetPersonNamesFrequency(List<Person> list)
        {
            return ((from f in list
                     select new { Name = f.FirstName })
                .Concat(from l in list
                        select new { Name = l.LastName })
                )
                .GroupBy(g => g.Name)
                .Select(group => new NameCount() { Name = group.Key, TotalCount = group.Count() })
                .OrderByDescending(x => x.TotalCount).ThenBy(x => x.Name).ToList<NameCount>();
        }

        public static List<string> GetAddressAlphabatically(List<Person> personList)
        {
            return personList
                     .Select(p => p.Address)
                     .OrderBy(address => ExtractAddressName(address.Trim())).ToList();

        }

        public static string ExtractAddressName(string fullAddress)
        {
            var pos = fullAddress.IndexOf(" ", StringComparison.Ordinal);
            return pos != -1 ? fullAddress.Substring(pos).Trim() : fullAddress;
        }
    }
}

// Author: Musa Simphiwe Sithole
// Email: Musasthl@yahoo.com
// Phone: 0837477313

using MSCodeTest.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MSCodeTest.Common.Utilities
{
    public static class CsvFileUtils
    {
        public static List<Person> GetPersonDataFromCsv(string fileName)
        {
            try
            {
                var personList = File.ReadAllLines(fileName)
                        .Skip(1)
                        .Select(p => p.Split(','))
                        .Select(p => new
                        Person()
                        {
                            FirstName = p[0],
                            LastName = p[1],
                            Address = p[2],
                            PhoneNumber = p[3]
                        }).ToList();
                return personList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string WriteCSV<T>(IEnumerable<T> items, string filename, bool hasHeader = false)
        {
            try
            {
                Type itemType = typeof(T);
                var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                    .OrderBy(p => p.Name);

                string filePath = GetCsvDirectory("CSVFiles") + filename;

                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(!hasHeader ? "Data" : string.Join(", ", props.Select(p => p.Name)));

                    foreach (var item in items)
                    {

                        if (item.GetType().FullName != "System.String")
                            writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                        else
                            writer.WriteLine(item);
                    }
                }
                return filePath;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static string GetCsvDirectory(string directoryName)
        {
            string appDirectory = $"{Environment.CurrentDirectory }\\{directoryName}\\";
            if (!Directory.Exists(appDirectory))
            {
                Directory.CreateDirectory(appDirectory);
            }
            return appDirectory;
        }
    }
}

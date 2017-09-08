// Author: Musa Simphiwe Sithole
// Email: Musasthl@yahoo.com
// Phone: 0837477313

using MSCodeTest.Common.Utilities;
using MSCodeTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSCodeTest.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get data from csv file
            List<Person> personList = CsvFileUtils.GetPersonDataFromCsv("Resources/data.csv");

            if (personList?.Count > 0)
            {
                Console.WriteLine("Successfully read csv file");
                Console.WriteLine($"Total lines found: { personList.Count}");

                // Get name frequency base on firstname and lastname and order by count descending and by name ascending
                var nameCollection = WordFrequency.GetPersonNamesFrequency(personList);
                // Get address sorted by name not by number
                var addressCollection = WordFrequency.GetAddressAlphabatically(personList);

                // Print data to console window
                PrintNameFrequencies(nameCollection);
                PrintAddressFrequencies(addressCollection);

                // Writing our sorted data and frequency data to csv files
                WriteToCsv(nameCollection, addressCollection);
            }
            else
            {
                Console.WriteLine("Total lines found: 0");
            }
            Console.ReadKey();
        }

        private static void WriteToCsv(List<NameCount> nameCollection, List<string> addressCollection)
        {
            var addressCsvPath = CsvFileUtils.WriteCSV(addressCollection, "address_sorted.csv");
            var nameFrequencyCsvPath = CsvFileUtils.WriteCSV(nameCollection, "name_frequency.csv", true);

            Console.WriteLine(Environment.NewLine);

            // Check if we got a file path if the is no csv write file path then something went wrong
            if (nameFrequencyCsvPath != null)
                Console.WriteLine($"\tName sorted frequency wrote to csv file:{Environment.NewLine}{nameFrequencyCsvPath}");
            else
                Console.WriteLine("\tFailed to write Name sorted frequency csv file");

            if (addressCsvPath != null)
                Console.WriteLine($"\tSorted address wrote to csv file:{Environment.NewLine}{addressCsvPath}");
            else
                Console.WriteLine("\tFailed to write sorted address csv file");
        }

        private static void PrintNameFrequencies(List<NameCount> collection)
        {
            if (collection != null && collection.Any())
            {
                Console.WriteLine("Show the frequency of the first and last names ordered by frequency descending and then alphabetically ascending.");
                foreach (var item in collection)
                {
                    Console.WriteLine("{0} {1}", item.Name, item.TotalCount);
                }
            }
        }

        private static void PrintAddressFrequencies(List<string> collection)
        {
            Console.WriteLine(Environment.NewLine);
            if (collection != null && collection.Any())
            {
                Console.WriteLine("show the addresses sorted alphabetically by street name.");
                foreach (var address in collection)
                {
                    Console.WriteLine(address);
                }
            }
        }


    }
}

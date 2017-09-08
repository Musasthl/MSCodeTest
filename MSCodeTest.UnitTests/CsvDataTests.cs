// Author: Musa Simphiwe Sithole
// Email: Musasthl@yahoo.com
// Phone: 0837477313

using MSCodeTest.Common.Utilities;
using MSCodeTest.Data;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MSCodeTest.UnitTests
{
    [TestFixture]
    public class CsvDataTests
    {
        private List<Person> PersonList;
        [SetUp]
        public void SetUp()
        {
            PersonList = new List<Person>();
            PersonList.Add(new Person() { FirstName = "Clive", LastName = "Smith", Address = "49 Sutherland St", PhoneNumber = "31214788" });
            PersonList.Add(new Person() { FirstName = "Smith", LastName = "Brown", Address = "94 Roland St", PhoneNumber = "8766556" });
            PersonList.Add(new Person() { FirstName = "Jimmy", LastName = "Smith", Address = "102 Long Lane", PhoneNumber = "29384857" });
            PersonList.Add(new Person() { FirstName = "Clive", LastName = "Owen", Address = "65 Ambling Way", PhoneNumber = "31214788" });
            PersonList.Add(new Person() { FirstName = "Owen", LastName = "Martin", Address = "94 Roland St", PhoneNumber = "31214788" });
        }

        [Test]
        public void TestGetPersonNamesFrequencyCount()
        {
            var nameFrequencyList = WordFrequency.GetPersonNamesFrequency(PersonList);
            var nameData1 = nameFrequencyList.Single(x => x.Name == "Smith");
            var nameData2 = nameFrequencyList.Single(x => x.Name == "Jimmy");

            Assert.AreEqual(nameData1.Name, "Smith");
            Assert.AreEqual(nameData1.TotalCount, 3);

            Assert.AreEqual(nameData2.Name, "Jimmy");
            Assert.AreEqual(nameData2.TotalCount, 1);
        }

        [Test]
        public void TestGetPersonNamesFrequencySortedByCountDesc()
        {
            var nameFrequencyList = WordFrequency.GetPersonNamesFrequency(PersonList);
            var nameData1 = nameFrequencyList[0];
            var nameData2 = nameFrequencyList[1];

            Assert.AreEqual(nameData1.Name, "Smith");
            Assert.AreEqual(nameData1.TotalCount, 3);

            Assert.AreEqual(nameData2.Name, "Clive");
            Assert.AreEqual(nameData2.TotalCount, 2);
        }

        [Test]
        public void TestGetPersonNamesFrequencySortedByCountNameDesc()
        {
            var nameFrequencyList = WordFrequency.GetPersonNamesFrequency(PersonList);
            var nameData1 = nameFrequencyList[0];
            var nameData2 = nameFrequencyList[1];
            var nameData3 = nameFrequencyList[2];

            Assert.AreEqual(nameData1.Name, "Smith");
            Assert.AreEqual(nameData1.TotalCount, 3);

            Assert.AreEqual(nameData2.Name, "Clive");
            Assert.AreEqual(nameData2.TotalCount, 2);

            Assert.AreEqual(nameData3.Name, "Owen");
            Assert.AreEqual(nameData3.TotalCount, 2);
        }

        [Test]
        public void TestGetAddressAlphabatically()
        {
            var addressSortedList = WordFrequency.GetAddressAlphabatically(PersonList);
            var addressData1 = addressSortedList[0];
            var addressData2 = addressSortedList[1];

            Assert.AreEqual(addressData1, "65 Ambling Way");
            Assert.AreEqual(addressData2, "102 Long Lane");
        }

        [Test]
        public void TestExtractAddressName()
        {
            var address = WordFrequency.ExtractAddressName("65 Ambling Way");
            Assert.AreEqual(address, "Ambling Way");
        }
    }
}

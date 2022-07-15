using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Exam_C.Tests
{
    [TestClass]
    public class Final_Exam_C
    {
        private readonly CountryServiceSoap.CountryInfoServiceSoapTypeClient countrySoap =
            new CountryServiceSoap.CountryInfoServiceSoapTypeClient(CountryServiceSoap.CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);

        static readonly Random rnd = new Random();

        private List<CountryServiceSoap.tCountryCodeAndName> ListOfCountryNamesByCode()
        {
            var listOfCountryCodeAndName = countrySoap.ListOfCountryNamesByCode().ToList();
            return listOfCountryCodeAndName;
        }

        private CountryServiceSoap.tCountryCodeAndName GetRandomCountryRecord(List<CountryServiceSoap.tCountryCodeAndName> listOfCountryCodeAndName)
        {
            int rndIndex = rnd.Next(listOfCountryCodeAndName.Count);
            var rndCountryCodeAndName = listOfCountryCodeAndName[rndIndex];
            return rndCountryCodeAndName;
        }

        //SOAP Problem 1
        [TestMethod]
        public void VerifyFullCountryInfo()
        {
            //Generate List of Countries
            var countryList = ListOfCountryNamesByCode();

            //Get random record from list
            var rndCountryRecord = GetRandomCountryRecord(countryList);

            var soapFullCountryInfo = countrySoap.FullCountryInfo(rndCountryRecord.sISOCode);

            //Assertion to verify FullCountryInfo endpoint
            Assert.AreEqual(rndCountryRecord.sISOCode, soapFullCountryInfo.sISOCode);
            Assert.AreEqual(rndCountryRecord.sName, soapFullCountryInfo.sName);
        }

        //SOAP Problem 2
        [TestMethod]
        public void VerifyCountryISOCode()
        {
            //Generate List of Countries
            var countryList = ListOfCountryNamesByCode();

            List<int> lstIndex = new List<int>();

            //Call 5 country records
            for(int i = 0; i < 5; i++)
            {
                int rndIndex = rnd.Next(countryList.Count);

                //Prevents duplicate
                if(lstIndex.Contains(rndIndex))
                {
                    rndIndex = rnd.Next(countryList.Count);
                }
                var rndCountryRecord = countryList[rndIndex];
                
                var soapCountryISOCode = countrySoap.CountryISOCode(rndCountryRecord.sName);
                //Assertion to verify VerifyCountryISOCode endpoint
                Assert.AreEqual(rndCountryRecord.sISOCode, soapCountryISOCode);
                lstIndex.Add(rndIndex);
            }
        }
    }
}

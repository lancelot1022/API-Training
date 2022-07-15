using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Session_4_HW
{
    [TestClass]
    public class Session_4_HW
    {
        private readonly CountryServiceSoap.CountryInfoServiceSoapTypeClient listCountryCode =
            new CountryServiceSoap.CountryInfoServiceSoapTypeClient(CountryServiceSoap.CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);

        //Test method 1
        [TestMethod]
        public void VerifyListOfCountryCode()
        {
            var soapResponse = listCountryCode.ListOfCountryNamesByCode();

            //Create a list of country codes sorted as expected result
            List<string> sortedCountryCode = new List<string>();
            for (int i = 0; i < soapResponse.Length; i++)
            {
                sortedCountryCode.Add(soapResponse[i].sISOCode);
            }
            sortedCountryCode.Sort();

            //Compare expected result and original soap response country code array
            for (int i = 0; i < soapResponse.Length; i++)
            {
                Assert.AreEqual(sortedCountryCode[i], soapResponse[i].sISOCode);
            }
        }

        //Test method 2
        [TestMethod]
        public void VerifyInvalidCountryCode()
        {
            var invalidCountryCode = "LZ";
            var soapResponse = listCountryCode.CountryName(invalidCountryCode);

            Assert.AreEqual("Country not found in the database", soapResponse);
        }

        //Test method 3
        [TestMethod]
        public void VerifyCountryNameByCode()
        {
            var listCountries = listCountryCode.ListOfCountryNamesByCode();
            var lastCountryCode = listCountries.Last();

            var soapVerifyCountry = listCountryCode.CountryName(lastCountryCode.sISOCode);

            Assert.AreEqual("Zimbabwe", soapVerifyCountry);
        }
    }
}

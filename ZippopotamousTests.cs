using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;


namespace DataDrivenTestForZippopotamus.us
{
    public class ZippopotamousTests
    {
        [TestCase("BG", "1000", "Sofija")]
        [TestCase("BG", "5000", "Veliko Turnovo")]
        [TestCase("CA", "M5S", "Toronto")]
        [TestCase("GB", "B1", "Birmingham")]
        [TestCase("DE", "01067", "Dresden")]
            public void TestZippopotamous(string countryCode, string zipCode, string expectedPlace)
            {
                //Arrange
                var restClient = new RestClient("https://api.zippopotam.us");
                var httpRequest = new RestRequest(countryCode + "/" + zipCode);

                //Act
                var httpResponse = restClient.Execute(httpRequest);
                var location = new JsonDeserializer().Deserialize<Location>(httpResponse);
                //Assert
                StringAssert.Contains(expectedPlace, location.Places[0].PlaceName);
                //Assert.That(location.Places[0].PlaceName.Contains(expectedPlace));
            }        
    }
}

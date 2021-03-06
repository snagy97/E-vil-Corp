using Xunit;
using EvilClient.ViewModels;
using System.Net.Http;
using System.Security.Cryptography;

namespace EvilClient.Tests
{
    public class UtilViewModelTests
    {
        private readonly HttpClient httpClient;
        private IUtilViewModel util;
        private readonly string password = "password";
        private string passwordHashedMD5 = "5f4dcc3b5aa765d61d8327deb882cf99";
        private string passwordHashedSHA256 = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8";

        public UtilViewModelTests()
        {
            httpClient = new HttpClient();
            // navigationManager.Setup(nm => nm.BaseUri).Returns("");

            util = new UtilViewModel(httpClient);
        }

        [Fact]
        public void Given_password_hashed_StringToHash_with_algorithm_return_the_same()
        {
            //When
            var actualMD5Hashed = util.StringToHash(password, MD5.Create());

            //Then
            Assert.Equal(passwordHashedMD5, actualMD5Hashed);
        }

        [Fact]
        public void Given_password_hashed_StringToHash_with_SHA256_return_the_same()
        {
            //When
            var actualMD5Hashed = util.StringToHash(password, SHA256.Create());

            //Then
            Assert.Equal(passwordHashedSHA256, actualMD5Hashed);
        }

        [Theory]
        [InlineData("password", "5f4dcc3b5aa765d61d8327deb882cf99", true)]
        [InlineData("password1", "5f4dcc3b5aa765d61d8327deb882cf99", false)]
        [InlineData("password", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", true)]
        [InlineData("password1", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", false)]
        public void TestName(string passwordGiven, string hashedPassword, bool expectedBoolOutcome)
        {
            //When
            var actualBoolOutput = util.DoesPasswordMatch(passwordGiven, passwordHashedMD5);

            //Then
            Assert.Equal(expectedBoolOutcome, actualBoolOutput);
        }
    }
}

using System.Collections.Generic;
using System.Security.Cryptography;
using Minitwit.Entities;

namespace EvilClient.ViewModels
{
    public interface IUtilViewModel
    {
        IEnumerable<string> FlashedMessages { get; set; }
        IEnumerable<UserMessageDTO> UserMessageDTO { get; set; }
        string URL { get; }
        string APIURL { get; }

        string StringToHash(string toBeHashed, HashAlgorithm algorithm);

        string CurrentPasswordHasher(string passwordToBeHashed);

        bool DoesPasswordMatch(string passwordGiven, string passwordExpected);

        string UrlFor(string name);

        string UrlForUser(string username);

        string UrlForUnfollow(string username);

        string UrlForFollow(string username);

        string GravatarUrl(string email, int size=80);
    }
}
using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using static System.Net.HttpStatusCode;

using Minitwit.Entities;
using Repos;

namespace DB.Tests
{
    public class ReposTest : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly MinitwitContext _context;
        private readonly UserRepository _userRepo;
        private readonly FollowerRepository _followerRepo;

        public ReposTest()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            var builder = new DbContextOptionsBuilder<MinitwitContext>().UseSqlite(_connection);
            _context = new DBTestContext(builder.Options);
            _context.Database.EnsureCreated();
            _userRepo = new UserRepository(_context);
            _followerRepo = new FollowerRepository(_context);
        }

        [Fact]
        public void Given_userid_returns_user()
        {
            var username = "user1";
            var userid = 1;

            var user = _userRepo.GetUserFromID(userid);

            Assert.Equal(username, user.username);
        }

        [Fact]
        public void Given_Username_returns_userID()
        {
            var userID = _userRepo.GetUserIDFromUsername("user1");

            Assert.Equal(1, userID);
        }

        [Fact]
        public void Given_wrong_username_returns_negative()
        {
            var userID = _userRepo.GetUserIDFromUsername("foo");

            Assert.Equal(-1, userID);
        }

        [Fact]
        public void Given_new_user_AddUser_returns_Created()
        {
            var newUser = new User {
                username = "mock",
                email = "test@mail.com",
                pw_hash = "some_hash"
            };

            var statusCode = _userRepo.AddUser(newUser);
            var insertedUser = _userRepo.GetUserFromID(newUser.user_id);

            Assert.Equal(NoContent, statusCode);
            Assert.Equal(newUser, insertedUser);
        }


        // tests for followerrepo .. yeah i know i know, should have had a test class to itself but what the hell

        [Fact]
        public void Given_usernames_to_FollowUser_return_NoContent()
        {
            var usernameInSession = "user3";
            var usernameToFollow = "user4";

            var statusCode = _followerRepo.FollowUser(usernameInSession, usernameToFollow);

            Assert.Equal(NoContent, statusCode);
        }

        [Fact]
        public void Given_invalid_username_to_FollowUser_returns_NotFound()
        {
            var usernameInSession = "I don't exist";
            var usernameToFollow = "user2";

            var statusCode = _followerRepo.FollowUser(usernameInSession, usernameToFollow);

            Assert.Equal(NotAcceptable, statusCode);
        }

        [Fact]
        public void Given_existing_followers_to_FollowerUser_returns_NotAcceptable()
        {
            var usernameInSession = "user1";
            var usernameToFollow = "user2"; // these already exists, check the DBTestContext.cs

            var statusCode = _followerRepo.FollowUser(usernameInSession, usernameToFollow);

            Assert.Equal(NotAcceptable, statusCode);
        }

        [Fact]
        public void Given_usernames_to_UnfollowUser_returns_NoContent()
        {
            var usernameInSession = "user1";
            var usernameToUnfollow = "user2";

            var statusCode = _followerRepo.UnfollowUser(usernameInSession, usernameToUnfollow);

            Assert.Equal(NoContent, statusCode);
        }



        public void Dispose()
        {
            _context.Dispose();
            _connection.Dispose();
        }
    }
}
using System;
using Xunit;
using Bunit;
using Bunit.TestDoubles;
using static Bunit.ComponentParameterFactory;
using Quorum.Pages;
using Quorum.Shared;
using Ganss.XSS;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using QuorumDB;
using QuorumDB.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QuorumUnit
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.egilhansen.com/docs/
    /// </summary>
    public class UserTests : TestContext
    {

        [Fact]
        public void CheckIfUserOnList()
        {
            var UserDataMock = new Mock<IUserData>();

            string UserID = "3";
            string UserName = "testUser";

            AspNetUser testUser = new AspNetUser();
            testUser.Id = UserID;
            testUser.UserName = UserName;

            List<AspNetUser> UserList = new List<AspNetUser>();

            UserList.Add(testUser);

            //// Arrange
            UserDataMock.Setup(_udata => _udata.GetUsers()).ReturnsAsync(UserList);
            Services.AddSingleton<IUserData>(UserDataMock.Object);

            //List<AspNetUser> TestList = await ForumDataMock.Object.GetForumsByParentId(ForumID);
            //// Assert
            var cut = RenderComponent<UserTable>();
            cut.MarkupMatches("<table class=\"table\"><thead><tr><th>Users</th></tr></thead><tbody><tr><td>testUser</td></tr></tbody></table>");
            
            //Assert.Equal(ForumList, TestList);

        }

        [Fact]
        public void CheckIfNoUsersOnList()
        {
            var UserDataMock = new Mock<IUserData>();

            string UserID = "3";
            string UserName = "testUser";

            AspNetUser testUser = new AspNetUser();
            testUser.Id = UserID;
            testUser.UserName = UserName;

            List<AspNetUser> UserList = new List<AspNetUser>();

            //// Arrange
            UserDataMock.Setup(_udata => _udata.GetUsers()).ReturnsAsync(UserList);
            Services.AddSingleton<IUserData>(UserDataMock.Object);

            //List<AspNetUser> TestList = await ForumDataMock.Object.GetForumsByParentId(ForumID);
            //// Assert
            var cut = RenderComponent<UserTable>();
            cut.MarkupMatches("<table class=\"table\"><thead><tr><th>Users</th></tr></thead><tbody></tbody></table>");

            //Assert.Equal(ForumList, TestList);

        }
    }
}

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
    public class ForumTests : TestContext
    {

        [Fact]
        public async void CheckIfForumUnderForumID()
        {
            var ForumDataMock = new Mock<IForumData>();

            int ForumID = 3;
            string ForumName = "testForum";

            Forum testForum = new Forum();
            testForum.ForumId = ForumID;
            testForum.Title = ForumName;

            List<Forum> ForumList = new List<Forum>();

            ForumList.Add(testForum);
            //string pladsf = ForumList[0].Title;
            //// Arrange
            ForumDataMock.Setup(_fdata => _fdata.GetForumsByParentId(ForumID)).ReturnsAsync(ForumList);
            Services.AddSingleton<IForumData>(ForumDataMock.Object);

            List<Forum> TestList = await ForumDataMock.Object.GetForumsByParentId(ForumID);
            //// Assert
            var cut = RenderComponent<ForumTable>();
            cut.MarkupMatches("<table class=\"table\"><thead><tr><th>Quorums</th></tr></thead><tbody><tr><td>testForum</td></tr></tbody></table>");
            
            //Assert.Equal(ForumList, TestList);

        }
    }
}

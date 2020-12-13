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
    public class ThreadTests : TestContext
    {

        [Fact]
        public void CheckIfThreadOnList()
        {
            var ThreadDataMock = new Mock<IThreadData>();

            int ThreadID = 1;
            string ThreadName = "testThread";

            ForumThread testThread = new ForumThread();
            testThread.Id = ThreadID;
            testThread.Title = ThreadName;

            List<ForumThread> ThreadList = new List<ForumThread>();

            ThreadList.Add(testThread);

            //// Arrange
            ThreadDataMock.Setup(_udata => _udata.GetForumThreads()).ReturnsAsync(ThreadList);
            Services.AddSingleton<IThreadData>(ThreadDataMock.Object);

            //List<Thread> TestList = await ForumDataMock.Object.GetForumsByParentId(ForumID);
            //// Assert
            var cut = RenderComponent<ThreadTable>();
            cut.MarkupMatches("<table class=\"table\"><thead><tr><th>Threads</th></tr></thead><tbody><tr><td>testThread</td></tr></tbody></table>");
            
            //Assert.Equal(ForumList, TestList);

        }

        [Fact]
        public void CheckIfNoThreadsOnList()
        {
            var ThreadDataMock = new Mock<IThreadData>();

            int ThreadID = 1;
            string ThreadName = "testThread";

            ForumThread testThread = new ForumThread();
            testThread.Id = ThreadID;
            testThread.Title = ThreadName;

            List<ForumThread> ThreadList = new List<ForumThread>();

            //// Arrange
            ThreadDataMock.Setup(_udata => _udata.GetForumThreads()).ReturnsAsync(ThreadList);
            Services.AddSingleton<IThreadData>(ThreadDataMock.Object);

            //List<Thread> TestList = await ForumDataMock.Object.GetForumsByParentId(ForumID);
            //// Assert
            var cut = RenderComponent<ThreadTable>();
            cut.MarkupMatches("<table class=\"table\"><thead><tr><th>Threads</th></tr></thead><tbody></tbody></table>");

            //Assert.Equal(ForumList, TestList);

        }
    }
}

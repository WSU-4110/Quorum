using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuorumDB.Models;
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
namespace QuorumUnit
{
    public class SearchTests : TestContext
    {
        [Fact]
        public void NoSearchResultsTest()
        {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "none";
            
            List<Forum> forumList = new List<Forum>();
            List<ForumThread> threadList = new List<ForumThread>();

            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);

            
            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));
            
            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'><div class='row'><div class='column'><table class='table'>" +
                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody><tr><td>No Quorums Found</td></tr></tbody></table><ul class='list-group list-group-horizontal'>" +
                "</ul><table class='table'><thead><tr><th>Threads</th></tr></thead><tbody><tr><td>No Threads Found</td>" +
                "</tr></tbody></table><ul class='list-group list-group-horizontal'></ul></div></div></div>");
        }

        [Fact]
        public void SingleForumSearchResultTest()
        {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "testForum";
            
            List<Forum> forumList = new List<Forum>();          
            Forum forum = new Forum() { Title = "testForum1", Url = "testUrl" };           
            forumList.Add(forum);
            
            List<ForumThread> threadList = new List<ForumThread>();

            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);

            
            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));
            
            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'><div class='row'><div class='column'><table class='table'>" +
                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody><tr><td><a href='testUrl'>testForum1</a></td></tr></tbody></table>" +
                "<ul class='list-group list-group-horizontal'><li id='forumsearchpagination' class='list-group-item'><b>1</b></li>" +
                "</ul><table class='table'><thead><tr><th>Threads</th></tr></thead><tbody><tr><td>No Threads Found</td>" +
                "</tr></tbody></table><ul class='list-group list-group-horizontal'></ul></div></div></div>");
        }

        [Fact]
        public void MultipleForumsSearchResultTest()
        {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "testForum";
            
            List<Forum> forumList = new List<Forum>();            
            Forum forum1 = new Forum() { Title = "testForum1", Url = "testUrl1" };
            Forum forum2 = new Forum() { Title = "testForum2", Url = "testUrl2" };
            Forum forum3 = new Forum() { Title = "testForum3", Url = "testUrl3" };           
            forumList.Add(forum1);
            forumList.Add(forum2);
            forumList.Add(forum3);

            List<ForumThread> threadList = new List<ForumThread>();

            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);

            
            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));
            
            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'><div class='row'><div class='column'><table class='table'>" +
                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody><tr><td><a href='testUrl1'>testForum1</a></td></tr>" +
                "<tr><td><a href='testUrl2'>testForum2</a></td></tr><tr><td><a href='testUrl3'>testForum3</a></td></tr></tbody></table>" +
                "<ul class='list-group list-group-horizontal'><li id='forumsearchpagination' class='list-group-item'><b>1</b></li>" +
                "</ul><table class='table'><thead><tr><th>Threads</th></tr></thead><tbody><tr><td>No Threads Found</td>" +
                "</tr></tbody></table><ul class='list-group list-group-horizontal'></ul></div></div></div>");
        }

        [Fact]
        public void SingleThreadSearchResultTest()
        {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "testThread";
            
            List<Forum> forumList = new List<Forum>();
            
            List<ForumThread> threadList = new List<ForumThread>();    
            ForumThread thread = new ForumThread() { Id = 1, Title = "testThread1", ViewCount = 5 };
            threadList.Add(thread);

            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);

            
            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));
            
            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'><div class='row'><div class='column'><table class='table'>" +
                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody><tr><td>No Quorums Found</td></tr></tbody></table><ul class='list-group list-group-horizontal'>" +
                "</ul><table class='table'><thead><tr><th>Threads</th></tr></thead><tbody><tr><td><a href='/p/1'>testThread1</a>" +
                "<div class='float-right'><span class='oi oi-eye'></span> 5</div></td></tr></tbody></table>" +
                "<ul class='list-group list-group-horizontal'><li id='threadsearchpagination' class='list-group-item'><b>1</b></li></ul></div></div></div>");
        }

        [Fact]
        public void MultipleThreadSearchResultTest()
        {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "testThread";

            List<Forum> forumList = new List<Forum>();

            List<ForumThread> threadList = new List<ForumThread>();
            ForumThread thread1 = new ForumThread() { Id = 1, Title = "testThread1", ViewCount = 5 };
            ForumThread thread2 = new ForumThread() { Id = 2, Title = "testThread2", ViewCount = 1 };
            ForumThread thread3 = new ForumThread() { Id = 3, Title = "testThread3", ViewCount = 10 };
            threadList.Add(thread1);
            threadList.Add(thread2);
            threadList.Add(thread3);

            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);


            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));

            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'><div class='row'><div class='column'><table class='table'>" +
                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody><tr><td>No Quorums Found</td></tr></tbody></table><ul class='list-group list-group-horizontal'>" +
                "</ul><table class='table'><thead><tr><th>Threads</th></tr></thead><tbody>" +
                "<tr><td><a href='/p/1'>testThread1</a><div class='float-right'><span class='oi oi-eye'></span> 5</div></td></tr>" +
                "<tr><td><a href='/p/2'>testThread2</a><div class='float-right'><span class='oi oi-eye'></span> 1</div></td></tr>" +
                "<tr><td><a href='/p/3'>testThread3</a><div class='float-right'><span class='oi oi-eye'></span> 10</div></td></tr>" +
                "</tbody></table>" +
                "<ul class='list-group list-group-horizontal'><li id='threadsearchpagination' class='list-group-item'><b>1</b></li></ul></div></div></div>");
        }

        [Fact]
        public void SingleForumAndSingleThreadSearchResultTest()
        {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "testForum";

            List<Forum> forumList = new List<Forum>();
            Forum forum = new Forum() { Title = "testForum1", Url = "testUrl" };
            forumList.Add(forum);

            List<ForumThread> threadList = new List<ForumThread>();
            ForumThread thread = new ForumThread() { Id = 1, Title = "testThread1", ViewCount = 5 };
            threadList.Add(thread);

            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);


            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));

            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'><div class='row'><div class='column'><table class='table'>" +
                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody><tr><td><a href='testUrl'>testForum1</a></td></tr></tbody></table>" +
                "<ul class='list-group list-group-horizontal'><li id='forumsearchpagination' class='list-group-item'><b>1</b></li>" +
                "</ul><table class='table'><thead><tr><th>Threads</th></tr></thead><tbody><tr><td><a href='/p/1'>testThread1</a>" +
                "<div class='float-right'><span class='oi oi-eye'></span> 5</div></td>" +
                "</tr></tbody></table><ul class='list-group list-group-horizontal'><li id='threadsearchpagination' class='list-group-item'><b>1</b></li>" +
                "</ul></div></div></div>");
        }
    }
}

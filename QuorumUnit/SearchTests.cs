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

        [Fact]
        public void MultipleThreadsAndForumsSearchResultTest()
        {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "test";

            List<Forum> forumList = new List<Forum>();
            Forum forum1 = new Forum() { Title = "testForum1", Url = "testUrl" };
            Forum forum2 = new Forum() { Title = "testForum2", Url = "testUrl" };
            forumList.Add(forum1);
            forumList.Add(forum2);


            List<ForumThread> threadList = new List<ForumThread>();
            ForumThread thread1 = new ForumThread() { Id = 1, Title = "testThread1", ViewCount = 5 };
            ForumThread thread2 = new ForumThread() { Id = 2, Title = "testThread2", ViewCount = 7 };
            threadList.Add(thread1);
            threadList.Add(thread2);

            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);


            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));

            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'><div class='row'><div class='column'><table class='table'>" +
                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody><tr><td><a href='testUrl'>testForum1</a></td></tr><tr><td><a href='testUrl'>testForum2</a></td></tr></tbody></table>" +
                "<ul class='list-group list-group-horizontal'><li id='forumsearchpagination' class='list-group-item'><b>1</b></li>" +
                "</ul><table class='table'><thead><tr><th>Threads</th></tr></thead><tbody><tr><td><a href='/p/1'>testThread1</a>" +
                "<div class='float-right'><span class='oi oi-eye'></span> 5</div></td>" +
                "</tr><tr><td><a href='/p/2'>testThread2</a>" +
                "<div class='float-right'><span class='oi oi-eye'></span> 7</div></td>" +
                "</tr></tbody></table><ul class='list-group list-group-horizontal'><li id='threadsearchpagination' class='list-group-item'><b>1</b></li>" +
                "</ul></div></div></div>");
        }

        [Fact]
        public void TwoPagePaginationForThreads() {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "testThread";

            List<Forum> forumList = new List<Forum>();

            List<ForumThread> threadList = new List<ForumThread>();
            ForumThread thread1 = new ForumThread() { Id = 1, Title = "testThread1", ViewCount = 5 };
            ForumThread thread2 = new ForumThread() { Id = 2, Title = "testThread2", ViewCount = 5 };
            ForumThread thread3 = new ForumThread() { Id = 3, Title = "testThread3", ViewCount = 5 };
            ForumThread thread4 = new ForumThread() { Id = 4, Title = "testThread4", ViewCount = 5 };
            ForumThread thread5 = new ForumThread() { Id = 5, Title = "testThread5", ViewCount = 5 };
            ForumThread thread6 = new ForumThread() { Id = 6, Title = "testThread6", ViewCount = 5 };
            ForumThread thread7 = new ForumThread() { Id = 7, Title = "testThread7", ViewCount = 5 };
            ForumThread thread8 = new ForumThread() { Id = 8, Title = "testThread8", ViewCount = 5 };
            ForumThread thread9 = new ForumThread() { Id = 9, Title = "testThread9", ViewCount = 5 };
            ForumThread thread10 = new ForumThread() { Id = 10, Title = "testThread10", ViewCount = 5 };
            ForumThread thread11 = new ForumThread() { Id = 11, Title = "testThread11", ViewCount = 5 };
            threadList.Add(thread1);
            threadList.Add(thread2);
            threadList.Add(thread3);
            threadList.Add(thread4);
            threadList.Add(thread5);
            threadList.Add(thread6);
            threadList.Add(thread7);
            threadList.Add(thread8);
            threadList.Add(thread9);
            threadList.Add(thread10);
            threadList.Add(thread11);


            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);


            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));

            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'>" +
                                "<div class='row'><div class='column'><table class='table'>" +
                                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody><tr><td>No Quorums Found</td>" +
                                "</tr></tbody></table><ul class='list-group list-group-horizontal'></ul>" +
                                "<table class='table'><thead><tr><th>Threads</th></tr></thead><tbody>" +
                                "<tr><td><a href ='/p/1'>testThread1</a><div class='float-right'>" +
                                "<span class='oi oi-eye'></span>5</div></td></tr><tr><td><a href='/p/2'>testThread2</a>" +
                                "<div class='float-right'><span class='oi oi-eye'></span>5</div></td></tr><tr>" +
                                "<td><a href='/p/3'>testThread3</a><div class='float-right'>" +
                                "<span class='oi oi-eye'></span>5</div></td></tr><tr><td><a href='/p/4'>testThread4</a>" +
                                "<div class='float-right'><span class='oi oi-eye'></span>5</div></td></tr>" +
                                "<tr><td><a href='/p/5'>testThread5</a><div class='float-right'>" +
                                "<span class='oi oi-eye'></span>5</div></td></tr><tr><td>" +
                                "<a href='/p/6'>testThread6</a><div class='float-right'><span class='oi oi-eye'></span>" +
                                "5</div></td></tr><tr><td><a href='/p/7'>testThread7</a><div class='float-right'>" +
                                "<span class='oi oi-eye'></span>5</div></td></tr><tr><td><a href='/p/8'>testThread8</a>" +
                                "<div class='float-right'><span class='oi oi-eye'></span>5</div></td></tr>" +
                                "<tr><td><a href='/p/9'>testThread9</a><div class='float-right'>" +
                                "<span class='oi oi-eye'></span>5</div></td></tr><tr><td>" +
                                "<a href='/p/10'>testThread10</a><div class='float-right'><span class='oi oi-eye'></span>" +
                                "5</div></td></tr></tbody></table><ul class='list-group list-group-horizontal'>" +
                                "<li id='threadsearchpagination' class='list-group-item'><b>1</b></li>" +
                                "<li id='threadsearchpagination' class='list-group-item'>" +
                                "<button type='button' class='pagbutton'>2</button></li>" +
                                "<li id='threadsearchpagination' class='list-group-item'>" +
                                "<button type='button' class='pagbutton'>Next</button></li></ul></div></div></div>");
        }

        [Fact]
        public void TwoPagePaginationForForums() {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "testThread";

            List<ForumThread> threadList = new List<ForumThread>();

            List<Forum> forumList = new List<Forum>();
            Forum forum1 = new Forum() { Title = "testForum1", Url = "testUrl1" };
            Forum forum2 = new Forum() { Title = "testForum2", Url = "testUrl2" };
            Forum forum3 = new Forum() { Title = "testForum3", Url = "testUrl3" };
            Forum forum4 = new Forum() { Title = "testForum4", Url = "testUrl4" };
            Forum forum5 = new Forum() { Title = "testForum5", Url = "testUrl5" };
            Forum forum6 = new Forum() { Title = "testForum6", Url = "testUrl6" };
            Forum forum7 = new Forum() { Title = "testForum7", Url = "testUrl7" };
            Forum forum8 = new Forum() { Title = "testForum8", Url = "testUrl8" };
            Forum forum9 = new Forum() { Title = "testForum9", Url = "testUrl9" };
            Forum forum10 = new Forum() { Title = "testForum10", Url = "testUrl10" };
            Forum forum11 = new Forum() { Title = "testForum11", Url = "testUrl11" };
            forumList.Add(forum1);
            forumList.Add(forum2);
            forumList.Add(forum3);
            forumList.Add(forum4);
            forumList.Add(forum5);
            forumList.Add(forum6);
            forumList.Add(forum7);
            forumList.Add(forum8);
            forumList.Add(forum9);
            forumList.Add(forum10);
            forumList.Add(forum11);

            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);


            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));

            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'>" +
                                "<div class='row'><div class='column'><table class='table'>" +
                                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody>" +
                                "<tr><td><a href='testUrl1'>testForum1</a></td></tr>" +
                                "<tr><td><a href='testUrl2'>testForum2</a></td></tr>" +
                                "<tr><td><a href='testUrl3'>testForum3</a></td></tr>" +
                                "<tr><td><a href='testUrl4'>testForum4</a></td></tr>" +
                                "<tr><td><a href='testUrl5'>testForum5</a></td></tr>" +
                                "<tr><td><a href='testUrl6'>testForum6</a></td></tr>" +
                                "<tr><td><a href='testUrl7'>testForum7</a></td></tr>" +
                                "<tr><td><a href='testUrl8'>testForum8</a></td></tr>" +
                                "<tr><td><a href='testUrl9'>testForum9</a></td></tr>" +
                                "<tr><td><a href='testUrl10'>testForum10</a></td></tr>" +
                                "</tbody></table>" +
                                "<ul class='list-group list-group-horizontal'>" + 
                                "<li id='forumsearchpagination' class='list-group-item'>" +	
                                "<b>1</b></li>" +
                                "<li id='forumsearchpagination' class='list-group-item'><button type='button' class='pagbutton'>2</button>" +	
                                "</li><li id='forumsearchpagination' class='list-group-item'><button type='button' class='pagbutton'>Next</button>" +
                                "</li></ul>" +
                                "<table class='table'><thead><tr><th>Threads</th></tr></thead><tbody><tr><td>No Threads Found</td></tr>" +
                                "</tbody></table><ul class='list-group list-group-horizontal'></ul></div></div></div>");
        }

        [Fact]
        public void MultipleThreadSingleForum() {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "test";

            List<Forum> forumList = new List<Forum>();
            Forum forum1 = new Forum() { Title = "testForum1", Url = "testUrl" };
            forumList.Add(forum1);


            List<ForumThread> threadList = new List<ForumThread>();
            ForumThread thread1 = new ForumThread() { Id = 1, Title = "testThread1", ViewCount = 5 };
            ForumThread thread2 = new ForumThread() { Id = 2, Title = "testThread2", ViewCount = 7 };
            threadList.Add(thread1);
            threadList.Add(thread2);

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
                "</tr><tr><td><a href='/p/2'>testThread2</a>" +
                "<div class='float-right'><span class='oi oi-eye'></span> 7</div></td>" +
                "</tr></tbody></table><ul class='list-group list-group-horizontal'><li id='threadsearchpagination' class='list-group-item'><b>1</b></li>" +
                "</ul></div></div></div>");
        }

        [Fact]
        public void MultipleForumSingleThread() {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "test";

            List<Forum> forumList = new List<Forum>();
            Forum forum1 = new Forum() { Title = "testForum1", Url = "testUrl" };
            Forum forum2 = new Forum() { Title = "testForum2", Url = "testUrl" };
            forumList.Add(forum1);
            forumList.Add(forum2);


            List<ForumThread> threadList = new List<ForumThread>();
            ForumThread thread1 = new ForumThread() { Id = 1, Title = "testThread1", ViewCount = 5 };
            threadList.Add(thread1);

            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);


            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));

            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'><div class='row'><div class='column'><table class='table'>" +
                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody><tr><td><a href='testUrl'>testForum1</a></td></tr><tr><td><a href='testUrl'>testForum2</a></td></tr></tbody></table>" +
                "<ul class='list-group list-group-horizontal'><li id='forumsearchpagination' class='list-group-item'><b>1</b></li>" +
                "</ul><table class='table'><thead><tr><th>Threads</th></tr></thead><tbody><tr><td><a href='/p/1'>testThread1</a>" +
                "<div class='float-right'><span class='oi oi-eye'></span> 5</div></td>" +
                "</tr></tbody></table><ul class='list-group list-group-horizontal'><li id='threadsearchpagination' class='list-group-item'><b>1</b></li>" +
                "</ul></div></div></div>");
        }

        [Fact]
        public void TenForums() {
            var SearchDataMock = new Mock<ISearchResults>();

            string query = "testThread";

            List<ForumThread> threadList = new List<ForumThread>();

            List<Forum> forumList = new List<Forum>();
            Forum forum1 = new Forum() { Title = "testForum1", Url = "testUrl1" };
            Forum forum2 = new Forum() { Title = "testForum2", Url = "testUrl2" };
            Forum forum3 = new Forum() { Title = "testForum3", Url = "testUrl3" };
            Forum forum4 = new Forum() { Title = "testForum4", Url = "testUrl4" };
            Forum forum5 = new Forum() { Title = "testForum5", Url = "testUrl5" };
            Forum forum6 = new Forum() { Title = "testForum6", Url = "testUrl6" };
            Forum forum7 = new Forum() { Title = "testForum7", Url = "testUrl7" };
            Forum forum8 = new Forum() { Title = "testForum8", Url = "testUrl8" };
            Forum forum9 = new Forum() { Title = "testForum9", Url = "testUrl9" };
            Forum forum10 = new Forum() { Title = "testForum10", Url = "testUrl10" };
            forumList.Add(forum1);
            forumList.Add(forum2);
            forumList.Add(forum3);
            forumList.Add(forum4);
            forumList.Add(forum5);
            forumList.Add(forum6);
            forumList.Add(forum7);
            forumList.Add(forum8);
            forumList.Add(forum9);
            forumList.Add(forum10);

            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByQuorum(query)).
                Returns(Task.FromResult(forumList));
            SearchDataMock.Setup(_sresults => _sresults.GetSearchResultsByPost(query)).
                Returns(Task.FromResult(threadList));

            Services.AddSingleton<ISearchResults>(SearchDataMock.Object);


            var cut = RenderComponent<SearchResultsPage>(Parameter("query", query), Parameter("forumPage", 1), Parameter("threadPage", 1));

            cut.MarkupMatches("<h3>Quorum Search Results</h3><div class='panel panel-default'>" +
                                "<div class='row'><div class='column'><table class='table'>" +
                                "<thead><tr><th>Sub-Quorums</th></tr></thead><tbody>" +
                                "<tr><td><a href='testUrl1'>testForum1</a></td></tr>" +
                                "<tr><td><a href='testUrl2'>testForum2</a></td></tr>" +
                                "<tr><td><a href='testUrl3'>testForum3</a></td></tr>" +
                                "<tr><td><a href='testUrl4'>testForum4</a></td></tr>" +
                                "<tr><td><a href='testUrl5'>testForum5</a></td></tr>" +
                                "<tr><td><a href='testUrl6'>testForum6</a></td></tr>" +
                                "<tr><td><a href='testUrl7'>testForum7</a></td></tr>" +
                                "<tr><td><a href='testUrl8'>testForum8</a></td></tr>" +
                                "<tr><td><a href='testUrl9'>testForum9</a></td></tr>" +
                                "<tr><td><a href='testUrl10'>testForum10</a></td></tr>" +
                                "</tbody></table>" +
                                "<ul class='list-group list-group-horizontal'><li id='forumsearchpagination' class='list-group-item'><b>1</b></li>" +
                                "</ul><table class='table'><thead><tr><th>Threads</th></tr></thead><tbody><tr><td>No Threads Found</td>" +
                                "</tr></tbody></table><ul class='list-group list-group-horizontal'></ul></div></div></div>");
        }
    }
}

using Bunit;
using Moq;
using QuorumDB;
using System;
using Quorum.Pages;
using Xunit;
using QuorumDB;
using QuorumDB.Models;
using Quorum.Services;
using Microsoft.AspNetCore.Components.Server.Circuits;
CircuitHandler _circuit;
IForumData _data;
IThreadData _tdata;
UserState _user;


namespace QuorumTest
{
    public class QuorumTest : TestContext
    {
        [Fact]
        public void Test1()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<Quorum.Pages.Index>();

            cut.MarkupMatches("<h1>Welcome</h1>");
        }

        [Fact]
        public void Test2()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<Quorum.Pages.Index>();

            cut.Find("button").Click();
            cut.MarkupMatches("<h3>Forum Creation Page</h3>");
        }
        [Fact]
        public void Test3()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<Quorum.Pages.Index>();

            cut.Find("table").MarkupMatches("<th>Quorums</th>");

        }

        [Fact]
        public void Test4()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<Quorum.Pages.Index>();

            cut.Find("table").MarkupMatches("<th>Recent Activity</th>");
        }

        [Fact]
        public void Test5()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<Quorum.Pages.Index>();

            cut.Find("table").MarkupMatches("<th>Top Threads</th>");
        }

        [Fact]
        public void Test6()
        {
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<Quorum.Pages.Index>();

            cut.MarkupMatches("<h3>Currently online:</h3>");
        }
    }
}

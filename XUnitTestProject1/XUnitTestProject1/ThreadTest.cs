using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using Quorum.Data;
using Quorum.Pages;
using Quorum.Services;
using QuorumDB;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class ForumPageTest
    {
        [Fact]
        public void ThreadPageTest1()
        {
            var navManagerMoq = new Mock<NavigationManager>();
            var authPolProviderMoq = new Mock<IAuthorizationPolicyProvider>();
            var dbContextMoq = new Mock<ApplicationDbContext>();
            var forumDataMoq = new Mock<IForumData>();
            var threadDataMoq = new Mock<IThreadData>();
            var replyDataMoq = new Mock<IReplyData>();
            var userStateMoq = new Mock<UserState>();
            var IJSRuntimeMoq = new Mock<IJSRuntime>();
            var userDataMoq = new Mock<IUserData>();

            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("Test User");
            authContext.SetPolicies("normal-user");
            authContext.SetRoles("user");

            ctx.Services.AddSingleton(navManagerMoq.Object);
            ctx.Services.AddSingleton(authPolProviderMoq.Object);
            ctx.Services.AddSingleton(dbContextMoq.Object);
            ctx.Services.AddSingleton(forumDataMoq.Object);
            ctx.Services.AddSingleton(threadDataMoq.Object);
            ctx.Services.AddSingleton(replyDataMoq.Object);
            ctx.Services.AddSingleton(userStateMoq.Object);
            ctx.Services.AddSingleton(IJSRuntimeMoq.Object);
            ctx.Services.AddSingleton(userDataMoq.Object);

            var cut = ctx.RenderComponent<Thread>();

            
        }
    }
}

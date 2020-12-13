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

namespace QuorumUnit
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.egilhansen.com/docs/
    /// </summary>
    public class AvatarTests : TestContext
    {
        [Fact]
        public void CheckAvatarWithUploadedPicture()
        {
            var UserDataMock = new Mock<IUserData>();

            string userName = "khalid4747";

            //// Arrange
            UserDataMock.Setup(_udata => _udata.GetUserAvatar(userName)).
                ReturnsAsync("Photos/khalid4747-20201123-070821.jpeg");

            Services.AddSingleton<IUserData>(UserDataMock.Object);

            // Assert that it removes the script and text
            var cut = RenderComponent<Avatar>(Parameter("UserName", userName));
            //Escaped component
            cut.MarkupMatches("<div class=\"avatar-icon\"><img src=\"Photos/khalid4747-20201123-070821.jpeg\" class=\"rounded-circle\" id=\"avatar-icon\" width=\"48\" height=\"48\"></div>");
        }

        [Fact]
        public void CheckAvatarWithoutUploadedPicture()
        {
            var UserDataMock = new Mock<IUserData>();

            string userName = "khalid4747";

            //// Arrange
            UserDataMock.Setup(_udata => _udata.GetUserAvatar(userName)).
                ReturnsAsync("");

            Services.AddSingleton<IUserData>(UserDataMock.Object);

            // Assert that it removes the script and text
            var cut = RenderComponent<Avatar>(Parameter("UserName", userName));
            //Escaped component
            cut.MarkupMatches("<div class=\"avatar-icon\"><span class=\"text-avatar\" id=\"avatar-icon\" width=\"48\" height=\"48\">K</span></div>");
        }

        [Fact]
        public void CheckAvatarWhenPhotoPicture()
        {
            var UserDataMock = new Mock<IUserData>();

            string userName = "khalid4747";

            //// Arrange
            UserDataMock.Setup(_udata => _udata.GetUserAvatar(userName)).
                ReturnsAsync("");

            Services.AddSingleton<IUserData>(UserDataMock.Object);

            // Assert that it removes the script and text
            var cut = RenderComponent<Avatar>(Parameter("UserName", userName));
            //Escaped component
            cut.MarkupMatches("<div class=\"avatar-icon\"><span class=\"text-avatar\" id=\"avatar-icon\" width=\"48\" height=\"48\">K</span></div>");


            UserDataMock.Setup(_udata => _udata.GetUserAvatar(userName)).
                ReturnsAsync("Photos/khalid4747-20201123-070821.jpeg");

            Console.WriteLine(UserDataMock.Object.GetUserAvatar(userName));

            cut.SetParametersAndRender(parameters => parameters
                            .Add(p => p.UserName, userName));
            cut.MarkupMatches("<div class=\"avatar-icon\"><img src=\"Photos/khalid4747-20201123-070821.jpeg\" class=\"rounded-circle\" id=\"avatar-icon\" width=\"48\" height=\"48\"></div>");
        }
    }
}

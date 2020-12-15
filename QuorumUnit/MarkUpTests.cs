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

namespace QuorumUnit
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.egilhansen.com/docs/
    /// </summary>
    public class MarkUpTests : TestContext
    {
        public MarkUpTests()
        {
            Services.AddScoped<IHtmlSanitizer, HtmlSanitizer>(x =>
            {
                var sanitizer = new HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");
                return sanitizer;
            });
        }

        [Fact]
        public void MarkupDirtyInput()
        {
            string xssInput = "<script> alert(1) </script>";

            // Assert that it removes the script and text
            var cut = RenderComponent<Markdown>(Parameter("InputText", xssInput));
            cut.MarkupMatches("");
        }

        [Fact]
        public void MarkupCleanInput()
        {
            string input = "i am clean and innocent";
            
            var cut = RenderComponent<Markdown>(Parameter("InputText", input));
            cut.Find("p").MarkupMatches($"<p>{input}</p>");
        }

        [Fact]
        public void MarkupDirtyAndCleanInput()
        {
            string input = @"i am clean and innocent but.. <script>alert(1)</script>";

            var cut = RenderComponent<Markdown>(Parameter("InputText", input));
            cut.Find("p").MarkupMatches($"<p>i am clean and innocent but..</p>");
        }

        [Fact]
        public void MarkupMultiMediaInput()
        {
            string input = @"![bug](https://64.media.tumblr.com/a173ece72bab1e6648c99ad4162eb046/tumblr_pw9hldCvv31us4qppo3_r1_500.gif)";

            var cut = RenderComponent<Markdown>(Parameter("InputText", input));
            cut.Find("p").MarkupMatches(@"<p><img src=""https://64.media.tumblr.com/a173ece72bab1e6648c99ad4162eb046/tumblr_pw9hldCvv31us4qppo3_r1_500.gif"" class=""img-fluid"" alt=""bug""></p>");
        }

        [Fact]
        public void MarkupMedia()
        {
            string input = @"![youtube.com](https://www.youtube.com/watch?v=mswPy5bt3TQ)";

            var cut = RenderComponent<Markdown>(Parameter("InputText", input));
            cut.Find("p").MarkupMatches("<p><iframe src=\"https://www.youtube.com/embed/mswPy5bt3TQ\" class=\"img-fluid youtube\" width=\"500\" height=\"281\" frameborder=\"0\" allowfullscreen=\"\"></iframe></p>");
        }

        [Fact]
        public void MarkupBlockQuote()
        {
            string input = @"> blockquote";

            var cut = RenderComponent<Markdown>(Parameter("InputText", input));
            cut.MarkupMatches(@"<blockquote class=""blockquote""><p>blockquote</p></blockquote>");
        }

        [Fact]
        public void FilterDirtyIframe()
        {
            string input = @"<iframe src=""javascript:alert(1)""></iframe>";

            var cut = RenderComponent<Markdown>(Parameter("InputText", input));
            cut.MarkupMatches("");
        }
    }
}

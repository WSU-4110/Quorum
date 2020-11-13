using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quorum.Data.ViewModels
{
    public class BreadCrumbData : IBreadCrumbData
    {
        public void GetBreadCrumbs(ref List<BreadCrumb> breadCrumb, string forumUrl)
        {
            //Breadcrumbs logic
            breadCrumb.Clear();

            List<string> breadCrumbTitle = forumUrl.Split('/').ToList();
            breadCrumbTitle.Remove("q"); //Remove default homepage directory
            for (int i = 0; i < breadCrumbTitle.Count; i++)
            {
                var title = new StringBuilder(breadCrumbTitle[i]);
                title.Replace('-', ' ');
                //Capatalize the first letter
                title[0] = char.ToUpper(title[0]);
                breadCrumbTitle[i] = title.ToString();
            }

            List<string> breadCrumbUrls = new List<string>();
            var forumUrlCopy = forumUrl;

            breadCrumbUrls.Add(forumUrlCopy);
            for (int i = 0; i < breadCrumbTitle.Count - 1; i++)
            {
                var lastSlashIndex = forumUrlCopy.LastIndexOf('/');
                forumUrlCopy = forumUrlCopy.Remove(lastSlashIndex);
                breadCrumbUrls.Add(forumUrlCopy);
            }
            breadCrumbUrls.Reverse();
            //Add the parts into UrlPart container
            for (int i = 0; i < breadCrumbTitle.Count; i++)
                breadCrumb.Add(new BreadCrumb() { Title = breadCrumbTitle[i], Url = breadCrumbUrls[i] });
        }
    }
}

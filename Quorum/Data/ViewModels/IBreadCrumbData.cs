using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Data.ViewModels
{
    public interface IBreadCrumbData
    {
        void GetBreadCrumbs(ref List<BreadCrumb> breadCrumb, string forumUrl);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Model
{
    //TODO : Implement entity framwork data tables
    public class ParentForumModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string LeafForum { get; set; }
    }
}

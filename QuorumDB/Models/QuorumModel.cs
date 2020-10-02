using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Model
{
    public class QuorumModel
    {
        public int QuorumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public List<ModModel> Mods { get; set; }
    }
}

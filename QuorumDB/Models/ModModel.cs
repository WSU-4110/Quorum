using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Model
{
    public class ModModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string UserId { get; set; }
        
        [Required]
        [MaxLength(256)]
        //[Column(TypeName = "varchar(10)")]
        public int QuorumId { get; set; }
    }
}

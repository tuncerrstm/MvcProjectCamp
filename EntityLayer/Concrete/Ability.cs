using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Ability 
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string AbilityName { get; set; }

        public int KnowledgeLevel { get; set; }
    }
}

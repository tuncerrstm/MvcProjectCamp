using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContenValue { get; set; }

        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; }

        public int TitleID { get; set; }
        public virtual Title Title { get; set; }

        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }

    }
}

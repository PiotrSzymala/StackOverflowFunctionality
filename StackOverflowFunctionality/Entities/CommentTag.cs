using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowFunctionality.Entities
{
    public class CommentTag
    {
        public Comment Comment { get; set; }
        public int CommentId { get; set; }

        public Tag Tag { get; set; }
        public int TagId { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}

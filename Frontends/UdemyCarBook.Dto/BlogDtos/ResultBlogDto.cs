using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.BlogDtos
{
    public class ResultBlogDto
    {
        public string AuthorName { get; set; }
        public int BlogID { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int AuthorID { get; set; }

        public string CoverImageUrl { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
    }
}

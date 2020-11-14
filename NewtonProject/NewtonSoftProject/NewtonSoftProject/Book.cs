using System.Collections.Generic;

namespace NewtonProject
{
    class Book
    {
        public string totalItems { get; set; }
        public string kind { get; set; }
        public IList<Items> items { get; set; }
    }
}
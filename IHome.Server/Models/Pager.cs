using System.Collections.Generic;

namespace IHome.Models
{
    public class Pager<T>
    {
        public int page_count { get; set; }
        public int page_index { get; set; }
        public int total { get; set; }
        public List<T> data_list { get; set; }
    }
}

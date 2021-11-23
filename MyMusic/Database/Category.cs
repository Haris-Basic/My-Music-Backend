using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Database
{
    public class Category
    {
        public int CategoryId{ get; set; }
        public string CategoryName { get; set; }
        public ICollection<Songs> Songs { get; set; }
    }
}

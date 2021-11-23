using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Model
{
    public class SongsSearchObj
    {
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Favorite { get; set; }
    }
}

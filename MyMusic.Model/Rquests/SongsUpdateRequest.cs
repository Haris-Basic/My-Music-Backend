using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Model.Rquests
{
    public class SongsUpdateRequest
    {
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string SongUrl { get; set; }
        public int Rate { get; set; }
        public bool Favorite { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime EditDate { get; set; }
        public int CategoryId { get; set; }
    }
}

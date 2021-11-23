﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Database
{
    public class Songs
    {
        public int SongsId { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string SongUrl { get; set; }
        public int Rate { get; set; }
        public bool Favorite { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? EditDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

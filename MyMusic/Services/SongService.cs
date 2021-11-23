using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMusic.Database;
using MyMusic.Model.Rquests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Services
{
    public class SongService : BaseCRUDService<Model.Songs,Database.Songs,Model.SongsSearchObj, SongsInsertRequest,SongsUpdateRequest>, ISongsService
    {
        public SongService(MyMusicContext db, IMapper mapper):base(db,mapper)
        {
        }
        // Prepisana funkcija Get radi pretrazivanja
        public override IEnumerable<Model.Songs> Get(Model.SongsSearchObj search = null)
        {
            var entity = Context.Set<Database.Songs>().AsQueryable(); // da bi mogli unutar if izraza pisati query
            entity = entity.Include("Category");

            if (!string.IsNullOrEmpty(search.SongName))
            {
                entity = entity.Where(x => x.SongName.Contains(search.SongName));
            }
            if (!string.IsNullOrEmpty(search.ArtistName))
            {
                entity = entity.Where(x => x.ArtistName.Contains(search.ArtistName));
            }
            if (search.CategoryID.HasValue)
            {
                entity = entity.Where(x => x.CategoryId==search.CategoryID);
            }
            var list = entity.ToList();

            return _mapper.Map<IEnumerable<Model.Songs>>(list);
        }

        public override Model.Songs GetById(int id)
        {
            var set = Context.Set<Database.Songs>().AsQueryable(); // da bi mogli unutar if izraza pisati query
            set = set.Include("Category");

            var entity = set.FirstOrDefault(x => x.SongsId == id);

            return _mapper.Map<Model.Songs>(entity);
        }

        public override Model.Songs Update(int id, SongsUpdateRequest request)
        {
            var set = Context.Set<Database.Songs>().AsQueryable();

            var entity = set.Where(w => w.SongsId == id).FirstOrDefault();

            _mapper.Map(request, entity);

            entity.EditDate = DateTime.Now;
            Context.SaveChanges();

            return base.Update(id, request);
        }

    }
}

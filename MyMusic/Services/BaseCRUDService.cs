using AutoMapper;
using MyMusic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Services
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseReadService<T,TDb,TSearch>, ICRUDService<T,TSearch,TInsert,TUpdate> where T : class where TDb : class where TSearch : class where TInsert : class where TUpdate : class
    {
        public BaseCRUDService(MyMusicContext db, IMapper mapper) : base(db,mapper)
        {
        }

        public virtual T Insert(TInsert request)
        {
            var set = Context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(request);

            set.Add(entity);

            Context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual T Update(int id, TUpdate request)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);

            _mapper.Map(request,entity);

            Context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual bool Delete(int id)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);
            if (entity != null)
            {
                Context.Remove(entity);
                Context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}

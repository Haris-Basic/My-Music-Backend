using AutoMapper;
using MyMusic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Services
{
    public class BaseReadService<T, TDb, TSearch> : IReadService<T, TSearch> where T : class where TDb : class where TSearch : class
    {
        protected MyMusicContext Context;
        protected IMapper _mapper;
        public BaseReadService(MyMusicContext db, IMapper mapper)
        {
            Context = db;
            _mapper = mapper;
        }
        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var set = Context.Set<TDb>();

            var list = set.ToList();

            return _mapper.Map<IEnumerable<T>>(list);
        }

        public virtual T GetById(int id)
        {
            var set = Context.Set<TDb>(); 

            var entity = set.Find(id);

            return _mapper.Map<T>(entity);
        }
    }
}

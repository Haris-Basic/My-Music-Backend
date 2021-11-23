using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMusic.Database;
using MyMusic.Filter;
using MyMusic.Model;
using MyMusic.Model.Rquests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Services
{
    public class UsersService : IUsersService
    {
        public MyMusicContext _db { get; set; }
        protected readonly IMapper _mapper;
        public UsersService(MyMusicContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IList<Model.Users> Get(UsersSearchRequest request)
        {
            var query = _db.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.FirsName))
            {
                query = query.Where(x => x.FirsName == request.FirsName);
            }

            if (!string.IsNullOrWhiteSpace(request?.LastName))
            {
                query = query.Where(x => x.LastName == request.LastName);
            }

            var entities = query.ToList();

            var result = _mapper.Map<IList<Model.Users>>(entities);

            return result;
        }
        public Model.Users GetById(int id)
        {
            var entity = _db.Users.Find(id);

            return _mapper.Map<Model.Users>(entity);
        }

        public Model.Users Insert(UsersInsertRequest request)
        {
            var entity = _mapper.Map<Database.Users>(request);
            //_db.Add(entity);

            if (request.Password != request.ConfirmPassword)
            {
                //throw new NotImplementedException();
                throw new Exception("Lozinka nije ispravna");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            _db.Add(entity);
            _db.SaveChanges();             

            return _mapper.Map<Model.Users>(entity);
        }
        public Model.Users Update(int id, UsersUpdateRequest request)
        {
            var entity = _db.Users.Find(id);
            _mapper.Map(request, entity);

            _db.SaveChanges();
            return _mapper.Map<Model.Users>(entity);
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public Model.Users Login(string username, string password)
        {
            var entity = _db.Users.FirstOrDefault(x => x.Username == username);

            if (entity == null)
            {
                //1 throw new UserException("Pogrešan username ili password");
                return null;
            }

            var hash = GenerateHash(entity.PasswordSalt, password);

            if (hash == entity.PasswordHash)
            {
                return _mapper.Map<Model.Users>(entity);
                //1 throw new UserException("Pogrešan username ili password");
            }

            return null;
            //1 return _mapper.Map<Model.Users>(entity);
        }
    }
}

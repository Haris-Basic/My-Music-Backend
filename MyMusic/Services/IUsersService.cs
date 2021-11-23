using MyMusic.Model.Rquests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Services
{
    public interface IUsersService
    {
        IList<Model.Users> Get(UsersSearchRequest request);

        Model.Users GetById(int id);

        Model.Users Insert(UsersInsertRequest request);

        Model.Users Update(int id, UsersUpdateRequest request);

        Model.Users Login(string username, string password);
    }
}

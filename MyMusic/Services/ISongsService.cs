using MyMusic.Model.Rquests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Services
{
    public interface ISongsService : ICRUDService<Model.Songs, Model.SongsSearchObj, SongsInsertRequest, SongsUpdateRequest>
    {

    }
}

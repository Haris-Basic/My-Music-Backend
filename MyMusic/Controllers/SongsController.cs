using Microsoft.AspNetCore.Mvc;
using MyMusic.Model.Rquests;
using MyMusic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Controllers
{
    public class SongsController : BaseCRUDController<Model.Songs, Model.SongsSearchObj, SongsInsertRequest, SongsUpdateRequest>
    {
        public SongsController(ISongsService service) : base(service)
        {

        }
        
    }
}

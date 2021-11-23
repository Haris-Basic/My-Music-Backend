using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyMusic.Model.Rquests;

namespace MyMusic.Mapping
{
    public class MyMusicProfile : Profile
    {
        public MyMusicProfile()
        {
            CreateMap<Database.Songs, Model.Songs>().ReverseMap();
            CreateMap<Database.Songs, Model.CategorySearchObj>().ReverseMap();

            CreateMap<Database.Category, Model.Category>().ReverseMap();
            CreateMap<Database.Category, Model.CategorySearchObj>().ReverseMap();

            CreateMap<Database.Category, CategoryInsertRequest>().ReverseMap();
            CreateMap<Database.Category, CategoryUbdateRequest>().ReverseMap();

            CreateMap<SongsInsertRequest, Database.Songs>().ReverseMap();
            CreateMap<Database.Songs, SongsUpdateRequest>().ReverseMap();

            CreateMap<UsersInsertRequest, Database.Users>();
            CreateMap<Database.Users, UsersUpdateRequest>().ReverseMap();

            CreateMap<Database.Users, Model.Users>().ReverseMap();

        }
    }
}

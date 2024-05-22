using Application2.DTO;
using AutoMapper;
using Domain2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

using Application3.DTO;
using AutoMapper;
using Domain3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application3.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
        }
    }


   

}

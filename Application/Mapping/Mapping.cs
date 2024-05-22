using Application.DTO;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}

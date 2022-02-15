using APICarro.Data.Dtos;
using APICarro.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarro.Profiles
{
    public class CarroProfile : Profile
    {
        public CarroProfile()
        {
            CreateMap<CreateCarroDto, Carro>();
            CreateMap<Carro, ReadCarroDto>();
            CreateMap<UpdateCarroDto, Carro>();
        }
    }
}

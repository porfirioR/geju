﻿using Access.Contract.Request;
using Access.Contract.Response;
using AutoMapper;
using GeJu.Sql.Entities;
using Resources.Contract.Brands;
using System;

namespace Admin.Mapping
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandAccess, Marca>()
                .ForMember(dest => dest.Activo,
                    opt => opt.MapFrom(src => src.Active))
                .ForMember(dest => dest.Descripcion,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Nombre,
                    opt => opt.MapFrom(src => src.Name));

            CreateMap<UpdateBrand, Marca>()
                .ForMember(dest => dest.FechaModificado,
                    opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Marca, BrandAccessResponse>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}

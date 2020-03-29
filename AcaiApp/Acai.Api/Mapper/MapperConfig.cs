using Acai.Api.ViewModel;
using Acai.Domain.Entities;
using AutoMapper;

namespace Acai.Api.Mapper
{
    public static class MapperConfig
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaborViewModel, Sabor>();
                cfg.CreateMap<Sabor, SaborViewModel>();
            });
        }
    }
}
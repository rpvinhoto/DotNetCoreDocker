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
                cfg.CreateMap<PedidoPersonalizacaoViewModel, PedidoPersonalizacao>();
                cfg.CreateMap<PedidoPersonalizacao, PedidoPersonalizacaoViewModel>();

                cfg.CreateMap<PedidoViewModel, Pedido>();
                cfg.CreateMap<Pedido, PedidoViewModel>();

                cfg.CreateMap<DetalhesPedidoViewModel, Pedido>();
                cfg.CreateMap<Pedido, DetalhesPedidoViewModel>();

                cfg.CreateMap<PersonalizacaoViewModel, Personalizacao>();
                cfg.CreateMap<Personalizacao, PersonalizacaoViewModel>();

                cfg.CreateMap<SaborViewModel, Sabor>();
                cfg.CreateMap<Sabor, SaborViewModel>();

                cfg.CreateMap<TamanhoViewModel, Tamanho>();
                cfg.CreateMap<Tamanho, TamanhoViewModel>();
            });
        }
    }
}

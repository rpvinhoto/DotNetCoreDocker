using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Services;

namespace Acai.Application.AppServices
{
    public class SaborAppService : GenericAppService<Sabor>, ISaborAppService
    {
        public SaborAppService(ISaborService saborService) : base(saborService)
        {
        }
    }
}
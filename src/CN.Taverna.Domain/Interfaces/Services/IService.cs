using System.Collections.Generic;
using System.Threading.Tasks;
using CN.Taverna.Domain.Dto;
using CN.Taverna.Domain.Entities;

namespace CN.Taverna.Domain.Interfaces.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDto">Any inheritance of DtoBase</typeparam>
    /// <typeparam name="TEntity">Any inheritance of ModelBase</typeparam>
    public interface IService<TDto, TEntity> where TDto : DtoBase where TEntity : ModelBase
    {
        Task<TDto> Atualizar(TDto objeto);
        Task<TDetailedDto> Atualizar<TDetailedDto>(TDto objeto);
        Task<TDto> Inserir(TDto objeto);
        Task<TDetailedDto> Inserir<TDetailedDto>(TDto objeto);
        Task<TDto> ObterPorIdAsync(string id);
        Task<TDetailedDto> ObterPorIdAsync<TDetailedDto>(string id);
        Task<IEnumerable<TDto>> ObterTodos();
        Task<IEnumerable<TListDto>> ObterTodos<TListDto>();
        Task RemoverAsync(TDto objeto);

        TDto Map(TEntity entity);
        TEntity Map(TDto dto);
        IEnumerable<TDto> Map(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> Map(IEnumerable<TDto> dtos);
    }
}

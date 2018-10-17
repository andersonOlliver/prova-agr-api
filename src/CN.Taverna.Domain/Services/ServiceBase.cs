using CN.Taverna.Domain.Dto;
using CN.Taverna.Domain.Entities;
using CN.Taverna.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CN.Taverna.Domain.Interfaces.Repositories;

namespace CN.Taverna.Domain.Services
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <typeparam name="TDto">Any inheritance of DtoBase</typeparam>
    /// <typeparam name="TEntity">Any inheritance of ModelBase</typeparam>
    public class ServiceBase<TDto, TEntity> : IService<TDto, TEntity> where TDto : DtoBase where TEntity : ModelBase
    {
        private readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public ServiceBase(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TDto> Atualizar(TDto objeto)
        {
            var entity = Map(objeto);

            entity = await _repository.Inserir(entity);

            return Map(entity);
        }

        public async Task<TDetailedDto> Atualizar<TDetailedDto>(TDto objeto)
        {
            var entity = Map(objeto);
            entity = await _repository.Atualizar(entity);
            return Map<TDetailedDto>(entity);
        }

        public async Task<TDto> Inserir(TDto objeto)
        {
            var entity = Map(objeto);

            entity = await _repository.Inserir(entity);

            return Map(entity);
        }

        public virtual async Task<TDetailedDto> Inserir<TDetailedDto>(TDto objeto)
        {
            var entity = Map(objeto);

            entity = await _repository.Inserir(entity);

            return Map<TDetailedDto>(entity);
        }


        public async Task<TDto> ObterPorIdAsync(string id)
        {
            var obj = await _repository.ObterPorIdAsync(id);
            return Map(obj);
        }


        public async Task<TDetailedDto> ObterPorIdAsync<TDetailedDto>(string id)
        {
            var obj = await _repository.ObterPorIdAsync(id);
            return Map<TDetailedDto>(obj);
        }

        public async Task<IEnumerable<TDto>> ObterTodos()
        {
            var collection = await _repository.ObterTodos();
            return Map(collection);
        }

        public async Task<IEnumerable<TListDto>> ObterTodos<TListDto>()
        {
            var collection = await _repository.ObterTodos();
            return Map<TListDto>(collection);
        }

        public Task RemoverAsync(TDto objeto)
        {
            throw new NotImplementedException();
        }

        #region Mapping Automapper

        public TDto Map(TEntity entity)
        {
            return _mapper.Map<TDto>(entity);
        }

        public TEntity Map(TDto dto)
        {
            return _mapper.Map<TEntity>(dto);
        }

        public TEntity Map<TAnyDto>(TAnyDto dto)
        {
            return _mapper.Map<TEntity>(dto);
        }

        public TAnyDto Map<TAnyDto>(TEntity dto)
        {
            return _mapper.Map<TAnyDto>(dto);
        }

        public IEnumerable<TAnyDto> Map<TAnyDto>(IEnumerable<TEntity> dto)
        {
            return _mapper.Map<IEnumerable<TAnyDto>>(dto);
        }

        public IEnumerable<TDto> Map(IEnumerable<TEntity> entities)
        {
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public IEnumerable<TEntity> Map(IEnumerable<TDto> dtos)
        {
            return _mapper.Map<IEnumerable<TEntity>>(dtos);
        }

        #endregion
    }
}

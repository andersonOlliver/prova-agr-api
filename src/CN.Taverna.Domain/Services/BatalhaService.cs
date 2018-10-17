using System.Threading.Tasks;
using AutoMapper;
using CN.Taverna.Domain.Dto.Batalha;
using CN.Taverna.Domain.Entities.Batalha;
using CN.Taverna.Domain.Interfaces.Repositories;
using CN.Taverna.Domain.Interfaces.Services;

namespace CN.Taverna.Domain.Services
{
    public class BatalhaService : ServiceBase<BatalhaDto, Batalha>, IBatalhaService
    {
        private readonly IBatalhaRepository _repository;
        private readonly IHeroiRepository _heroiRepository;
        public BatalhaService(IBatalhaRepository repository, IMapper mapper, IHeroiRepository heroiRepository) : base(repository, mapper)
        {
            _repository = repository;
            _heroiRepository = heroiRepository;
        }

        public async Task<BatalhaDto> EfetuarBatalhaAsync(PedidoBatalhaDto pedidoBatalhaDto)
        {
            var primeiroJogador = await _heroiRepository.ObterPorIdAsync(pedidoBatalhaDto.IdPrimeiroJogador);
            var segundoJogador = await _heroiRepository.ObterPorIdAsync(pedidoBatalhaDto.IdSegundoJogador);

            var ganhador = primeiroJogador.ObterMelhorStatus(segundoJogador);
            var perdedor = primeiroJogador == ganhador ? segundoJogador : primeiroJogador;
            var batalha = new Batalha
            {
                Ganhador = _mapper.Map<Heroi>(ganhador),
                Perdedor = _mapper.Map<Heroi>(perdedor)
            };

            await _repository.Inserir(batalha);

            return Map(batalha);
        }

        
    }
}
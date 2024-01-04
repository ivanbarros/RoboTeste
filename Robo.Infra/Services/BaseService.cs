using Microsoft.Extensions.Logging;
using Robo.Domain.Enums;
using Robo.Domain.Interfaces.Repositories;
using Robo.Domain.Interfaces.Services.Base;
using Robo.Infra.Extension;

namespace Robo.Infra.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly ILogger<TEntity> _logger;
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseService(ILogger<TEntity> logger, IBaseRepository<TEntity> repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<int> MoveCotovelo(CotoveloEnum rotacao,  string braco)
        {
            
               var insert = await _repository.MoveCotovelo(rotacao.ToString(), braco);
            

            return insert;
        }

        public async Task<int> MovePulso(string status, string braco)
        {
            var insert = await _repository.MovePulso(status, braco);
            return insert;
        }

        public Task<string> MoveCabeca(string rotacao, string status)
        {
            throw new NotImplementedException();
        }


        public Task<string> MoveBraco(int IdCotovelo, int IdPulso, string braco)
        {
            try
            {
                var result = _repository.MoveBraco(IdCotovelo, IdPulso,braco);
                return Task.FromResult($"{result}");
            }
            catch (Exception ex)
            {
                return Task.FromResult($"{ex.InnerException}, {ex.Message}");
                
            }
        }
        public async Task<TEntity> CheckMoveBraco(string braco)
        {
            var result = await _repository.CheckMoveBraco(braco);
            return result;
        }

        public async Task<int> UpdateMoveCotovelo(string status, string braco)
        {
            var result = await _repository.UpdateMoveCotovelo(status,braco);
            return result;
        }
    }
}


using Dapper;
using Microsoft.EntityFrameworkCore;
using Robo.Domain.Constants.QueriesTables;
using Robo.Domain.Interfaces.Repositories;
using Robo.Domain.Interfaces.UOW;
using Robo.Infra.Data;
using System.Data;

namespace Robo.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        MyContext _context = new MyContext();
        public IDbConnection _dbConnection => throw new System.NotImplementedException();
        public IDbTransaction _dbTransaction { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TEntity> CheckMoveBraco(string braco)
        {
            try
            {
                var parametros = new DynamicParameters();            
            parametros.Add("Lado", braco, DbType.AnsiString);
            var result =  _unitOfWork.Connection.QueryFirstOrDefault<TEntity>(BracoQueryConstant.getBraco,parametros, commandType: CommandType.Text, transaction: _unitOfWork.Transaction);
            return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }     
        public Task<string> MoveCabeca(string rotacao, string status)
        {
            throw new NotImplementedException();
        }

        public async Task<int> MoveCotovelo(string status, string braco)
        {
            var parametros = new DynamicParameters();
            parametros.Add("Status", status, DbType.AnsiString);
            parametros.Add("Lado", braco, DbType.AnsiString);
            var result = await _unitOfWork.Connection.ExecuteAsync(BracoQueryConstant.InsertStatusCotovelo, parametros, commandType: CommandType.Text, transaction: _unitOfWork.Transaction);
            
            return result;
        }
        public async Task<int> UpdateMoveCotovelo(string status, string braco)
        {
            var parametros = new DynamicParameters();
            parametros.Add("Status", status, DbType.AnsiString);
            parametros.Add("Lado", braco, DbType.AnsiString);
            var result = await _unitOfWork.Connection.ExecuteAsync(BracoQueryConstant.UpdateStatusCotovelo, parametros, commandType: CommandType.Text, transaction: _unitOfWork.Transaction);
            
            return result;
        }

        public async Task<int> MovePulso(string rotacao,string braco)
        {
            var parametros = new DynamicParameters();
            parametros.Add("Rotacao", rotacao, DbType.AnsiString);
            parametros.Add("Lado", braco, DbType.AnsiString);
            var result = await _unitOfWork.Connection.ExecuteAsync(BracoQueryConstant.insertPulso, parametros, commandType: CommandType.Text, transaction: _unitOfWork.Transaction);
            
            return result;
        }

        public async Task<string> MoveBraco(int IdCotovelo, int IdPulso, string braco)
        {
            try
            {
                var parametros = new DynamicParameters();
                parametros.Add("IdCotovelo", IdCotovelo, DbType.Int32);
                parametros.Add("IdPulso", IdPulso, DbType.Int32);
                var result = await _unitOfWork.Connection.ExecuteAsync(BracoQueryConstant.insereBracoDireito, parametros, commandType: CommandType.Text, transaction: _unitOfWork.Transaction);

                return "Finalizado";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

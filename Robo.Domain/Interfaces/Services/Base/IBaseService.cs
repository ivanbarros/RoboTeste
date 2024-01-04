using Robo.Domain.Enums;

namespace Robo.Domain.Interfaces.Services.Base
{
    public interface IBaseService<T> where T : class
    {
        Task<int> MoveCotovelo(CotoveloEnum rotacao,  string braco);
        Task<int> MovePulso(string status, string braco);
        Task<string> MoveCabeca(string rotacao, string status);
        Task<string> MoveBraco(int IdCotovelo, int IdPulso, string braco);
        Task<int> UpdateMoveCotovelo(string status, string braco);
        Task<T> CheckMoveBraco(string braco);
    }
}

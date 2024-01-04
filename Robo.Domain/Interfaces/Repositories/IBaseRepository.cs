namespace Robo.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> MoveCotovelo(string status, string braco);
        Task<int> UpdateMoveCotovelo(string status, string braco);
        Task<int> MovePulso(string rotacao, string braco);
        Task<string> MoveCabeca(string rotacao, string status);
        Task<string> MoveBraco(int IdCotovelo, int IdPulso, string braco);
        Task<T> CheckMoveBraco(string braco);
    }
}

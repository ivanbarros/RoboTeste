namespace Robo.Domain.Constants.QueriesTables
{
    public static class BracoQueryConstant
    {
        public const string getBraco = $@"
                SELECT c.status, p.rotacao FROM braco b
INNER JOIN cotovelo c ON c.Id = b.IdCotovelo
INNER JOIN pulso p ON p.Id = b.IdPulso
WHERE c.lado = @Lado AND p.lado = @Lado";


        public const string InsertStatusCotovelo = $@"INSERT INTO cotovelo (status, lado) values(@Status, @Lado)";

        public const string UpdateStatusCotovelo = $@"UPDATE cotovelo SET status = @Status Where lado = @Lado";

        public const string insertPulso = $@"INSERT into pulso (rotacao, lado) values (@Rotacao, @Lado)";


        public const string insereBracoDireito = $@"INSERT INTO braco (IdCotovelo,IdPulso)
Values(@IdCotovelo,@IdPulso)";
    }
}

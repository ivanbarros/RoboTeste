using FluentMigrator;
using Robo.Infra.Migrations.Config;

namespace Robo.Infra.Migrations.Tables
{
    [Migration(7)]
    public class Braco : Migration
    {
        public override void Down()
        {
            Delete.Table("braco");
        }

        public override void Up()
        {
            Create.Table("braco")
                .CreateBase(false)
                .WithColumn("IdCotovelo").AsInt32()
                .ForeignKey("cotovelo","Id")
                .WithColumn("IdPulso").AsInt32()
                .ForeignKey("pulso","Id");
        }
    }
}

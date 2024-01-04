using FluentMigrator;
using Robo.Infra.Migrations.Config;

namespace Robo.Infra.Migrations.Tables
{
    [Migration(10)]
    public class Cabeca : Migration
    {
        public override void Down()
        {
            Delete.Table("cabeca");
        }

        public override void Up()
        {
            Create.Table("cabeca")
                .CreateBase(false)
                .WithColumn("rotacao").AsInt32()
                .WithColumn("inclinacao").AsInt32();
        }
    }
}

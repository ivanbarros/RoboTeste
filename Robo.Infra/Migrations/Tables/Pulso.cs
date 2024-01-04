using FluentMigrator;
using Robo.Infra.Migrations.Config;

namespace Robo.Infra.Migrations.Tables
{
    [Migration(5)]
    public class Pulso : Migration
    {
        public override void Down()
        {
            Delete.Table("pulso");
        }

        public override void Up()
        {
            Create.Table("pulso")
                .CreateBase(false)
                .WithColumn("rotacao").AsString()
                .WithColumn("lado").AsString();
        }
    }
}

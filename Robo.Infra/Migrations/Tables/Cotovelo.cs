using FluentMigrator;
using Robo.Infra.Migrations.Config;

namespace Robo.Infra.Migrations.Tables
{
    [Migration(3)]
    public class Cotovelo : Migration
    {
        public override void Down()
        {
            Delete.Table("cotovelo");
        }

        public override void Up()
        {
            Create.Table("cotovelo")
                .CreateBase(false)
                .WithColumn("status").AsString()
                .WithColumn("lado").AsString() ;
        }
    }
}

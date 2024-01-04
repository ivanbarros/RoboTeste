using FluentMigrator.Builders.Create.Table;

namespace Robo.Infra.Migrations.Config
{
    public static class CreateTableBase
    {
        public static ICreateTableWithColumnSyntax CreateBase(this ICreateTableWithColumnSyntax create, bool userFK = true)
        {
            create
                .WithColumn("Id")
                    .AsInt32()
                    .NotNullable()
                    .Identity()
                    .PrimaryKey();

            if (userFK)
                create
                    .WithColumn("IdUsuario")
                    .AsInt32()
                    .NotNullable()
                    .ForeignKey("Usuario", "Id");

            return create;
        }
    }
}

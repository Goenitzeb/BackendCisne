using FluentMigrator; 

namespace BackendMacetas.Migrations.Data;

[Migration(00000001)]
public class M00000001 : Migration
{
    public override void Down()
    {
        Execute.Sql("DROP VIEW IF EXISTS public.\"ListadoMacetasView\";");
        Execute.Sql("DROP VIEW IF EXISTS public.\"ListadoDisenoView\";");
        Execute.Sql("DROP VIEW IF EXISTS public.\"ListadoColorView\";");
        Execute.Sql("DROP VIEW IF EXISTS public.\"ListadoModeloView\";");
        Execute.Sql("DROP VIEW IF EXISTS public.\"ListadoTamanoView\";");

        Delete.FromTable("Macetas").AllRows();
        Delete.FromTable("Tamano").AllRows();
        Delete.FromTable("Modelo").AllRows();
        Delete.FromTable("Diseno").AllRows();
        Delete.FromTable("Color").AllRows();

        Delete.ForeignKey("FK_Macetas_Color").OnTable("Macetas");
        Delete.ForeignKey("FK_Macetas_Diseno").OnTable("Macetas");
        Delete.ForeignKey("FK_Macetas_Modelo").OnTable("Macetas");
        Delete.ForeignKey("FK_Macetas_Tamano").OnTable("Macetas");

        Delete.Table("Macetas");
        Delete.Table("Diseno");
        Delete.Table("Modelo");
        Delete.Table("Color");
        Delete.Table("Tamano");
    }

    public override void Up()
    {
    
        Create.Table("Diseno")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Nombre").AsString(255).NotNullable();

        Create.Table("Modelo")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("Nombre").AsString(255).NotNullable();

        Create.Table("Color")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("Nombre").AsString(255).NotNullable();

        Create.Table("Tamano")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("Nombre").AsString(255).NotNullable();

        Create.Table("Macetas")
        .WithColumn("Id").AsInt32().PrimaryKey().Identity()
        .WithColumn("Nombre").AsString(255).NotNullable()
        .WithColumn("ColorId").AsInt32().NotNullable()
            .ForeignKey("FK_Macetas_Color", "Color", "Id")
        .WithColumn("DisenoId").AsInt32().NotNullable()
            .ForeignKey("FK_Macetas_Diseno", "Diseno", "Id")
        .WithColumn("ModeloId").AsInt32().NotNullable()
            .ForeignKey("FK_Macetas_Modelo", "Modelo", "Id")
        .WithColumn("TamanoId").AsInt32().NotNullable()
            .ForeignKey("FK_Macetas_Tamano", "Tamano", "Id")
        .WithColumn("Precio").AsDecimal().NotNullable()
        .WithColumn("Stock").AsInt32().NotNullable();

        // 1. Llenamos los catálogos primero (porque Macetas depende de ellos)
        Insert.IntoTable("Color").Row(new { Nombre = "Rojo Terracota" });
        Insert.IntoTable("Color").Row(new { Nombre = "Blanco" });

        Insert.IntoTable("Diseno").Row(new { Nombre = "Granito" });
        Insert.IntoTable("Diseno").Row(new { Nombre = "Liston azteca" });

        Insert.IntoTable("Modelo").Row(new { Nombre = "Estandar" });
        Insert.IntoTable("Modelo").Row(new { Nombre = "Molcajete" });

        Insert.IntoTable("Tamano").Row(new { Nombre = "Chico" });
        Insert.IntoTable("Tamano").Row(new { Nombre = "Grande" });

        // 2. Insertamos una maceta de ejemplo
        // Como nuestras llaves primarias (Id) son autoincrementables (Identity), 
        // sabemos que los primeros registros que insertamos arriba tienen el Id = 1
        Insert.IntoTable("Macetas").Row(new
        {
            Nombre = "Maceta Colgante Minimalista",
            ColorId = 2,  // Blanco Cerámica
            DisenoId = 1, // Minimalista
            ModeloId = 2, // Colgante
            TamanoId = 1, // Chico
            Precio = 250,
            Stock = 15
        });

        //views 

        Execute.Sql(@"
            CREATE OR REPLACE VIEW public.""ListadoMacetasView""
            AS
            SELECT m.""Id"",
                m.""Nombre"",
                m.""Precio"",
                m.""Stock"",
                c.""Nombre"" AS ""Color"",
                d.""Nombre"" AS ""Diseno"",
                t.""Nombre"" AS ""Tamano"",
                m1.""Nombre"" AS ""Modelo""
               FROM ""Macetas"" m
                 JOIN ""Color"" c ON m.""ColorId"" = c.""Id""
                 JOIN ""Diseno"" d ON m.""DisenoId"" = d.""Id""
                 JOIN ""Tamano"" t ON m.""TamanoId"" = t.""Id""
                 JOIN ""Modelo"" m1 ON m.""ModeloId"" = m1.""Id"";

                ALTER TABLE public.""ListadoMacetasView""
                OWNER TO postgres;
        ");

        Execute.Sql(@"
            CREATE OR REPLACE VIEW public.""ListadoDisenoView""
            AS
            SELECT ""Id"",
                ""Nombre""
               FROM ""Diseno"";

            ALTER TABLE public.""ListadoDisenoView""
                OWNER TO postgres;
        ");

        Execute.Sql(@"
            CREATE OR REPLACE VIEW public.""ListadoColorView""
            AS
            SELECT ""Id"",
                ""Nombre""
               FROM ""Color"";

            ALTER TABLE public.""ListadoColorView""
                OWNER TO postgres;
        ");

        Execute.Sql(@"
            CREATE OR REPLACE VIEW public.""ListadoModeloView""
            AS
            SELECT ""Id"",
                ""Nombre""
               FROM ""Modelo"";

            ALTER TABLE public.""ListadoModeloView""
                OWNER TO postgres;
        ");

        Execute.Sql(@"
            CREATE OR REPLACE VIEW public.""ListadoTamanoView""
            AS
            SELECT ""Id"",
                ""Nombre""
               FROM ""Tamano"";

            ALTER TABLE public.""ListadoTamanoView""
                OWNER TO postgres;
        ");
    }
}

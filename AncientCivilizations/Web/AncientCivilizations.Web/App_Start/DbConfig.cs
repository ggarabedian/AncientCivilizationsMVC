namespace AncientCivilizations.Web.App_Start
{
    using System.Data.Entity;

    using Data;
    using Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AncientCivilizationsDbContext, Configuration>());
            AncientCivilizationsDbContext.Create().Database.Initialize(true);
        }
    }
}
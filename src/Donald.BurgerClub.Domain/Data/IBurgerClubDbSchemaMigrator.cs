using System.Threading.Tasks;

namespace Donald.BurgerClub.Data;

public interface IBurgerClubDbSchemaMigrator
{
    Task MigrateAsync();
}

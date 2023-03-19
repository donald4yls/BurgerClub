using Donald.BurgerClub.Model;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Donald.BurgerClub.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class BurgerClubDbContext :
    AbpDbContext<BurgerClubDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    //Burger Club Entities

    public DbSet<BurgerStore> BurgerStores { get; set; }

    public DbSet<BurgerStoreScore> BurgerStoreScores { get; set; }

    public DbSet<BurgerStoreMenu> BurgerStoreMenus { get; set; }

    public DbSet<BurgerClubUser> BurgerClubUsers { get; set; }

    public DbSet<BurgerClubUserActive> BurgerClubUserActives { get; set; }

    public DbSet<BurgerClubUserActivePhoto> BurgerClubUserActivePhotos { get; set; }

    public DbSet<BurgerClubUserFan> BurgerClubUserFans { get; set; }

    #endregion

    public BurgerClubDbContext(DbContextOptions<BurgerClubDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<BurgerStore>(b =>
        {
            b.ToTable(BurgerClubConsts.DbTablePrefix + "BurgerStore", BurgerClubConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });

        builder.Entity<BurgerStoreScore>(b =>
        {
            b.ToTable(BurgerClubConsts.DbTablePrefix + "BurgerStoreScore", BurgerClubConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.BurgerStoreId).IsRequired();
            b.Property(x => x.BurgerClubUserId).IsRequired();
        });

        builder.Entity<BurgerStoreMenu>(b =>
        {
            b.ToTable(BurgerClubConsts.DbTablePrefix + "BurgerStoreMenu", BurgerClubConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.BurgerStoreId).IsRequired();
            b.Property(x => x.MenuItemName).IsRequired();
        });

        builder.Entity<BurgerClubUser>(b =>
        {
            b.ToTable(BurgerClubConsts.DbTablePrefix + "BurgerClubUser", BurgerClubConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.ClubUserName).HasMaxLength(128).IsRequired();
            b.Property(x => x.Password).HasMaxLength(56).IsRequired();
        });

        builder.Entity<BurgerClubUserActive>(b =>
        {
            b.ToTable(BurgerClubConsts.DbTablePrefix + "BurgerClubUserActive", BurgerClubConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.BurgerClubUserId).IsRequired();
            b.Property(x => x.Note).HasMaxLength(512);
        });

        builder.Entity<BurgerClubUserActivePhoto>(b =>
        {
            b.ToTable(BurgerClubConsts.DbTablePrefix + "BurgerClubUserActivePhoto", BurgerClubConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.BurgerClubUserActiveId).IsRequired();
            b.Property(x => x.Photo).HasMaxLength(1024).IsRequired();
        });

        builder.Entity<BurgerClubUserFan>(b =>
        {
            b.ToTable(BurgerClubConsts.DbTablePrefix + "BurgerClubUserFan", BurgerClubConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.UserId).IsRequired();
            b.Property(x => x.FanId).IsRequired();
        });
    }
}

using ApiLayer.Core.Domain;
using ApiLayer.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;


namespace ApiLayer.Persistance.Context
{
    public class JWTContext:DbContext
    {
        public JWTContext(DbContextOptions<JWTContext> options):base (options)
        {

        }
        public DbSet<Product> Products => this.Set<Product>(); // bunu bizim boş propertylerimiz olduğu için o yuzden böyle yapptık
        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles 
        { 
                get
                  {
                return this.Set<AppRole>();// bu kulanım ile yukardaki kullanımlar aynı 
                  }
                
                }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration()); //İLİŞKİ KISMI configuration kısmında yaptık
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }

  

   
}

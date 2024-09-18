using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models
{
    public class IdentityContext : IdentityDbContext<AppUser, AppRole, string>//her context farklı database kullanabilir bir projede hem ıdentitycontext hem dbcontext kullanabilirim.istediğimiz tabloyuda buraya alabiliriz

    //AppRole eklediğimiz için key parametresi olarak string i eklemek durumundayız id değerini ifadesi için.
    {   
      
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            
        }
    }
}
//kısaca IdentityDbContext normal dbcontextden farkı authontication özelliklerini barındırabilen tablolar tutan daha gelişmiş versiyonlu bir dbcontexttir.
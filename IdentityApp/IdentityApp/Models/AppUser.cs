using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Models
{
    public class AppUser: IdentityUser //identityUser dan türetilecek
    {
        public string? FullName { get; set; }//identity den default olarak gelen IdentityUser a ekstra bir prop eklemiş olduk.
    }
}
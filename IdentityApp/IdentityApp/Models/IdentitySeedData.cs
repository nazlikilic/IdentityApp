using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "admin";//oluşturulacak test verisi program.cs de oluştrulan kullanıcı adı kısıtlamalarına takılmaması için admin küçük harfle yazılmalı.
        private const string adminPassword = "Admin_123";

        public static async void IdentityTestUser(IApplicationBuilder app)//program.cs de doğrudan app bilgisini parametre olarak gönderiyoruz bu da o app.
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();//app üzerinden context alıyorum ve hangi servis konteynırından aldığımı söylüyorum IdentityContetden

            if(context.Database.GetAppliedMigrations().Any())//bekleyen bir migrations var mı
            {
                context.Database.Migrate();//bekleyen migrationları aktar
            }
           
           //app içerisinden servis scopundan userManager sınıfını alıyoruz bu hazır var olan kütüphANE SINIFI
            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var user = await userManager.FindByNameAsync(adminUser);//kullanıcı adına göre  admin user arıyoruz ve usera atıyoruz.

            if(user == null)//kullanıcı yoksa admin kullanıcı oluştur
            {
                user = new AppUser {
                    FullName="Admin admin",
                    UserName = adminUser,
                    Email = "admin@sadikturan.com",
                    PhoneNumber = "44444444"                    
                };

                await userManager.CreateAsync(user, adminPassword); //kullanıcı kaydı yoksa adminUser ve adminPassword ile oluştur demiş olduk.Identity passwordu otomatik hashler.
            }
        }
    } 
}
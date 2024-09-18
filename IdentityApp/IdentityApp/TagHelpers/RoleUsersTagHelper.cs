using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace IdentityApp.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "asp-role-users")]//bu attribute: td etiketi kapsamında
    public class RoleUsersTagHelper:TagHelper //TagHelper classından üretildi.
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleUsersTagHelper(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HtmlAttributeName("asp-role-users")]
        public string RoleId { get; set; } = null!; //role ıd i porpu tanımlıyoruz

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var userNames = new List<string>(); //bir stirng listesi
            var role = await _roleManager.FindByIdAsync(RoleId); //role managerda eşleşen ıd bulunup role atanır.

            if(role != null && role.Name != null) //rol ve rol adı null değilse
            {
                foreach(var user in _userManager.Users)//tüm userlar alınır
                {
                    if(await _userManager.IsInRoleAsync(user, role.Name))//o anda eriştiğimiz user o rol içerisinde mi kontrolü yapılır.
                    {
                        userNames.Add(user.UserName ?? "");//username yoksa boş değer ataması yapar. uyarıyı gidermek için
                    }
                }
                output.Content.SetHtmlContent(userNames.Count == 0 ? "kullanıcı yok": setHtml(userNames));
                // dışarıya geri döndereceğimiz değer. Eğer count sıfırsa kllanıcı yok varsa UserNamesler gönderilip set edilir.
            }

        }

        private string setHtml(List<string> userNames)//User nameler çevrelenip gönderilir.
        {
            var html = "<ul>";
            foreach (var item in userNames)
            {
                html += "<li>"+ item +"</li>";
            } 
            html += "</ul>";
            return html;
        }
    }
}
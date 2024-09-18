//create view den model taşıyacak olan bir class 124.ders
using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels
{
    public class EditViewModel
    {
        public string? Id { get; set; }
        public string? FullName { get; set; } 

      
        [EmailAddress]
        public string? Email { get; set; } 

       
        [DataType(DataType.Password)]//parola karakterleri yazılırken görünmesin diye.
        public string? Password { get; set; } 

        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parola eşleşmiyor.")]//password karşılaştırması doğru mu validasyonu
        public string? ConfirmPassword { get; set; } 

        public IList<string>? SelectedRoles { get; set; }
    } 
}
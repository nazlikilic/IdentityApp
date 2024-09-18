//create view den model taşıyacak olan bir class 124.ders
using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]//parola karakterleri yazılırken görünmesin diye.
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Parola eşleşmiyor.")]//password karşılaştırması doğru mu validasyonu
        public string ConfirmPassword { get; set; } = string.Empty;


    } 
}
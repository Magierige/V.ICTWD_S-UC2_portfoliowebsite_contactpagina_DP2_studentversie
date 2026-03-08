using System.ComponentModel.DataAnnotations;

namespace Portfoliowebsite.Models
{
    public class ContactModel
    {
        [Display(Name = "Naam")]
        [Required(ErrorMessage = "Vul uw naam in.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "De naam moet tussen 2 en 50 tekens bevatten.")]
        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$", ErrorMessage = "Alleen letters en spaties zijn toegestaan.")]
        public string? Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vul uw email in.")]
        [EmailAddress(ErrorMessage = "Vul een geldig emailadres in.")]
        public string? Email { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Vul een onderwerp in.")]
        [RegularExpression(@"^[^\r\n]{1,100}$", ErrorMessage = "Onderwerp bevat ongeldige tekens.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Het onderwerp moet tussen 5 en 100 tekens bevatten.")]
        public string? Subject { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Vul een bericht in.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Het bericht moet tussen 10 en 1000 tekens bevatten.")]
        public string? Message { get; set; }

        //honneypot field
        public string? website { get; set; }
    }
}

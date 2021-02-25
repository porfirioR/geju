using GeJu.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.Models.Users
{
    public class CreateUserApiRequest : IValidatableObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Document { get; set; }
        [Required]
        public CountryType Country { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (!Enum.IsDefined(typeof(CountryType), Country))
            {
                results.Add(new ValidationResult($"Pais {Country} es invalido."));
            }
            return results;
        }
    }
}

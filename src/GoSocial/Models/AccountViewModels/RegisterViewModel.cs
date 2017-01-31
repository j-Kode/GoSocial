using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoSocial.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        [RegularExpression(@"(^[\w]+$)", ErrorMessage = "some error")]
        [Remote("CheckUserNameAsync", "Account", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Instagram Username")]
        public string InstagramUsername { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int locationId { get; set; }

        public string locationName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [Remote("CheckEmailAsync", "Account", ErrorMessage = "The email is already in use.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [RegularExpression(@"(^((?=\S*?[A-Z])(?=\S*?[a-z])(?=\S*?[0-9])(?=\S*?[~!@#$%^&*()_+\-\\=\/.,<>?|\[\]\{\};':`]).{6,})\S$)", ErrorMessage = "Password must contain 1 uppercase, 1 lowercase, 1 special character and 1 number [no spaces].")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

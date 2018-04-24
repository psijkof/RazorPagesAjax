using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesWithAjax.Model
{
    public class ContactDetails
    {
        [Required(ErrorMessage = "Email required")]
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}

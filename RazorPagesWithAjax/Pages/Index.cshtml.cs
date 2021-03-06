﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HttpRequestExtension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesWithAjax.Model;

namespace RazorPagesWithAjax.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ContactDetails ContactForm { get; set; }

        public void OnGet()
        {

        }

        // handler for ajax postback
        public async Task<IActionResult> OnPostSaveFormAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Request.IsAjaxRequest())
            {
                Console.WriteLine("saving to the database ...");
                // simulate long running operation
                await Task.Delay(2000);

                Console.WriteLine("saved to database!");

                // for example use a service to save the data
                // await _myContactService.SaveAsync(ContactForm);

                ViewData.Add("email", ContactForm.Email);

                var view = new PartialViewResult
                {
                    // look for partial
                    ViewName = "SubmitSuccess",
                    // add the data for the partial
                    ViewData = ViewData
                };
                //return new BadRequestResult();
                return view;
            }
            return new OkResult();
        }
    }
}
# RazorPagesAjax
## Use Ajax unobtrusive with Razor Pages AspNetCore


Calling a pagemodel/controller with ajax is possible, but it is not well documented.

Steps done in this project:

Add jquery, jquery-unobtrusive-ajax, jquery-validation and jquery-validation-unobtrusive to your scripts lib in wwwroot

Add NuGet package Microsoft.jQuery.Unobtrusive.Ajax to project (and Microsoft.jQuery.Unobtrusive.Validation)

Add handler to your pagemodel, for example "public async Task<IActionResult> OnPostSaveFormAsync()" or "public IActionResult OnPostSaveForm()"

Return in that method a new PartialViewResult() (viewname="submitsuccess") and create a partial (submitsuccess.cshtml)

In main form (for example in Index.cshtml) add a form (or scaffold from model) with the form element like:

`<form id="thanks" asp-page-handler="SaveForm"
              data-ajax="true"
              data-ajax-method="POST"
              data-ajax-mode="replace"
              data-ajax-update="#thanks" <!--the element to replace with result from partial on success, here I replace the form (see id="thanks") -->
              data-ajax-loading="#loading" <!-- element to show when call is in progress -->
              data-ajax-success="Success"
              data-ajax-failure="Failure"> `
              
Use `[BindingProperty]` on your pagemodel class for the model, for example

`[BindProperty]
        public ContactForm ContactForm { get; set; }`

Please see this repo for an example: https://github.com/psijkof/RazorPagesAjax

Thanks to @AmTute (https://github.com/AmTute/VS2017AjaxFormExample) for his example repo. It helped me to create a working sample for Asp Net Core Razor Pages!

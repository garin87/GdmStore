#pragma checksum "C:\Projects\GdmStore\GdmStore\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0eb88d9642596da269e01a44f02547c797bbf4ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Register.cshtml", typeof(AspNetCore.Views_Account_Register))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "C:\Projects\GdmStore\GdmStore\Views\_ViewImports.cshtml"
using GdmStore.Models;

#line default
#line hidden
#line 3 "C:\Projects\GdmStore\GdmStore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0eb88d9642596da269e01a44f02547c797bbf4ff", @"/Views/Account/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a22a714ec6281f11f43e178ed68cceeee6f4fc5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GdmStore.ViewModels.RegisterModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projects\GdmStore\GdmStore\Views\Account\Register.cshtml"
  
    ViewData["Title"] = "Register";

#line default
#line hidden
            BeginContext(88, 1499, true);
            WriteLiteral(@"
<h2>Register</h2>

    <h4>RegisterModel</h4>
    <hr />
    <div class=""row"">
        <div class=""col-md-4"">
            <form asp-action=""Register"" method=""post"">
                <div  asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
                <div class=""form-group"">
                    <label asp-for=""Email"" class=""control-label""></label>
                    <input name=""Email"" asp-for=""Email"" class=""form-control"" />
                    <span asp-validation-for=""Email"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <label asp-for=""Password"" class=""control-label""></label>
                    <input name=""Password"" asp-for=""Password"" class=""form-control"" />
                    <span asp-validation-for=""Password"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <label asp-for=""ConfirmPassword"" class=""control-label""></label>
                  ");
            WriteLiteral(@"  <input name=""ConfirmPassword"" asp-for=""ConfirmPassword"" class=""form-control"" />
                    <span asp-validation-for=""ConfirmPassword"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <input type=""submit"" value=""Отправить""  class=""btn btn-default"" />
                </div>
            </form>
        </div>
    </div>

    <div>
        <a asp-action=""Index"">Back to List</a>
    </div>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GdmStore.ViewModels.RegisterModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

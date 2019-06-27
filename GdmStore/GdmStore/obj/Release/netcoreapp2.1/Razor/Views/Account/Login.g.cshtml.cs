#pragma checksum "C:\Projects\GdmStore\GdmStore\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0600c594940a6df5908b563a3dbf747f03a18be4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Login.cshtml", typeof(AspNetCore.Views_Account_Login))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0600c594940a6df5908b563a3dbf747f03a18be4", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a22a714ec6281f11f43e178ed68cceeee6f4fc5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GdmStore.ViewModels.LoginModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(39, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projects\GdmStore\GdmStore\Views\Account\Login.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
            BeginContext(82, 1031, true);
            WriteLiteral(@"
<h2>Авторизация</h2>
<p>Пожалуйста, авторизуйтесь</p>
<hr />

<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Login"" method=""post"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Email"" class=""control-label"">Email</label>
                <input name=""Email"" asp-for=""Email"" class=""form-control"" />
                <span asp-validation-for=""Email"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Password"" class=""control-label"">Password</label>
                <input name=""Password"" asp-for=""Password"" class=""form-control"" />
                <span asp-validation-for=""Password"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <button type=""submit"" value=""send"" class=""btn btn-primary"">Войти</button>
            </div>
        </form>
    </div>
</div>
");
            WriteLiteral("\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GdmStore.ViewModels.LoginModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

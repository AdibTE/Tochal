#pragma checksum "E:\NewGit\src\TochalUI\Views\Home\Pro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3bdcbcf7f9ab2db50088f4181837c0258afa3233"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Pro), @"mvc.1.0.view", @"/Views/Home/Pro.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Pro.cshtml", typeof(AspNetCore.Views_Home_Pro))]
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
#line 1 "E:\NewGit\src\TochalUI\Views\_ViewImports.cshtml"
using TochalUI;

#line default
#line hidden
#line 2 "E:\NewGit\src\TochalUI\Views\_ViewImports.cshtml"
using TochalUI.Models;

#line default
#line hidden
#line 1 "E:\NewGit\src\TochalUI\Views\Home\Pro.cshtml"
using Tochal.Core.DomainModels.Entity.Blog;

#line default
#line hidden
#line 2 "E:\NewGit\src\TochalUI\Views\Home\Pro.cshtml"
using Tochal.Core.DomainModels.SSOT;

#line default
#line hidden
#line 3 "E:\NewGit\src\TochalUI\Views\Home\Pro.cshtml"
using Tochal.Core.DomainModels.Entity.Menu;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bdcbcf7f9ab2db50088f4181837c0258afa3233", @"/Views/Home/Pro.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61f0b304abae5b095fdcac43bf7aed30b591793f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Pro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContentEntity>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(181, 170, true);
            WriteLiteral("\r\n<div class=\"filterdiv\"\r\n     style=\"display:none;width: 100vw;height: 100vh;background-color: rgba(255, 255, 255, 0.7);z-index: 5000;position: fixed;top: 0;\"></div>\r\n\r\n");
            EndContext();
            BeginContext(2224, 113, true);
            WriteLiteral("\r\n<section class=\"page-content\">\r\n    <div class=\"content\">\r\n        <div class=\"content-text\">\r\n            <h2>");
            EndContext();
            BeginContext(2338, 11, false);
#line 50 "E:\NewGit\src\TochalUI\Views\Home\Pro.cshtml"
           Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2349, 60, true);
            WriteLiteral("</h2>\r\n            <hr />\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(2410, 23, false);
#line 53 "E:\NewGit\src\TochalUI\Views\Home\Pro.cshtml"
           Write(Html.Raw(Model.Content));

#line default
#line hidden
            EndContext();
            BeginContext(2433, 823, true);
            WriteLiteral(@"
            </p>
        </div>
        <div class=""slideshow"">
            <div class=""slideshow-img"">
                <img src=""https://picsum.photos/500/505"" />
                <img class=""selectedimg"" src=""https://picsum.photos/500/601"" />
                <img src=""https://picsum.photos/500/700"" />
                <img src=""https://picsum.photos/500/600"" />
            </div>
            <div class=""imgnavigator"">
                <i class=""fas fa-angle-left"" onclick=""previmage()""></i>
                <div class=""indexnumber""><span>1</span> / <span>2</span></div>
                <i class=""fas fa-angle-right"" onclick=""nextimage()""></i>
            </div>
        </div>
    </div>
</section>

<div style=""background-color:white;z-index:-1;height:100%;width:100vw;display: table-cell;""></div>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FileConfig fileConfig { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContentEntity> Html { get; private set; }
    }
}
#pragma warning restore 1591

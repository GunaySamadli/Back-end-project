#pragma checksum "C:\Users\LENOVO\Desktop\Back-end-project\Back-End\Back-End\Views\Shared\_SearchPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db3b23b0790a6347c51059248ffe25b4a97c691d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchPartial), @"mvc.1.0.view", @"/Views/Shared/_SearchPartial.cshtml")]
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
#nullable restore
#line 1 "C:\Users\LENOVO\Desktop\Back-end-project\Back-End\Back-End\Views\_ViewImports.cshtml"
using Back_End;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Back-end-project\Back-End\Back-End\Views\_ViewImports.cshtml"
using Back_End.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\Desktop\Back-end-project\Back-End\Back-End\Views\_ViewImports.cshtml"
using Back_End.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\LENOVO\Desktop\Back-end-project\Back-End\Back-End\Views\_ViewImports.cshtml"
using Back_End.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\LENOVO\Desktop\Back-end-project\Back-End\Back-End\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db3b23b0790a6347c51059248ffe25b4a97c691d", @"/Views/Shared/_SearchPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58a078de14807cd3e400faa6f7e3ce4dfa031dae", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\LENOVO\Desktop\Back-end-project\Back-End\Back-End\Views\Shared\_SearchPartial.cshtml"
 foreach (Product product in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"list-group-item\" style=\"margin-top:5px\">");
#nullable restore
#line 6 "C:\Users\LENOVO\Desktop\Back-end-project\Back-End\Back-End\Views\Shared\_SearchPartial.cshtml"
                                                  Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 7 "C:\Users\LENOVO\Desktop\Back-end-project\Back-End\Back-End\Views\Shared\_SearchPartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591

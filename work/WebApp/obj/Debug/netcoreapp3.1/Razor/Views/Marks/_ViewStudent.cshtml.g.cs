#pragma checksum "C:\Users\acer\source\repos\work\WebApp\Views\Marks\_ViewStudent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fc748f39e56ca289901a15cbdc0b2f331242f01"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Marks__ViewStudent), @"mvc.1.0.view", @"/Views/Marks/_ViewStudent.cshtml")]
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
#line 1 "C:\Users\acer\source\repos\work\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\acer\source\repos\work\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fc748f39e56ca289901a15cbdc0b2f331242f01", @"/Views/Marks/_ViewStudent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Marks__ViewStudent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<strong>Marks</strong>\r\n\r\n<br>\r\n<ul>\r\n");
#nullable restore
#line 8 "C:\Users\acer\source\repos\work\WebApp\Views\Marks\_ViewStudent.cshtml"
      
        if (ViewBag.ListStudents.Count != 0)
        {
            foreach (var mark in ViewBag.ListStudents)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("             <li>\r\n             ");
#nullable restore
#line 14 "C:\Users\acer\source\repos\work\WebApp\Views\Marks\_ViewStudent.cshtml"
        Write(mark);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 16 "C:\Users\acer\source\repos\work\WebApp\Views\Marks\_ViewStudent.cshtml"
            }
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("         <li>No Data Available</li>   \r\n");
#nullable restore
#line 21 "C:\Users\acer\source\repos\work\WebApp\Views\Marks\_ViewStudent.cshtml"
        }

    

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

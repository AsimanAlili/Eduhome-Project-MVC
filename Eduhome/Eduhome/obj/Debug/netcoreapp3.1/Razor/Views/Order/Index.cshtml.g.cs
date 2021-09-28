#pragma checksum "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00a8996a6fdf6d2046c74a00a57b54da1b074e5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\_ViewImports.cshtml"
using Eduhome.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\_ViewImports.cshtml"
using Eduhome.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\_ViewImports.cshtml"
using Eduhome.Data.Enum;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00a8996a6fdf6d2046c74a00a57b54da1b074e5b", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edf61a6619d3d28cc774772d50ab531f5189c14a", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

    double subTotal = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""table-responsive"">
        <table class=""table"">
            <thead>
                <tr>
                    <th class=""width-1"">Product Name</th>
                    <th class=""width-2"">Price</th>
                    <th class=""width-4"">Subtotal</th>
                    <th class=""width-4"">Date</th>
                    <th class=""width-4"">Status</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 22 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\Order\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <div class=\"o-pro-dec\">\r\n                            <p>");
#nullable restore
#line 27 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\Order\Index.cshtml"
                          Write(item.Course.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </td>\r\n                    <td>\r\n                        <div class=\"o-pro-dec\">\r\n                            <p>$ ");
#nullable restore
#line 32 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\Order\Index.cshtml"
                            Write(item.Course.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </td>\r\n                   \r\n                    <td>\r\n                        <div class=\"o-pro-dec\">\r\n                            <p>$");
#nullable restore
#line 38 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\Order\Index.cshtml"
                           Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </td>\r\n                    <td>\r\n                        <div class=\"o-pro-dec\">\r\n                            <p>");
#nullable restore
#line 43 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\Order\Index.cshtml"
                          Write(item.CreatedAt.AddHours(4).ToString("HH:mm dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </td>\r\n                    <td>\r\n                        <div class=\"o-pro-dec\">\r\n                            <p>");
#nullable restore
#line 48 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\Order\Index.cshtml"
                           Write(item.Status == OrderStatus.Pending?"pending":(item.Status == OrderStatus.Accepted?"accepted":"rejected"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                </tr>\r\n");
#nullable restore
#line 51 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\Order\Index.cshtml"

                    if (item.Status != OrderStatus.Rejected)
                    {
                        subTotal += item.Price;
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n            <tfoot>\r\n                <tr>\r\n                    <td colspan=\"3\">Subtotal </td>\r\n                    <td colspan=\"1\">$ ");
#nullable restore
#line 62 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Views\Order\Index.cshtml"
                                 Write(subTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n            </tfoot>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591

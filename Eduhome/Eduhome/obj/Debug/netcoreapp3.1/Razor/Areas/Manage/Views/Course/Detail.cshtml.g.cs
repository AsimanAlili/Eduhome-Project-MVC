#pragma checksum "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1adffb8260b046215d8043a035fb5e42bbe2dca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Course_Detail), @"mvc.1.0.view", @"/Areas/Manage/Views/Course/Detail.cshtml")]
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
#line 3 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\_ViewImports.cshtml"
using Eduhome.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\_ViewImports.cshtml"
using Eduhome.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\_ViewImports.cshtml"
using Eduhome.Data.Enum;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1adffb8260b046215d8043a035fb5e42bbe2dca", @"/Areas/Manage/Views/Course/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0f5a9866d3ba2af672309a7c526c4e13577e594", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Course_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Course>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-width:250px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("course image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "course", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success mt-md-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Areas/Manage/Views/Shared/_Layout.cshtml";
    List<Category> categories = ViewBag.Categories;
    List<Tag> tags = ViewBag.Tags;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <h2 style=\"color:green;font:bold\">Info</h2>\r\n    <div class=\"card-group\">\r\n        <div class=\"card\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c1adffb8260b046215d8043a035fb5e42bbe2dca6198", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 368, "~/uploads/courses/", 368, 18, true);
#nullable restore
#line 13 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
AddHtmlAttributeValue("", 386, Model.Photo, 386, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">Title: ");
#nullable restore
#line 15 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                         Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">Slug: ");
#nullable restore
#line 16 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                      Write(Model.Slug);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Desc: ");
#nullable restore
#line 17 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                      Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">About Desc: ");
#nullable restore
#line 18 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                            Write(Model.AboutDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Apply Desc: ");
#nullable restore
#line 19 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                            Write(Model.ApplyDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Certification Desc: ");
#nullable restore
#line 20 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                                    Write(Model.CertificationDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">About Desc: ");
#nullable restore
#line 21 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                            Write(Model.AboutDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Start: ");
#nullable restore
#line 22 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                       Write(Model.Start);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Duration: ");
#nullable restore
#line 23 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                          Write(Model.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Hours: ");
#nullable restore
#line 24 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                       Write(Model.Hours);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Skill Level: ");
#nullable restore
#line 25 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                             Write(Model.SkillLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Language: ");
#nullable restore
#line 26 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                          Write(Model.Language);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Student: ");
#nullable restore
#line 27 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                         Write(Model.Student);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Price: ");
#nullable restore
#line 28 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                       Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Category: ");
#nullable restore
#line 29 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                          Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <div class=\"card-text bg-light\" style=\"border-radius:5px\">\r\n                    Tags:\r\n");
#nullable restore
#line 32 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                     foreach (var item in tags)
                    {
                        if (tags[tags.Count - 1] != item)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p class=\"d-inline\">");
#nullable restore
#line 36 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(",</p>\r\n");
#nullable restore
#line 37 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p class=\"d-inline\">");
#nullable restore
#line 40 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 41 "C:\Users\HP\Desktop\p120_backend_project-AsimanAlili\Eduhome\Eduhome\Areas\Manage\Views\Course\Detail.cshtml"
                        }

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1adffb8260b046215d8043a035fb5e42bbe2dca15014", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Course> Html { get; private set; }
    }
}
#pragma warning restore 1591
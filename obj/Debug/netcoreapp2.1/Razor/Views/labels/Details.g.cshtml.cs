#pragma checksum "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7dfe4be879d51ee8dad4b647830a74803bd18df9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_labels_Details), @"mvc.1.0.view", @"/Views/labels/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/labels/Details.cshtml", typeof(AspNetCore.Views_labels_Details))]
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
#line 1 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\_ViewImports.cshtml"
using MyBlog;

#line default
#line hidden
#line 2 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\_ViewImports.cshtml"
using MyBlog.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dfe4be879d51ee8dad4b647830a74803bd18df9", @"/Views/labels/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b889b3f4308041dc292b61010b9c4781c7386c2", @"/Views/_ViewImports.cshtml")]
    public class Views_labels_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyBlog.Models.label>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_SideBar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_rightSideBar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("Blog_title"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Blogs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(28, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(120, 85, true);
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"C_container\" style=\"margin-top:20px;\">\r\n\r\n        ");
            EndContext();
            BeginContext(205, 27, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7600da28b3a44499bbc0510ea837981d", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(232, 12, true);
            WriteLiteral("\r\n\r\n        ");
            EndContext();
            BeginContext(244, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "392b605275c845baae8b985a71554f12", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(276, 61, true);
            WriteLiteral("\r\n        <div class=\"category_title\">\r\n            标签：<span>");
            EndContext();
            BeginContext(338, 36, false);
#line 14 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml"
                Write(Html.DisplayFor(Model => Model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(374, 25, true);
            WriteLiteral("</span>\r\n        </div>\r\n");
            EndContext();
#line 16 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml"
         foreach (var blog in Model.BlogLabels)
        {

#line default
#line hidden
            BeginContext(459, 48, true);
            WriteLiteral("            <div class=\"main\">\r\n                ");
            EndContext();
            BeginContext(507, 148, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "395965efbc5947649f3136c77dd13961", async() => {
                BeginContext(602, 49, false);
#line 19 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml"
                                                                                                         Write(Html.DisplayFor(modelItem => blog.Blog.BlogTitle));

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 19 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml"
                                                                                    WriteLiteral(blog.BlogId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(655, 175, true);
            WriteLiteral("\r\n                <div class=\"Blog_information\">\r\n                    <span class=\"Blog_Date\"><span class=\"glyphicon glyphicon-calendar\" style=\"margin-right:8px;\"></span>Date ");
            EndContext();
            BeginContext(831, 48, false);
#line 21 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml"
                                                                                                                        Write(Html.DisplayFor(modelItem => blog.Blog.PostTime));

#line default
#line hidden
            EndContext();
            BeginContext(879, 187, true);
            WriteLiteral("</span>\r\n                    <span class=\"Blog_category\"><span class=\"glyphicon glyphicon-folder-close\" style=\"margin-right:8px;\"></span>分类： <p style=\"display:inline-block; color:black;\">");
            EndContext();
            BeginContext(1067, 54, false);
#line 22 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml"
                                                                                                                                                                             Write(Html.DisplayFor(modelItem => blog.Blog.Catergory.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1121, 140, true);
            WriteLiteral("</p></span>\r\n                    <span class=\"comment_count\"><span class=\"glyphicon glyphicon-comment\" style=\"margin-right:8px;\"></span>评论： ");
            EndContext();
            BeginContext(1262, 52, false);
#line 23 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml"
                                                                                                                          Write(Html.DisplayFor(modelItem => blog.Blog.CommentCount));

#line default
#line hidden
            EndContext();
            BeginContext(1314, 97, true);
            WriteLiteral("</span>\r\n                </div>\r\n                <div class=\"Blog_content\">\r\n                    ");
            EndContext();
            BeginContext(1412, 49, false);
#line 26 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml"
               Write(Html.DisplayFor(modelItem => blog.Blog.BlogBrief));

#line default
#line hidden
            EndContext();
            BeginContext(1461, 46, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 29 "C:\Users\kxu30\source\repos\MyBlog\MyBlog\Views\labels\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(1518, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyBlog.Models.label> Html { get; private set; }
    }
}
#pragma warning restore 1591

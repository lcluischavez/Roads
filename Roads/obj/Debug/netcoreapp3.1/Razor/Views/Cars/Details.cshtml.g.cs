#pragma checksum "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee01ed570672ce6016b96b022d27533fd50ba239"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cars_Details), @"mvc.1.0.view", @"/Views/Cars/Details.cshtml")]
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
#line 1 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\_ViewImports.cshtml"
using Roads;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\_ViewImports.cshtml"
using Roads.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee01ed570672ce6016b96b022d27533fd50ba239", @"/Views/Cars/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a704ccbe267089027060b9a931a5ba2ad642a21", @"/Views/_ViewImports.cshtml")]
    public class Views_Cars_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Roads.Models.Car>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
  
    var currentUser = await UserManager.GetUserAsync(User);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>\r\n    ");
#nullable restore
#line 17 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
Write(Html.DisplayFor(model => model.Make));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
                                     Write(Html.DisplayFor(model => model.Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
                                                                            Write(Html.DisplayFor(model => model.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h1>\r\n<div>\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n");
            WriteLiteral("        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <image");
            BeginWriteAttribute("src", " src=\"", 558, "\"", 606, 1);
#nullable restore
#line 25 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
WriteAttributeValue("", 564, Html.DisplayFor(model => model.ImagePath), 564, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Product Image Unavailable\" width=\"545\" height=\"440\" />\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            <h5>Modifications</h5>\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PerformanceMods));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
       Write(Html.DisplayFor(model => model.PerformanceMods));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AstheticMods));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
       Write(Html.DisplayFor(model => model.AstheticMods));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Color));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
       Write(Html.DisplayFor(model => model.Color));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            By.\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
       Write(Html.DisplayFor(model => model.ApplicationUser.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n");
#nullable restore
#line 59 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
     if (Model.ApplicationUserId != currentUser.Id)
    {
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
   Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Luis Chavez\Desktop\workspace\Roads\Roads\Views\Cars\Details.cshtml"
                                                               
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee01ed570672ce6016b96b022d27533fd50ba2398858", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Roads.Models.Car> Html { get; private set; }
    }
}
#pragma warning restore 1591

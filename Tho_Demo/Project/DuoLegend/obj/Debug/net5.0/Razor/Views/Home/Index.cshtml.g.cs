#pragma checksum "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f782b55d8ec4f92ad781ec4db77e1894c12af9d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 3 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\_ViewImports.cshtml"
using DuoLegend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\_ViewImports.cshtml"
using DuoLegend.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\_ViewImports.cshtml"
using DuoLegend.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f782b55d8ec4f92ad781ec4db77e1894c12af9d7", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b14c78f6b2e13d76d840008201ea55b0f64d1c0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DuoLegend.ViewModels.MainPageViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/ThoMainPagestyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("modal fade"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("example"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""></script>
<script type=""text/javascript"">
    const { Alert } = require(""bootstrap"");

    function Choosing(previewPic) {
        previewPic.style.backgroundColor = ""#dc3545"";

    }
    function removeOtherChoosing(previewPic) {
        var x = document.getElementsByClassName(previewPic.className);
        if (previewPic.className == 'playPurposeOption') {
            for (i = 0; i < x.length; i++) {
                x[i].style.backgroundColor = ""#3835dc7a"";
            }
        } else {

            for (i = 0; i < x.length; i++) {
                x[i].style.backgroundColor = ""inherit"";
            }
        }

    }
</script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f782b55d8ec4f92ad781ec4db77e1894c12af9d75994", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d77108", async() => {
                WriteLiteral(@"
    <div class=""modal-dialog"">
        <!--Mọi thứ của modal(popup) sẽ nằm ở trong element có class ""modal-content""-->
        <div class=""modal-content"">
            <!--Đây là cái cục header của modal(popup)-->
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalTitle""></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"">
                    <!--%times; là character entity cho dấu ""x"" (hay còn gọi là cái cục đóng bên góc phải phía trên cùng ấy)-->
                    <span>&times;</span>
                </button>
            </div>
            <!--Đây là phần body của modal-->
            <!--Đây sẽ là phần mình để những ngôi sao để cho người ta click vào-->
            <div class=""modal-body"">
                You need to login to use this feature
            </div>
            <!--Đây là phần footer của modal-->
            <div class=""modal-footer"">
                <button style=""width: 5vw; font-size: 1.25vw;text-ali");
                WriteLiteral(@"gn: center; padding-left: 0; padding-right: 0"" type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <a style=""width: 5vw; font-size: 1.25vw;text-align: center; padding-left: 0; padding-right: 0"" href=""Account/RedirectLoginPage"" type=""button"" class=""btn btn-primary"">Login</a>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"backContainer\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d710004", async() => {
                WriteLiteral("\r\n        <center>\r\n            <div class=\"searchBar\">\r\n");
#nullable restore
#line 55 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                 if (ViewBag.isLogin)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <label for=\"submit\"><p style=\"margin-left: 0vw; margin-bottom: 0vw;\">Find your Duo</p></label>\r\n                    <input type=\"submit\"");
                BeginWriteAttribute("name", " name=\"", 2597, "\"", 2604, 0);
                EndWriteAttribute();
                WriteLiteral(" id=\"submit\" style=\"display: none;\">\r\n");
#nullable restore
#line 59 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <button data-toggle=\"modal\" data-target=\"#example\" type=\"button\" style=\"background-color: inherit; border: hidden\"><p style=\"margin-left: 0vw; margin-bottom: 0vw;\">Find your Duo</p></button>\r\n");
#nullable restore
#line 63 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </center>
        <br>

        <div class=""searchBar"">
            <fieldset id=""laneOption"">
                <center><h3 style=""color: white"">Choose duo's lane</h3></center>
                <label for=""topLane""><img class=""laneOptionLabel"" src=""img/Top_icon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""laneOption"" id=""topLane"" style=""display: none;"">

                <label for=""jungLane""><img class=""laneOptionLabel"" src=""img/Jung_icon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""laneOption"" id=""jungLane"" style=""display: none;"">

                <label for=""midLane""><img class=""laneOptionLabel"" src=""img/Mid_icon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""laneOption"" id=""midLane"" style=""display: none;"">

                <label for=""botLane""><img class=""laneOptionLabel"" src=""img/Bo");
                WriteLiteral(@"t_icon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""laneOption"" id=""botLane"" style=""display: none;"">

                <label for=""supLane""><img class=""laneOptionLabel"" src=""img/Sup_icon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""laneOption"" id=""supLane"" style=""display: none;"">
            </fieldset>
        </div>
        <div class=""searchBar"">
            <fieldset id=""rankOption"">
                <center><h3 style=""color: white"">Choose duo's rank</h3></center>
                <label for=""ironRank""><img class=""rankOptionLabel"" src=""img/ironIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""rankOption"" id=""ironRank"" style=""display: none;"">

                <label for=""bronzeRank""><img class=""rankOptionLabel"" src=""img/bronzeIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <i");
                WriteLiteral(@"nput type=""radio"" name=""rankOption"" id=""bronzeRank"" style=""display: none;"">

                <label for=""silverRank""><img class=""rankOptionLabel"" src=""img/silverIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""rankOption"" id=""silverRank"" style=""display: none;"">

                <label for=""goldRank""><img class=""rankOptionLabel"" src=""img/goldIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""rankOption"" id=""goldRank"" style=""display: none;"">

                <label for=""platinumRank""><img class=""rankOptionLabel"" src=""img/platinumIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""rankOption"" id=""platinumRank"" style=""display: none;"">

                <label for=""diamondRank""><img class=""rankOptionLabel"" src=""img/diamondIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""rad");
                WriteLiteral(@"io"" name=""rankOption"" id=""diamondRank"" style=""display: none;"">
                <label for=""masterRank""><img class=""rankOptionLabel"" src=""img/masterIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>

                <label for=""grandMasterRank""><img class=""rankOptionLabel"" src=""img/grandMasterIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""rankOption"" id=""grandMasterRank"" style=""display: none;"">

                <label for=""challengerRank""><img class=""rankOptionLabel"" src=""img/challengerIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                <input type=""radio"" name=""rankOption"" id=""challengerRank"" style=""display: none;"">
            </fieldset>
        </div>
        <div class=""searchBar"">
            <h3 style=""margin-left: 5vw; color: white"">Server</h3>
            <select>
                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d716059", async() => {
                    WriteLiteral("BR1");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d717087", async() => {
                    WriteLiteral("EUN1");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d718116", async() => {
                    WriteLiteral("EUW1");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d719145", async() => {
                    WriteLiteral("JP1");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d720173", async() => {
                    WriteLiteral("KR");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d721200", async() => {
                    WriteLiteral("LA1");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d722228", async() => {
                    WriteLiteral("LA2");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("OPTION", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d723256", async() => {
                    WriteLiteral("NA1");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("OPTION", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d724284", async() => {
                    WriteLiteral("OC1");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d725312", async() => {
                    WriteLiteral("RU");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f782b55d8ec4f92ad781ec4db77e1894c12af9d726339", async() => {
                    WriteLiteral("TR1");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </select>
        </div>
        <br>
        <div class=""searchBar"">
            <label for=""playToWin""><p class=""playPurposeOption"" onclick=""removeOtherChoosing(this),Choosing(this)"">Win is matter</p></label>
            <input type=""radio"" name=""playPurposeOption"" id=""playToWin"" style=""display: none;"">
            <label for=""playForFun""><p class=""playPurposeOption"" onclick=""removeOtherChoosing(this),Choosing(this)"">Fun is matter</p></label>
            <input type=""radio"" name=""playPurposeOption"" id=""playForFun"" style=""display: none;"">
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <br>


    <br>


    <br>
    <table>
        <tr>
            <th>Summoner</th>
            <th>Lane</th>
            <th>Rank</th>
            <th>Latest play</th>
            <th>Win Rate</th>
            <th>KDA</th>
            <th>Note</th>
            <th>Mic</th>

        </tr>
");
#nullable restore
#line 161 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
          for (int i = 0; i < 3; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 164 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                   Write(Model.InGameName[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><img src=\"img/Mid_icon.png\"></td>\r\n");
            WriteLiteral("                    <td>\r\n");
#nullable restore
#line 168 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                          
                            switch (@Model.Rank[i])
                            {
                                case "IRON":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img src=\"img/ironIcon.png\">\r\n");
#nullable restore
#line 173 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                    break;
                                case "BRONZE":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img src=\"img/BronzeIcon.png\">\r\n");
#nullable restore
#line 176 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                    break;
                                case "SILVER":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img src=\"img/silverIcon.png\">\r\n");
#nullable restore
#line 179 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                    break;
                                case "GOLD":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img src=\"img/goldIcon.png\">\r\n");
#nullable restore
#line 182 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                    break;
                                case "PLATINUM":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img src=\"img/platinumIcon.png\">\r\n");
#nullable restore
#line 185 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                    break;
                                case "MASTER":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img src=\"img/masterIcon.png\">\r\n");
#nullable restore
#line 188 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                    break;
                                case "GRANDMASTER":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img src=\"img/grandMasterIcon.png\">\r\n");
#nullable restore
#line 191 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                    break;
                                case "DIAMOND":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img src=\"img/diamondIcon.png\">\r\n");
#nullable restore
#line 194 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                    break;
                                case "CHALLENGER":

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img src=\"img/challengerIcon.png\">\r\n");
#nullable restore
#line 197 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                    break;
                                case "prod":

                                    break;
                                default:

                                    break;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 208 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                          for (int j = 0; j < 3; j++)
                            {
                                if (Model.ListUserInfor[i] is null) { }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>");
#nullable restore
#line 213 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                  Write(Model.ListUserInfor[i].champName[j]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 214 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                                }
                            }

                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 222 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                         if (Model.ListUserInfor[i] is null) { }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p>");
#nullable restore
#line 225 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                          Write(Model.ListUserInfor[i].WinRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 226 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 230 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                         if (Model.ListUserInfor[i] is null) { }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p>");
#nullable restore
#line 233 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                          Write(Model.ListUserInfor[i].Kill);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>");
#nullable restore
#line 234 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                          Write(Model.ListUserInfor[i].Death);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>");
#nullable restore
#line 235 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                          Write(Model.ListUserInfor[i].Assist);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 236 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>test</td>\r\n                    <td>test</td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 242 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Home\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DuoLegend.ViewModels.MainPageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

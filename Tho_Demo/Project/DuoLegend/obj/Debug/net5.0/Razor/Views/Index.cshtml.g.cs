#pragma checksum "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0aa055f57925d2cc37a0206a16f0c1d02777060b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Index), @"mvc.1.0.view", @"/Views/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0aa055f57925d2cc37a0206a16f0c1d02777060b", @"/Views/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b4f44f4c8b5e79045ae9162889695a08f7e0f40", @"/Views/_ViewImports.cshtml")]
    public class Views_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DuoLegend.ViewModels.MainPageViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/ThoMainPagestyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <script type=""text/javascript"">
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0aa055f57925d2cc37a0206a16f0c1d02777060b4150", async() => {
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
            WriteLiteral(@"
    <div class=""backContainer"">
        <form>
            <center>
                <div class=""searchBar"">
                    <label for=""submit""><p style=""margin-left: 0vw; margin-bottom: 0vw;"">Find your Duo</p></label>
                    <input type=""submit""");
            BeginWriteAttribute("name", " name=\"", 1051, "\"", 1058, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""submit"" style=""display: none;"">
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
                    <input type=""radio"" name=""laneOption"" id=""midLane"" style=""display: none");
            WriteLiteral(@";"">

                    <label for=""botLane""><img class=""laneOptionLabel"" src=""img/Bot_icon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
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

                    <label for=""bronzeRank""><");
            WriteLiteral(@"img class=""rankOptionLabel"" src=""img/bronzeIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                    <input type=""radio"" name=""rankOption"" id=""bronzeRank"" style=""display: none;"">

                    <label for=""silverRank""><img class=""rankOptionLabel"" src=""img/silverIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                    <input type=""radio"" name=""rankOption"" id=""silverRank"" style=""display: none;"">

                    <label for=""goldRank""><img class=""rankOptionLabel"" src=""img/goldIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                    <input type=""radio"" name=""rankOption"" id=""goldRank"" style=""display: none;"">

                    <label for=""platinumRank""><img class=""rankOptionLabel"" src=""img/platinumIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                    <input type=""radio"" name=""rankOption"" id=""platinumRank"" style=""display: none;"">

                    <label fo");
            WriteLiteral(@"r=""diamondRank""><img class=""rankOptionLabel"" src=""img/diamondIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                    <input type=""radio"" name=""rankOption"" id=""diamondRank"" style=""display: none;"">

                    <label for=""masterRank""><img class=""rankOptionLabel"" src=""img/masterIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                    <input type=""radio"" name=""rankOption"" id=""masterRank"" style=""display: none;"">

                    <label for=""grandMasterRank""><img class=""rankOptionLabel"" src=""img/grandMasterIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                    <input type=""radio"" name=""rankOption"" id=""grandMasterRank"" style=""display: none;"">

                    <label for=""challengerRank""><img class=""rankOptionLabel"" src=""img/challengerIcon.png"" onclick=""removeOtherChoosing(this),Choosing(this)""></label>
                    <input type=""radio"" name=""rankOption"" id=""challengerRank"" style=""dis");
            WriteLiteral(@"play: none;"">
                </fieldset>
            </div>
            <div class=""searchBar"">
                <h3 style=""margin-left: 5vw; color: white"">Server</h3>
                <select>
                    <option>BR1</option>
                    <option>EUN1</option>
                    <option>EUW1</option>
                    <option>JP1</option>
                    <option>KR</option>
                    <option>LA1</option>
                    <option>LA2</option>
                    <OPTION>NA1</OPTION>
                    <OPTION>OC1</OPTION>
                    <option>RU</option>
                    <option>TR1</option>
                </select>
            </div>
            <br>
            <div class=""searchBar"">
                <label for=""playToWin""><p class=""playPurposeOption"" onclick=""removeOtherChoosing(this),Choosing(this)"">Win is matter</p></label>
                <input type=""radio"" name=""playPurposeOption"" id=""playToWin"" style=""display: none;"">
              ");
            WriteLiteral(@"  <label for=""playForFun""><p class=""playPurposeOption"" onclick=""removeOtherChoosing(this),Choosing(this)"">Fun is matter</p></label>
                <input type=""radio"" name=""playPurposeOption"" id=""playForFun"" style=""display: none;"">
            </div>
        </form>
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
            <tr>
                <td>");
#nullable restore
#line 121 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Index.cshtml"
               Write(Model.inGameName[0]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                <td><img src=""img/Mid_icon.png""></td>
                <td><img src=""img/challengerIcon.png""></td>
                <td>test</td>
                <td>test</td>
                <td>test</td>
                <td>test</td>
                <td>test</td>

            </tr>
            <tr>
                <td>");
#nullable restore
#line 132 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Index.cshtml"
               Write(Model.inGameName[2]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                <td><img src=""img/Mid_icon.png""></td>
                <td><img src=""img/platinumIcon.png""></td>
                <td>test</td>
                <td>test</td>
                <td>test</td>
                <td>testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt</td>
                <td>test</td>

            </tr>
            <tr>
                <td>");
#nullable restore
#line 143 "E:\Hoc_tap_Dai_hoc\Summer_2021\SWP391\Project_DuoLegend\Tho_Demo\Project\DuoLegend\Views\Index.cshtml"
               Write(Model.inGameName[2]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                <td><img src=""img/Mid_icon.png""></td>
                <td>test</td>
                <td>test</td>
                <td>test</td>
                <td>test</td>
                <td>test</td>
                <td>test</td>

            </tr>
        </table>
    </div>");
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
#pragma checksum "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2819da9232fb885c0012e5a00025407ed8077a3"
// <auto-generated/>
#pragma warning disable 1591
namespace PayYourLight.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using PayYourLight;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using PayYourLight.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor"
using PayYourLight.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/editType/{id:int}")]
    public partial class Edit_TypeCompteur : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Type Compteur</h3>\r\n\r\n");
            __builder.OpenElement(1, "form");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "row");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "col-md-6");
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.OpenComponent<Radzen.Blazor.RadzenFieldset>(9);
            __builder.AddAttribute(10, "Text", "Enregistrement Client");
            __builder.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(12, "\r\n                ");
                __builder2.OpenElement(13, "div");
                __builder2.AddAttribute(14, "class", "row");
                __builder2.AddMarkupContent(15, "\r\n                    ");
                __builder2.AddMarkupContent(16, "<div class=\"col-md-4 align-items-center d-flex\">\r\n                        <label for=\"Name\" class=\"control-label\">Identifiant : </label>\r\n                    </div>\r\n                    ");
                __builder2.OpenElement(17, "div");
                __builder2.AddAttribute(18, "class", "col-md-8");
                __builder2.AddMarkupContent(19, "\r\n                        ");
                __builder2.OpenElement(20, "input");
                __builder2.AddAttribute(21, "style", "width: 100%;");
                __builder2.AddAttribute(22, "for", "Name");
                __builder2.AddAttribute(23, "class", "form-control");
                __builder2.AddAttribute(24, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 17 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor"
                                                                                            typeComp.Id

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(25, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => typeComp.Id = __value, typeComp.Id));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(26, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(27, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n                ");
                __builder2.OpenElement(29, "div");
                __builder2.AddAttribute(30, "class", "row");
                __builder2.AddMarkupContent(31, "\r\n                    ");
                __builder2.AddMarkupContent(32, "<div class=\"col-md-4 align-items-center d-flex\">\r\n                        <label for=\"Name\" class=\"control-label\">Designation : </label>\r\n                    </div>\r\n                    ");
                __builder2.OpenElement(33, "div");
                __builder2.AddAttribute(34, "class", "col-md-8");
                __builder2.AddMarkupContent(35, "\r\n                        ");
                __builder2.OpenElement(36, "input");
                __builder2.AddAttribute(37, "style", "width: 100%;");
                __builder2.AddAttribute(38, "for", "Name");
                __builder2.AddAttribute(39, "class", "form-control");
                __builder2.AddAttribute(40, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 25 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor"
                                                                                            typeComp.Designation

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(41, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => typeComp.Designation = __value, typeComp.Designation));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(42, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(43, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(44, "\r\n                <br>\r\n                ");
                __builder2.OpenElement(45, "div");
                __builder2.AddAttribute(46, "class", "row");
                __builder2.AddMarkupContent(47, "\r\n                    ");
                __builder2.AddMarkupContent(48, "<div class=\"col-md-4 align-items-center d-flex\">\r\n                        <label for=\"Name\" class=\"control-label\">Montant Mensuel : </label>\r\n                    </div>\r\n                    ");
                __builder2.OpenElement(49, "div");
                __builder2.AddAttribute(50, "class", "col-md-8");
                __builder2.AddMarkupContent(51, "\r\n                        ");
                __builder2.OpenElement(52, "input");
                __builder2.AddAttribute(53, "style", "width: 100%;");
                __builder2.AddAttribute(54, "for", "Name");
                __builder2.AddAttribute(55, "class", "form-control");
                __builder2.AddAttribute(56, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 34 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor"
                                                                                            typeComp.Montantmoi

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(57, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => typeComp.Montantmoi = __value, typeComp.Montantmoi));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(58, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(59, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(60, "\r\n                <br>\r\n                ");
                __builder2.OpenElement(61, "div");
                __builder2.AddAttribute(62, "class", "row");
                __builder2.AddMarkupContent(63, "\r\n                    ");
                __builder2.AddMarkupContent(64, "<div class=\"col-md-4 align-items-center d-flex\">\r\n                        <label for=\"Name\" class=\"control-label\">MontantAbonnement : </label>\r\n                    </div>\r\n                    ");
                __builder2.OpenElement(65, "div");
                __builder2.AddAttribute(66, "class", "col-md-8");
                __builder2.AddMarkupContent(67, "\r\n                        ");
                __builder2.OpenElement(68, "input");
                __builder2.AddAttribute(69, "style", "width: 100%;");
                __builder2.AddAttribute(70, "for", "Name");
                __builder2.AddAttribute(71, "class", "form-control");
                __builder2.AddAttribute(72, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 43 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor"
                                                                                            typeComp.MontantAbonnement

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(73, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => typeComp.MontantAbonnement = __value, typeComp.MontantAbonnement));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(74, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(75, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(76, "\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(77, "\r\n            ");
            __builder.OpenElement(78, "div");
            __builder.AddAttribute(79, "class", "row");
            __builder.AddMarkupContent(80, "\r\n                ");
            __builder.OpenElement(81, "div");
            __builder.AddAttribute(82, "class", "row justify-content-center");
            __builder.AddMarkupContent(83, "\r\n                    ");
            __builder.OpenElement(84, "div");
            __builder.AddAttribute(85, "class", "col-md-12 d-flex align-items-end justify-content-center");
            __builder.AddAttribute(86, "style", "margin-top: 16px;");
            __builder.AddMarkupContent(87, "\r\n                        ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(88);
            __builder.AddAttribute(89, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 50 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor"
                                                  ButtonType.Reset

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(90, "Icon", "save");
            __builder.AddAttribute(91, "Text", "Modifier");
            __builder.AddAttribute(92, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 50 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor"
                                                                                                        EditTypeComp

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(93, "\r\n                        ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(94);
            __builder.AddAttribute(95, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 51 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor"
                                                   ButtonStyle.Light

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(96, "Icon", "cancel");
            __builder.AddAttribute(97, "style", "display: inline-block; margin-left: 10px;");
            __builder.AddAttribute(98, "Text", "Annuler");
            __builder.AddAttribute(99, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 51 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor"
                                                                                                                                                             Cancel

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(100, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(101, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(102, "\r\n\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(103, "\r\n\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(104, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(105, "\r\n    ");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 61 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor"
           
        [Parameter]
        public int id { get; set; }
        ClsTypeComteurs typeComp = new ClsTypeComteurs();
        protected override async Task OnInitializedAsync()
        {
            typeComp = await TypeCls.SingleTypeCompteurs(id);
        }
        protected async Task EditTypeComp()
        {
            await TypeCls.EditTypeCompteur(id, typeComp);
            NavigationManager.NavigateTo("typecompteur");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("typecompteur");
        }
    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IClsTypeCompteur TypeCls { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591

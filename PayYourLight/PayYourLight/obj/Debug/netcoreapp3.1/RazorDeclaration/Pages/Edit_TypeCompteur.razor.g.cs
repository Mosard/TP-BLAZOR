#pragma checksum "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Edit_TypeCompteur.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2819da9232fb885c0012e5a00025407ed8077a3"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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

#pragma checksum "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\TypeCompteur.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d58d69d2bb8fad87157d8b0f5350865db668ce23"
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
#line 2 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\TypeCompteur.razor"
using PayYourLight.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/typecompteur")]
    public partial class TypeCompteur : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 120 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\TypeCompteur.razor"
       

    ClsTypeComteurs typeComp = new ClsTypeComteurs();
    ClsCompteurs comp = new ClsCompteurs();

    protected async Task CreateTypeCompteur()
    {
        await TypeCls.CreateTypeCompteur(typeComp);
        NavigationManager.NavigateTo("typecompteur");

    }

    protected async Task CreateCompteur()
    {
        await IComp.CreateCompteur(comp);
        NavigationManager.NavigateTo("typecompteur");

    }

    void cancel()
    {
        NavigationManager.NavigateTo("typecompteur");
    }



    IEnumerable<ClsTypeComteurs> type;
    IEnumerable<ClsTypeComteurs> compteurType;
    protected override async Task OnInitializedAsync()
    {
        compteurType = await TypeCls.GetTypeCompteur();
        type = await TypeCls.GetTypeCompteur();
    }







#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICompteur IComp { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IClsTypeCompteur TypeCls { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591

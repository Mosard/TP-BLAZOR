#pragma checksum "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\ClientForm.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1116c4abaab4ef9e784072bff09dd1b1bea8ddbf"
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
#line 1 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\ClientForm.razor"
using PayYourLight.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/addclient")]
    public partial class ClientForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 123 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\ClientForm.razor"
       
    ClsClients clients = new ClsClients();
    protected async Task CreateClient()
    {
        await ClsClient.CreateClients(clients);
        NavigationManager.NavigateTo("addclient");
        clients.Nom = "";
        clients.Postnom = "";
        clients.Prenom = "";
        clients.Email = "";
        clients.Telephone1 = "";
        clients.Telephone2 = "";

    }
    void cancel()
    {
        NavigationManager.NavigateTo("addclient");
        clients.Nom = "";
        clients.Postnom = "";
        clients.Prenom = "";
        clients.Email = "";
        clients.Telephone1 = "";
        clients.Telephone2 = "";
    }

    IEnumerable<ClsClients> client;
    protected override async Task OnInitializedAsync()
    {
        client = await ClsClient.GetClients();
    }


    private ClientForm _earningToDelete;
    public bool DeleteDialogOpen { get; set; }

    private void OpenDeleteDialog(ClientForm earning)
    {
        DeleteDialogOpen = true;
        _earningToDelete = earning;
        StateHasChanged();
    }






#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IClients ClsClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4da1a39d12094262194dc1e45a01e86ccb0023c"
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
#line 2 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Index.razor"
using PayYourLight.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Index.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 52 "C:\Users\Mosard salama\Desktop\SIWA MUMBERE C#\PayYourLight\PayYourLight\Pages\Index.razor"
      

    Timer timer;
    double hours;
    double minutes;
    double seconds;

    double minorStep = 12 / 60.0;

    double move = 338;
    double exercise = 2;
    double stand = 8;

    protected override void OnInitialized()
    {
        timer = new Timer(state =>
        {
            var now = DateTime.Now;

            hours = now.Hour % 12 + now.Minute / 60.0;

            minutes = now.Minute * minorStep + now.Second * 12 / 3600.0;
            seconds = now.Second * minorStep;

            InvokeAsync(StateHasChanged);
        }, null, 0, 1000);
    }

    public void Dispose()
    {
        timer.Dispose();
    }

    string userName = "admin";
    string password = "admin";
    string console;

    void OnLogin(LoginArgs args, string name)
    {
        console = ($"{name} -> Username: {args.Username} and password: {args.Password}");
    }

    void OnRegister(string name)
    {
        console = ($"{name} -> Register");
    }

    void OnResetPassword(string value, string name)
    {
        console = ($"{name} -> ResetPassword for user: {value}");
    }


    [Parameter]
    public int id { get; set; }
    ClsCompteurs Comp = new ClsCompteurs();
    IEnumerable<ClsCompteurs> type;
    protected override async Task OnInitializedAsync()
    {
        type = await IComp.GetCompteur();
    }
  


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICompteur IComp { get; set; }
    }
}
#pragma warning restore 1591
#pragma checksum "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41b8ab411ff625be0cbc3c4b894b607793c5e540"
// <auto-generated/>
#pragma warning disable 1591
namespace minitwit.Pages
{
    #line hidden
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/lvol/Desktop/E-vil-Corp/minitwit/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/lvol/Desktop/E-vil-Corp/minitwit/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/lvol/Desktop/E-vil-Corp/minitwit/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/lvol/Desktop/E-vil-Corp/minitwit/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/lvol/Desktop/E-vil-Corp/minitwit/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/lvol/Desktop/E-vil-Corp/minitwit/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/lvol/Desktop/E-vil-Corp/minitwit/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/lvol/Desktop/E-vil-Corp/minitwit/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/lvol/Desktop/E-vil-Corp/minitwit/_Imports.razor"
using minitwit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/lvol/Desktop/E-vil-Corp/minitwit/_Imports.razor"
using minitwit.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/public")]
    public partial class Timeline : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 7 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
 if (NavigationManager.Uri == MiniMain.Url_for("public timeline")) 

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
                                                                                        
     {
        

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "p");
            __builder.AddContent(1, 
#nullable restore
#line 10 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
            NavigationManager.Uri

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(2, "\n        ");
            __builder.AddMarkupContent(3, "<h2>Public Timeline</h2>");
#nullable restore
#line 12 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
     }
    else if ("request endpoint" == "user_timeline")
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(4, "<h2>{{ profile_user.username }}\'s Timeline</h2>");
#nullable restore
#line 16 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(5, "<h2>My Timeline</h2>");
#nullable restore
#line 20 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
     if (MiniMain.User != null)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
         if ("request endpoint" == "user timeline") 
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "followstatus");
#nullable restore
#line 29 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
             if (MiniMain.User == "profile_user.user_id")
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
                                  
            }
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
             if (false)
            {
                

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(8, "<a class=\"unfollow\" href=\"{{ url_for(\'unfollow_user\', username=profile_user.username)}}\">Unfollow user</a>");
#nullable restore
#line 38 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
            }
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
                            
            else
            {
                

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(9, "<a class=\"follow\" href=\"{{ url_for(\'follow_user\', username=profile_user.username)}}\">Follow user</a>");
#nullable restore
#line 44 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 46 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
        }
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
                                                       
        else if ("request.endport" == "timeline")
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(10, "<div class=\"twitbox\"><h3>What\'s on your mind {{ g.user.username }}?</h3>\n                <form action=\"{{ url_for(\'add_message\') }}\" method=\"post\"><input type=\"text\" name=\"text\" size=\"60\">\n                <input type=\"submit\" value=\"Share\"></form></div>");
#nullable restore
#line 57 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
         
    }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(11, "ul");
#nullable restore
#line 60 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
         if (MiniMain.Messages.ToList().Count == 0)
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(12, "<li><em>There\'s no messages so far</em></li>");
#nullable restore
#line 63 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
        }
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
                                       
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "/home/lvol/Desktop/E-vil-Corp/minitwit/Pages/Timeline.razor"
                                                                              
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMiniMain MiniMain { get; set; }
    }
}
#pragma warning restore 1591

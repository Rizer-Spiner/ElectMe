#pragma checksum "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64be3d9be4017ce010f1b08df31973d5aa592f3f"
// <auto-generated/>
#pragma warning disable 1591
namespace ElectMe_WebClient.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\_Imports.razor"
using ElectMe_WebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\_Imports.razor"
using ElectMe_WebClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using ElectMe_WebClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using ElectMe_WebClient.ECIES;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using ElectMe_WebClient.ECIES.KeyGeneration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using ElectMe_WebClient.ECIES.util;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using ElectMe_WebServer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using System.Net.Http.Headers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Hello, voter!</h1>\r\n\r\nAre you ready to vote?\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "aria-colspan", "12");
            __builder.AddAttribute(3, "align", "center");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(4);
            __builder.AddAttribute(5, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 24 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
                      identity

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 24 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
                                                HandleLoginAttempt

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(7, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 24 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
                                                                                      InvalidCredentials

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(9);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(10, "\r\n        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(11);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(12, "\r\n\r\n        ");
                __builder2.OpenElement(13, "div");
                __builder2.AddAttribute(14, "id", "cpr");
                __builder2.AddMarkupContent(15, "<div align=\"center\" aria-colspan=\"3\"> Cpr number:</div>\r\n            ");
                __builder2.OpenElement(16, "div");
                __builder2.AddAttribute(17, "align", "center");
                __builder2.AddAttribute(18, "aria-colspan", "9");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(19);
                __builder2.AddAttribute(20, "id", "Cpr nummer");
                __builder2.AddAttribute(21, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
                                                        identity.Cpr

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => identity.Cpr = __value, identity.Cpr))));
                __builder2.AddAttribute(23, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => identity.Cpr));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n\r\n        <br>\r\n        ");
                __builder2.OpenElement(25, "div");
                __builder2.AddAttribute(26, "id", "cpr");
                __builder2.AddMarkupContent(27, "<div align=\"center\" aria-colspan=\"3\"> Pin code:</div>\r\n            ");
                __builder2.OpenElement(28, "div");
                __builder2.AddAttribute(29, "align", "center");
                __builder2.AddAttribute(30, "aria-colspan", "9");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(31);
                __builder2.AddAttribute(32, "type", "password");
                __builder2.AddAttribute(33, "id", "Kode pin");
                __builder2.AddAttribute(34, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 39 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
                                                                      identity.Pin

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(35, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => identity.Pin = __value, identity.Pin))));
                __builder2.AddAttribute(36, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => identity.Pin));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(37, "\r\n\r\n        <br>\r\n\r\n        ");
                __builder2.AddMarkupContent(38, "<button type=\"submit\">Login</button>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 51 "D:\ralup\VIA\SCP\ElectMeProject\ElectMe WebClient\Pages\Index.razor"
 
    private Identity identity = new();

    private void HandleLoginAttempt()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:5001");
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("text/json"));
    // Task<CA> certificateTask = Http.GetFromJsonAsync<CA>("https://localhost:5001/connect");
    //
    // while (!certificateTask.IsCompleted)
    // {
    //     Console.WriteLine("Waiting for CA....");
    // }
    //
    // Console.WriteLine(certificateTask.Status.ToString());

    // CA certificate = certificateTask.Result;

        HttpResponseMessage responseMessage = httpClient.GetAsync("/connect").Result;


    // Parse the response body.


        var json = responseMessage.Content.ReadAsStringAsync().Result;
        
        JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
        jsonSerializerSettings.Converters.Add(new BigIntegerConverter());
        var initial = JsonConvert.DeserializeObject<InitialPackage>(json, jsonSerializerSettings);
        Console.WriteLine(initial.EllipticCurve.a);

        

    // if (verifyCA(certificate))
    // {
    //     ClientVariables.Puk = KeyGeneration.calculatePublicKey(ClientVariables.Prk, certificate.EllipticCurve.G, certificate.EllipticCurve);
    //     EllipticCurvePoint shareKey = KeyGeneration.calculatePublicKey(ClientVariables.Prk, certificate.ServerPuk, certificate.EllipticCurve);
    //
    //     ClientVariables.Kenc = KDF.DeriveKey(Encoding.ASCII.GetBytes(shareKey.x.ToString()), KDF.DefaultRoundsEnc);
    //     ClientVariables.KMac = KDF.DeriveKey(Encoding.ASCII.GetBytes(shareKey.x.ToString()), KDF.DefaultRoundsMac);
    //     
    //     AesEncryptionProvider aes = new AesEncryptionProvider(Encoding.ASCII.GetBytes(shareKey.x.ToString()));
    //     byte[] encryptedCredentials = aes.Encrypt(JsonConvert.SerializeObject(identity), certificate.NiosKey);
    //
    //     LoginForm loginForm = new()
    //     {
    //         ClientPuk = ClientVariables.Puk,
    //         EncryptedCredentials = Encoding.ASCII.GetString(encryptedCredentials)
    //     };
    //
    //     string signedLoginForm = signLoginForm(loginForm, certificate.ServerPuk);
    //     
    //     StringContent httpContent = new StringContent(signedLoginForm, Encoding.UTF8, "application/json");
    //
    //
    //     Task<HttpResponseMessage> loginResultTask =  Http.PostAsync("https://localhost:5001/ElectMe/login", httpContent);
    //
    //     while (!loginResultTask.IsCompleted)
    //     {
    //         Console.WriteLine("Waiting for Login response...");
    //     }
    //
    //     string loginResult = loginResultTask.Result.Content.ToString();
    //
    //     if (MAC.VerifyTag(Encoding.ASCII.GetBytes(loginResult), ClientVariables.KMac))
    //     {
    //         byte[] encryptedMessage = MAC.extractEncryptedContent(Encoding.ASCII.GetBytes(loginResult), ClientVariables.KMac);
    //         string jsonDecrypted = aes.Decrypt(encryptedMessage, ClientVariables.Kenc);
    //
    //         LoginResult result = JsonConvert.DeserializeObject<LoginResult>(jsonDecrypted);
    //
    //         if (result.Status.Equals(200))
    //         {
    //             NavManager.NavigateTo("/vote");
    //         }
    //         else
    //         {
    //             NavManager.NavigateTo("/error");
    //         }
    //
    //     }
    //     
    // }
    }

    private string signLoginForm(LoginForm loginForm, EllipticCurvePoint serverPuk)
    {
        return JsonConvert.SerializeObject(loginForm);
    }

    private bool verifyCA(InitialPackage certificate)
    {
        byte[] InitialPackagesignature = certificate.CertificateSignature;
        return true;
    }

    private void InvalidCredentials()
    {
        Console.WriteLine("Invalid Credentials");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591

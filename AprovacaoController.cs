using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RiscoSacado.Models;
using System.Text.Json;

namespace RiscoSacadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AprovacaoController : ControllerBase
    {
        private IConfiguration Configuration;

        static HttpClient client = new HttpClient();

        public AprovacaoController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public string AprovacaoCompra(string idCompraMonkey, string idCompraItemStatus)
        {
            //TokenResponse token = MonkeyService.GetToken(Configuration);
            Root listaItems = new Root();

            List<Item> items = new List<Item>();

            items.Add(new Item("CNX2ainyYF", 1, "APPROVED"));
            items.Add(new Item("IBj77aEYtV", 1, "APPROVED"));
            items.Add(new Item("IBj77aEYtV", 1, "APPROVED"));
            items.Add(new Item("WVfZoSxkht", 1, "APPROVED"));

            listaItems.items = items;

            var json = JsonSerializer.Serialize(listaItems);


            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://hmg-zuul.monkeyecx.com/v2/buyers/589215871/purchases/589215871/custodies-response"))
                {
                    request.Headers.TryAddWithoutValidation("authorization", "Bearer 62baddbc-425e-45c3-8360-061655a0acee");
                    request.Headers.TryAddWithoutValidation("program", "PROGRAMAMAISVALOR");

                    request.Content = new StringContent("{\"items\":[{\"id\":\"CNX2ainyYF\",\"installment\":1,\"status\":\"APPROVED\"},{\"id\":\"IBj77aEYtV\",\"installment\":1,\"status\":\"APPROVED\"},{\"id\":\"IBj77aEYtV\",\"installment\":1,\"status\":\"APPROVED\"},{\"id\":\"WVfZoSxkht\",\"installment\":1,\"status\":\"APPROVED\"}]}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");



                    HttpResponseMessage response = httpClient.SendAsync(request).Result;

                    HttpContent content = response.Content;

                    var jsonResponse = content.ReadAsStringAsync().Result;


                }
            }

            return "foi_" + idCompraMonkey + "_" + idCompraItemStatus;
        }
    }


    public class Root
    {
        public List<Item> items { get; set; }
    }

    public class Item
    {
        public Item(string id, int installment, string status)
        {
            this.id = id;
            this.installment = installment;
            this.status = status;
        }

        public string id { get; set; }
        public int installment { get; set; }
        public string status { get; set; }

    }
}

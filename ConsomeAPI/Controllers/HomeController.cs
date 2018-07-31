using ConsomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConsomeAPI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            IList<UsuarioModel> result = await PesquisaPessoa("S", null, null);

            var qtdResultado = result.Count;
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        private async Task<IList<UsuarioModel>> CadastraPessoa(string nome, bool? ativo, DateTime? dtNascimento)
        {
            IEnumerable<KeyValuePair<string, string>> postData;
            string endereco = "http://localhost:27174/api/Usuario/";

            try
            {
                using (var client = new HttpClient())
                {
                    postData = new[]
                    {
                         new KeyValuePair<string, string>("Nome", nome)
                        ,new KeyValuePair<string, string>("Ativo", ativo.ToString())
                        ,new KeyValuePair<string, string>("DtNascimento", dtNascimento.ToString())
                    };

                    using (var content = new FormUrlEncodedContent(postData))
                    {
                        content.Headers.Clear();
                        content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                        HttpResponseMessage response = await client.PostAsync(endereco, content);

                        return await response.Content.ReadAsAsync<IList<UsuarioModel>>();
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private async Task<IList<UsuarioModel>> PesquisaPessoa(string nome, bool? ativo, DateTime? dtNascimento)
        {
            IEnumerable<KeyValuePair<string, string>> postData;
            string endereco = "http://localhost:27174/api/Usuario/Pesquisa/";

            try
            {
                using (var client = new HttpClient())
                {
                    postData = new[]
                    {
                         new KeyValuePair<string, string>("Nome", nome)
                        ,new KeyValuePair<string, string>("Ativo", ativo.ToString())
                        ,new KeyValuePair<string, string>("DtNascimento", dtNascimento.ToString())
                    };

                    using (var content = new FormUrlEncodedContent(postData))
                    {
                        content.Headers.Clear();
                        content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                        HttpResponseMessage response = await client.PostAsync(endereco, content);

                        response.EnsureSuccessStatusCode();

                        var result = await response.Content.ReadAsAsync<IList<UsuarioModel>>();

                        return result;
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
    }
}
using AppFuncionario.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppFuncionario.Repositories
{
    public class PessoaRepository
    {
        HttpClient cliente = new HttpClient();

        public PessoaRepository()
        {
            cliente.BaseAddress = new Uri("http://dummy.restapiexample.com/");
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string BaseUrl
        {
            get
            {
                return "http://dummy.restapiexample.com/";
            }
        }

 

        public async Task<List<PessoaModel>> GetPessoasAsync()
        {
            try
            {
                HttpResponseMessage response = await cliente.GetAsync("api/v1/employees");
                if (response.IsSuccessStatusCode)
                {
                    var dados = await response.Content.ReadAsStringAsync();

                    var ret = JsonConvert.DeserializeObject<PessoaRetorno>(dados);

                    return ret.data.ToList();
                }
                return new List<PessoaModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PessoaModel> GetPessoas()
        {
            string MetodoPath = "api/v1/employees"; //caminho do método a ser chamado

            IList <PessoaModel> pessoas= new List<PessoaModel>();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(BaseUrl + MetodoPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<PessoaRetorno>(streamReader.ReadToEnd());
      
                    if (retorno.status == "success")
                    {
                        return retorno.data.ToList();
                    } else
                    {
                        return new List<PessoaModel>();
                    }
                    

                }

               
            }
            catch (Exception e)
            {
                throw e;
            }

            
        }
    }
}
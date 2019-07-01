using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAppDemo.Models;

namespace WebAppDemo.HttpClients
{
    public class FilmeApiClient
    {
        private readonly HttpClient _httpClient;
        public FilmeApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Filme>> GetFilmeAsync()
        {
            List<Filme> filme = new List<Filme>();
            HttpResponseMessage resposta = null;
            resposta = await _httpClient.GetAsync("http://copadosfilmes.azurewebsites.net/api/filmes");
            if (resposta.IsSuccessStatusCode)
            {
                var retorno = await resposta.Content.ReadAsStringAsync();
                filme = JsonConvert.DeserializeObject<List<Filme>>(retorno);
            }
            return filme;
        }
    }
}


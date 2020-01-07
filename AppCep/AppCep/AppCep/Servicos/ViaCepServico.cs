using AppCep.Servicos.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AppCep.Servicos
{
    public class ViaCepServico
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscaEnderecoViaCep(string cep)
        {
            string novoEnderecoUrl = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);
            return end;
        }
    }
}

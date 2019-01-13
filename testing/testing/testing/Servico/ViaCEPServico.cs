using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using testing.Servico.Modelo;
using Newtonsoft.Json;

namespace testing.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();

            string Conteudo = wc.DownloadString(NovoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}

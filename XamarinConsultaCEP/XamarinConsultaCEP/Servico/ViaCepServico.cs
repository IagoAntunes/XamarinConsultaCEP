using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using XamarinConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace XamarinConsultaCEP.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderedoViaCep(string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoUrl);//Recebe dados do site

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);//Converter JSON para objeto
            if(end.cep == null)
                return null;

            return end;
        }
        
    }
}

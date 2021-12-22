using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinConsultaCEP.Servico.Modelo;
using XamarinConsultaCEP.Servico;

namespace XamarinConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();
            if (isValidCep(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderedoViaCep(cep);
                    if (end != null)
                        Resultado.Text = string.Format("Endereco: \n{0} \n{1} \n{2} \n{3}", end.localidade, end.uf, end.logradouro, end.bairro);
                    else
                        DisplayAlert("Erro", "Endereco nao encotnrado", "Ok");
                }catch(Exception ex)
                {
                    DisplayAlert("ERRO", ex.Message, "Ok");
                }
            }
        }
        private bool isValidCep(string cep)
        {
            Boolean valido = true;

            if(cep.Length != 8)
            {
                //ERRO
                DisplayAlert("ERRO", "CEP deve ter 8 caracteres.", "Ok");
                valido = false;
            }
            int NovoCep = 0;

            if (!int.TryParse(cep, out NovoCep))
            {
                //ERRO
                valido = false;
                DisplayAlert("ERRO", "CEP deve ser composto apenas por numeros.", "Ok");
            }

            return valido;
        }
    }
}

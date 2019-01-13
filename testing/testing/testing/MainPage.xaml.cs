using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using testing.Servico.Modelo;
using testing.Servico;

namespace testing
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscarCep.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            string cep = edtCep.Text.Trim();

            if (VerifyCep(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        lblEndereco.Text = string.Format("Cep: {4}\nCidade: {0}\nEstado: {1}\nBairro: {2}\nRua: {3}", end.localidade, end.uf, end.bairro, end.logradouro, end.cep);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "CEP Invalido! Este CEP é inexistente", "OK");
                    }
                }catch(Exception e)
                {
                    DisplayAlert("Erro Crítico!", e.Message, "OK");
                }
            }
        }
        private bool VerifyCep(string cep)
        {
            bool valido = true;
            string MsgErro = "";

            if(cep.Length != 8){
                MsgErro = MsgErro + " O CEP deve ser composto por 8 caracters";

                valido = false;
            }

            int NovoCEP = 0;

            if(!int.TryParse(cep, out NovoCEP))
            {
                if (MsgErro.Length != 0)
                {
                    MsgErro = MsgErro + " e deve conter apenar números";
                }
                else
                {
                    MsgErro = MsgErro + " CEP deve conter apenar números";
                }

                valido = false;
            }

            if (!valido)
            {
                DisplayAlert("ERRO", "CEP Inválido!" + MsgErro + ".", "OK");
            }

            return valido;
        }
    }
}

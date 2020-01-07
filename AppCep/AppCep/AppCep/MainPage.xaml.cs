using AppCep.Servicos;
using AppCep.Servicos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Buscar.Clicked += BuscarCep;
        }

        private void BuscarCep(Object sender, EventArgs args)
        {
            string cep = "";
            try
            {
                 cep = Cep.Text.Trim();
            }
            catch(NullReferenceException nEx)
            {
                Resultado.Text = "Insira um Cep";
                return;
            }
            
            try
            {
                Endereco end = ViaCepServico.BuscaEnderecoViaCep(cep);

                Resultado.Text = $"Cidade: {end.Localidade} \r\n" +
                    $"UF: {end.Uf} \r\n" +
                    $"Logradouro: {end.Logradouro} \r\n" +
                    $"Bairro: {end.Bairro} \r\n";
            }
            catch (Exception ex)
            {
                Resultado.Text = "";
                DisplayAlert("ERRO", $"ERRO: {ex.Message}","OK");
            }          

        }
    }
}

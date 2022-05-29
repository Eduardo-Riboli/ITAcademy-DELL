using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademy
{
    public class Medicamentos
    {
        public string Substancia { get; set; }
        public string CNPJ { get; set; }
        public string Laboratorio { get; set; }
        public string CodGgrem { get; set; }
        public string Registro { get; set; }
        public string EAN1 { get; set; }
        public string EAN2 { get; set; }
        public string EAN3 { get; set; }
        public string Produto { get; set; }
        public string Apresentacao { get; set; }
        public string ClasseTerapeutica { get; set; }
        public string TipoProdutoStatus { get; set; }
        public string RegimePreco { get; set; }
        public string PFSemImposto { get; set; }
        public string PF0 { get; set; }
        public string PF12 { get; set; }
        public string PF17 { get; set; }
        public string PF17ALC { get; set; }
        public string PF17E5 { get; set; }
        public string PF17E5ALC { get; set; }
        public string PF18 { get; set; }
        public string PF18ALC { get; set; }
        public string PF20 { get; set; }
        public string PMC0 { get; set; }
        public string PMC12 { get; set; }
        public string PMC17 { get; set; }
        public string PMC17ALC { get; set; }
        public string PMC17E5 { get; set; }
        public string PMC17E5ALC { get; set; }
        public string PMC18 { get; set; }
        public string PMC18ALC { get; set; }
        public string PMC20 { get; set; }
        public string RestricaoHospitalar { get; set; }
        public string CAP { get; set; }
        public string CONFAZ87 { get; set; }
        public string ICMS0 { get; set; }
        public string AnaliseRecursal { get; set; }
        public string ListaConcessao { get; set; }
        public string Comercializacao2020 { get; set; }
        public string Tarja { get; set; }

        public string getNome()
        {
            string nome = string.Empty;

            string[] SubstanciaSeparada = Substancia.Split(';');
            foreach (string substancia in SubstanciaSeparada)
            {
                nome += substancia + ", ";
            }
            return nome;
        }

        public string getProduto()
        {
            return Produto;
        }

        public string getApresentacao()
        {
            return Apresentacao;
        }

        public string getValorPFSemImposto()
        {
            return PFSemImposto;
        }

        public override string ToString()
        {
            return "Substância: " + getProduto() +
                   "\nCNPJ: " + CNPJ +
                   "\nLaboratorio: " + Laboratorio +
                   "\nCódigo GGREM: " + CodGgrem +
                   "\nRegistro: " + Registro +
                   "\nEAN 1: " + EAN1 +
                   "\nEAN 2: " + EAN2 +
                   "\nEAN 3: " + EAN3 +
                   "\nProduto: " + Produto +
                   "\nApresentação: " + Apresentacao +
                   "\nClasse Terapeutica: " + ClasseTerapeutica +
                   "\nTipo Produto Status: " + TipoProdutoStatus +
                   "\nRegime Preço: " + RegimePreco +
                   "\nPF Sem Imposto: " + PFSemImposto +
                   "\nPF 0%: " + PF0 +
                   "\nPF 12%: " + PF12 +
                   "\nPF 17%: " + PF17 +
                   "\nPF 17% ALC: " + PF17ALC +
                   "\nPF 17,5%: " + PF17E5 +
                   "\nPF 17,5% ALC: " + PF17E5ALC +
                   "\nPF 18%: " + PF18 +
                   "\nPF 18% ALC: " + PF18ALC +
                   "\nPF 20%: " + PF20 +
                   "\nPMC 0%: " + PMC0 +
                   "\nPMC 12%: " + PMC12 +
                   "\nPMC 17%: " + PMC17 +
                   "\nPMC 17% ALC: " + PMC17ALC +
                   "\nPMC 17,5%: " + PMC17E5 +
                   "\nPMC 17,5% ALC: " + PMC17E5ALC +
                   "\nPMC 18%: " + PMC18 +
                   "\nPMC 18% ALC: " + PMC18ALC +
                   "\nPMC 20%: " + PMC20 +
                   "\nRestrição Hospitalar: " + RestricaoHospitalar +
                   "\nCAP: " + CAP +
                   "\nCONFAZ 87: " + CONFAZ87 +
                   "\nICMS 0%: " + ICMS0 +
                   "\nAnalise Recursal: " + AnaliseRecursal +
                   "\nLista Concessão: " + ListaConcessao +
                   "\nComercialização 2020: " + Comercializacao2020 +
                   "\nTarja: " + Tarja;
        }
    }

    
}

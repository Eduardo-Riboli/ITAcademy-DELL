using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace ITAcademy
{
    public class Program
    {
        // Utiliza-se o método Main para a execução principal do programa.
        public static void Main(string[] args)
        {
            // Chama-se o método Menu() que, a partir dele, o programa será executado de acordo com a opção selecionada pelo usuário.
            Menu();
            // Uiliza-se o Console.ReadKey() para o console não encerrar automáticamente após realizar suas atividades.
            Console.ReadKey();
        }

        // Cria-se o método Menu() onde ficará armazenadas as opções e as possíveis escolhas do usuário.
        public static void Menu()
        {
            // Abaixo está as opções disponíveis para o usuário digitar.
            Console.WriteLine("Digite o número da opção selecionada abaixo:");
            Console.WriteLine("1 - [Consultar medicamentos pelo nome]");
            Console.WriteLine("2 - [Buscar pelo código de barras]");
            Console.WriteLine("3 - [Comparativo da lista de concessão de crédito (PIS/COFINS)]");
            Console.WriteLine("4 - [Sair do programa]");
            Console.WriteLine();

            // Utiliza-se um try/catch para caso ocorra alguma excessão, ela será identificada e tratada.
            try
            {
                // Pede para o usuário digitar o número correspondente à opção que desejar e armazena na variável opção.
                Console.Write("Número digitado: ");
                int option = int.Parse(Console.ReadLine());

                // Realiza um switch para verificar o número digitado pelo usuário e assim, chamar o método daquela opção.
                switch (option)
                {
                    // Se o usuário digitar 1, será executado o método ConsultarMedicamentos();
                    case 1:
                        ConsultarMedicamentos();
                        break;
                    // Caso o usuário digite 2, será executado o método BuscarCódigoDeBarra();
                    case 2:
                        BuscarCodigoDeBarra();
                        break;
                    // Caso 3, será executado o método ComparativoListaConcessao();
                    case 3:
                        ComparativoListaConcessao();
                        break;
                    // E foi adicionado a opção 4, que encerra o terminal, caso o usuário deseje.
                    case 4:
                        Environment.Exit(1);
                        break;
                    // Caso o usuário não digite nenhum número das opções acima, ele mostrata uma mensagem no console relatando que o
                    // número inserido é inválido e mostrará novamente o Menu();
                    default:
                        Console.WriteLine("Você digitou uma opção inválida, por favor, digite novamente!");
                        Console.WriteLine();
                        Menu();
                        break;
                }
            }
            catch
            {
                // Caso o usuário não digite um número, mostrará uma mensagem no console e executará o método Menu(), mostrando assim, as
                // opções novamente para que o usuário possa fazer a escolha correta.
                Console.WriteLine("Você não digitou um número, por favor, digite novamente!");
                Console.WriteLine();
                Menu();
            }
            
        }

        public static void ConsultarMedicamentos()
        {
            // Solicita o nome do medicamento para o usuário e armazena em uma variável, convertendo toda palavra para letra maiúscula.
            Console.Write("Por favor, informe o nome do medicamento que desejar: "); 
            string nomeMedicamento = Console.ReadLine().ToUpper();

            // Instância-se uma lista da classe Medicamentos e atribui a ela a lista resultante do método ObterMedicamento();
            List<Medicamentos> listaDeMedicamentos = ObterMedicamentos();

            // Se essa lista não for nula, ele executará o método.
            if (listaDeMedicamentos != null)
            {
                // Utiliza-se um try para caso haja alguma exceção, ela ser direcionada ao catch para ser tratada.
                try
                {
                    // No foreach busca-se cada medicamento da classe Medicamento dentro da lista medicamento.
                    foreach (Medicamentos medicamento in listaDeMedicamentos)
                    {
                        // Se o medicamento encontrado conter o nome do medicamento digitado pelo usuário e for comercializado
                        // no ano de 2020, essa condição será verdadeira e mostrará na tela os campos solicitados. 
                        if (medicamento.Substancia.Contains(nomeMedicamento) && medicamento.Comercializacao2020.Equals("Sim"))
                        {
                            Console.WriteLine("Medicamento: {0} Produto: {1}, Apresentação: {2} e Valor PF S/ Imposto: {3}",
                                medicamento.getNome(), medicamento.getProduto(), medicamento.getApresentacao(), medicamento.getValorPFSemImposto());
                        }
                    }
                }
                // Caso ocorrer alguma exceção, ela será tratada aqui.
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            } 
            else
            {
                // Caso a lista for nula, será mostrado uma mensagem informando esse problema.
                Console.WriteLine("Não foi possível encontrar valores de medicamentos!");
            }
        }

        // Método que busca pelo código de barra todas as informações daquele medicamento, o maior, menor e a diferença dos PCM 0%;
        public static void BuscarCodigoDeBarra()
        {
            // Solicita ao usuário que digite o código de barras do produto desejado.
            Console.Write("Por favor, digite o código de barras do produto que desejar: ");
            string codigoDeBarra = Console.ReadLine();

            // Instância uma lista da classe Medicamentos obtendo uma lista de medicamentos do método ObterMedicamentos();
            List<Medicamentos> listaDeMedicamentos = ObterMedicamentos();
            // Instância uma lista de valores double para armazenar os PMC;
            List<double> PCM = new List<double>();

            // Se a lista de medicamentos não for nula, ele executará o código abaixo.
            if (listaDeMedicamentos != null)
            {
                try
                {
                    // Verifica cada medicamento na lista de medicamentos.
                    foreach (Medicamentos medicamento in listaDeMedicamentos)
                    {
                        // Se a coluna EAN1 for igual ao código de barra digitado pelo usuário, ele adicionará o PCM 0% desse
                        // medicamento à lista PCM e imprimirá na tela todas as informações referente a esse medicamento.
                        if (medicamento.EAN1.Equals(codigoDeBarra))
                        {
                            PCM.Add(double.Parse(medicamento.PMC0)); //ex: 7899640809806
                            //Console.WriteLine(medicamento.ToString());
                        }
                    }

                    // Cria-se duas variáveis para armazenar o valor do PCM máximo e mínimo.
                    double maiorPcm = PCM.Max();
                    double menorPcm = PCM.Min();
                    // Caso o valor do menor PCM for igual ao valor do maior, atribui-se o valor do menor igual a 0;
                    menorPcm = menorPcm != maiorPcm ? menorPcm : 0;

                    // Imprime na tela o valor do maior PCM, do menor PCM e a diferença de ambos.
                    Console.WriteLine("\nO maior valor do PMC 0% é: {0}" +
                                      "\nO menor valor do PMC 0% é: {1} " +
                                      "\nA diferença entre os dois PCM 0% é: {2}",
                                      maiorPcm, menorPcm, maiorPcm - menorPcm);
                }
                // Caso haja alguma exceção, ele mostrará ela e fara o tratamento necessário.
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            // Caso a lista de medicamentos for nula, ele mostrará essa mensagem falando que não há valores na lista. 
            else
            {
                Console.WriteLine("Não foi possível encontrar valores de medicamentos!");
            }
        }

        // Cria-se o método ComparativoListaConcessao() para a realização da atividade 3.
        public static void ComparativoListaConcessao()
        {
            // Instância-se a lista da classe medicamentos e atribui o seu valor a lista de resultados do método ObterMedicamentos();
            List<Medicamentos> listaDeMedicamentos = ObterMedicamentos();
            // Instância-se a lista de string para armazenar os valores dos medicamentos comercializados em 2020.
            List<string> listaDeMedicamentos2020 = new List<string>();

            // Se a lista de medicamentos não for nula, ele executará o resto do código.
            if (listaDeMedicamentos != null)
            {
                // Utiliza-se o try para caso houver alguma exceção, ela ser tratada no catch.
                try
                { 
                    // Ele verifica cada medicamento da classe Medicamentos na lista de medicamentos.
                    foreach (Medicamentos medicamento in listaDeMedicamentos)
                    {
                        // Verifica se o medicamento foi cormecializado em 2020.
                        if (medicamento.Comercializacao2020.Equals("Sim"))
                        {
                            // Se ele foi comercializado, ele armazena na lista de mercadorias de 2020 o valor da lista de concessão desse medicamento.
                            listaDeMedicamentos2020.Add(medicamento.ListaConcessao);
                        }
                    }

                    // Cria-se três variáveis inteiras para armazenar a quantidade de concessões negativas, positivas e neutras.
                    int quantidadeNegativa = 0;
                    int quantidadePositiva = 0;
                    int quantidadeNeutra = 0;

                    // Verifica-se cada lista de concessão dentro da lista de medicamentos de 2020.
                    foreach (string listaConcessao in listaDeMedicamentos2020)
                    {
                        // Se a lista de concessão tiver seu valor igual a "Negativa", acrescenta +1 na quantidadeNegativa.
                        if (listaConcessao.Equals("Negativa"))
                        {
                            quantidadeNegativa += 1;
                        }
                        // Se a lista de concessão tiver seu valor igual a "Positiva", acrescenta +1 na quantidadePositiva.
                        else if (listaConcessao.Equals("Positiva"))
                        {
                            quantidadePositiva += 1;
                        }
                        // Caso não for Negativa ou Positiva, sobrará a concessão "Neutra", assim acrescenta +1 na quantidadeNeutra
                        else
                        {
                            quantidadeNeutra += 1;
                        }
                    }

                    // Cria-se 3 variáveis para armazenar a porcentagem de cada concessão em relação ao total de medicamentos de 2020.
                    // Para isso, utiliza-se o método PercentualClassificacao() que recebe como parâmetro a quantidade de concessão 
                    // e a listas de medicamentos de 2020, para assim calcular a porcentagem.
                    double percentualNegativa = PercentualClassificacao(quantidadeNegativa, listaDeMedicamentos2020);
                    double percentualPositiva = PercentualClassificacao(quantidadePositiva, listaDeMedicamentos2020);
                    double percentualNeutra = PercentualClassificacao(quantidadeNeutra, listaDeMedicamentos2020); 

                    // Por fim, imprimi na tela a classificação com seu respectivo percentual e o gráfico representado pelo asterisco que é
                    // criado pelo método ContadorGrafico() recebendo como parâmetro o percentual de cada concessão.
                    // Cada asterisco representa 1 número percentual.
                    Console.Write("CLASSIFICAÇÃO            PERCENTUAL          GRAFICO");
                    Console.Write("\nNegativa                 " + percentualNegativa.ToString("N2", CultureInfo.InvariantCulture) + "%              " + ContadorGrafico(percentualNegativa));
                    Console.Write("\nNeutra                   " + percentualNeutra.ToString("N2", CultureInfo.InvariantCulture) + "%               " + ContadorGrafico(percentualNeutra));
                    Console.Write("\nPositiva                 " + percentualPositiva.ToString("N2", CultureInfo.InvariantCulture) + "%              " + ContadorGrafico(percentualPositiva));
                }
                // Caso ocorra alguma exceção, ela será mostrada e tratada no catch.
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // Caso a lista de medicamentos for nula, ele mostrará essa mensagem falando que não há valores na lista.
            else 
            {
                Console.WriteLine("Não foi possível encontrar valores de medicamentos!");
            }
        }

        // Método para realizar a contagem percentual de cada classificação da concessão.
        public static double PercentualClassificacao(int quantidadeClassificacao, List<string> listaDeMedicamentos2020)
        {
            // Pega-se a quantidade da classificação declarada como parâmetro no método, multiplica por 1.0 para transformar o resultado em double,
            // divide pela quantidade de elementos da lista de medicamentos de 2020 e, por fim, multiplica por 100 para ficar na forma percentual padrão.
            double porcentagem = (quantidadeClassificacao * 1.0 / listaDeMedicamentos2020.Count) * 100;

            // retorna o resultado da porcentagem.
            return porcentagem;
        }

        // Método para realizar a contagem de números na forma percentual e transformar cada número em um *.
        public static string ContadorGrafico(double percentual)
        {
            // Cria-se uma variável string vazia.
            string asterisco = string.Empty;

            // Realiza um laço de repetição. Enquanto a variável i for menor que o percentual, ele adicionará um * na string asterisco.
            for (int i = 0; i < percentual; i++)
            {
                asterisco += '*';
            }

            // Retorará a string asterisco com todos os * daquele percentual.
            return asterisco;
        }

        // Método para ler o arquivo excel, cada coluna do mesmo e retornar uma lista com os resultados.
        public static List<Medicamentos> ObterMedicamentos()
        {
            // Cria-se uma variável chamada de path para armazenar o diretório do arquivo xls.
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "teste.xls");
            // Utiliza-se uma classe de conexão de banco de dados da microsoft para instanciar o arquivo e relacioná-lo a uma planilha do excel.
            OleDbConnection connection = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + path + " ; Extended Properties = 'Excel 8.0;HDR=YES;'");
            // Cria-se um comando de banco de dados (SQL) para ler todos os campos da planilha do excel, localizada na variável path.
            string commandSql = "Select * from [Planilha1$]";
            // Instância-se a classe de comando de dados da microsoft que recebe como parâmetro o comando do sql e a conexão com a planilha, para ler a mesma e executar o comando descrito.
            OleDbCommand command = new OleDbCommand(commandSql, connection);

            // Instância uma lista da classe Medicamentos.
            List<Medicamentos> listDeMedicamentos = new List<Medicamentos>();

            try
            {
                // Pegamos a conexão e abrimos ela para executar a leitura da planilha.
                connection.Open();
                // Instância a classe de leitura da microsoft e manda ler o comando criado acima.
                OleDbDataReader reader = command.ExecuteReader();

                // Enquanto ouver linhas para ler no arquivo excel, ele executará o laço de repetição abaixo.
                while (reader.Read())
                {
                    // Cria-se um construtor e adicona todos elementos de cada medicamento na lista de medicamentos,
                    // pegando coluna por coluna e separando seus valores em variáveis, para assim, poderem ser chamadas separadamente.
                    listDeMedicamentos.Add(new Medicamentos()
                    {
                        // Utilizamos as atribuições instanciadas na classe Medicamento.cs para receber o valor da coluna que o reader está lendo no momento.
                        Substancia = reader["SUBSTÂNCIA"].ToString(),
                        CNPJ = reader["CNPJ"].ToString(),
                        Laboratorio = reader["LABORATÓRIO"].ToString(),
                        CodGgrem = reader["CÓDIGO GGREM"].ToString(),
                        Registro = reader["REGISTRO"].ToString(),
                        EAN1 = reader["EAN 1"].ToString(),
                        EAN2 = reader["EAN 2"].ToString(),
                        EAN3 = reader["EAN 3"].ToString(),
                        Produto = reader["PRODUTO"].ToString(),
                        Apresentacao = reader["APRESENTAÇÃO"].ToString(),
                        ClasseTerapeutica = reader["CLASSE TERAPÊUTICA"].ToString(),
                        TipoProdutoStatus = reader["TIPO DE PRODUTO (STATUS DO PRODUTO)"].ToString(),
                        RegimePreco = reader["REGIME DE PREÇO"].ToString(),
                        PFSemImposto = reader["PF Sem Impostos"].ToString(),
                        PF0 = reader["PF 0%"].ToString(),
                        PF12 = reader["PF 12%"].ToString(),
                        PF17 = reader["PF 17%"].ToString(),
                        PF17ALC = reader["PF 17% ALC"].ToString(),
                        PF17E5 = reader["PF 17,5%"].ToString(),
                        PF17E5ALC = reader["PF 17,5% ALC"].ToString(),
                        PF18 = reader["PF 18%"].ToString(),
                        PF18ALC = reader["PF 18% ALC"].ToString(),
                        PF20 = reader["PF 20%"].ToString(),
                        PMC0 = reader["PMC 0%"].ToString(),
                        PMC12 = reader["PMC 12%"].ToString(),
                        PMC17 = reader["PMC 17%"].ToString(),
                        PMC17ALC = reader["PMC 17% ALC"].ToString(),
                        PMC17E5 = reader["PMC 17,5%"].ToString(),
                        PMC17E5ALC = reader["PMC 17,5% ALC"].ToString(),
                        PMC18 = reader["PMC 18%"].ToString(),
                        PMC18ALC = reader["PMC 18% ALC"].ToString(),
                        PMC20 = reader["PMC 20%"].ToString(),
                        RestricaoHospitalar = reader["RESTRIÇÃO HOSPITALAR"].ToString(),
                        CAP = reader["CAP"].ToString(),
                        CONFAZ87 = reader["CONFAZ 87"].ToString(),
                        ICMS0 = reader["ICMS 0%"].ToString(),
                        AnaliseRecursal = reader["ANÁLISE RECURSAL"].ToString(),
                        ListaConcessao = reader["LISTA DE CONCESSÃO DE CRÉDITO TRIBUTÁRIO (PIS/COFINS)"].ToString(),
                        Comercializacao2020 = reader["COMERCIALIZAÇÃO 2020"].ToString(),
                        Tarja = reader["TARJA"].ToString()

                    });
                }

                // Se a lista de medicamentos conter itens, esse método retornará a lista.
                if (listDeMedicamentos.Count > 0)
                {
                    return listDeMedicamentos;
                }
                // Caso contrário, retornará nullo.
                else
                {
                    return null;
                }

            }
            // Caso ocorra alguma exceção, ele mostrará uma mensagem e retornará valor nulo para a planilha. 
            catch 
            {
                Console.WriteLine("Não foi possível ler a planilha!");
                return null;
            }
            // Por fim, fecha a conexão aberta no começo da execução.
            finally
            {
                connection.Close();
            }
        }
    }
}

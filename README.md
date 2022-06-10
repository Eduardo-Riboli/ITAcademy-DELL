Nesta etapa, você vai escrever um programa de computador. Para isso deve ser feita a leitura do
arquivo .csv enviado junto com este enunciado. Neste arquivo você encontra dados sobre
medicamentos disponíveis no Brasil. Você deve implementar as seguintes funcionalidades:

--------------------------------------------------------------------------------------------------------

1. [Consultar medicamentos pelo nome] Permitir que o usuário informe o nome do
medicamento (ou parte do nome do medicamento) que desejar e como resultado o programa
deverá exibir:
  a. Uma lista com os medicamentos encontrados e suas informações (Nome, Produto,
Apresentação e valor PF Sem Impostos);
Atenção: somente devem aparecer no resultado os registros de produtos que foram
comercializados em 2020 (observar a coluna de dados “COMERCIALIZAÇÃO 2020”).

2. [Buscar pelo código de barras] O programa deverá solicitar ao usuário o número
correspondente ao código de barras de um produto (coluna de dados “EAN 1”, por exemplo
‘525516020019503’) e então:
  a. Localizar todos os registros referentes a este produto, independentemente de terem
sido comercializados ou não em 2020;
  b. Dentre todos os registos encontrados, identificar o Preço Máximo ao Consumidor
(alíquota de 0%, coluna de dados “PMC 0%”) mais alto e o mais baixo. Exibir na tela
o mais alto, o mais baixo e a diferença entre eles.

3. [Comparativo da LISTA DE CONCESSÃO DE CRÉDITO TRIBUTÁRIO (PIS/COFINS)] Com
base somente nos produtos que foram comercializados em 2020, o programa deverá:
  a. Consultar a coluna de dados “LISTA DE CONCESSÃO DE CRÉDITO TRIBUTÁRIO
(PIS/COFINS)” para determinar o percentual de produtos classificados como
“Negativa”, “Neutra” ou “Positiva” para esta coluna.
  b. Mostrar os respectivos valores percentuais da seguinte maneira (dados fictícios):
  
[* repare que a quantidade de asteriscos é proporcional ao respectivo percentual, por
exemplo, neste caso são 21 asteriscos para a classificação Negativa.]
CLASSIFICACAO PERCENTUAL GRAFICO
Negativa 21,33% ********************
Neutra 45,18% *********************************************
Positiva 33,49% *********************************

TOTAL 100,00%

Observações:
a) Sugere-se o desenvolvimento de um programa na linguagem de sua preferência, com
uma interface também de sua preferência podendo ser gráfica ou textual/console, com
um menu com as opções enumeradas nos requisitos;
b) Juntamente a este enunciado foi fornecido um arquivo no formato CSV contendo nomes,
valores em decimais, bem como o respectivo dicionário de dados;
c) Você deve escrever o código que lê o arquivo e armazena os dados lidos em memória (do
jeito que você quiser).
d) Não é necessário gravar dados em nenhum formato, nem usar sistemas de banco de dados.
e) O programa deverá lidar com dados de entrada inválidos e informar uma mensagem
adequada caso ocorram.
f) Para facilitar, não é necessário lidar com a acentuação de palavras.
g) Na escrita do relatório apresente comentários sobre como você realizou os testes. Não
esqueça de incluir uma autoavaliação.

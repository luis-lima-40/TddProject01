using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; //porque vamos usar o console para imprimir mensagens de retorno
using System.Net.WebSockets;
using System.Security.Claims;
using TddProject.Domain;

namespace TddProject.Tests
{
    [TestClass]
    public class HelloLuisTests
    {
        [TestMethod]
        public void SayHello_test()
        {
            string mensagem = HelloLuis.SayHello(); // para capturar um retorno, coloque no inicio o tipo do retorno e de um nome para esse retorno
            Assert.AreEqual("Hello Luis", mensagem); // o  Assert.AreEqual tem 2 parametros, um é o que eu espero que ele retorne e a mensagem que meu metodo acima irá refotnar que é valo que está na variavel mensagem, para validar se o retorno do meu metodo está ok ou não, use uma classe do framework de teste chamada de Assert / AreEqual valida o retorno esperado se é igual, ou seja vc verifica se o retorno do metodo que vc está testando bate com o valor que vc especificou como valor esperado
            Console.WriteLine(mensagem);//cw + tab é um atalho para Console.WriteLine...  neste  teste vai dar errado pq no meu metrodo está retornando uma string vazia, quando eu preencher no meu metodo a mesma string que eu declarei aqui como string esperada ai sim o teste vai dar OK
        }




        //######################################################################################################################################//
        //  *** 16 - V20 - Tipos - Tipos Explicitos, Implicitos e Nuláveis ***
        //
        //
        //######################################################################################################################################//




        [TestMethod]
        public void Tipos_Primitivos_e_Complexos_Test()
        {
            //tipos primitivos
            string mensagem = "Helo Luis";
            double peso = 74;
            int idade = 42;

            Console.WriteLine($"mensagem: {mensagem}, peso: {peso}, idade: {idade}");

            // tipos complexos
            Cachorro leia = new Cachorro();
            leia.Nome = "Sou a Leia";
            string retorno = leia.Nome;
            Console.WriteLine($"retorno tipo complexo: {retorno} / {leia}");
            // aqui nesse teste não declaramos o Assert
        }

        [TestMethod]
        public void Conversão_Implicita_Test()
        {
            int inteiro = 10;
            double valor = inteiro;
            Console.WriteLine(valor);
            Assert.AreEqual(inteiro, valor);
        }

        [TestMethod]
        public void Conversão_Explicita_Test()
        {

            double valor = 10.5;
            int inteiro = (int)valor; //cast explicito, um convert encurtado
            Console.WriteLine($"inteiro: {inteiro}, valor:{valor}");
            //Assert.AreEqual(inteiro, valor); //aqui vai dar erro por não será igual apos a conversão
            Assert.AreNotEqual(inteiro, valor); //AreNotEqual vai dar sucesso no teste pois as variaveis contem valores diferentes 
        }

        [TestMethod]
        //tipos de valor
        public void Tipo_de_Valor_Test()
        {
            int valor = 10;
            HelloLuis.PassaValor(valor);
            //Assert.AreEqual(999, valor);
            Assert.AreNotEqual(999, valor);
        }

        [TestMethod]
        public void Tipo_de_Referencia_Test()
        {
            var cachorro = new Cachorro();
            cachorro.Nome = "Leia";
            HelloLuis.PassaReferencia(cachorro);

            var nomeCachorro = cachorro.Nome;
            Console.WriteLine($"nomeCachorro: {nomeCachorro}, cachorro: {cachorro}");

            //Assert.AreEqual("leia", nomeCachorro);
            Assert.AreEqual("Tequila", nomeCachorro);
        }

        [TestMethod]
        public void Igualdade_entre_tipo_de_valor_Test()
        {
            int valor = 10;
            int valor2 = 10;
            Console.WriteLine("Igualdade_entre_tipo_de_valor por serem do tipo PRIMITIVO, o conteudo da variavel valor e valor2 são iguais ");
            Assert.AreEqual(valor, valor2);
        }

        [TestMethod]
        public void Desigualdade_entre_tipo_de_Referencia_Test()
        {
            //Estamos testando a igualdade entre os objetos, comparar dois objetos mesmo que tenham o mesmo conteudo não será igual para o compitador
            var tequila = new Cachorro();
            tequila.Peso = 10;
            var spaik = new Cachorro();
            spaik.Peso = 10;
            Console.WriteLine($"Tequila: {tequila.Peso}, Spaik: {spaik.Peso} ");
            Assert.AreEqual(tequila.Peso, spaik.Peso);
            //Assert.AreNotEqual(tequila.Peso, spaik.Peso);
        }


        [TestMethod]
        public void Igualdade_entre_tipo_de_Referencia_Test()
        {
            //Estamos testando a igualdade entre os objetos, comparar dois objetos mesmo que tenham o mesmo conteudo não será igual se vc der new em cada um dos objetos, para um objeto ser igual ao outro, atribua o valor do outro objeto a esse objeto novo, nao crie uma nova instancia com o new, coloque, objeto 1 = objeto 2 dai ambos serão iguais.
            var tequila = new Cachorro();
            tequila.Peso = 10;
            var spaik = tequila; // para um objeto ser igual ao outro, atribua o valor do outro objeto a esse objeto novo, nao crie uma nova instancia com o new, coloque, objeto 1 = objeto 2 dai ambos serão iguais. 
            //aqui vc está apontando a referencia de um objeto para o outro assim ambos serão iguais ou seja duas referencia em memoria apontando para o mesmo objeto instanciado
            //spaik.Peso=10;
            Console.WriteLine($"Tequila: {tequila.Peso}, Spaik: {spaik.Peso} ");
            Assert.AreEqual(tequila.Peso, spaik.Peso);
            //Assert.AreNotEqual(tequila.GetPeso, spaik.GetPeso);
        }

        [TestMethod]
        public void Declaração_Explicitas_Variaveis_Test()
        {
            //são basicamente o que ja estamos acostumados a fazer com as variaveis
            string nome = ""; //note que toda variavel que vc especifica o tipo antes do nome é um tipo explicito
            int idade = 13; //note que toda variavel que vc especifica o tipo antes do nome é um tipo explicito
            double peso = 1.3; //note que toda variavel que vc especifica o tipo antes do nome é um tipo explicito
            Cachorro cachorro = new Cachorro(); //variavel cachorro do Tipos_Primitivos_e_Complexos_Test classe Cachorro que eu inicializei com seu contrutos

            //assert para validar se as variaveis são do tipo que criamos use typeof como parametro no AreEqual 
            Assert.AreEqual((typeof(string)), nome.GetType());
            Assert.AreEqual(typeof(int), idade.GetType());
            Assert.AreEqual(typeof(double), peso.GetType());
            Assert.AreEqual(typeof(Cachorro), cachorro.GetType());
        }


        [TestMethod]
        public void Declaração_Implicita_Variaveis_Test()
        {
            //em uma declaração implicita, ao inves do tipo da variavel, use a palavra chave "var" antes do nome da sua variavel
            var nome = ""; // na declaração implicita, o compilador identifica o tipo da sua varial de acordo com o tipo de atribuição de valor que vc fez a ela
            var idade = 13;
            var peso = 1.3;
            var cachorro = new Cachorro(); // na declaração implicita, o compilador identifica o tipo da sua varial de acordo com o tipo de atribuição de valor que vc fez a ela

            //assert para validar se as variaveis são do tipo que criamos use typeof como parametro no AreEqual 
            Assert.AreEqual((typeof(string)), nome.GetType());
            Assert.AreEqual(typeof(int), idade.GetType());
            Assert.AreEqual(typeof(double), peso.GetType());
            Assert.AreEqual(typeof(Cachorro), cachorro.GetType());
        }


        [TestMethod]
        public void Declaração_Implicita_Var_Nao_Aceita_Test()
        {
            //não podemos declarar variaveis do tipo implicito sem atribuir valor
            //Existe umas limitações onde vc não pode utilizar o var como uma declaração implicita, a principal é que vc não pode fa
            Cachorro cachorro;
            cachorro = new Cachorro();
            Assert.AreEqual(typeof(Cachorro), cachorro.GetType());
            //neste exemplo acima nos declaramos uma variavel chachorro explicitamnte do tipo cachorro e atribuimos o valor a ela na linha abaixo, isso o compilador permite, pois ele ja conhece o tipo da variavel

            string nome;
            nome = "Luis";
            Assert.AreEqual(typeof(string), nome.GetType());
            //neste exemplo acima nos declaramos uma variavel nome explicitamnte do tipo string e atribuimos o valor a ela na linha abaixo, isso o compilador permite, pois ele ja conhece o tipo da variavel

            //var sobrenome;  //Neste caso de declaração implicita o compilador não aceita vc declarar a variavel sem atribuir o tipo dela na mesma linha da declaração, se vc cria e tenta atribuir o valor dela em uma linha abaixo note que da erro pois na declaração do var ele não sabe qual é o tipo da variavel pois o c# é uma linguagem fortemente tipada e os tipos tem que ser definidos no momento da sua criação
            //sobrenome = "Luis";
            //var nome = null// também não e aceito pois o nullo não é de nenum tipo, é vazio


            var sobrenome = "Luis";
            Assert.AreEqual(typeof(string), sobrenome.GetType());
        }



        [TestMethod]

        public void Tipos_Que_Aceitam_Null_Test()
        {
            //Valores Null, é uma variavel que não aponta para nenhum espaço em memória, ou seja uma ausencia de valor
            //Tipos Nuláveis por padrão no C#:  variaveis do tipo string e todos os tipos de objects e seus derivados como nulos

            string nome = null;
            Cachorro cachorro = null;

            Assert.AreEqual(null, nome);
            Assert.AreEqual(null, cachorro);

            //não da certo, não aceitam nulo
            //int idade = null; //nao podemos atribuir null ao tipo inteito, não é um tipo nulavel
            //double peso = null; // não podemos atribuir null a double, não é um tipo nulavel
            //Assert.AreEqual(null, idade);
            //Assert.AreEqual(null, peso);

            //no C#, para variaveis que não aceitam o tipo nullo podemos marcar estes tipo como nuláveis conforme exemplo abaixo
        }



        [TestMethod]

        public void Tipos_Que_Nulável_Test()
        {

            // TECLAS DE ATALHO, CONTROL + KC COMENTA UM TEIXO SELECIONADO E CONTROL + KU DESCOMENTA

            //no C#, para variaveis que não aceitam o tipo nullo podemos marcar estes tipo como nuláveis conforme exemplo abaixo

            //no tipo da variavel explicita, coloque um ? para definila como uma variavel NULÁVEL
            int? idade = null; //
            double? peso = null; // 
            bool? vacinado = null;  //por excencia o tipo boleano só possui 2 estados, verdadeiro ou falso, quando vc define ela como um pipo nulável ela passa a porssuir 3 estados, verdadeiro, falso ou null
            Assert.AreEqual(null, idade);
            Assert.AreEqual(null, peso);
            Assert.AreEqual(null, vacinado);
        }

        //######################################################################################################################################//
        //  *** 17 - V22 - Atributos de Vusibilidade***
        //  Níveis de Vusibilidade / Niveis de acesso de uma classe e seus membros
        //
        //  class
        //  public: Classe publica pode ser acessada de qualquer parte do nosso codigo, dentro ou fora do seu assembli original
        //  internal: Classe Internal spo pode ser acessada de dentro do seu proprio Assembly, Para declarar uma classe internal, podemos omitir o atributo internal, o compilador ja á classeifica como internal automaticamente
        //
        //  Membros
        //  public - mesmo nivel de acesso da classe, de qualquer lugar dentro ou fora do assembly
        //  private - metodo privado só pode ser acessado de dentro da propria classe, dessa forma vc so podera acessar um metodo privado atraves de um outro metodo dentro da sua propria classe
        //  internal -  nesse caso também so podemos acessalo dentro da nossa propria classe ou também dentro do seu assembly (seu projeto e nas demais classes desse projeto), nos demais assemblys "projetos" da solution vc não rerá acesso a um metodo que está como internal
        //  protected - o nivel de visibilidade protected member define ue o membro poderá ser acessado apenas pela propia classe, ou por classes derivadas, ou seja as heranças 
        //  protected internal
        //######################################################################################################################################//


        //vamos simular uma nova classe detro do TddProject.Domain, lembrando que TddProject.Domain é um projeto que quando compilado vira um assembly

        [TestMethod]
        public void MinhaClasse_test()
        {
            var obj = new MinhaClasse();
            //obj.MeuMetodo(); //o metodo está com nivel de proteção privado, não posso acessar esse metodo aqui
        }

        [TestMethod]
        public void Tentando_Acessar_Metodo_Protected_Por_Herança_Test()
        {

        }




        //######################################################################################################################################//
        //  *** - 19 - V25 DateTime***
        //  Classe do .Net com recursos para representar e manipular datas e horas
        //
        //  
        //######################################################################################################################################//

        [TestMethod]
        public void DateTime_test()
        {
            var hoje = DateTime.Today; //aqui vamor atribuir a variavel apenas a data de hoje sem a hora
            Console.WriteLine($"Today é: {hoje}");

            var agora = DateTime.Now;
            Console.WriteLine($"Now é: {agora}");
        }

        [TestMethod]
        public void DateTime_Desmembrando_Test()
        {
            var agora = DateTime.Now;

            Console.WriteLine($"data e hora: {agora}");
            Console.WriteLine($"ano: {agora.Year}");
            Console.WriteLine($"mes: {agora.Month}");
            Console.WriteLine($"dia: {agora.Day}");
            Console.WriteLine($"hora: {agora.Hour}");
            Console.WriteLine($"minuto: {agora.Minute}");
            Console.WriteLine($"segundo: {agora.Second}");
            Console.WriteLine($"Milisegundo {agora.Millisecond}");
            Console.WriteLine($"dia do mes: {agora.DayOfWeek}");
            Console.WriteLine($"dia do ano: {agora.DayOfYear}");
        }

        [TestMethod]
        public void Datetime_Add_Test()
        {
            //existe uma serie de metodos do datetime que começam com Add
            //Umas das funcionalidades praticas que podemos usar com datetime e fazer calculos ou adicionar tempos as datas
            var agora = DateTime.Now;
            Console.WriteLine($"agora: {agora}");

            var mais5Horas = DateTime.Now.AddHours(5);
            Console.WriteLine($"metodo AddHours(5): {mais5Horas}");


            var amanha = agora.AddDays(1);
            Console.WriteLine($"metodo amanhã AddDays(1): {amanha}");

            var ontem = agora.AddDays(-1); //se vc colocar um valor negativo ele vai retroceder os dias ou horas e te mostrar a quantidade que vc especificou retroativamente
            Console.WriteLine($"metodo AddDays(-1) mostra ontem: {ontem}");

            var mesQueVem = agora.AddMonths(1);
            Console.WriteLine($"metodo um mes a frente AddMonths(1): {mesQueVem}");
        }

        [TestMethod]
        public void DateTime_Inicializacao_Test()
        {
            //para iniciliar uma data e hora, crie uma instancia de datetime
            var data = new DateTime(2025, 1, 1); //temos 12 tipos de contrutores diferentes, então utilize o mais adequado, passe um que usa 3 parametros como ano, mes e dia
            Console.WriteLine($"instanciando uma variavel do tipo datedime e passando o parametro usando o construtor ano,mes,dia: {data}");

            var dataHora = new DateTime(2025, 1, 1, 20, 10, 0); //temos 12 tipos de contrutores diferentes, então utilize o mais adequado, passe um que usa 3 parametros como ano, mes e dia
            Console.WriteLine($"instanciando uma variavel do tipo datedime e passando o parametro usando o construtor ano,mes,dia, hora, minuto e segundos: {dataHora}");
        }

        [TestMethod]
        public void Datetime_Convertendo_De_String_Test()
        {
            //convertendo dateTime = transformar uma string que representa data e hora em um DateTime
            //utilize o metodo statico do Datetime chamado Parse que faz conversão
            var dataParse = DateTime.Parse("17/10/2020"); //aqui passamos no formato brasileiro dia mes e ano, meu computador está no bormato PT-BR 
            Console.WriteLine($"Utilizando o metodo Parse para converter string em data: {dataParse}");

            var dataHoraParse = DateTime.Parse("17/10/2020 23:45"); //aqui passamos no formato brasileiro dia mes e ano, meu computador está no bormato PT-BR 
            Console.WriteLine($"Utilizando o metodo Parse para converter string em data e Hora: {dataHoraParse}");
        }

        [TestMethod]
        public void Datetime_Quantidade_Dias_Mes_Test()
        {
            //util para saber qual é o ultimo dia de um determinado mes, 28, 29, 30 ou 31 dependendo do mes
            //utilize o metodo do Datetime chamado DaysInMonth()
            var diaMes = DateTime.DaysInMonth(24, 2); //esse metodo DaysInMonth() receve 2 parametros ano e mes separados por virgura
            Console.WriteLine($"ultimo dia de um determinado mes DaysInMonth(17,10) : {diaMes}");

            //para vc calcular o ultimo dia do mes, utilize o mestodo acima e depois use
            var ultimoDiaMes = new DateTime(2024, 2, (int)(DateTime.DaysInMonth(24, 2)));
            Console.WriteLine($"Variavel com Intancia datetime passando no campo dia outro datetime com o metodo DaysInMonth()) do mesmo ano/mes que quero saber o ultimo dia do mês var ultimoDiaMes = new DateTime(2024, 2, (int)(DateTime.DaysInMonth(24, 2))); note que foi feito um convert para int do resultado do DaysInMonth para subistituir o parametro do dia do primeiro metodo datetime  : {ultimoDiaMes}");
        }

        [TestMethod]

        public void DateTime_Formatações_Test()
        {
            var agora = DateTime.Now;
            //Console.WriteLine() aceita qualquer coisa como parametro, qualquer tipo de objeto, variavel, array texto etc
            Console.WriteLine(agora); //toda vez que passamos um objeto ou variavel para o Console.WriteLine(),  o compilador sempre chama o metodo ToString() para exibir em tela o resultado que que vc passou como parametro
            Console.WriteLine($"agora no formato padrao da maquina PT-BR: {agora.ToString()}");// a linha acima é a mesma coisa que esta linha, ToString() é omitido pelo compilador mas esta sendo executado de forma oculta para exibir o resultado
            Console.WriteLine($"Agora no formato Universal full date/Time: {agora.ToString("U")}"); // com o metodo ToString() dentro do parenteses digite uma aspas simples para que o intelicense te mostre todos os tipos de formatos de string que o ToString aceita, escolha o formato que deseja. podemos colocar a formatação especifica que determinarmos para ser exibida em tela
            //voce também pode criar a sua propria formatação personalizada passando os parametros de como deve aparecer o dia mes ano hora minuto segundo etc
            Console.WriteLine($"Agora personalizado, formatei para Mes / dia / ano c/ 2 dig: {agora.ToString("MM/dd/yy")}");
        }





        //######################################################################################################################################//
        //  ***- 19 - V25 TimeSpan***
        //  Classe do .Net que representa uma "quantidade de tempo"
        //  para trabalhar com calculos entre dadas e horas
        //  
        //######################################################################################################################################//

        [TestMethod]

        public void TipeSpan_Test()
        {
            //ATENÇÃO - quando for trabalhar em calculos de anos e meses o TimeSpan não é uma boa solução, ao inves de usalo, tente trabalhar do DateTime como exemplo
            ////var anos = DateTime.Now.Year - DataNascimento.Year;
            ///var mes = DateTime.Now.Month - DataNascimento.Month + (12 * anos);
            //ATENÇÃO FIM
            var hoje = DateTime.Today;
            var amanha = hoje.AddDays(1);
            //aqui vamos fazer uma conta, de qual a diferença de tempo entre hoje e amanhã
            var difTempo = amanha.Subtract(hoje); // o metodo Subtract() não vai me retornar um outro date time, ele é um Time Span e vai me mostrar o resultado como uma quantidade de tempo
            Console.WriteLine($"Essa é o resultado da quantidade de tempo entre hoje e amanha usando o metodo .Subtract() que retorna um tymespan :  {difTempo}");
            //o resultado retornado é  1.00:00:00 ou seja 1 dia, 00 horas 00 minutos 00 segundos
            var data1 = new DateTime(2024, 4, 29, 23, 19, 15);
            var data2 = new DateTime(2024, 5, 1, 10, 11, 54);
            Console.WriteLine($"Resultado data2.Subtract(data1) com datas instanciadas no datetime passando como parametro minhas datas:  {data2.Subtract(data1)}");
            var dif = data2.Subtract(data1);
            Console.WriteLine($"Resultado segundos :  {dif.TotalSeconds}");
            Console.WriteLine($"Resultado minutos :  {dif.TotalMinutes}");
            Console.WriteLine($"Resultado horas :  {dif.TotalHours}");
            Console.WriteLine($"Resultado dias :  {dif.Days}");
        }

        // Crie uma propriedade no cachorro para armazenar data de nascimento
        //remover a propriedade idade do cachorro
        //crie um teste unitario e um metodo que retorne a idade do cachorro
        //a idade deve ser retornada em uma string exemplo "10 anos" ou "2 meses"


        //Em C#, o operador relacional != significa "diferente de". Outros operadores relacionais incluem: == (igual), < (menor que), > (maior que), <= (menor ou igual), >= (maior ou igual)



        //######################################################################################################################################//
        //  *** 20 - V27 - Array / List / While / FOR / LOOPS E CONDIÇÕES ***
        //  Um array é um elemento de um determinado tipo, sendo uma estrutura estatica, fixa limitada a um tipo unico, não é possivel misturar string e inteiro por exemplo, ou uma vez que vc determina as posição vc não cosegue em tempo de execução eliminar ou incluir posições
        //  List
        //  
        //######################################################################################################################################//


        [TestMethod]
        public void Array_While_Test()
        {
            var array = new int[3]; // instanciando um objeto do tipo Array int de 3 posições
            array[0] = 10; //atribuindo valores as posições usando o i (indice de cada posição no array)
            array[1] = 20;
            array[2] = 30;

            var i = 0; // para fazer o laço de repetição crie uma variavel contador i que representara o indice e servira para fazer a contagem da posição

            while (i < array.Length) // enquanto o i for menos que array.Length a propriedade Length é o que verifica(determina) a quantidade de posição que existe no array, de elementos que estão no array, no caso vai retornar 3
            {
                Console.WriteLine(array[i]);// vamos mostrar no console o conteudo do array usando o i como indice,
                i++; //implementando o contador para que ele serviça de estrutura para o loop, 
                // para cada interação do while vai ser impreso o conteudo do array
            }
        }

        [TestMethod]

        public void Array_Do_While_Test()
        {
            //outro laço de repetição é o dowhile que é a inversão do  While
            var array = new string[] { "leia", "Yuri", "Tequila", "Thor" }; // uma forma facilitade de inicializar um array , sem definir a quantidade de posições, o tamanho do arrai vai ser definido pela quantidade de elementos que vc passar para o array

            var i = 0; // para fazer o laço de repetição crie uma variavel contador i que representara o indice e servira para fazer a contagem da posição

            do //ele inicia o laco de repetição e valida a condição no final
            {
                //Console.WriteLine(array[i]);
                //i++;
                Console.WriteLine(array[i++]); // vc pode simplificar desta forma, assim o compilador vai primeiro mostrar o conteudo do array na posição 0 depois ele ira implementar o i++, funciona da mesma forma que o codigo acima

            } while (i < array.Length);
        }


        [TestMethod]

        public void Array_For_Test()
        {
            //outro laço de repetição é o dowhile que é a inversão do  While
            var array = new string[] { "leia", "Yuri", "Tequila", "Thor" }; // uma forma facilitade de inicializar um array , sem definir a quantidade de posições, o tamanho do arrai vai ser definido pela quantidade de elementos que vc passar para o array

            // o For contrala o contador dentro de sua própria estrutura, não precisamos declarar o i previamente, ele ja estara na estrutura padrão do for

            for (var i = 0; i < array.Length; i++)
                //{
                Console.WriteLine(array[i]); // como aqui temos apenas 1 linha de instrução podemos omitir as chaves
            //}
        }


        [TestMethod]

        public void Array_For_Invertido_Test()
        {
            //FOR INVERTIDO muito Util para quando vc for fazer uma exclusão dentro de um laço de repetição. Um loop invertido do final para o começo, vc vai percorrer o array e dentro do laço vc vai eliminar o item em uma determinada coleção dentro de um laço faça de forma invertida para não quebrar o laço.

            //For Invertido
            var array = new[] { "leia", "Yuri", "Tequila", "Thor" }; // uma forma implicita de inicializar um array , sem definir a quantidade de posições nem o tipo, o tipo será determinado de acordo com a atrivuição de valores

            //clique no for com o botão esquerdo > refatorar > Reverse For Statement, ele vai criar a estrutura do for invertido
            for (var i = array.Length - 1; i >= 0; i--) //começe do final, faça enquanto for maior ou igual a 0 e use um decrementador -- no indice i
                //{
                Console.WriteLine(array[i]); // como aqui temos apenas 1 linha de instrução podemos omitir as chaves
            //}
        }



        [TestMethod]

        public void Array_Foreach_Test()
        {
            // Foreach é uma evolução do For, comum em liguagens orientadas a objeto 
            // Simplificando o Foreach internamente monta um For onde vc não precisa se preocupar com o contador nem com o implemento deste contador
            //
            var array = new[] { "leia", "Yuri", "Tequila", "Thor" }; // uma forma implicita de inicializar um array , sem definir a quantidade de posições nem o tipo, o tipo será determinado de acordo com a atrivuição de valores

            foreach (var item in array) // foreach (var item in collection) vc declara a variavem e usa a palavra chave de uma determinada coleção, essa coleção no caso é nossa array, assim nossa var vai ser do tipo string conforme nosso array foi declarado implicitamente com os valores
            {
                Console.WriteLine(item);
            }
        }


        [TestMethod]

        public void List_Foreach_Test()
        {
            // List - quando vc precisar trabalhar com coleções de uma forma dinamica, não utilize array, utilize listas por exemplo para um crud em banco de dados
            // dentro do <> vc passa o tipo que vc quer que a lista represente, o tipo de cada item da lista
            // List<tipo>() a vantagem da Lista é que que vc pode adicionar e remover itens dela
            // na lista vc tem opções de Add, Count, Foreach entre outras
            var lista = new List<string> { "leia", "Yuri", "Tequila", "Thor" };     //é um tipo de objeto diferente no C# que é um tipo generico, topo tipo generico tem o sinal de notação "<>" menor maior ,
            lista.Add("Monck");
            lista.Remove("Yuri");


            foreach (var item in lista) // foreach (var item in collection) vc declara a variavem e usa a palavra chave de uma determinada coleção, essa coleção no caso é nossa array, assim nossa var vai ser do tipo string conforme nosso array foi declarado implicitamente com os valores
            {
                Console.WriteLine(item);
            }
        }


        [TestMethod]
        public void Dictionary_Test()
        {
            // Dictionary também é um tipo generico mas diferente da lista vc pode definir 2 tipos pra ele
            // é uma estrutura que contem uma chave e um valor, sua chave pode ser inteiro e seu tipo valor pode ser uma string
            // use quando vc quer ter um indice, uma chave para seus elementos da sua coleção de dados, vc tanbem pode remover um item dado a sua chave.



            //  var dic = new Dictionary<int, string>(); // instanciando o dicionario chave inteira e conteudo string
            //  dic.Add(1, "leia"); //adicionando itens no dicionario, o medoto Add vai receber 2 argumentos como parametros, o primeiro um inteiro que vai ser uma chave e segundo uma string que será o valor
            //  dic.Add(2, "Yuri");
            //  dic.Add(3, "Tequila");
            //  dic.Add(4, "Thor");
            //  dic.Add(5, "Monck");
            //  dic.Remove(2); // para remover vc pode apenas passar o numero da chave Key
            //  
            //  //vamos percorrer o dicionario mas o item do dicionario é o que chamamo de KeyValuePair, observe isso apontando o mouse para o "ITEM" no  foreach
            //  //KeyValuePair é um objeto que tem as propriedades Key do tipo inteiro e value do tipo string
            //  
            //  foreach (var item in dic) // 
            //  {
            //      Console.WriteLine($"este é o Key - chave do dicionario: {item.Key} e este é o value (valor string) desta Key: {item.Value}  ");
            //      Console.WriteLine($"{item.Key} : {item.Value}");
            //  }


            //outra forma de declarar o Dic ja inicializando seus valores na declaração
            var dic = new Dictionary<int, string>
            {
                { 1, "leia" }, //adicionando itens no dicionario, o medoto Add vai receber 2 argumentos como parametros, o primeiro um inteiro que vai ser uma chave e segundo uma string que será o valor
                { 2, "Yuri" },
                { 3, "Tequila" },
                { 4, "Thor" },
                { 5, "Monck" }
            }; // instanciando o dicionario chave inteira e conteudo string
            dic.Remove(2); // para remover vc pode apenas passar o numero da chave Key

            //vamos percorrer o dicionario mas o item do dicionario é o que chamamo de KeyValuePair, observe isso apontando o mouse para o "ITEM" no  foreach
            //KeyValuePair é um objeto que tem as propriedades Key do tipo inteiro e value do tipo string

            foreach (var item in dic) // 
            {
                Console.WriteLine($"este é o Key - chave do dicionario: {item.Key} e este é o value (valor string) desta Key: {item.Value}  ");
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }


        [TestMethod]
        public void If_Else_Test()
        {
            //estruturas de condição:
            var agora = DateTime.Now;
            var numero = agora.Second;
            var mensagem = "";

            //if verifica uma condição logica, se é verdadeira ou falsa e vai executar o primeiro bloco, do contrario ele executa o segundo bloco
            // % = resto da divisão / = atribui / == igual
            if (numero % 2 == 0) // vamos verificar se o numero é impar, pegando o resultado dividindo (% é operador que retorna o resto da divisão) por 2 se é igual a 0, se for é par, senão é impar
                mensagem = "Par";
            else
                mensagem = "Impar";
            Console.WriteLine(mensagem);
        }

        [TestMethod]
        public void If_Inline_ou_Ternario_Test()
        {
            //estruturas de condição:
            var agora = DateTime.Now;
            var numero = agora.Second;

            var mensagem = numero % 2 == 0 ? $"{numero} é Par" : $"{numero} é Impar";
            Console.WriteLine(mensagem);
        }


        [TestMethod]
        public void If_Else_If_Test()
        {
            //outra variação do if else é o contrario else if, uma estrutura de if com varias condições
            var hoje = DateTime.Today;
            var mensagem = "";

            //DayOfWeek é uma estrutura de enum, significa enumerador estrutura fisica de valores possiveis que eu posso dar para uma determinada propriedade
            if (hoje.DayOfWeek == DayOfWeek.Sunday) //DayOfWeek só pode ganhar um valor desses valores possíveis da lista 
                mensagem = "Hoje é domingo";
            else if (hoje.DayOfWeek == DayOfWeek.Monday)
                mensagem = "Hoje é segunda :(";
            else if (hoje.DayOfWeek == DayOfWeek.Tuesday)
                mensagem = "Hoje é terça";
            else if (hoje.DayOfWeek == DayOfWeek.Wednesday)
                mensagem = "Hoje é quarta";
            else if (hoje.DayOfWeek == DayOfWeek.Saturday)
                mensagem = "Sextou! :)";
            Console.WriteLine(mensagem);
        }

        [TestMethod]
        public void Switch_Case_Test()
        {

            var hoje = DateTime.Today;
            var mensagem = "";

            //switch case : na estrutura inicial vc diz qual é a condição que vc quer fazer a validação  hoje.DayOfWeek e pra cada valor eu tenho um case. quando o seu swit identifica uma condição valida vc usa o break; para que ele não use os demais
            //quando vc for trabalhar com enuns é interessante iteração com o switch
            switch (hoje.DayOfWeek) //DayOfWeek só pode ganhar um valor desses valores possíveis da lista 
            {
                case DayOfWeek.Sunday:
                    mensagem = "Hoje é domingo";
                    break;
                case DayOfWeek.Monday:
                    mensagem = "Hoje é segunda :(";
                    break;
                case DayOfWeek.Tuesday:
                    mensagem = "Hoje é terça";
                    break;
                case DayOfWeek.Wednesday:
                    mensagem = "Hoje é quarta";
                    break;
                case DayOfWeek.Saturday:
                    mensagem = "Sextou! :)";
                    break;
            }
            Console.WriteLine(mensagem);
        }


        //Os operadores bolianos lógicos executam operações lógicas com operandos bool. 
        //Os operadores incluem: 
        //negação lógica unária(!),
        //AND lógico binário(&),
        //OR(|) e OR exclusivo(^)
        //e os lógicos condicionais binários AND(&&) e OR(||).

        //Atividades:
        //criar testes unitarios e um metodo no cachorro que faça as seguintes validações:
        //Nome do cachorro é obrigatório
        //Sexo do cachorro precisa ser "Femea" ou "Macho". Qualquer outro valor é inválido!
        //Data de nascimento não pode ser maior que data de hoje
        //Peso deve ser maior que 0
        //Esse Metodo deverá retornar as mensagens no caso de campos inválidos. ou Null se tudo estiver OK
        //esse metodo deverá retornar caso uma ou mais dessas condições sejam falsas, retorne uma mensagem,
        //se tiver mais que uma mensagem de erro retorne as mensagem em uma coleção, uma lista de strings
        //se todas as condições estão ok e o cachorro 100% validado, retorne null


        //######################################################################################################################################//
        //  *** 21 - V29 Exceptions ***
        //  Exception é um erro ou problema que ocorre durante a execução de um programa
        //  o C# nos permite fazer o tratamento de exceptions
        //  temos uma série de ferramentas para trabalhar com exceptions, veremos algumas delas
        //######################################################################################################################################//

        [TestMethod]
        public void Exception_Test()
        {
            // o recurso para tratamento de exception tray catch  faz com que seu programa não pare inesperadamente e seja exibido para o usuário que ele esta fazendo uma operação ilegal o que houve um erro sistemico.
            try
            {

                Cachorro cachorro = null; //aqui estamos criando uma variavel do tipo Cachorro e atribuindo Null, quando vc tentar rodar algum metodo dessa variavel vai estourar um erro
                //aqui é um ponteiro de memoria que não aponta pra nada
                if (cachorro == null) //Por ultimo podemos forçar o programa para ocorrer uma excessção com a vamos exemplificar isso aqui
                    throw new Exception("O Cachorro não foi Instanciado!");  // throw lança uma exception e vc pode definir a mensagem que deseja para essa excessão

                cachorro.Validar(); //System.NullReferenceException: 'Object reference not set to an instance of an object.' é o tipo de exception que mais vamos ver em c#
                //que é System.NullReferenceException,vc tem um objeto que está nulo, não tem nenhuma referencia em memora e não aponta para uma classe,  e estamos tentando executar um metodo da classe que ainda não foi instanciado

                var x = 10; //vamos forçar um erro comum em linguagem de programação
                var y = 0;
                var resultado = x / y; // vai dar erro pois não é possivel fazer divisão por 0
                Console.WriteLine(resultado); // o teste falhou e foi lancado uma exception (System.DivideByZeroException: Attempted to divide by zero.)

            }// vc pode fazer uma tratativa para cada tipo de exception  e ter mais do que 1 bloco catch de excessão

            catch (DivideByZeroException)
            {
                //catch de exceptions excesivas
                Console.WriteLine("Erro de divisão por Zero!");
            }

            catch (Exception ex)
            {
                //catch de exceptions excesivas
                Console.WriteLine(ex);
            }
            // um outro recurso importante do try, catch é finally
            // O finally é um bloco de codigo que vai ser executado se cair em algum catch, ele sempre será executado se der erro ou não
            // // Se o codigo no seu tray executar sem nenhum erro, com sucesso ele vai cair no Finally, se der erro, vai cair no Catch e depois no Finally também
            finally
            {
                Console.WriteLine("Fim do Teste no bloco Finally");
            }


        }

        //######################################################################################################################################//
        //  *** 22 - V31 - Associação ***
        //  Associação na orientação a objetos, é quando uma classe 
        //  possui uma propriedade que aponta para outra classe do Modelo
        //  Seria o equivalente a chave estrangeira do modelo relacional
        //  ou seja, um relacionamento entre duas classe chamamos de Associação
        //######################################################################################################################################//


        //######################################################################################################################################//
        //  *** 23 - V33 - Enum ***
        //  Um enum ou enumeration é um tipo especial do C#, onde podemos definir um conjunto de constantes nomeadas
        //  Internamente essas constantes sçao do tipo int
        //  Muito útil para enriquecer o modelo da aplicação, para tipos que so podem ser unicos, como sexo, Macho ou Fêmea, 
        //  ou uma propriedade como Departamento de uma empresa onde sua estrutura fisica e organizacional
        //  ja possui um numero determinado e fixo de departamento, ou seja, vc é obrigado e escolhar uma das opções listadas no enum
        //  sem a possibilidade de mudar ou alterar evitando erros de iput incorreto
        //######################################################################################################################################//



        // Abstração
        //[TestMethod]
        //public void Classe_Abstrata_Test()
        //{
        //var animal = new Animal(); // a classe pai Animal, foi criada pela primeira vez dessa forma public class Animal, assim, ele pode ser instanciada diretamente
        // como neste exemplo desta linha de codigo, mas se mudarmos ela para abstrata public abstract class Animal ela não podera mais ser
        // instanciada diretamente, somente por seus filhos, gato ou cachorro 
        //assim como não podemos instanciar um objeto de uma interface também não podemos instanciar objetos de uma classe abstrata
        // então qual o objetivo de ter uma classe abstrata? eu nao poderia ter apenas uma interface? 
        // A DIFERENÇA entre uma INTERFACE e uma CLASSE ABSTRACT ?
        // é que a interface não tem haver com a reutilização de código, ela tem haver com contratos que nossas classes são obrigadas a implementar
        // A classe abstrata permite que o codigo seja reutilizado, se eu tenho a propriedade nome da classe animal, a minha classe cachorro vai ganhar a propriedade nome
        // Metodos abstratos, public abstract virtual string QuantoDevoComer(int peso), quando eu faço isso
        // o metodo não podera ter um conteudo, ou seja , se o metodo é abstract dentro de uma classe abstrata ele terá um
        // comportamento como se fosse de uma interface, quem herdar da Classe Pai Animal.cs obrigatoriamente tem que sobrecarregar, fazer um override do metodo abstract da classe pai personalizado na classe filho
        // quando vc fizer um metodo abstract em uma classe pai, note que sua classe filho vai ser obrigada a fazer o override desse metodo abstrato como no exemplo da classe gato que criamos
        // QUAL A DIFERENÇA entre um MÉTODO VIRTUAL e MÉTODO ABSTRATO NA CLASSE PAI? no virtual vc tem a opção de sobrecarregar ou não com o overrride
        // ja na classe abstrada, vc não terá a opção de não sobregarregar pelo contrario, vc será OBRIGADO  a sobrecarregar 
        //}




        //######################################################################################################################################//
        // *** 30 - V46 - System.IO  (input, output)*** 
        // 
        // É um conjunto de recursos que vamos encontrar na Interface para trabalhar com pastas, diretórios e arquivos
        //
        // No .NET, os namespaces System.IO contêm tipos que permitem a leitura e a gravação, tanto de forma síncrona quanto assíncrona,
        // em fluxos de dados e arquivos. Esses namespaces também contêm tipos que realizam compactação e descompactação em arquivos e 
        // tipos que permitem a comunicação por meio de pipes e portas seriais.
        // 
        // Mamos Usar o HalloLuisTests
        //  
        //######################################################################################################################################//

        [TestMethod]
        public void SystemIO_CriateDirectory_Test()
        {
            // criando diretorios com System.IO
            // Directory é uma classe estatica com elementos estaticos
            //C: \Users\CorteStiloTatuape\Documents\Luis Lima\01_LUIS_ESTUDOS_2024\TDD - Tests\TddProject01
            // em C# uma barra para esquerda é um caracter de escape, para vc colocar algum carater especial, por exemplo
            // se vc quiser imprimir em tela na sua string uma "  voce pode colocar o \" e o compilador vai mostar as aspas no resultado da string
            // para vc criar ou acessar um diterorio dentro de uma string, o caracter especial para representar a barra é jusatamente usar
            // a basse de caracter de escape \ e na sequencia outra barra, ficando assim \\ (C:\\Users\\)
            // se a pasta ja existir o CreateDirectory vai ignorar o comando, não vai estourar nenhum erro e nao fara nada
            // se não existir ele irá criar o diretorio ou subpasta

            Directory.CreateDirectory("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030");
            Directory.CreateDirectory("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\SubPasta");
            //Directory.Delete("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\SubPasta");
            //Directory.Delete("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030");

            //Directory.CreateDirectory("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\Aula030");
            //Directory.CreateDirectory("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\Aula030\\SubPasta");
        }



        [TestMethod]
        public void SystemIO_File_Create_Txt_Test()
        {
            // A classe File vc também acessa varios metodos estaticos e muitos começam com Write 
            // metodos que iniciam com  Write permitem criar arquivos com um determinado path (caminho) com um determinado conteudo
            // o mais comum é a gente usar o WriteAllBytes que é um array de bytes, um binário que estamos querendo gravar em disco
            // vamos criar um arquivo que grava texto, um mais simples para exemplificar usando o WriteAllText

            // WriteAllText no pripeiro parametro coloque o caminho do arquivo onde irá criar sequido do nomeDoArquivo.txt, no segundo parametro, coloque o conteudo do arquivo que será uma string qualquer
            File.WriteAllText("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\Hello.txt", "Hello Desenvolvedor");
        }

        [TestMethod]
        public void SystemIO_GetFileSystemEntries_Test()
        {
            // GetFileSystemEntries - Carregar o conteúdo de um diretório
            // GetFileSystemEntries vai retornar uma lista, um array de strings contendo todos os itens que tem em um diretório
            // ele faz parte do Directory.GetFileSystemEntries
            // 

            // 
            var lista = Directory.GetFileSystemEntries("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030");
            foreach (var item in lista)
            {
                Console.WriteLine($"Lista: {item}");
            }
        }


        [TestMethod]
        public void SystemIO_File_Read_Txt_Test()
        {
            // Ler o conteudo de um arquivo
            // 
            // 
            // 

            // 
            var conteudo = File.ReadAllText("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\Hello.txt");

                Console.WriteLine($"conteudo arquivo: {conteudo}");
        }

        // Exercícios *** 30.1 - V46 - System.IO(input, output)***
        // Criar uma rotina que devera ler o conteudo do arquivo pets.csv, e retornar um Lis<Ipet>,
        // contendo todos os animais que estão nessa lista
        //
        // Criar um teste unitário para listar no console todos os pets dessa Lista
        // arquivo csv "C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\pets.csv"
        // continue no arquito de teste PetTest.cs



    }

    public class CasseFilha2 : MinhaClasse
    {
        // Aqui vamos criar uma Classe de fora do assembly "namespace TddProject.Tests " para ver o comportamento de tentar Acessar Metodo Protected Por Herança
        public void MetodoFilho2()
        {
            this.MetodoProtectedInternal();
        }
    }

}

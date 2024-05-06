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
            Assert.AreEqual("Hello Luis", mensagem); // o  Assert.AreEqual tem 2 parametros, um � o que eu espero que ele retorne e a mensagem que meu metodo acima ir� refotnar que � valo que est� na variavel mensagem, para validar se o retorno do meu metodo est� ok ou n�o, use uma classe do framework de teste chamada de Assert / AreEqual valida o retorno esperado se � igual, ou seja vc verifica se o retorno do metodo que vc est� testando bate com o valor que vc especificou como valor esperado
            Console.WriteLine(mensagem);//cw + tab � um atalho para Console.WriteLine...  neste  teste vai dar errado pq no meu metrodo est� retornando uma string vazia, quando eu preencher no meu metodo a mesma string que eu declarei aqui como string esperada ai sim o teste vai dar OK
        }




        //######################################################################################################################################//
        //  *** 16 - V20 - Tipos - Tipos Explicitos, Implicitos e Nul�veis ***
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
            // aqui nesse teste n�o declaramos o Assert
        }

        [TestMethod]
        public void Convers�o_Implicita_Test()
        {
            int inteiro = 10;
            double valor = inteiro;
            Console.WriteLine(valor);
            Assert.AreEqual(inteiro, valor);
        }

        [TestMethod]
        public void Convers�o_Explicita_Test()
        {

            double valor = 10.5;
            int inteiro = (int)valor; //cast explicito, um convert encurtado
            Console.WriteLine($"inteiro: {inteiro}, valor:{valor}");
            //Assert.AreEqual(inteiro, valor); //aqui vai dar erro por n�o ser� igual apos a convers�o
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
            Console.WriteLine("Igualdade_entre_tipo_de_valor por serem do tipo PRIMITIVO, o conteudo da variavel valor e valor2 s�o iguais ");
            Assert.AreEqual(valor, valor2);
        }

        [TestMethod]
        public void Desigualdade_entre_tipo_de_Referencia_Test()
        {
            //Estamos testando a igualdade entre os objetos, comparar dois objetos mesmo que tenham o mesmo conteudo n�o ser� igual para o compitador
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
            //Estamos testando a igualdade entre os objetos, comparar dois objetos mesmo que tenham o mesmo conteudo n�o ser� igual se vc der new em cada um dos objetos, para um objeto ser igual ao outro, atribua o valor do outro objeto a esse objeto novo, nao crie uma nova instancia com o new, coloque, objeto 1 = objeto 2 dai ambos ser�o iguais.
            var tequila = new Cachorro();
            tequila.Peso = 10;
            var spaik = tequila; // para um objeto ser igual ao outro, atribua o valor do outro objeto a esse objeto novo, nao crie uma nova instancia com o new, coloque, objeto 1 = objeto 2 dai ambos ser�o iguais. 
            //aqui vc est� apontando a referencia de um objeto para o outro assim ambos ser�o iguais ou seja duas referencia em memoria apontando para o mesmo objeto instanciado
            //spaik.Peso=10;
            Console.WriteLine($"Tequila: {tequila.Peso}, Spaik: {spaik.Peso} ");
            Assert.AreEqual(tequila.Peso, spaik.Peso);
            //Assert.AreNotEqual(tequila.GetPeso, spaik.GetPeso);
        }

        [TestMethod]
        public void Declara��o_Explicitas_Variaveis_Test()
        {
            //s�o basicamente o que ja estamos acostumados a fazer com as variaveis
            string nome = ""; //note que toda variavel que vc especifica o tipo antes do nome � um tipo explicito
            int idade = 13; //note que toda variavel que vc especifica o tipo antes do nome � um tipo explicito
            double peso = 1.3; //note que toda variavel que vc especifica o tipo antes do nome � um tipo explicito
            Cachorro cachorro = new Cachorro(); //variavel cachorro do Tipos_Primitivos_e_Complexos_Test classe Cachorro que eu inicializei com seu contrutos

            //assert para validar se as variaveis s�o do tipo que criamos use typeof como parametro no AreEqual 
            Assert.AreEqual((typeof(string)), nome.GetType());
            Assert.AreEqual(typeof(int), idade.GetType());
            Assert.AreEqual(typeof(double), peso.GetType());
            Assert.AreEqual(typeof(Cachorro), cachorro.GetType());
        }


        [TestMethod]
        public void Declara��o_Implicita_Variaveis_Test()
        {
            //em uma declara��o implicita, ao inves do tipo da variavel, use a palavra chave "var" antes do nome da sua variavel
            var nome = ""; // na declara��o implicita, o compilador identifica o tipo da sua varial de acordo com o tipo de atribui��o de valor que vc fez a ela
            var idade = 13;
            var peso = 1.3;
            var cachorro = new Cachorro(); // na declara��o implicita, o compilador identifica o tipo da sua varial de acordo com o tipo de atribui��o de valor que vc fez a ela

            //assert para validar se as variaveis s�o do tipo que criamos use typeof como parametro no AreEqual 
            Assert.AreEqual((typeof(string)), nome.GetType());
            Assert.AreEqual(typeof(int), idade.GetType());
            Assert.AreEqual(typeof(double), peso.GetType());
            Assert.AreEqual(typeof(Cachorro), cachorro.GetType());
        }


        [TestMethod]
        public void Declara��o_Implicita_Var_Nao_Aceita_Test()
        {
            //n�o podemos declarar variaveis do tipo implicito sem atribuir valor
            //Existe umas limita��es onde vc n�o pode utilizar o var como uma declara��o implicita, a principal � que vc n�o pode fa
            Cachorro cachorro;
            cachorro = new Cachorro();
            Assert.AreEqual(typeof(Cachorro), cachorro.GetType());
            //neste exemplo acima nos declaramos uma variavel chachorro explicitamnte do tipo cachorro e atribuimos o valor a ela na linha abaixo, isso o compilador permite, pois ele ja conhece o tipo da variavel

            string nome;
            nome = "Luis";
            Assert.AreEqual(typeof(string), nome.GetType());
            //neste exemplo acima nos declaramos uma variavel nome explicitamnte do tipo string e atribuimos o valor a ela na linha abaixo, isso o compilador permite, pois ele ja conhece o tipo da variavel

            //var sobrenome;  //Neste caso de declara��o implicita o compilador n�o aceita vc declarar a variavel sem atribuir o tipo dela na mesma linha da declara��o, se vc cria e tenta atribuir o valor dela em uma linha abaixo note que da erro pois na declara��o do var ele n�o sabe qual � o tipo da variavel pois o c# � uma linguagem fortemente tipada e os tipos tem que ser definidos no momento da sua cria��o
            //sobrenome = "Luis";
            //var nome = null// tamb�m n�o e aceito pois o nullo n�o � de nenum tipo, � vazio


            var sobrenome = "Luis";
            Assert.AreEqual(typeof(string), sobrenome.GetType());
        }



        [TestMethod]

        public void Tipos_Que_Aceitam_Null_Test()
        {
            //Valores Null, � uma variavel que n�o aponta para nenhum espa�o em mem�ria, ou seja uma ausencia de valor
            //Tipos Nul�veis por padr�o no C#:  variaveis do tipo string e todos os tipos de objects e seus derivados como nulos

            string nome = null;
            Cachorro cachorro = null;

            Assert.AreEqual(null, nome);
            Assert.AreEqual(null, cachorro);

            //n�o da certo, n�o aceitam nulo
            //int idade = null; //nao podemos atribuir null ao tipo inteito, n�o � um tipo nulavel
            //double peso = null; // n�o podemos atribuir null a double, n�o � um tipo nulavel
            //Assert.AreEqual(null, idade);
            //Assert.AreEqual(null, peso);

            //no C#, para variaveis que n�o aceitam o tipo nullo podemos marcar estes tipo como nul�veis conforme exemplo abaixo
        }



        [TestMethod]

        public void Tipos_Que_Nul�vel_Test()
        {

            // TECLAS DE ATALHO, CONTROL + KC COMENTA UM TEIXO SELECIONADO E CONTROL + KU DESCOMENTA

            //no C#, para variaveis que n�o aceitam o tipo nullo podemos marcar estes tipo como nul�veis conforme exemplo abaixo

            //no tipo da variavel explicita, coloque um ? para definila como uma variavel NUL�VEL
            int? idade = null; //
            double? peso = null; // 
            bool? vacinado = null;  //por excencia o tipo boleano s� possui 2 estados, verdadeiro ou falso, quando vc define ela como um pipo nul�vel ela passa a porssuir 3 estados, verdadeiro, falso ou null
            Assert.AreEqual(null, idade);
            Assert.AreEqual(null, peso);
            Assert.AreEqual(null, vacinado);
        }

        //######################################################################################################################################//
        //  *** 17 - V22 - Atributos de Vusibilidade***
        //  N�veis de Vusibilidade / Niveis de acesso de uma classe e seus membros
        //
        //  class
        //  public: Classe publica pode ser acessada de qualquer parte do nosso codigo, dentro ou fora do seu assembli original
        //  internal: Classe Internal spo pode ser acessada de dentro do seu proprio Assembly, Para declarar uma classe internal, podemos omitir o atributo internal, o compilador ja � classeifica como internal automaticamente
        //
        //  Membros
        //  public - mesmo nivel de acesso da classe, de qualquer lugar dentro ou fora do assembly
        //  private - metodo privado s� pode ser acessado de dentro da propria classe, dessa forma vc so podera acessar um metodo privado atraves de um outro metodo dentro da sua propria classe
        //  internal -  nesse caso tamb�m so podemos acessalo dentro da nossa propria classe ou tamb�m dentro do seu assembly (seu projeto e nas demais classes desse projeto), nos demais assemblys "projetos" da solution vc n�o rer� acesso a um metodo que est� como internal
        //  protected - o nivel de visibilidade protected member define ue o membro poder� ser acessado apenas pela propia classe, ou por classes derivadas, ou seja as heran�as 
        //  protected internal
        //######################################################################################################################################//


        //vamos simular uma nova classe detro do TddProject.Domain, lembrando que TddProject.Domain � um projeto que quando compilado vira um assembly

        [TestMethod]
        public void MinhaClasse_test()
        {
            var obj = new MinhaClasse();
            //obj.MeuMetodo(); //o metodo est� com nivel de prote��o privado, n�o posso acessar esse metodo aqui
        }

        [TestMethod]
        public void Tentando_Acessar_Metodo_Protected_Por_Heran�a_Test()
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
            Console.WriteLine($"Today �: {hoje}");

            var agora = DateTime.Now;
            Console.WriteLine($"Now �: {agora}");
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
            //existe uma serie de metodos do datetime que come�am com Add
            //Umas das funcionalidades praticas que podemos usar com datetime e fazer calculos ou adicionar tempos as datas
            var agora = DateTime.Now;
            Console.WriteLine($"agora: {agora}");

            var mais5Horas = DateTime.Now.AddHours(5);
            Console.WriteLine($"metodo AddHours(5): {mais5Horas}");


            var amanha = agora.AddDays(1);
            Console.WriteLine($"metodo amanh� AddDays(1): {amanha}");

            var ontem = agora.AddDays(-1); //se vc colocar um valor negativo ele vai retroceder os dias ou horas e te mostrar a quantidade que vc especificou retroativamente
            Console.WriteLine($"metodo AddDays(-1) mostra ontem: {ontem}");

            var mesQueVem = agora.AddMonths(1);
            Console.WriteLine($"metodo um mes a frente AddMonths(1): {mesQueVem}");
        }

        [TestMethod]
        public void DateTime_Inicializacao_Test()
        {
            //para iniciliar uma data e hora, crie uma instancia de datetime
            var data = new DateTime(2025, 1, 1); //temos 12 tipos de contrutores diferentes, ent�o utilize o mais adequado, passe um que usa 3 parametros como ano, mes e dia
            Console.WriteLine($"instanciando uma variavel do tipo datedime e passando o parametro usando o construtor ano,mes,dia: {data}");

            var dataHora = new DateTime(2025, 1, 1, 20, 10, 0); //temos 12 tipos de contrutores diferentes, ent�o utilize o mais adequado, passe um que usa 3 parametros como ano, mes e dia
            Console.WriteLine($"instanciando uma variavel do tipo datedime e passando o parametro usando o construtor ano,mes,dia, hora, minuto e segundos: {dataHora}");
        }

        [TestMethod]
        public void Datetime_Convertendo_De_String_Test()
        {
            //convertendo dateTime = transformar uma string que representa data e hora em um DateTime
            //utilize o metodo statico do Datetime chamado Parse que faz convers�o
            var dataParse = DateTime.Parse("17/10/2020"); //aqui passamos no formato brasileiro dia mes e ano, meu computador est� no bormato PT-BR 
            Console.WriteLine($"Utilizando o metodo Parse para converter string em data: {dataParse}");

            var dataHoraParse = DateTime.Parse("17/10/2020 23:45"); //aqui passamos no formato brasileiro dia mes e ano, meu computador est� no bormato PT-BR 
            Console.WriteLine($"Utilizando o metodo Parse para converter string em data e Hora: {dataHoraParse}");
        }

        [TestMethod]
        public void Datetime_Quantidade_Dias_Mes_Test()
        {
            //util para saber qual � o ultimo dia de um determinado mes, 28, 29, 30 ou 31 dependendo do mes
            //utilize o metodo do Datetime chamado DaysInMonth()
            var diaMes = DateTime.DaysInMonth(24, 2); //esse metodo DaysInMonth() receve 2 parametros ano e mes separados por virgura
            Console.WriteLine($"ultimo dia de um determinado mes DaysInMonth(17,10) : {diaMes}");

            //para vc calcular o ultimo dia do mes, utilize o mestodo acima e depois use
            var ultimoDiaMes = new DateTime(2024, 2, (int)(DateTime.DaysInMonth(24, 2)));
            Console.WriteLine($"Variavel com Intancia datetime passando no campo dia outro datetime com o metodo DaysInMonth()) do mesmo ano/mes que quero saber o ultimo dia do m�s var ultimoDiaMes = new DateTime(2024, 2, (int)(DateTime.DaysInMonth(24, 2))); note que foi feito um convert para int do resultado do DaysInMonth para subistituir o parametro do dia do primeiro metodo datetime  : {ultimoDiaMes}");
        }

        [TestMethod]

        public void DateTime_Formata��es_Test()
        {
            var agora = DateTime.Now;
            //Console.WriteLine() aceita qualquer coisa como parametro, qualquer tipo de objeto, variavel, array texto etc
            Console.WriteLine(agora); //toda vez que passamos um objeto ou variavel para o Console.WriteLine(),  o compilador sempre chama o metodo ToString() para exibir em tela o resultado que que vc passou como parametro
            Console.WriteLine($"agora no formato padrao da maquina PT-BR: {agora.ToString()}");// a linha acima � a mesma coisa que esta linha, ToString() � omitido pelo compilador mas esta sendo executado de forma oculta para exibir o resultado
            Console.WriteLine($"Agora no formato Universal full date/Time: {agora.ToString("U")}"); // com o metodo ToString() dentro do parenteses digite uma aspas simples para que o intelicense te mostre todos os tipos de formatos de string que o ToString aceita, escolha o formato que deseja. podemos colocar a formata��o especifica que determinarmos para ser exibida em tela
            //voce tamb�m pode criar a sua propria formata��o personalizada passando os parametros de como deve aparecer o dia mes ano hora minuto segundo etc
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
            //ATEN��O - quando for trabalhar em calculos de anos e meses o TimeSpan n�o � uma boa solu��o, ao inves de usalo, tente trabalhar do DateTime como exemplo
            ////var anos = DateTime.Now.Year - DataNascimento.Year;
            ///var mes = DateTime.Now.Month - DataNascimento.Month + (12 * anos);
            //ATEN��O FIM
            var hoje = DateTime.Today;
            var amanha = hoje.AddDays(1);
            //aqui vamos fazer uma conta, de qual a diferen�a de tempo entre hoje e amanh�
            var difTempo = amanha.Subtract(hoje); // o metodo Subtract() n�o vai me retornar um outro date time, ele � um Time Span e vai me mostrar o resultado como uma quantidade de tempo
            Console.WriteLine($"Essa � o resultado da quantidade de tempo entre hoje e amanha usando o metodo .Subtract() que retorna um tymespan :  {difTempo}");
            //o resultado retornado �  1.00:00:00 ou seja 1 dia, 00 horas 00 minutos 00 segundos
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
        //  *** 20 - V27 - Array / List / While / FOR / LOOPS E CONDI��ES ***
        //  Um array � um elemento de um determinado tipo, sendo uma estrutura estatica, fixa limitada a um tipo unico, n�o � possivel misturar string e inteiro por exemplo, ou uma vez que vc determina as posi��o vc n�o cosegue em tempo de execu��o eliminar ou incluir posi��es
        //  List
        //  
        //######################################################################################################################################//


        [TestMethod]
        public void Array_While_Test()
        {
            var array = new int[3]; // instanciando um objeto do tipo Array int de 3 posi��es
            array[0] = 10; //atribuindo valores as posi��es usando o i (indice de cada posi��o no array)
            array[1] = 20;
            array[2] = 30;

            var i = 0; // para fazer o la�o de repeti��o crie uma variavel contador i que representara o indice e servira para fazer a contagem da posi��o

            while (i < array.Length) // enquanto o i for menos que array.Length a propriedade Length � o que verifica(determina) a quantidade de posi��o que existe no array, de elementos que est�o no array, no caso vai retornar 3
            {
                Console.WriteLine(array[i]);// vamos mostrar no console o conteudo do array usando o i como indice,
                i++; //implementando o contador para que ele servi�a de estrutura para o loop, 
                // para cada intera��o do while vai ser impreso o conteudo do array
            }
        }

        [TestMethod]

        public void Array_Do_While_Test()
        {
            //outro la�o de repeti��o � o dowhile que � a invers�o do  While
            var array = new string[] { "leia", "Yuri", "Tequila", "Thor" }; // uma forma facilitade de inicializar um array , sem definir a quantidade de posi��es, o tamanho do arrai vai ser definido pela quantidade de elementos que vc passar para o array

            var i = 0; // para fazer o la�o de repeti��o crie uma variavel contador i que representara o indice e servira para fazer a contagem da posi��o

            do //ele inicia o laco de repeti��o e valida a condi��o no final
            {
                //Console.WriteLine(array[i]);
                //i++;
                Console.WriteLine(array[i++]); // vc pode simplificar desta forma, assim o compilador vai primeiro mostrar o conteudo do array na posi��o 0 depois ele ira implementar o i++, funciona da mesma forma que o codigo acima

            } while (i < array.Length);
        }


        [TestMethod]

        public void Array_For_Test()
        {
            //outro la�o de repeti��o � o dowhile que � a invers�o do  While
            var array = new string[] { "leia", "Yuri", "Tequila", "Thor" }; // uma forma facilitade de inicializar um array , sem definir a quantidade de posi��es, o tamanho do arrai vai ser definido pela quantidade de elementos que vc passar para o array

            // o For contrala o contador dentro de sua pr�pria estrutura, n�o precisamos declarar o i previamente, ele ja estara na estrutura padr�o do for

            for (var i = 0; i < array.Length; i++)
                //{
                Console.WriteLine(array[i]); // como aqui temos apenas 1 linha de instru��o podemos omitir as chaves
            //}
        }


        [TestMethod]

        public void Array_For_Invertido_Test()
        {
            //FOR INVERTIDO muito Util para quando vc for fazer uma exclus�o dentro de um la�o de repeti��o. Um loop invertido do final para o come�o, vc vai percorrer o array e dentro do la�o vc vai eliminar o item em uma determinada cole��o dentro de um la�o fa�a de forma invertida para n�o quebrar o la�o.

            //For Invertido
            var array = new[] { "leia", "Yuri", "Tequila", "Thor" }; // uma forma implicita de inicializar um array , sem definir a quantidade de posi��es nem o tipo, o tipo ser� determinado de acordo com a atrivui��o de valores

            //clique no for com o bot�o esquerdo > refatorar > Reverse For Statement, ele vai criar a estrutura do for invertido
            for (var i = array.Length - 1; i >= 0; i--) //come�e do final, fa�a enquanto for maior ou igual a 0 e use um decrementador -- no indice i
                //{
                Console.WriteLine(array[i]); // como aqui temos apenas 1 linha de instru��o podemos omitir as chaves
            //}
        }



        [TestMethod]

        public void Array_Foreach_Test()
        {
            // Foreach � uma evolu��o do For, comum em liguagens orientadas a objeto 
            // Simplificando o Foreach internamente monta um For onde vc n�o precisa se preocupar com o contador nem com o implemento deste contador
            //
            var array = new[] { "leia", "Yuri", "Tequila", "Thor" }; // uma forma implicita de inicializar um array , sem definir a quantidade de posi��es nem o tipo, o tipo ser� determinado de acordo com a atrivui��o de valores

            foreach (var item in array) // foreach (var item in collection) vc declara a variavem e usa a palavra chave de uma determinada cole��o, essa cole��o no caso � nossa array, assim nossa var vai ser do tipo string conforme nosso array foi declarado implicitamente com os valores
            {
                Console.WriteLine(item);
            }
        }


        [TestMethod]

        public void List_Foreach_Test()
        {
            // List - quando vc precisar trabalhar com cole��es de uma forma dinamica, n�o utilize array, utilize listas por exemplo para um crud em banco de dados
            // dentro do <> vc passa o tipo que vc quer que a lista represente, o tipo de cada item da lista
            // List<tipo>() a vantagem da Lista � que que vc pode adicionar e remover itens dela
            // na lista vc tem op��es de Add, Count, Foreach entre outras
            var lista = new List<string> { "leia", "Yuri", "Tequila", "Thor" };     //� um tipo de objeto diferente no C# que � um tipo generico, topo tipo generico tem o sinal de nota��o "<>" menor maior ,
            lista.Add("Monck");
            lista.Remove("Yuri");


            foreach (var item in lista) // foreach (var item in collection) vc declara a variavem e usa a palavra chave de uma determinada cole��o, essa cole��o no caso � nossa array, assim nossa var vai ser do tipo string conforme nosso array foi declarado implicitamente com os valores
            {
                Console.WriteLine(item);
            }
        }


        [TestMethod]
        public void Dictionary_Test()
        {
            // Dictionary tamb�m � um tipo generico mas diferente da lista vc pode definir 2 tipos pra ele
            // � uma estrutura que contem uma chave e um valor, sua chave pode ser inteiro e seu tipo valor pode ser uma string
            // use quando vc quer ter um indice, uma chave para seus elementos da sua cole��o de dados, vc tanbem pode remover um item dado a sua chave.



            //  var dic = new Dictionary<int, string>(); // instanciando o dicionario chave inteira e conteudo string
            //  dic.Add(1, "leia"); //adicionando itens no dicionario, o medoto Add vai receber 2 argumentos como parametros, o primeiro um inteiro que vai ser uma chave e segundo uma string que ser� o valor
            //  dic.Add(2, "Yuri");
            //  dic.Add(3, "Tequila");
            //  dic.Add(4, "Thor");
            //  dic.Add(5, "Monck");
            //  dic.Remove(2); // para remover vc pode apenas passar o numero da chave Key
            //  
            //  //vamos percorrer o dicionario mas o item do dicionario � o que chamamo de KeyValuePair, observe isso apontando o mouse para o "ITEM" no  foreach
            //  //KeyValuePair � um objeto que tem as propriedades Key do tipo inteiro e value do tipo string
            //  
            //  foreach (var item in dic) // 
            //  {
            //      Console.WriteLine($"este � o Key - chave do dicionario: {item.Key} e este � o value (valor string) desta Key: {item.Value}  ");
            //      Console.WriteLine($"{item.Key} : {item.Value}");
            //  }


            //outra forma de declarar o Dic ja inicializando seus valores na declara��o
            var dic = new Dictionary<int, string>
            {
                { 1, "leia" }, //adicionando itens no dicionario, o medoto Add vai receber 2 argumentos como parametros, o primeiro um inteiro que vai ser uma chave e segundo uma string que ser� o valor
                { 2, "Yuri" },
                { 3, "Tequila" },
                { 4, "Thor" },
                { 5, "Monck" }
            }; // instanciando o dicionario chave inteira e conteudo string
            dic.Remove(2); // para remover vc pode apenas passar o numero da chave Key

            //vamos percorrer o dicionario mas o item do dicionario � o que chamamo de KeyValuePair, observe isso apontando o mouse para o "ITEM" no  foreach
            //KeyValuePair � um objeto que tem as propriedades Key do tipo inteiro e value do tipo string

            foreach (var item in dic) // 
            {
                Console.WriteLine($"este � o Key - chave do dicionario: {item.Key} e este � o value (valor string) desta Key: {item.Value}  ");
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }


        [TestMethod]
        public void If_Else_Test()
        {
            //estruturas de condi��o:
            var agora = DateTime.Now;
            var numero = agora.Second;
            var mensagem = "";

            //if verifica uma condi��o logica, se � verdadeira ou falsa e vai executar o primeiro bloco, do contrario ele executa o segundo bloco
            // % = resto da divis�o / = atribui / == igual
            if (numero % 2 == 0) // vamos verificar se o numero � impar, pegando o resultado dividindo (% � operador que retorna o resto da divis�o) por 2 se � igual a 0, se for � par, sen�o � impar
                mensagem = "Par";
            else
                mensagem = "Impar";
            Console.WriteLine(mensagem);
        }

        [TestMethod]
        public void If_Inline_ou_Ternario_Test()
        {
            //estruturas de condi��o:
            var agora = DateTime.Now;
            var numero = agora.Second;

            var mensagem = numero % 2 == 0 ? $"{numero} � Par" : $"{numero} � Impar";
            Console.WriteLine(mensagem);
        }


        [TestMethod]
        public void If_Else_If_Test()
        {
            //outra varia��o do if else � o contrario else if, uma estrutura de if com varias condi��es
            var hoje = DateTime.Today;
            var mensagem = "";

            //DayOfWeek � uma estrutura de enum, significa enumerador estrutura fisica de valores possiveis que eu posso dar para uma determinada propriedade
            if (hoje.DayOfWeek == DayOfWeek.Sunday) //DayOfWeek s� pode ganhar um valor desses valores poss�veis da lista 
                mensagem = "Hoje � domingo";
            else if (hoje.DayOfWeek == DayOfWeek.Monday)
                mensagem = "Hoje � segunda :(";
            else if (hoje.DayOfWeek == DayOfWeek.Tuesday)
                mensagem = "Hoje � ter�a";
            else if (hoje.DayOfWeek == DayOfWeek.Wednesday)
                mensagem = "Hoje � quarta";
            else if (hoje.DayOfWeek == DayOfWeek.Saturday)
                mensagem = "Sextou! :)";
            Console.WriteLine(mensagem);
        }

        [TestMethod]
        public void Switch_Case_Test()
        {

            var hoje = DateTime.Today;
            var mensagem = "";

            //switch case : na estrutura inicial vc diz qual � a condi��o que vc quer fazer a valida��o  hoje.DayOfWeek e pra cada valor eu tenho um case. quando o seu swit identifica uma condi��o valida vc usa o break; para que ele n�o use os demais
            //quando vc for trabalhar com enuns � interessante itera��o com o switch
            switch (hoje.DayOfWeek) //DayOfWeek s� pode ganhar um valor desses valores poss�veis da lista 
            {
                case DayOfWeek.Sunday:
                    mensagem = "Hoje � domingo";
                    break;
                case DayOfWeek.Monday:
                    mensagem = "Hoje � segunda :(";
                    break;
                case DayOfWeek.Tuesday:
                    mensagem = "Hoje � ter�a";
                    break;
                case DayOfWeek.Wednesday:
                    mensagem = "Hoje � quarta";
                    break;
                case DayOfWeek.Saturday:
                    mensagem = "Sextou! :)";
                    break;
            }
            Console.WriteLine(mensagem);
        }


        //Os operadores bolianos l�gicos executam opera��es l�gicas com operandos bool. 
        //Os operadores incluem: 
        //nega��o l�gica un�ria(!),
        //AND l�gico bin�rio(&),
        //OR(|) e OR exclusivo(^)
        //e os l�gicos condicionais bin�rios AND(&&) e OR(||).

        //Atividades:
        //criar testes unitarios e um metodo no cachorro que fa�a as seguintes valida��es:
        //Nome do cachorro � obrigat�rio
        //Sexo do cachorro precisa ser "Femea" ou "Macho". Qualquer outro valor � inv�lido!
        //Data de nascimento n�o pode ser maior que data de hoje
        //Peso deve ser maior que 0
        //Esse Metodo dever� retornar as mensagens no caso de campos inv�lidos. ou Null se tudo estiver OK
        //esse metodo dever� retornar caso uma ou mais dessas condi��es sejam falsas, retorne uma mensagem,
        //se tiver mais que uma mensagem de erro retorne as mensagem em uma cole��o, uma lista de strings
        //se todas as condi��es est�o ok e o cachorro 100% validado, retorne null


        //######################################################################################################################################//
        //  *** 21 - V29 Exceptions ***
        //  Exception � um erro ou problema que ocorre durante a execu��o de um programa
        //  o C# nos permite fazer o tratamento de exceptions
        //  temos uma s�rie de ferramentas para trabalhar com exceptions, veremos algumas delas
        //######################################################################################################################################//

        [TestMethod]
        public void Exception_Test()
        {
            // o recurso para tratamento de exception tray catch  faz com que seu programa n�o pare inesperadamente e seja exibido para o usu�rio que ele esta fazendo uma opera��o ilegal o que houve um erro sistemico.
            try
            {

                Cachorro cachorro = null; //aqui estamos criando uma variavel do tipo Cachorro e atribuindo Null, quando vc tentar rodar algum metodo dessa variavel vai estourar um erro
                //aqui � um ponteiro de memoria que n�o aponta pra nada
                if (cachorro == null) //Por ultimo podemos for�ar o programa para ocorrer uma excess��o com a vamos exemplificar isso aqui
                    throw new Exception("O Cachorro n�o foi Instanciado!");  // throw lan�a uma exception e vc pode definir a mensagem que deseja para essa excess�o

                cachorro.Validar(); //System.NullReferenceException: 'Object reference not set to an instance of an object.' � o tipo de exception que mais vamos ver em c#
                //que � System.NullReferenceException,vc tem um objeto que est� nulo, n�o tem nenhuma referencia em memora e n�o aponta para uma classe,  e estamos tentando executar um metodo da classe que ainda n�o foi instanciado

                var x = 10; //vamos for�ar um erro comum em linguagem de programa��o
                var y = 0;
                var resultado = x / y; // vai dar erro pois n�o � possivel fazer divis�o por 0
                Console.WriteLine(resultado); // o teste falhou e foi lancado uma exception (System.DivideByZeroException: Attempted to divide by zero.)

            }// vc pode fazer uma tratativa para cada tipo de exception  e ter mais do que 1 bloco catch de excess�o

            catch (DivideByZeroException)
            {
                //catch de exceptions excesivas
                Console.WriteLine("Erro de divis�o por Zero!");
            }

            catch (Exception ex)
            {
                //catch de exceptions excesivas
                Console.WriteLine(ex);
            }
            // um outro recurso importante do try, catch � finally
            // O finally � um bloco de codigo que vai ser executado se cair em algum catch, ele sempre ser� executado se der erro ou n�o
            // // Se o codigo no seu tray executar sem nenhum erro, com sucesso ele vai cair no Finally, se der erro, vai cair no Catch e depois no Finally tamb�m
            finally
            {
                Console.WriteLine("Fim do Teste no bloco Finally");
            }


        }

        //######################################################################################################################################//
        //  *** 22 - V31 - Associa��o ***
        //  Associa��o na orienta��o a objetos, � quando uma classe 
        //  possui uma propriedade que aponta para outra classe do Modelo
        //  Seria o equivalente a chave estrangeira do modelo relacional
        //  ou seja, um relacionamento entre duas classe chamamos de Associa��o
        //######################################################################################################################################//


        //######################################################################################################################################//
        //  *** 23 - V33 - Enum ***
        //  Um enum ou enumeration � um tipo especial do C#, onde podemos definir um conjunto de constantes nomeadas
        //  Internamente essas constantes s�ao do tipo int
        //  Muito �til para enriquecer o modelo da aplica��o, para tipos que so podem ser unicos, como sexo, Macho ou F�mea, 
        //  ou uma propriedade como Departamento de uma empresa onde sua estrutura fisica e organizacional
        //  ja possui um numero determinado e fixo de departamento, ou seja, vc � obrigado e escolhar uma das op��es listadas no enum
        //  sem a possibilidade de mudar ou alterar evitando erros de iput incorreto
        //######################################################################################################################################//



        // Abstra��o
        //[TestMethod]
        //public void Classe_Abstrata_Test()
        //{
        //var animal = new Animal(); // a classe pai Animal, foi criada pela primeira vez dessa forma public class Animal, assim, ele pode ser instanciada diretamente
        // como neste exemplo desta linha de codigo, mas se mudarmos ela para abstrata public abstract class Animal ela n�o podera mais ser
        // instanciada diretamente, somente por seus filhos, gato ou cachorro 
        //assim como n�o podemos instanciar um objeto de uma interface tamb�m n�o podemos instanciar objetos de uma classe abstrata
        // ent�o qual o objetivo de ter uma classe abstrata? eu nao poderia ter apenas uma interface? 
        // A DIFEREN�A entre uma INTERFACE e uma CLASSE ABSTRACT ?
        // � que a interface n�o tem haver com a reutiliza��o de c�digo, ela tem haver com contratos que nossas classes s�o obrigadas a implementar
        // A classe abstrata permite que o codigo seja reutilizado, se eu tenho a propriedade nome da classe animal, a minha classe cachorro vai ganhar a propriedade nome
        // Metodos abstratos, public abstract virtual string QuantoDevoComer(int peso), quando eu fa�o isso
        // o metodo n�o podera ter um conteudo, ou seja , se o metodo � abstract dentro de uma classe abstrata ele ter� um
        // comportamento como se fosse de uma interface, quem herdar da Classe Pai Animal.cs obrigatoriamente tem que sobrecarregar, fazer um override do metodo abstract da classe pai personalizado na classe filho
        // quando vc fizer um metodo abstract em uma classe pai, note que sua classe filho vai ser obrigada a fazer o override desse metodo abstrato como no exemplo da classe gato que criamos
        // QUAL A DIFEREN�A entre um M�TODO VIRTUAL e M�TODO ABSTRATO NA CLASSE PAI? no virtual vc tem a op��o de sobrecarregar ou n�o com o overrride
        // ja na classe abstrada, vc n�o ter� a op��o de n�o sobregarregar pelo contrario, vc ser� OBRIGADO  a sobrecarregar 
        //}




        //######################################################################################################################################//
        // *** 30 - V46 - System.IO  (input, output)*** 
        // 
        // � um conjunto de recursos que vamos encontrar na Interface para trabalhar com pastas, diret�rios e arquivos
        //
        // No .NET, os namespaces System.IO cont�m tipos que permitem a leitura e a grava��o, tanto de forma s�ncrona quanto ass�ncrona,
        // em fluxos de dados e arquivos. Esses namespaces tamb�m cont�m tipos que realizam compacta��o e descompacta��o em arquivos e 
        // tipos que permitem a comunica��o por meio de pipes e portas seriais.
        // 
        // Mamos Usar o HalloLuisTests
        //  
        //######################################################################################################################################//

        [TestMethod]
        public void SystemIO_CriateDirectory_Test()
        {
            // criando diretorios com System.IO
            // Directory � uma classe estatica com elementos estaticos
            //C: \Users\CorteStiloTatuape\Documents\Luis Lima\01_LUIS_ESTUDOS_2024\TDD - Tests\TddProject01
            // em C# uma barra para esquerda � um caracter de escape, para vc colocar algum carater especial, por exemplo
            // se vc quiser imprimir em tela na sua string uma "  voce pode colocar o \" e o compilador vai mostar as aspas no resultado da string
            // para vc criar ou acessar um diterorio dentro de uma string, o caracter especial para representar a barra � jusatamente usar
            // a basse de caracter de escape \ e na sequencia outra barra, ficando assim \\ (C:\\Users\\)
            // se a pasta ja existir o CreateDirectory vai ignorar o comando, n�o vai estourar nenhum erro e nao fara nada
            // se n�o existir ele ir� criar o diretorio ou subpasta

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
            // A classe File vc tamb�m acessa varios metodos estaticos e muitos come�am com Write 
            // metodos que iniciam com  Write permitem criar arquivos com um determinado path (caminho) com um determinado conteudo
            // o mais comum � a gente usar o WriteAllBytes que � um array de bytes, um bin�rio que estamos querendo gravar em disco
            // vamos criar um arquivo que grava texto, um mais simples para exemplificar usando o WriteAllText

            // WriteAllText no pripeiro parametro coloque o caminho do arquivo onde ir� criar sequido do nomeDoArquivo.txt, no segundo parametro, coloque o conteudo do arquivo que ser� uma string qualquer
            File.WriteAllText("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\Hello.txt", "Hello Desenvolvedor");
        }

        [TestMethod]
        public void SystemIO_GetFileSystemEntries_Test()
        {
            // GetFileSystemEntries - Carregar o conte�do de um diret�rio
            // GetFileSystemEntries vai retornar uma lista, um array de strings contendo todos os itens que tem em um diret�rio
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

        // Exerc�cios *** 30.1 - V46 - System.IO(input, output)***
        // Criar uma rotina que devera ler o conteudo do arquivo pets.csv, e retornar um Lis<Ipet>,
        // contendo todos os animais que est�o nessa lista
        //
        // Criar um teste unit�rio para listar no console todos os pets dessa Lista
        // arquivo csv "C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\pets.csv"
        // continue no arquito de teste PetTest.cs



    }

    public class CasseFilha2 : MinhaClasse
    {
        // Aqui vamos criar uma Classe de fora do assembly "namespace TddProject.Tests " para ver o comportamento de tentar Acessar Metodo Protected Por Heran�a
        public void MetodoFilho2()
        {
            this.MetodoProtectedInternal();
        }
    }

}

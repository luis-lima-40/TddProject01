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
        //  ***Níveis de Vusibilidade***
        //  Niveis de acesso de uma classe e seus membros
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
        //  ***DateTime***
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
        //  ***TimeSpan***
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
        //  *** Array / While / FOR / LOOPS E CONDIÇÕES ***
        //  
        //  
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
                Console.WriteLine(array[i]);
                i++;

            } while (i < array.Length);
        }
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

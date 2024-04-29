using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; //porque vamos usar o console para imprimir mensagens de retorno
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
            Console.WriteLine( mensagem );//cw + tab � um atalho para Console.WriteLine...  neste  teste vai dar errado pq no meu metrodo est� retornando uma string vazia, quando eu preencher no meu metodo a mesma string que eu declarei aqui como string esperada ai sim o teste vai dar OK
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
            leia.Nome="Sou a Leia";
            string retorno = leia.Nome;
            Console.WriteLine($"retorno tipo complexo: {retorno} / {leia}");
            // aqui nesse teste n�o declaramos o Assert
        }

        [TestMethod]
        public void Convers�o_Implicita_Test()
        {
            int inteiro = 10;
            double valor = inteiro;
            Console.WriteLine( valor );
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
            cachorro.Nome="Leia";
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

            Assert.AreEqual(null , nome);
            Assert.AreEqual(null , cachorro);

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
        //  ***N�veis de Vusibilidade***
        //  Niveis de acesso de uma classe e seus membros
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
        //  ***DateTime e TimeSpan***
        //  Classe do .Net com recursos para representar e manipular datas e horas
        //
        //  
        //######################################################################################################################################//

        [TestMethod]
        public void DateTime_test()
        { 
            var hoje = DateTime.Today; //aqui vamor atribuir a variavel apenas a data de hoje sem a hora
            Console.WriteLine( $"Today �: {hoje}" );

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

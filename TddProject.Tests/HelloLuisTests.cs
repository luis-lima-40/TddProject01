using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; //porque vamos usar o console para imprimir mensagens de retorno
using System.ComponentModel;
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
            Console.WriteLine( mensagem );//cw + tab é um atalho para Console.WriteLine...  neste  teste vai dar errado pq no meu metrodo está retornando uma string vazia, quando eu preencher no meu metodo a mesma string que eu declarei aqui como string esperada ai sim o teste vai dar OK
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
            leia.SetNome("Sou a Leia");
            string retorno = leia.GetNome();
            Console.WriteLine($"retorno tipo complexo: {retorno} / {leia}");
            // aqui nesse teste não declaramos o Assert
        }

        [TestMethod]
        public void Conversão_Implicita_Test()
        {
            int inteiro = 10;
            double valor = inteiro;
            Console.WriteLine( valor );
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
            Cachorro cachorro = new Cachorro();
            cachorro.SetNome("Leia");
            HelloLuis.PassaReferencia(cachorro);

            string nomeCachorro = cachorro.GetNome();
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
            Cachorro tequila = new Cachorro();
            tequila.SetPeso(10);
            Cachorro spaik = new Cachorro();
            spaik.SetPeso(10);
            Console.WriteLine($"Tequila: {tequila.GetPeso}, Spaik: {spaik.GetPeso} ");
            //Assert.AreEqual(tequila.GetPeso, spaik.GetPeso);
            Assert.AreNotEqual(tequila.GetPeso, spaik.GetPeso);
        }


        [TestMethod]
        public void Igualdade_entre_tipo_de_Referencia_Test()
        {
            //Estamos testando a igualdade entre os objetos, comparar dois objetos mesmo que tenham o mesmo conteudo não será igual se vc der new em cada um dos objetos, para um objeto ser igual ao outro, atribua o valor do outro objeto a esse objeto novo, nao crie uma nova instancia com o new, coloque, objeto 1 = objeto 2 dai ambos serão iguais.
            Cachorro tequila = new Cachorro();
            tequila.SetPeso(10);
            Cachorro spaik = tequila; // para um objeto ser igual ao outro, atribua o valor do outro objeto a esse objeto novo, nao crie uma nova instancia com o new, coloque, objeto 1 = objeto 2 dai ambos serão iguais. 
            //aqui vc está apontando a referencia de um objeto para o outro assim ambos serão iguais ou seja duas referencia em memoria apontando para o mesmo objeto instanciado
            spaik.SetPeso(10);
            Console.WriteLine($"Tequila: {tequila.GetPeso}, Spaik: {spaik.GetPeso} ");
            Assert.AreEqual(tequila.GetPeso, spaik.GetPeso);
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

            Assert.AreEqual(null , nome);
            Assert.AreEqual(null , cachorro);

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
    }
}
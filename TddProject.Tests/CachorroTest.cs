
using System.Reflection.PortableExecutable;
using TddProject.Domain;

namespace TddProject.Tests
{
    [TestClass]//ao criar uma nova classe de teste, coloque a Decoração [TestClass] e faça o import do Using (using Microsoft.VisualStudio.TestTools.UnitTesting;) apenas se o visual studio não idendificar a decoração
    public class CachorroTest
    {
        //vamos iniciar o teste, fazendo o teste de um dos comportamentos do cachorro que é o latir, para isso vc vai criar o metodo de latir dentro da classe cachorro apos criar esse comportamento de teste aqui
        [TestMethod]
        public void cachorro_latir_test() //esta primeira linha superior é a assinatura do metodo e ela não pode se repetir em outro metodo exatamente igual
        {
            var leia = new Cachorro();  //Cachorro() é o construtor da classe, aqui estamos criando um objeto da classe cashorro, declaramos uma variavel, damos um nome a esta variavel e instanciamos a classe cachorro (new)  atribuindo o retorno da classe para esta variavel to tipo chachorro chamada Leia
            var latido = leia.Latir();  //quando vc esta escrevendo um teste, vc cria metodos sem mesmo ele existir, use o intelisense para utilizar a opção do visual studio criar o metodo para vc lá dentro da sua classe
            Console.WriteLine( latido ); //aqui estou exibindo o resuldado da variavel latido

            Assert.AreEqual("Au! Au!", latido);

        }

        // considerando que a Léia pesa 1kg,
        // e come 5% do seu peso de ração,
        // implemente o método "QuantoDevoComer"
        // para passar nesse Teste

        [TestMethod]
        public void Leia_QuantoDevoComer_test()
        {
            var leia = new Cachorro();
            var quantoDevoComerPeso = leia.QuantoDevoComerPeso(10);
            Console.WriteLine( quantoDevoComerPeso );
            Assert.AreEqual("Como tenho 10kg, devo comer 500g por dia", quantoDevoComerPeso);
        }

        [TestMethod]
        public void Tequila_QuantoDevoComer_test()
        {
            var tequila = new Cachorro();
            var quantoDevoComer = tequila.QuantoDevoComer();
            Console.WriteLine(quantoDevoComer);
            Assert.AreEqual("Coma no maximo 5 % do seu peso corporal, qual é seu peso?", quantoDevoComer);
        }

        [TestMethod]
        public void Yuri_QuantoDevoComer_test()
        {
            var yuri = new Cachorro();
            var quantoDevoComerMacho = yuri.QuantoDevoComerMacho(10,true);
            Console.WriteLine(quantoDevoComerMacho);
            Assert.AreEqual(1, quantoDevoComerMacho);
        }

        [TestMethod]
        public void Cachorro_Set_Get_Nome_Test()
        {
            var yuri = new Cachorro();
            yuri.Nome="Yuri"; // o set vai gravar a string Yuri dentro do atributo nome clique em refatorar para criar no metodo SetNome na classe cachorro
            var nome = yuri.Nome; //o get vai buscar o valor que está gravado dentro do atributo nome
            Console.WriteLine( nome );

            Assert.AreEqual("Yuri", nome );

        }

        [TestMethod]
        public void Cachorro_Peso_Nao_Pode_Ser_Negativo_Test()
        {
            //se o peso informado for negativo não deve gravar o Set, ele tem que ficar como 0
            var spaik = new Cachorro();
            spaik.Peso=-1.2;
            var peso = spaik.Peso;
            Console.WriteLine(spaik.Peso);

            Assert.AreEqual(0, spaik.Peso);

        }


        //Crie um atributo para identificar se o cachorro foi vacinado, usando o tipo bool
        [TestMethod]
        public void Cachorro_Foi_Vacinado_Test() 
        {
            var thor = new Cachorro();
            var FuiVacinado = thor.FuiVacinado(true);
            Console.WriteLine(FuiVacinado);
            Assert.AreEqual(true, FuiVacinado);
        }

        //Modifique o Método Latir para que ele receba como parâmetro a quantidade de latidos, num parametro do tipo short.
        [TestMethod]
        public void Quantas_Vezes_Devo_Latir_Wile_Test()
        {
            var thor = new Cachorro();
            var latindo = thor.Latindo(5);
            Console.WriteLine(latindo.Length);
            Assert.AreEqual(5, latindo.Length);
        }


        [TestMethod]
        public void Quantas_Vezes_Devo_Latir_For_Test()
        {
            var tequila = new Cachorro();
            var latindoFor = tequila.latindoFor(3);
            Console.WriteLine(latindoFor);
            Assert.AreEqual("Au! Au! Au!", latindoFor);
        }

        [TestMethod]
        public void Peso_do_Cachorro_Pode_Ser_Nulo_Test() 
        {
            var thor = new Cachorro();
            thor.Peso=null;
            Console.WriteLine($"o peso do thor é: {thor.Peso}");

            Assert.AreEqual(null, thor.Peso);
        }




        // Crie uma propriedade no cachorro para armazenar data de nascimento
        //remover a propriedade idade do cachorro
        //crie um teste unitario e um metodo que retorne a idade do cachorro
        //a idade deve ser retornada em uma string exemplo "10 anos" ou "2 meses"
        [TestMethod]
        public void Cachorro_GetIdade_Em_Anos_Test()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = new DateTime(2020, 1, 10);

            var idade =  cachorro.GetIdade();
            // Assert.AreEqual("4 anos", idade); // como o DateTime atual não para o assert dara erro conforme o passar do tempo, vamor comentar esses asserts para não regar erro na compilação e usalo somente quando formos testar esses metodos em especifico
            Console.WriteLine($"idade: {idade}");
        }


        [TestMethod]
        public void Cachorro_GetIdade_Um_Ano_Test()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = new DateTime(2023, 1, 10);

            var idade = cachorro.GetIdade();
            //Assert.AreEqual("1 ano", idade); //// como o DateTime atual não para o assert dara erro conforme o passar do tempo, vamor comentar esses asserts para não regar erro na compilação e usalo somente quando formos testar esses metodos em especifico
            Console.WriteLine($"idade: {idade}");
        }




        [TestMethod]
        public void Cachorro_GetIdade_Meses_Test()
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = new DateTime(1981, 6, 19);

            var idade = cachorro.GetIdade();
            //Assert.AreEqual("43 anos", idade); // como o DateTime atual não para o assert dara erro conforme o passar do tempo, vamor comentar esses asserts para não regar erro na compilação e usalo somente quando formos testar esses metodos em especifico

            Console.WriteLine($"idade: {idade}");
        }


 
        [TestMethod]
        public void Cachorro_GetIdade_Completa_Test() //metodo luis paga calcular anos e meses de idade GetIdadeCompleta
        {
            var cachorro = new Cachorro();
            cachorro.DataNascimento = new DateTime(1981, 6, 19);
            var idade = cachorro.GetIdadeCompleta();
            //Assert.AreEqual("42 anos e 11 meses", idade); // como o DateTime atual não para o assert dara erro conforme o passar do tempo, vamor comentar esses asserts para não regar erro na compilação e usalo somente quando formos testar esses metodos em especifico
            Console.WriteLine($"idade: {idade}");
        }



    }
}

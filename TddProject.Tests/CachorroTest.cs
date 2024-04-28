﻿
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
            Cachorro leia = new Cachorro();  //Cachorro() é o construtor da classe, aqui estamos criando um objeto da classe cashorro, declaramos uma variavel, damos um nome a esta variavel e instanciamos a classe cachorro (new)  atribuindo o retorno da classe para esta variavel to tipo chachorro chamada Leia
            string latido = leia.Latir();  //quando vc esta escrevendo um teste, vc cria metodos sem mesmo ele existir, use o intelisense para utilizar a opção do visual studio criar o metodo para vc lá dentro da sua classe
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
            Cachorro leia = new Cachorro();
            string quantoDevoComerPeso = leia.QuantoDevoComerPeso(10);
            Console.WriteLine( quantoDevoComerPeso );
            Assert.AreEqual("Como tenho 10kg, devo comer 500g por dia", quantoDevoComerPeso);
        }

        [TestMethod]
        public void Tequila_QuantoDevoComer_test()
        {
            Cachorro tequila = new Cachorro();
            string quantoDevoComer = tequila.QuantoDevoComer();
            Console.WriteLine(quantoDevoComer);
            Assert.AreEqual("Coma no maximo 5 % do seu peso corporal, qual é seu peso?", quantoDevoComer);
        }

        [TestMethod]
        public void Yuri_QuantoDevoComer_test()
        {
            Cachorro yuri = new Cachorro();
            double quantoDevoComerMacho = yuri.QuantoDevoComerMacho(10,true);
            Console.WriteLine(quantoDevoComerMacho);
            Assert.AreEqual(1, quantoDevoComerMacho);
        }

        [TestMethod]
        public void Cachorro_Set_Get_Nome_Test()
        {
            Cachorro yuri = new Cachorro();
            yuri.SetNome("Yuri"); // o set vai gravar a string Yuri dentro do atributo nome clique em refatorar para criar no metodo SetNome na classe cachorro
            string nome = yuri.GetNome(); //o get vai buscar o valor que está gravado dentro do atributo nome
            Console.WriteLine( nome );

            Assert.AreEqual("Yuri", nome );

        }

        [TestMethod]
        public void Cachorro_Peso_Nao_Pode_Ser_Genativo_Test()
        {
            //se o peso informado for negativo não deve gravar o Set, ele tem que ficar como 0
            Cachorro spaik = new Cachorro();
            spaik.SetPeso(-1.2);
            double peso = spaik.GetPeso();
            Console.WriteLine(peso);

            Assert.AreEqual(0, peso);

        }


        //Crie um atributo para identificar se o cachorro foi vacinado, usando o tipo bool
        [TestMethod]
        public void Cachorro_Foi_Vacinado_Test() 
        {
            Cachorro thor = new Cachorro();
            bool FuiVacinado = thor.FuiVacinado(true);
            Console.WriteLine(FuiVacinado);
            Assert.AreEqual(true, FuiVacinado);
        }

        //Modifique o Método Latir para que ele receba como parâmetro a quantidade de latidos, num parametro do tipo short.
        [TestMethod]
        public void Quantas_Vezes_Devo_Latir_Wile_Test()
        {
            Cachorro thor = new Cachorro();
            string[] latindo = thor.Latindo(5);
            Console.WriteLine(latindo.Length);
            Assert.AreEqual(5, latindo.Length);
        }


        [TestMethod]
        public void Quantas_Vezes_Devo_Latir_For_Test()
        {
            Cachorro tequila = new Cachorro();
            string latindoFor = tequila.latindoFor(3);
            Console.WriteLine(latindoFor);
            Assert.AreEqual("Au! Au! Au!", latindoFor);
        }

    }
}
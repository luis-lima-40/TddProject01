using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddProject.Domain;

namespace TddProject.Tests
{
    [TestClass]
    public class DonoTest
    {

        //######################################################################################################################################//
        //  *** Associação de Coleção ***
        //  A orientação a Objetos permite que façamos associações com Coleções de Objetos
        //  Eu tenho uma classe que tem uma propriedade que aponta para uma coleção de objetos de outra classe.
        //  Podemos ter um relacionamento de M para M, muitos para muitos, atraves das associações com coleções
        //  
        //  exemplo, na classe dono, olando para o ponto de vista do dono, um dono pode ter varios animais
        //  ja olhando do ponto de vista da classe Cachorro, um cachorro tem 1 dono, Sendo assim podemos representar isso
        //  atraves de uma Associação de coleções, represente isso no Modelo.cd
        //  na classe dono, crie uma propriedade do tipo coleção onde ele possa ter varios cachorros, exemplo lista (public List<Cachorro> Pets { get; set; })
        //  Desta forma criamos no nosso modelo, a classe dono esta associada a uma coleção do tipo list da classe cachorro
        //  Vamos criar uma nova classe de Testes chamada DonoTest.cs para nossos proximos testes ref. ao dono olhando da perspectiva da classe dono
        //######################################################################################################################################//

        [TestMethod]
        public void Dono_AddPet_Test()
        {
            //como eu faço para adicionar uma lista de cachorros para um dono

            // *** Atenção *** --> Toda coleção List que vc criar precisa ser inicializada, pois ela é inicializada como null
            // automaticamente pelo compilador, se vc tendar dar um Add, valor, ele não será atribuido porque a lista não 
            // foi inicilizada ainda com um valor e vai estourar um System.NullReferenceException: Object reference not set to an instance of an object.

            //vamos adicionar os dois cachorros acima sendo cachorros da silvia utilizando
            //a propriedade Pets que é uma lista de cachorros

            var leia = new Cachorro { Nome = "Leia" };
            var yuri = new Cachorro { Nome = "Yuri" };
            var vesgo = new Gato { Nome = "Vesgo" };
            var mingau = new Gato { Nome = "Mingau" };

            var silvia = new Dono { Nome = "Silvia" }; 

            silvia.AddPet(leia); // vamos criar um metodo AddPet para fazer a adição de um Pet a um dono e seus respectivos atributos
            silvia.AddPet(yuri);
            silvia.AddPet(vesgo);
            silvia.AddPet(mingau);

            Assert.AreEqual(4, silvia.Pets.Count());
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(silvia, yuri.Dono);
            Assert.AreEqual(silvia, vesgo.Dono);
            Assert.AreEqual(silvia, mingau.Dono);

            //Agora que temos uma associação onde um dono tem 2 cachorros, verifique o outro lado dessa associação
            //para verificar se aquele cachorro em sua propriedade dono possui o mesmo dono que vc informou na atribuição da classe
            // os carrocho leia e Yuri devem ter a silvia como sua dona sedado na propriedade dono do cachorro,
            // ou seja vc tem uma associação inversa, vc tem no seu cachorro uma associação ao dono e vc tem no dono uma lista de cachorros


            foreach (var pet in silvia.Pets)
            {
                //Console.WriteLine(pet.Nome); // use a linha abaico para pegar o nome da classe e assim saber quem é gato e quem é cachorro ou qualquer outro animal pertecente a interface IPet
                // A interface é uma abstração de classes, então vc pode pegar o nome da classe da qual ela foi implementada.
                Console.WriteLine($"{pet.GetType().Name} : {pet.Nome}");
                //se vc usar o .GetType apos o nome de uma classe que foi instanciada, e pegar o atributo .Name exemplo {pet.GetType().Name} , ele irá retornar o nome da classe a qual o resultado pertence, no casso cai trazer o nome da classe gato ou cachorro que foi instanciado
            }
            //Console.WriteLine($"leia.Dono: {leia.Dono} {Environment.NewLine} Yuri.Dono: {Yuri.Dono}");
            Console.WriteLine
                ($" leia.Dono: {leia.Dono.Nome} {Environment.NewLine} yuri.Dono: {yuri.Dono.Nome} {Environment.NewLine} vesgo.Dono: {vesgo.Dono.Nome} {Environment.NewLine} mingau.Dono: {mingau.Dono.Nome}");
        }



        [TestMethod]
        public void Dono_RemovePet_Test()
        {
            // vamos criar um metodo AddPet para fazer a adição de um Pet a um dono e seus respectivos atributos
            //vamos supor que vc está preenchendo um cadastro de um dono e a pessoa errou em incluir um pet, para ela remover
            //vamos chamar o metodo RemovePet para remover o pet que foi passado erroneamente

            var leia = new Cachorro { Nome = "Leia" };
            var yuri = new Cachorro { Nome = "Yuri" };
            var vesgo = new Gato { Nome = "Vesgo" };
            var mingau = new Gato { Nome = "Mingau" };

            var silvia = new Dono { Nome = "Silvia" };

            silvia.AddPet(leia); 
            silvia.AddPet(yuri);
            silvia.AddPet(vesgo);
            silvia.AddPet(mingau);

            silvia.RemovePet(yuri);
            silvia.RemovePet(vesgo);

            Assert.AreEqual(2, silvia.Pets.Count());
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(silvia, mingau.Dono);
            Assert.AreEqual(null, yuri.Dono); // como vamos remorer o dono do yuri ele vai ficar sem dono com sua propriedade Dono nula
            Assert.AreEqual(null, vesgo.Dono);

            foreach (var pet in silvia.Pets)
            {
                Console.WriteLine($"{pet.GetType().Name} :{pet.Nome}");
            }
            //Console.WriteLine($"leia.Dono: {leia.Dono.Nome} {Environment.NewLine} Yuri.Dono: {Yuri.Dono.Nome}");
        }

        //Exercicios
        // Crie mais 2 metodos no dono para permitir adicionar e remover varios pets de uma só vez

        [TestMethod]
        public void Dono_Varios_AddPetS_Test() //sobrecarga de metodos, o mesmo metodo que aceita adicionar 1 pet por vez, voi criado novamente como sobrecarga recebendo um parametro de array que serve para adicionar varios cachorros ao mesmo tempo
        {
            var leia = new Cachorro { Nome = "Leia" };
            var yuri = new Cachorro { Nome = "Yuri" };
            var vesgo = new Gato { Nome = "Vesgo" };
            var mingau = new Gato { Nome = "Mingau" };


            var silvia = new Dono {Nome = "Silvia" };

            //var pets = new[] {leia, Yuri }; 
            //silvia.AddPet(pets); 
            //ao inves de declarar um array aqui vamos usar os objetos criados acima, passando um por um como parametro para a chamada do metrodo
            // AddPet e lá na dentro da classe AddPet vamos usar o termo params  public void AddPet(params Cachorro[] pets) dessa forma o compilador entende e interpreta que esses objetos passados aqui são parametros do tipo array que esta esperando lá no metodo lá na classe

            silvia.AddPet(leia, yuri, vesgo, mingau); 

            Assert.AreEqual(4, silvia.Pets.Count());
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(silvia, yuri.Dono);
            Assert.AreEqual(silvia, vesgo.Dono);
            Assert.AreEqual(silvia, mingau.Dono);


            foreach (var pet in silvia.Pets)
            {
                Console.WriteLine($"{pet.GetType().Name} : {pet.Nome}");
            }

        }



        [TestMethod]
        public void Dono_Varios_RemovePet_Test()
        {
            var leia = new Cachorro { Nome = "Leia" };
            var yuri = new Cachorro { Nome = "Yuri" };
            var toby = new Cachorro { Nome = "Toby" };
            var vesgo = new Gato { Nome = "Vesgo" };
            var mingau = new Gato { Nome = "Mingau" };
            var magrelo = new Gato { Nome = "Magrelo" };


            var silvia = new Dono { Nome = "Silvia" };
            

            silvia.AddPet(leia, yuri, toby, vesgo, mingau, magrelo);
            
            //vamos supor que vc está preenchendo um cadastro de um dono e a pessoa errou em incluir um pet, para ela remover
            //vamos chamar o metodo RemovePet para remover o pet que foi passado erroneamente
            silvia.RemovePet(yuri, toby, mingau, magrelo );

            Assert.AreEqual(2, silvia.Pets.Count());
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(silvia, vesgo.Dono);

            Assert.AreEqual(null, yuri.Dono); // como vamos remorer o dono do yuri ele vai ficar sem dono com sua propriedade Dono nula
            Assert.AreEqual(null, toby.Dono);
            Assert.AreEqual(null, mingau.Dono);
            Assert.AreEqual(null, magrelo.Dono);

            foreach (var pet in silvia.Pets)
            {
                Console.WriteLine($"{pet.GetType().Name} : {pet.Nome}");
            }
            //Console.WriteLine($"leia.Dono: {leia.Dono.Nome} {Environment.NewLine} Yuri.Dono: {Yuri.Dono.Nome}");
        }




    }
}

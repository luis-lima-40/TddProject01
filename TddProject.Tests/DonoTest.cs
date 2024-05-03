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
            var Yuri = new Cachorro { Nome = "Yuri" };
            var silvia = new Dono { Nome = "Silvia" }; 

            silvia.AddPet(leia); // vamos criar um metodo AddPet para fazer a adição de um Pet a um dono e seus respectivos atributos
            silvia.AddPet(Yuri);

            Assert.AreEqual(2, silvia.Pets.Count());
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(silvia, Yuri.Dono);
            //Agora que temos uma associação onde um dono tem 2 cachorros, verifique o outro lado dessa associação
            //para verificar se aquele cachorro em sua propriedade dono possui o mesmo dono que vc informou na atribuição da classe
            // os carrocho leia e Yuri devem ter a silvia como sua dona sedado na propriedade dono do cachorro,
            // ou seja vc tem uma associação inversa, vc tem no seu cachorro uma associação ao dono e vc tem no dono uma lista de cachorros


            foreach (var pet in silvia.Pets)
            {
                Console.WriteLine(pet.Nome);
            }
            //Console.WriteLine($"leia.Dono: {leia.Dono} {Environment.NewLine} Yuri.Dono: {Yuri.Dono}");
            Console.WriteLine($"leia.Dono: {leia.Dono.Nome} {Environment.NewLine} Yuri.Dono: {Yuri.Dono.Nome}");
        }



        [TestMethod]
        public void Dono_RemovePet_Test()
        {
            var leia = new Cachorro { Nome = "Leia" };
            var Yuri = new Cachorro { Nome = "Yuri" };
            var silvia = new Dono { Nome = "Silvia" };

            silvia.AddPet(leia); 
            silvia.AddPet(Yuri);
            //vamos supor que vc está preenchendo um cadastro de um dono e a pessoa errou em incluir um pet, para ela remover
            //vamos chamar o metodo RemovePet para remover o pet que foi passado erroneamente
            silvia.RemovePet(Yuri);

            Assert.AreEqual(1, silvia.Pets.Count());
            Assert.AreEqual(silvia, leia.Dono);
            Assert.AreEqual(null, Yuri.Dono); // como vamos remorer o dono do yuri ele vai ficar sem dono com sua propriedade Dono nula

            foreach (var pet in silvia.Pets)
            {
                Console.WriteLine(pet.Nome);
            }
            //Console.WriteLine($"leia.Dono: {leia.Dono.Nome} {Environment.NewLine} Yuri.Dono: {Yuri.Dono.Nome}");
        }



    }
}

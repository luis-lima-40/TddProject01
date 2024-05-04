
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using TddProject.Domain;

namespace TddProject.Tests
{
    [TestClass]//ao criar uma nova classe de teste, coloque a Decoração [TestClass] e faça o import do Using (using Microsoft.VisualStudio.TestTools.UnitTesting;) apenas se o visual studio não idendificar a decoração
    public class GatoTest
    {
        // Exercicios:
        // Implementar o Metodo "Miar" para o Gato

        // Refatorar o Método "Validar" para que as validações comuns entre gato e cachorro fiquem no Animal (Pai) e as
        // Validações específicas fiquem nas classes do Cachorro ou do Gato

        [TestMethod]
        public void Gato_Miar_test() 
        {
            var vesgo = new Gato();  
            var miado = vesgo.Miar(3); 
            
            Console.WriteLine(miado);

            Assert.AreEqual("Miau! Miau! Miau!", miado);

        }


    }


}

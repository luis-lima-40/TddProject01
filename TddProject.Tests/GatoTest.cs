
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

        [TestMethod]
        public void Gato_Validar_Test() //Este metodo valida todas as regras de validação do cadastro de cachorro usando tray catch
        {
            try
            {
                var gato = new Gato
                {
                    Nome = "",
                }; 
                
                gato.Validar(); 
                                    
                Assert.Fail();
            }
            catch (Exception ex)
            {
                var ok = ex.Message.Contains("Nome do Pet é obrigatório!"); 
                Assert.AreEqual(true, ok);
                Console.WriteLine(ex.Message);
            }

        }


        [TestMethod]
        public void Gato_QuantoDevoComer_Test()
        {
            var gato = new Gato { Peso = 6 };
            var quantoDevoComer = gato.QuantoDevoComer();

            Console.WriteLine(quantoDevoComer);
            Assert.AreEqual("Como tenho 6kg, devo comer 60g por dia", quantoDevoComer);
        }

    }

}

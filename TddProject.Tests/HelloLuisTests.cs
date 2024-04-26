using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; //porque vamos usar o console para imprimir mensagens de retorno
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
    }
}
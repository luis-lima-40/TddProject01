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




        //Atividades:
        //criar testes unitarios e um metodo no cachorro que faça as seguintes validações:
        //Nome do cachorro é obrigatório
        //Sexo do cachorro precisa ser "Femea" ou "Macho". Qualquer outro valor é inválido!
        //Data de nascimento não pode ser maior que data de hoje
        //Peso deve ser maior que 0
        //Esse Metodo deverá retornar as mensagens no caso de campos inválidos. ou Null se tudo estiver OK
        //esse metodo deverá retornar caso uma ou mais dessas condições sejam falsas, retorne uma mensagem,
        //se tiver mais que uma mensagem de erro retorne as mensagem em uma coleção, uma lista de strings
        //se todas as condições estão ok e o cachorro 100% validado, retorne null
        //criando um teste unitário para cada uma das validações:


        // [TestMethod]
        // public void Cachorro_Nome_Obrigatorio_Test() //criando um metodo com todas as propriedades corretas exceto o nome, que não estou definindo e ele vai estar nulo, logo é uma condição invalida
        // {
        //     try
        //     {
        //         var cachorro = new Cachorro
        //         {
        //             Nome = "",
        //             Sexo = "Fêmea",
        //             DataNascimento = new DateTime(2020 / 2 / 20),
        //             Peso = 2
        //         }; // ao invez de vc instanciar um objeto e preencher propriedade por propriedade manualmente, vc pode fazer uma inicilização automatica em refatorar usando Object initialization can be simplified
        // 
        //         //o comportamento experado é que o sistema valide, lance um exception nessa linha cachorro.Validar() e o sistema direcione para o catch (Exception ex), agora vamo refatorar o metodo validar com try catch
        //         cachorro.Validar(); //deve retornar pra gente uma lista de mensagens
        //                             //vai retornar uma lista com 1 unico item dizendo que o nome do cachorro é obrigatório
        //         Assert.Fail(); //se o metodo validar e não encontrar o erro do nome significa que meu teste deve falhar, assim usamos o Assert.Fail
        //     }
        //     catch (Exception ex)
        //     {
        // 
        //         //não vamos poder usar o AreEqual, pois o retorno pode ter mais que uma mensagem de erro, vamos precisr
        //         //usar uma variavel auxiliar com o metodo Contains();  que verifica se o texto expecifico contem no retorno do ex.Message
        //         var ok = ex.Message.Contains("Nome do cachorro é obrigatório!");
        // 
        //         Assert.AreEqual(true, ok); //a validação vai com a variavel booleana ok que criamos acima para ver se contem o testo do erro
        //         Console.WriteLine(ex.Message);
        //     }
        // 
        // }

        // [TestMethod]
        // public void Cachorro_Sexo_Deve_Ser_Femea_ou_Macho_Test()
        // {
        //     var cachorro = new Cachorro
        //     {
        //         Nome = "Leia",
        //         Sexo = "xyz",
        //         DataNascimento = new DateTime(2020 / 2 / 20),
        //         Peso = 2
        //     }; // ao invez de vc instanciar um objeto e preencher propriedade por propriedade manualmente, vc pode fazer uma inicilização automatica em refatorar usando Object initialization can be simplified
        // 
        //     var mensagens = cachorro.Validar(); 
        //     Assert.AreEqual("Sexo do cachorro deve ser Fêmea ou Macho!", mensagens[0]); //a validação vai ser olhando para lista no indice [0]
        //     Console.WriteLine(mensagens[0]);
        // 
        // }
        // 
        // [TestMethod]
        // public void Cachorro_DataNascimento_Deve_Ser_Menor_que_Hoje_Test()
        // {
        //     var cachorro = new Cachorro
        //     {
        //         Nome = "Leia",
        //         Sexo = "Fêmea",
        //         DataNascimento = DateTime.Today.AddMonths(5),
        //         Peso = 2
        //     }; 
        // 
        //     var mensagens = cachorro.Validar();
        //     Assert.AreEqual("Data de nascimento deve ser menor que data de hoje!", mensagens[0]); //a validação vai ser olhando para lista no indice [0]
        //     Console.WriteLine(mensagens[0]);
        // }
        // 
        // [TestMethod]
        // public void Cachorro_Peso_Deve_ser_Maior_que_Zero_Test()
        // {
        //     var cachorro = new Cachorro
        //     {
        //         Nome = "Leia",
        //         Sexo = "Fêmea",
        //         DataNascimento = DateTime.Today.AddMonths(-10),
        //         Peso = 0
        //     };
        // 
        //     var mensagens = cachorro.Validar();
        //     Assert.AreEqual("Peso do cachorro deve ser maior que Zero!", mensagens[0]); //a validação vai ser olhando para lista no indice [0]
        //     Console.WriteLine(mensagens[0]);
        // }



        //Atividades:
        // Refatorar o metodo validar cachorro, para lançar uma exception com as mensagens de erro encontradas na validaçãp
        // 


        [TestMethod]
        public void Cachorro_Validar_Test() //Este metodo valida todas as regras de validação do cadastro de cachorro usando tray catch
        {
            try
            {
                var cachorro = new Cachorro
                {
                    Nome = "",
                    Sexo = "xdds",
                    DataNascimento = new DateTime(2025,2,20),
                    Peso = 0
                }; // ao invez de vc instanciar um objeto e preencher propriedade por propriedade manualmente, vc pode fazer uma inicilização automatica em refatorar usando Object initialization can be simplified

                //o comportamento experado é que o sistema valide, lance um exception nessa linha cachorro.Validar() e o sistema direcione para o catch (Exception ex), agora vamo refatorar o metodo validar com try catch
                cachorro.Validar(); //se estiver tudo ok não retorna erro
                                    //vai retornar um throw com o erro se existir
                Assert.Fail(); //se o metodo validar e não encontrar o erro do nome significa que meu teste deve falhar, assim usamos o Assert.Fail
            }
            catch (Exception ex)
            {

                //não vamos poder usar o AreEqual, pois o retorno pode ter mais que uma mensagem de erro, vamos precisr
                //usar uma variavel auxiliar com o metodo Contains();  que verifica se o texto expecifico contem no retorno do ex.Message
                var ok = ex.Message.Contains("Nome do cachorro é obrigatório!") &&
                         ex.Message.Contains("Sexo do cachorro deve ser Fêmea ou Macho!") &&
                         ex.Message.Contains("Data de nascimento deve ser menor que data de hoje!") &&
                         ex.Message.Contains("Peso do cachorro deve ser maior que Zero!");

                Assert.AreEqual(true, ok); //a validação vai com a variavel booleana ok que criamos acima para ver se contem o testo do erro
                Console.WriteLine(ex.Message);
            }

        }

        //######################################################################################################################################//
        //  *** Associação ***
        //  Associação na orientação a objetos, é quando uma classe 
        //  possui uma propriedade que aponta para outra classe do Modelo
        //  Seria o equivalente a chave estrangeira do modelo relacional
        //  ou seja, um relacionamento entre duas classe chamamos de Associação
        //######################################################################################################################################//

        [TestMethod]

        public void Cachorro_Associacao_Raca_Test()
        {
            //quando pensamos em associação pensamos em dois lado, em duas classes que irão se relacionar
            //exemplo temos a classe chachorro, e a classe cachorro pode se relacionar com outra classe Raca,
            //ou seja a propriedade raca do cachorro pode ser outra classe, e no modelo relacional poderiamos
            //ter uma tabela cachorro e outra de raça
            var labrador = new Raca {Nome = "Labrador" };
            var tequila = new Cachorro
            {
                Nome = "Tequila",
                Raca = labrador                //estamos instanciando esses objetos mas criando um vinculo entre os dois objetos, temos uma propriedade Raca na classe cachorro do Tipo da classe Raca que esta vinvulado a classe cachorro
            };

            Console.WriteLine( tequila.Raca.Nome );
            Assert.AreEqual("Labrador", tequila.Raca.Nome);
        }



        //######################################################################################################################################//
        //  *** Cass Diagram ***
        //  O Visual Studio possui uma ferramenta interessante, para vermos na forma de diagramas, o modelo das nossas classes
        //  Essa ferramenta se chama Designer de Classe
        //  Por padrão, essa funcionalidade não é instalada no Visual Studio.
        //  Mas podemos instalá-la pelo Visual Studio Installer.
        //  Esta ferramente permite vc montar um diagrama de uma maneira visual e é otima para modelar e ver o modelo como um todo
        //######################################################################################################################################//

    }
}

﻿
using System.ComponentModel.DataAnnotations;
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
            Console.WriteLine(latido); //aqui estou exibindo o resuldado da variavel latido

            Assert.AreEqual("Au! Au!", latido);

        }

        // considerando que a Léia pesa 1kg,
        // e come 5% do seu peso de ração,
        // implemente o método "QuantoDevoComer"
        // para passar nesse Teste

        [TestMethod]
        public void Leia_QuantoDevoComer_test()
        {
            var leia = new Cachorro { Peso = 10};
            var QuantoDevoComer = leia.QuantoDevoComer();
            Console.WriteLine(QuantoDevoComer);
            Assert.AreEqual("Como tenho 10kg, devo comer 500g por dia", QuantoDevoComer);
        }

        [TestMethod]
        public void Tequila_QuantoDevoComer_test()
        {
            var tequila = new Cachorro {Peso = 30 };
            var quantoDevoComer = tequila.QuantoDevoComer();
            Console.WriteLine(quantoDevoComer);
            Assert.AreEqual("Como tenho 30kg, devo comer 1500g por dia", quantoDevoComer);
        }

        [TestMethod]
        public void Yuri_QuantoDevoComer_test()
        {
            var yuri = new Cachorro();
            var quantoDevoComerMacho = yuri.QuantoDevoComerMacho(10, true);
            Console.WriteLine(quantoDevoComerMacho);
            Assert.AreEqual(1, quantoDevoComerMacho);
        }

        [TestMethod]
        public void Cachorro_Set_Get_Nome_Test()
        {
            var yuri = new Cachorro();
            yuri.Nome = "Yuri"; // o set vai gravar a string Yuri dentro do atributo nome clique em refatorar para criar no metodo SetNome na classe cachorro
            var nome = yuri.Nome; //o get vai buscar o valor que está gravado dentro do atributo nome
            Console.WriteLine(nome);

            Assert.AreEqual("Yuri", nome);

        }

        [TestMethod]
        public void Cachorro_Peso_Nao_Pode_Ser_Negativo_Test()
        {
            //se o peso informado for negativo não deve gravar o Set, ele tem que ficar como 0
            var spaik = new Cachorro();
            spaik.Peso = -1.2;
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
            thor.Peso = null;
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

            var idade = cachorro.GetIdade();
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
                    Sexo = Sexo.Macho,
                    DataNascimento = new DateTime(2025, 2, 20),
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
                var ok = ex.Message.Contains("Nome do Pet é obrigatório!") &&
                         //ex.Message.Contains("Sexo do cachorro deve ser Fêmea ou Macho!") && // transformado em enum não precisamos mais validar o sexo
                         ex.Message.Contains("Data de nascimento deve ser menor que data de hoje!") &&
                         ex.Message.Contains("Peso do cachorro deve ser maior que Zero!");

                Assert.AreEqual(true, ok); //a validação vai com a variavel booleana ok que criamos acima para ver se contem o testo do erro
                Console.WriteLine(ex.Message);
            }

        }

        //######################################################################################################################################//
        //  *** 22 - V31 - Associação ***
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
            var labrador = new Raca { Nome = "Labrador" };
            var tequila = new Cachorro
            {
                Nome = "Tequila",
                Raca = labrador                //estamos instanciando esses objetos mas criando um vinculo entre os dois objetos, temos uma propriedade Raca na classe cachorro do Tipo da classe Raca que esta vinvulado a classe cachorro
            };

            Console.WriteLine(tequila.Raca.Nome);
            Assert.AreEqual("Labrador", tequila.Raca.Nome);
        }



        //######################################################################################################################################//
        //  *** 22.1 V31 / V32 - Class Diagram ***
        //  O Visual Studio possui uma ferramenta interessante, para vermos na forma de diagramas, o modelo das nossas classes
        //  Essa ferramenta se chama Designer de Classe
        //  Por padrão, essa funcionalidade não é instalada no Visual Studio.
        //  Mas podemos instalá-la pelo Visual Studio Installer.
        //  Esta ferramente permite vc montar um diagrama de uma maneira visual e é otima para modelar e ver o modelo como um todo
        //  Apos instalado, selecione seu projeto, vá no menu project > Add new Item, Procure por  Cass Diagram, de um nome nesse caso aqui sera Modelo
        //  Arraste suas classes para o Designer, em suas propriedades que tem associação com outras classe clique nela e selecione Show Ass Association
        //######################################################################################################################################//


        //Exercicios:
        //Crie uma nova classe chamada Dono com as propriedades Nome, Telefone e Email
        //Na classe cachorro, crie uma associação com a classe Dono, ou seja um cachorro deve ter um Dono
        //Inclua essa nova classe e Associação no Diagrama

        [TestMethod]

        public void Cachorro_Deve_Ter_Um_Dono_Test()
        {
            var luis = new Dono
            {
                Nome = "Luis",
                Telefone = "11948357348",
                Email = "luis.carlos.lider@hotmail.com"
            };
            var tequila = new Cachorro
            {
                Nome = "Tequila",
                Dono = luis                //estamos instanciando esses objetos mas criando um vinculo entre os dois objetos, temos uma propriedade Raca na classe cachorro do Tipo da classe Raca que esta vinvulado a classe cachorro
            };

            Console.WriteLine(tequila.Dono.Nome);
            Assert.AreEqual("Luis", tequila.Dono.Nome);
        }

        //######################################################################################################################################//
        //  *** 23 - V33 - Enum ***
        //  Um enum ou enumeration é um tipo especial do C#, onde podemos definir um conjunto de constantes nomeadas
        //  Internamente essas constantes sçao do tipo int
        //  Muito útil para enriquecer o modelo da aplicação, para tipos que so podem ser unicos, como sexo, Macho ou Fêmea, 
        //  ou uma propriedade como Departamento de uma empresa onde sua estrutura fisica e organizacional
        //  ja possui um numero determinado e fixo de departamento, ou seja, vc é obrigado e escolhar uma das opções listadas no enum
        //  sem a possibilidade de mudar ou alterar evitando erros de iput incorreto
        //######################################################################################################################################//


        [TestMethod]
        public void Cachorro_Enum_Sexo_Test()
        {
            var cachorro = new Cachorro
            {
                Nome = "Leia",
                Sexo = Sexo.Femea
            };
            Console.WriteLine(cachorro.Sexo);
            Assert.AreEqual(Sexo.Femea, cachorro.Sexo);

        }


        //Exercícios
        //  *** Enum ***
        //  transfira a propriedade Porte do Cachorro para Classe Raca
        //  Transformar a propriedade Porte da Raca do Cachorro para um Enum
        //  Atualizar Testes Unitários e Diagrama
        // Portes: 
        // Mini_toy_ate_6kg
        // Pequeno_anao_6a15kg
        // Médio_15a25kg
        // Grande_25a45kg
        // Gigante_acima45kg

        [TestMethod]
        public void Cachorro_Enum_Raca_Porte_Test()
        {
            var york = new Raca
            {
                Nome = "Yorkshire",
                Porte = Porte.Pequeno_6_a_15kg
            };

            var leia = new Cachorro
            {
                Nome = "leia",
                Raca = york
            };

            Console.WriteLine(leia.Raca.Porte);
            Assert.AreEqual(Porte.Pequeno_6_a_15kg, leia.Raca.Porte);
        }

        //######################################################################################################################################//
        //  *** 24 - V35 - Associação de Coleção ***
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



        //######################################################################################################################################//
        //  *** 25 - V37 - Interfaces ***
        // Em resumo a interface serve como um contrato para nossas classe, nem sempre eu tenho todas as propriedades
        // da classe na interface, mas posso obtelas com o unboxing como foi exemplificado acima pegando o atributo peso que está somente em cachorro e não está na interface
        // conforme formos evoluindo a modelagem da aplicação e muito comum ter interfaces para representar nossas classes,
        // abstraindo partes da nossa aplicacação atraves de interfaces para criar os contratos que vamos usar na nossa arquitetura
        // um outro notivo ou vantagem de se ter uma interface, a partir de agora alem da classe cachorro, vamos ter
        // uma classe de gatos, vamos criar uma classe gato, e vamos implementar a mesma interface IPet, assim o IPet, será o contrato para qualquer tipo de animal que seja um Pet, abstraindo todos os campos (atributos) que todos os pets possuem em comum entre eles.
        // public class Gato : IPet --> o compilador pode gerar automaticamente, implementear o atributos que IPet requer na classe Gato.cs
        // quando eu for trabalhar com atributos especificos de cachorro posso usar o unboxing para o cachorro e o mesmo para atributos especificos do gato.
        //######################################################################################################################################//

        [TestMethod]
        public void Cachorro_IPet_Test()
        {
            // nao podemos instanciar diretamente uma interface, então vamos instanciar um cachorro que vai implementar a interface
            // se a gente tentar atibuir o valor peso para a interfaçe IPet, vai dar erro pois a interface não tem 
            //propriedade peso, somente a classe cachorro tem peso, nesse caso podemos utilizar o recurso chamado de
            //Conversão boxing é o processo de conversão de um tipo de valor para o tipo object ou para qualquer tipo de interface implementada por esse tipo de valor.
            //A conversão unboxing extrai o tipo de valor do objeto. A conversão boxing é implícita, a conversão unboxing é explícita.
            //O conceito de conversões boxing e unboxing serve como base para a exibição unificada de C# do sistema de tipos em que um valor de qualquer tipo pode ser tratado como um objeto.
            // em outras palavras de forma mais clara significa que o IPet ou qualquer Interface funciona como um boxing, um caixote
            // vc pode estrair, obter a classe cahorro integralmente, com todos os seus atributos mesmo que não estejam declarados na interface
            // para isso acontecer vamos usar o unboxing
            // para eu recuperar o cachorro com todos os recursos (propriedades) que ele tem independente da interface faremos o seguinte
            IPet pet = new Cachorro { Nome = "Leia", Peso = 2};

            var leia = pet as Cachorro; //converter um Ipet em um Cachorro, (converter interface em classe)// a leia vai ser igual a pet, mas vc está transformando o pet igual cachorro para pegar o atributo peso que não está implementado na interface IPet
            var thor = (Cachorro)pet;//um outro jeito que da o mesmo resultado é esta notação. converter um Ipet em um Cachorro, (converter interface em classe)


            Assert.AreEqual(2, leia.Peso);
            Assert.AreEqual("Leia", pet.Nome); //vamos verificar se conseguimos criar uma variavel do tipo pet com os dados que criamos uma variavel do tipo cachorro
            Console.WriteLine( pet.Nome );

            // Em resumo a interface serve como um contrato para nossas classe, nem sempre eu tenho todas as propriedades
            // da classe na interface, mas posso obtelas com o unboxing como foi exemplificado acima pegando o atributo peso que está somente em cachorro e não está na interface
            // conforme formos evoluindo a modelagem da aplicação e muito comum ter interfaces para representar nossas classes,
            // abstraindo partes da nossa aplicacação atraves de interfaces para criar os contratos que vamos usar na nossa arquitetura
            // um outro notivo ou vantagem de se ter uma interface, a partir de agora alem da classe cachorro, vamos ter
            // uma classe de gatos, vamos criar uma classe gato, e vamos implementar a mesma interface IPet, assim o IPet, será o contrato para qualquer tipo de animal que seja um Pet, abstraindo todos os campos (atributos) que todos os pets possuem em comum entre eles.
            // public class Gato : IPet --> o compilador pode gerar automaticamente, implementear o atributos que IPet requer na classe Gato.cs
            // quando eu for trabalhar com atributos especificos de cachorro posso usar o unboxing para o cachorro e o mesmo para atributos especificos do gato.


            //Interfaces, Exercícios

            // Na classe Dono, mudar o tipo da propriedade Pets, de chachorro para Ipet, para permitir que um dono
            // tenha cachorros e gatos
            //Fazer o mesmo com os parametros dos Métodos AddPet e RemovePet

        }




        //######################################################################################################################################//
        // *** 26 - V39 - HERANÇA ***
        // 
        // Na OO Orientação a Objetos as  classes podem ter uma relaçao de herança - 
        // Podemos dizer que a herança é um conceito de modelagem
        // A Herançã permite que uma classe "ficlho" herde de uma classe "Pai"
        // 
        // Isso Ignifica que a classe "Filho" vai ter todos os recursos da classe "Pai", mas os seus próprios recursos.
        // Se bem Utilizada, a herança nos permite um alto grau de reutilização de codigo
        // 
        // vamor exemplificar, temos a classe cachorro e a classe gato e ambas as classes implementam a classe IPet
        // Atenção nesse ponto pois Interface não é a mesma coisa que Herança,
        // interface é uma forma de criar contratos no seu codigo quando eu falo que cachorro implementa IPet eu so digo que a classe
        // cachorro obrigatoriamente deve ter os elementos que estao no contrato da interface IPet
        // quando falamos de Herança vamos quebrar a estrutura da classe e vamos passar parte do codigo da estrutura da classe
        // para uma classe Pai e isso só vale a pena ser feito se vamos ter pelo menos DOIS ou MAIS filhos dentro daquela classe PAI
        // Cachorro e Gato tem muitos codigos repetidos falando de suas propriedades, temos em comum em ambos
        // NOME, SEXO, FOTO, DONO, podemos abstrair isso e criar uma classe PAI chamada Animal.cs
        // ATENÇÃO: não existe herança multipla, uma classe filho só pode herdear de 1 unica classe pai
        // ATENÇÃO: No caso de Interfaces, uma classe pode implementar quantas interfaces forem necessários, mas uma clsse filho só implementa apenas 1 classe pai
        // Na classe Gato.cs, ela vai herdar da classe pai Animal.cs e implementar a interface Ipet dessa forma -->  public class Gato : Animal, IPet
        // Também podemos fazer Herança para metodos, ou seja, tanto o gato quanto o cachorro possuem em comum o metodo QuantoDevoComer e Validar
        // a diferença é que a implementação desses metodos QuantoDevoComer e Validar são diferentes
        // o metodo QuantoDevoComer do cachorro tem uma regra de negócio especifica para ele e essa mesma logica para o Metodo Validar, que do cachorro e gato podem ser diferentes.
        // quando temos uma relação de herança, podemos pegar os metodos que são iguais para suas duas classes filho e jogar para a Classe pai
        // tanto o cachorro como gato irão ganhar os dois metodos pela herança
        // vamos falar de Virtual e de Overriide
        // O Virtual podemos colocar nos metodos que a gente quer que os filhos herdem mas que opcionalmente eles podem sobrecarregar
        // ou seja, sobrecarregar é implementar sua propria versão , usar a sua propria versão personalizada em sua propria classe filho.
        // Ja o Overriide, vc coloca no seu metodo filho onde vc quer que o metodo pai seja sobrecarregado, assim vc dis ao compilador
        // usar obrigatoriamente o metodo que está implementado no metodo filho com suas proprias regras de negócio
        //######################################################################################################################################//

        // Exercicios:
        // Implementar o Metodo "Miar" para o Gato

        // Refatorar o Método "Validar" para que as validações comuns entre gato e cachorro fiquem no Animal (Pai) e as
        // Validações específicas fiquem nas classes do Cachorro ou do Gato



        //######################################################################################################################################//
        // *** 27 - V41 - ABSTRAÇÃO - CLASSE ABSTRATA ***
        // 
        // Podemos declarar uma classe como sendo abstrata
        // 
        // Classe Abstrata não vai poder ser instanciada diretamente, e só serve para ser usada numa relação de herança
        // basicamente para uma reutilização de código
        // Também podemos ter métodos abstratos em uma classe classe abstrata
        // a classe abstrata é uma forma de vc criar uma herança e impedir que a classe pai seja instanciada,
        // somente as classes filhas poderao ser instanciadas
        // também podemos ter metodos abstratos dentro de uma classe abstrata
        //######################################################################################################################################//


        //######################################################################################################################################//
        // *** 28 - V43 - Classes e Membros Estaticos  ***
        // 
        // Classes Estáticas não podem ser instanciadas, são classes que não conseguimos instanciar e nao podemos criar objetos
        // Vamos usar os recursos que ela tem sem precisar criar um Objeto da classe estatica
        // Membros estáticos podem ser chamados diretamente através da classe estática, sem necessidade de instaciar objetos
        // 
        // São Muito utilizados para operações Pontuais, em rotinas de utilidades ou conversão, geralmente chamadas de Helpers (ajudantes)
        //######################################################################################################################################//

        // A classe HelloLuis é um excemplo de classe Estatica e seus menbros podem ser chamados diretamente como neste exemplo que está na classe HelloLuisTests.cs, eu chamo diretamente SayHello() sem instanciar nada --> string mensagem = HelloLuis.SayHello();
        // vamos exemplicicar isso de ma forma melhor nos nossos metodos Validar() na Classe pai Animal e na classe filha Cachorro

        //aqui temos o mesmo trecho de codigo em animal e cachorro para converter uma lista de string em uma exception para lancar essa
        //exception no validar do animal e també no validar cachorro, ou seja podemos reutilizar esse codigo dentro de uma classe estatica
        //camos criar uma classe no nosso Domain, chamada Helpers.cs
        //if (mensagens.Count > 0) 
        //{
        //   var exceptionMessage = "";
        //   foreach (var item in mensagens)
        //   {
        //       exceptionMessage += item + Environment.NewLine;
        //   }
        //   throw new Exception(exceptionMessage);
        //}



        //######################################################################################################################################//
        // *** 29 - V44 - Metodos de Extensão  ***
        // 
        // é Uma forma de extender as funcionalidades de uma classe Qualquer. Seja nossa ou de terceiros do proprios framework
        // 
        // Quando Criamos um método de extensão para a classe "string", por exemplo, ela "ganha" esse método adicional criado por nós
        // 
        // Metodos de Extensão são estáticos, obrigatoriamente devem ser estaticos por isso eles são a continuação da aula anterior sobre Classes e Membros Estaticos
        //######################################################################################################################################//

        // Exercicios 29.1 Metodos de Extensão
        // Criar uma classe / Metodo de extensão para o Ipet
        // Esse método deverá retornar uma string, dizendo se o Pet é um Gato ou um Cachorro
        // Refatorar o DonoTest, usando esse novo método onde temos: pet.GetType().Name // este tipo de chamada pet.GetType().Name usa um conceito conhecido como Reflection apenas para conhecimento pois não e com Reflection que estamos trabalhando nesse momento e sim em um metodo de extenão para não usar o Reflection

        //Resolução:
        //começando pelo IPet vamos criar um metodo de extensão e estender o IPet
        // Atenção - Metodos de extensão podem ser criados para classes e interfaces, no caso IPet é uma interface
        // vamos criar o metodo de extensão que pega o nome da classe como esse exemplo que usamos anteriormente pet.GetType().Name}
        // Vamos criar uma classe no Domain chada de PetExtensions.cs



        //######################################################################################################################################//
        // *** 30 - V46 - System.IO  ***
        // 
        // É um conjunto de recursos que vamos encontrar na Interface para trabalhar com pastas, diretórios e arquivos
        // 
        // Mamos Usar o HalloLuisTests
        // 
        // 
        //######################################################################################################################################//





    }


}

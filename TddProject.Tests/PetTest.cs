using TddProject.Domain;
using System.Linq;

namespace TddProject.Tests
{
    [TestClass]//ao criar uma nova classe de teste, coloque a Decoração [TestClass] e faça o import do Using (using Microsoft.VisualStudio.TestTools.UnitTesting;) apenas se o visual studio não idendificar a decoração
    public class PetTest
    {
        // com a decoração [ClassInitialize] vamos criar um metodo de inicialização de testes para codigo que usamos repetidamente com frenquencia nos testes
        //temos também que criar os atributos desse metodo[ClassInitialize] do tipo static
        
        private static List<IPet> _pets;
        
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _pets = new List<IPet>();
            _pets.CarregaPetsdoArquivo("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\pets.csv");
            // desta forma ele vai buscar uma unica vez a lista de pets do arquivo e vai usar em todos os metodos que eu precisar
        }

        private static void ImprimePets(IEnumerable<IPet> pets)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine($"Pets: [{pet.GetTipo()}]  {pet.Nome} - {pet.Dono.Nome}");
            }
        }

        //######################################################################################################################################//
        // *** 30 - V46 - System.IO  ***
        // 
        // É um conjunto de recursos que vamos encontrar na Interface para trabalhar com pastas, diretórios e arquivos
        // 
        // Mamos Usar o HalloLuisTests
        // 
        // 
        //######################################################################################################################################//


        // Exercícios *** 30.1 - V46 - System.IO(input, output)***
        // Criar uma rotina que devera ler o conteudo do arquivo pets.csv, e retornar um Lis<Ipet>,
        // contendo todos os animais que estão nessa lista
        //
        // Criar um teste unitário para listar no console todos os pets dessa Lista
        // arquivo csv "C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\pets.csv"


        [TestMethod]
        public void CarregaPetsdoArquivo_Test()
        {
            //var pets = new List<IPet>();

            //Carrega a lista de pets pelo arquivo "C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\pets.csv"
            // para carregar existem varias formas de implementar, vamos utilizar a classe PetExtensions e vamos criar
            // um metodo de extensão. A idéia é que 
            // 
            //este metodo CarregaPetsdoArquivo() vai ser uma extensão do proprio Lis<IPet> e vamos passar para ele como parametro o caminho de onde está o arquivo a ser carregado
            //com isso o proprio metodo vai dar conta de ler o arquivo e preencher a lista de pets
            //pets.CarregaPetsdoArquivo("C:\\Users\\CorteStiloTatuape\\Documents\\Luis Lima\\01_LUIS_ESTUDOS_2024\\TDD-Tests\\TddProject01\\Aula030\\pets.csv"); 




            // se conseguirmos com sussesso nosso Assert será o seguinte, ela vai conter 15 elementos, linhas de pets:
            Assert.AreEqual(15, _pets.Count); //esse _pets foi carregado estativamente no metodo de inicialização do dos tests no comeco do codigo [ClassInitialize]  _pets
            ImprimePets(_pets);
        }



        //######################################################################################################################################//
        // *** 31 - V48 - LINQ  ***
        // 
        // Language Integrated Query
        // 
        // Permite escrever queries em C#
        // Pode ser usado em coleções em memória, ou em algum database, através de provedores de ORMs
        // ORMs como HHibernate ou Entity Framework traduzem queries LINQ em queries SQL
        //######################################################################################################################################//


        [TestMethod]
        public void Linq_Test()
        {
                                                                                    // ao inves do select iniciamos a instrução de select com a palavra from
            var query = from pet in _pets                                           // vc pode usar o LINQ em qualquer tipo de lista, Enumerable etc, esse _pets foi carregado estativamente no metodo de inicialização do dos tests no comeco do codigo [ClassInitialize]  _pets
                        where pet.GetTipo() == "Cachorro"
                        select pet;

                                                                                    // se conseguirmos com sussesso nosso Assert será o seguinte, ela vai conter 15 elementos, linhas de pets:
                                                                                    //Assert.AreEqual(15, _pets.Count);
            ImprimePets(query);
        }


        [TestMethod]
        public void Linq_Metodos_Test()
        {
            // ao inves do select iniciamos a instrução de select com a palavra from
            // Where() pertente ao using System.Linq; para usalo precisa dar o using
            // a expressao lambda do Where, vc passa o parametro dentro dele( pet => pet.GetTipo() == "Gato" )
            // Geralmente usamos x, nesse caso de forma didatica vamor usar pet 
            // onde pet é a lista de pet.   este operador da expressao lambda => significa dado um elemento da lista de pet aplique esta condição  pet.GetTipo() == "Gato"
            // a expressao Lambda e sempre aplicada em uma coleção e ele vai sempre considerar um elemento da coleção e aplicar a condição Where
            var query = _pets.Where(pet => pet.GetTipo() == "Gato");  

            ImprimePets(query); 
        }



        [TestMethod]
        public void Linq_Order_Test()
        {
            
            var query = from pet in _pets                   
                        where pet.GetTipo() == "Cachorro"
                        orderby pet.Nome
                        select pet;
            ImprimePets(query);
        }


        [TestMethod]
        public void Linq_Order_Metodo_Test()
        {
                                                                                    //podemos alcançar o mesmo objetivo por um metodo de extensão
                                                                                    //os metodos de extensão permitem que vc chame um encima do outro
            var query = _pets.Where(pet => pet.GetTipo() == "Gato")
                        .OrderBy(pet => pet.Nome);                                  //aqui para ordenar não precisa passar um Where, só precisamos dizer qual é a propriedade que vc quer ordenar
                        //.OrderByDescending(pet => pet.Nome);                      // ordena mas tras o resultado de forma decrescente 

            ImprimePets(query);
        }



        [TestMethod]
        public void Linq_Projecao_Test()
        {
                                                                    //projeção de uma query
                                                                    //quando o resultado da query é direrente da estrutura do objeto ou da classe
                                                                    //projeção - exemplo do sql  - ao inves de um select * from vc daria um select codigo, nome, endereço (passando campo por campo) from nome da tabela para trazer apenas os campos que vc quer discartando os demais
            var query = from pet in _pets
                        where pet.GetTipo() == "Cachorro"
                        orderby pet.Peso descending
                        select new { Nome = pet.Nome, Peso = pet.Peso}; //  new porque o resultado da query não vai ser de um tipo conhecido, vai ser to tipo anonimo
                                                                        //ImprimePets(query);// como essa query não é mais um Enumerable devido a projeção ''select new { Nome = pet.Nome, Peso = pet.Peso};'', vamos mudar aqui para 

            foreach (var pet in query)
            {
                Console.WriteLine($"[{pet.Nome}]  {pet.Nome} - {pet.Peso}");
            }

        }

        [TestMethod]
        public void Linq_Projecao_Metodo_Test()
        {

            var query = _pets.Where(pet => pet.GetTipo() == "Gato")
                        .OrderByDescending(pet => pet.Peso)
                        .Select(pet => new {pet.Nome, pet.Peso});

            foreach (var pet in query)
            {
                Console.WriteLine($"[{pet.Nome}]  {pet.Nome} - {pet.Peso}");
            }

        }


    }
}

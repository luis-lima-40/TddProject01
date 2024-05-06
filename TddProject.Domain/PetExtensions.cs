using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace TddProject.Domain
{
    public static class PetExtensions
    {
        public static string GetTipo(this IPet pet)             //criando um metodo statico que retorna uma string chamada GetTipo, que usa a notação this para se tornar uma extensão, que é do tipo Ipet que damos o nome de pet
        {
            return pet.GetType().Name;
        }

                                                                //o metodo de extentão CarregaPetsdoArquivo vai ser estatico, com retorno void, ele vai receber
                                                                //2 parametros, uma é a própria lista que ele está estendendo    com o endereço e nome do arquivo.

        public static void CarregaPetsdoArquivo(this List<IPet> pets, string caminho)
        {
                                                                //ReadAllLines le o arquivo e ja traz um array de string que é mais proprício para nosso retorno e leitura dos dados do CSV, ja o ReadAllText le a string como um todo 
            var donos = new List<Dono>();
            var racas = new List<Raca>();

            var linhas = File.ReadAllLines(caminho);            //cada linha de string desse array ReadAllLines, vai ser uma linha no nosso console, terornaremos 15 linhas
                                                                //neste caso vamos ler essas linhas com um for, não usareos o for foreach porque queremos pular a primeira linha que é o cabeçalho, assim é melhor usar o for normal para pular essa primeira linha
            for (int i = 1; i < linhas.Length; i++)
            {
                                                                // aqui vamos separar as colunas campo por campo que estão delimitadas com ';'
                                                                // dentro da classe string, temos um metodo chamado Split(';') que quebra uma string em partes, vc usa um caracter para dizer qual é o separador, no caso será o ';'
                                                                // ele vai devolter um array de string onde cada elemento desse array é um elemento que foi separado pelo ';'
                                                                //var colunas = linhas[i].Split(";".ToCharArray());
                var colunas = linhas[i].Split(';');             // sabemos que a linha ode vir como um cachorro ou como um gato, então faremos uma validação aqui..

                                                                //A estrutura basica desse metodo faz o seguinte: le o arquivo, separa por virgula as colunas, verifica se é um cachorro
                                                                //ou gato, preenche os parametros parra instanciar a classe chachorro ou gato
                                                                //na sequencia, linha por linha e jogar para dentro da lista List<IPet>

                if (colunas[0] == "Cachorro")
                {


                    var cachorro = new Cachorro();
                                                                                            //preencher todos os dados do cachorro
                                                                                            // o metodo cachorro tem o nome e vamos encontrar o nome na posição numero 1 das colunas do arquivo, lembrando que começa em 0 e a primeira posição é o tipo gato ou cachorro
                                                                                            // o sexo é do tipo enum na classe e o arquivo retorna uma string, então vamos fazer uma ferificação para fazer essa conversao corretamente
                                                                                            // o peso é um double na classe cachorro, vamos converter usando o double.Parse
                                                                                            // o dono do cachorro é mais complexo pois ele é uma outra classe, teriamos que criar uma instancia do dono para vincular ele ao cachorro que é uma outra classe
                                                                                            // se vc observar a lista vc vai ver o mesmo dono para diferentes animais, levando a risca a orientação a objetos o ideal é que
                                                                                            // a instancia do dono do cachorro Yuri tem que ser a mesma instancia do gato Juliano, ambos tem a mesma dona que se chama LILI
                                                                                            // para controlar isso com a mesma instancia a gente precisa criar uma lista de donos que vamos criar la encima no começo da rotina
                                                                                            // com o nome de var donos = new List<Dono>(); com essa lista vamos criar o metodo de extensão getDono que vamos obter atravez da propria lista para devolver a instancia do dono

                    cachorro.SetPropriedadesComuns(donos, colunas);

                    cachorro.Raca = racas.GetRaca(colunas[5], colunas[6]);    //faremos a mesma coisa que criamos com o dono para pegar a lista de raças, vamos buscar a raça de acordo com o nome da raça
                    cachorro.DataNascimento = Convert.ToDateTime(colunas[7]);
                    cachorro.Vacinado = colunas[8] == "sim";


                    pets.Add(cachorro);
                }
                else if (colunas[0] =="Gato")
                {
                    var gato = new Gato();
                    gato.SetPropriedadesComuns(donos, colunas);                                                        //preencher todos os dados do gato
                    pets.Add(gato);
                }

            }

        }

        private static void SetPropriedadesComuns(this IPet pet, List<Dono> donos, string[] colunas)
        {
            pet.Nome = colunas[1];
            pet.Sexo = colunas[2] == "Macho" ? Sexo.Macho : Sexo.Femea;
            pet.Peso = double.Parse(colunas[4]);

            var dono = donos.GetDono(colunas[3]);
            dono.AddPet(pet);
        }

        // este é um metodo de extenão para capturar a instancia do dono atravez de uma lista obtina na leitura de um arquivo
        // é um metodo privado para ser lido no CarregaPetsdoArquivo, é uma extensão da classe Dono, vai extender uma lista de donos this List<Dono> chamada donos , vai retornar um nome
        private static Dono GetDono(this List<Dono> donos, string nomeDono)
        {
            foreach (var dono in donos)
            {
                if (dono.Nome == nomeDono)                                  // se algum dos donos que ja está na lista for igual ao nome do dono que estou recebendo esse será o dono que estou procurando
                    return dono;                                            // se ele percorrer toda lista ou se a lista tiver vazia e não encontar um dono com aquele nome ele vai continuar na proxima instrução abaixo:
            }

                var novoDono = new Dono { Nome = nomeDono};
                                                                            // assim eu adiciono esse novo dona na lista de donos para que na proxima vez que ele aparecer na rotina ele não precise instanciar um novo dono, ele usará o que ja está na lista  
                donos.Add(novoDono);
                return novoDono;

                                                                            //Assim, toda vez que a rotina CarregaPetsdoArquivo for buscar um dono pra gente o metodo GetDono vai garantir que temos uma instancia somente para cada nome de dono
        }

        //GetRaca

        private static Raca GetRaca(this List<Raca> racas, string nomeRaca, string porte)
        {
            foreach (var raca in racas)
            {
                if (raca.Nome == nomeRaca)
                    return raca;
            }

            var novoRaca = new Raca
            {
                Nome = nomeRaca,
                Porte = GetPorte(porte)
            };
            racas.Add(novoRaca);
            return novoRaca;
        }

        private static Porte GetPorte(string porte)
        {
            switch (porte)
            {
                case "Mini":
                    return Porte.Mini_ate_6kg;
                
                case "Pequeno":
                    return Porte.Pequeno_6_a_15kg;
                
                case "Medio":
                    return Porte.Medio_15_a_25kg;
                
                case "Grande":
                    return Porte.Grande_25_a_45kg;
                
                default:
                    return Porte.Gigante_acima_45kg;

                                                                //Mini_ate_6kg,
                                                                //Pequeno_6_a_15kg,
                                                                //Médio_15_a_25kg,
                                                                //Grande_25_a_45kg,
                                                                //Gigante_acima_45kg
            }
        }
    }
}


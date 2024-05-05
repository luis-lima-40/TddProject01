using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace TddProject.Domain
{
    public class Cachorro : Animal,  IPet
    {
        //herdando da classe Pai Animal, os atributos NOME, SEXO, FOTO E DONO E IMPLEMENTANDO A INTERFACE IPET
        // public string? Nome { get; set; } //propriedades automaticas não permitem que vc inclua comportamentos nelas, como validações, para isso vc precisa criar uma estrutura padrão de propriedade com o get / set
        // public Sexo Sexo { get; set; }
        // public string Foto { get; set; }
        // public Dono? Dono { get; set; }

        //public string? Raca { get; set; }
        public Raca? Raca { get; set; }//trocando o tipo da propriedade Raca de String para Classe Raca que criamos para fazer associação entre as classes cachorro e a nova classe Raca, neste momento estamos dizendo que a classe cachorro tem uma associação com a classe raca

        public DateTime DataNascimento { get; set; }


        public bool Vacinado { get; set; }
        


        // private string _nome;
        // private string _sexo;
        // private string _raca;
        // private string _porte;
        // private string _idade;
        // private double? _peso;
        // private bool _vacinado;

        public string Latir() //metodo latir
        {
            return "Au! Au!";

            //throw new NotImplementedException(); // throw´significa lançar uma excessão, e uma excessão é todo erro que ocorre em nosso codigo, aqui significa que esta lancando uma nova excessão dizendo que este metodo não foi implementado ainda.. 
        }

        //public string QuantoDevoComer()  
        //{                                
        //
        //    return "Coma no maximo 5 % do seu peso corporal, qual é seu peso?";
        //    //throw new NotImplementedException();
        //
        //
        //}

        //public string QuantoDevoComerPeso(int peso)
        //{
        //
        //    double qtdRacao = peso * 1000 * 0.05;
        //    //string mensagem = "Como tenho " + peso +
        //    //                    "kg, devo comer " + qtdRacao +
        //    //                    "g por dia";
        //    //usando o recurso de interpolar strings com o $ e ao invez de usar + e concatenar com a variavel, vc utiliza {com o nome da variavel dentro do colchetes}
        //
        //    string mensagem = $"Como tenho {peso}kg, devo comer {qtdRacao}g por dia";
        //
        //    //"Como tenho 10kg, devo comer 100g por dia"
        //    //return (double)(peso * 0.5);
        //    return mensagem;
        //    //throw new NotImplementedException();
        //}

        //simplificando ao maximo o metodo acima, ou seja metodo para calcular 5% do peso do cachorro em gramas de Ração.
        //Aula 13.1
        public override string QuantoDevoComer()   // Ja o Overriide, vc coloca no seu metodo filho onde vc quer que o metodo pai seja sobrecarregado, assim vc dis ao compilador
        {                                                   // usar obrigatoriamente o metodo que está implementado no metodo filho com suas proprias regras de negócio
            return $"Como tenho {Peso}kg, devo comer {Peso * 50}g por dia";
        }

        public double QuantoDevoComerMacho(int peso, bool macho)
        {
            //if ternario ( expressão booleana ? código 1 : código 2; ) exemplo resultado += media >= 7 ? "aprovado." : "reprovado.";
            //regra de comer 10% do peso corporal para macho e comer 5% do peso corporal para femea
            return macho ? peso * 0.10 : peso * 0.05;

        }

        //public void SetNome(string nome)
        //{
        //    _nome = nome;
        //}
        //
        //public string GetNome()
        //{
        //    return _nome;
        //}

        //public void SetPeso(double? peso)
        //{
        //    peso = peso < 0 ? peso = 0 : peso;
        //    _peso = peso;
        //}
        //
        //public double? GetPeso()
        //{
        //    return _peso;
        //}



        public bool FuiVacinado(bool vacina)
        {
            return vacina;
        }

        public string[] Latindo(short latindo)
        {
            //tipo[] nomeDoArray = new tipo[tamanho_do_array];
            string[] _latido = new string[latindo];

            short i = 0; 
            while (i < latindo)
            {
               
                _latido[i] = "How!";
                Console.WriteLine(_latido[i]);
                i++;
            }

            return _latido;
        }

        public string latindoFor(short latindoFor)
        {
            var latidos = "";

            for (int i = 1; i <= latindoFor; i++)
  //          {
               latidos += "Au! "; //apenas uma instrução no for não precisa usar abrir e fechar chaves
  //          }
            return latidos.TrimEnd();
        }


        public string GetIdade()
        {
            var anos = DateTime.Now.Year - DataNascimento.Year; // aqui calcula o ano atual - ano de nascimento
            var mes = DateTime.Now.Month - DataNascimento.Month + (12 * anos); //aqui pegamos o mes atual - mes de nascimento, se  tiver 0 anos no calculo acima somando com a quantidade de meses vai dar 0 anos + os meses de vida, se tiver 1 ano ou mais, var ser a quantidade de anos calculado acima + a quantidade de meses calculado abaixo obtendo assim a idade com anos e meses

            //string _return = idade > 1 ? $"{idade} anos" : $"{idade} ano";
            //return _return;

            if (mes < 12)
                return mes > 1 ?  $"{mes} meses" : " 1 mes";
            else
                return anos > 1 ? $"{anos} anos" : $"1 ano";
        }

        public string GetIdadeCompleta()
        {
            var anosBruto = DateTime.Now.Year - DataNascimento.Year; // aqui calcula o ano atual - ano de nascimento
            var anos = (DateTime.Now.DayOfYear < DataNascimento.DayOfYear) ? anosBruto = anosBruto - 1 : anosBruto;
            
            var mesBruto = DateTime.Now.Month - DataNascimento.Month;

            int mes;

            if (mesBruto != 0)
            {
                if (mesBruto < DateTime.Now.Month)
                {
                    var calMes = (mesBruto < 0 ? mesBruto + 12 : mesBruto - 12);
                    mes = calMes < 0 ? calMes * -1 : calMes;
                }
                else
                {
                    var calMes = (mesBruto < 0 ? mesBruto + 12 : mesBruto - 12);
                    mes = calMes < 0 ? calMes * -1 : calMes;
                }
            }
            else 
            {
                mes = mesBruto;
            }


            if (anos <0 & mes < 12)
                return $"{mes} meses";
            else
                return anos > 1 ? $"{anos} anos e {mes} meses" : $"{anos} ano e {mes} meses";
        }


        //Atividades:
        //criar testes unitarios e um metodo no cachorro que faça as seguintes validações:
        //Nome do cachorro é obrigatório
        //Sexo do cachorro precisa ser "Femea" ou "Macho". Qualquer outro valor é inválido!
        //Data de nascimento não pode ser menor que data de hoje
        //Peso deve ser maior que 0
        //Esse Metodo deverá retornar as mensagens no caso de campos inválidos. ou Null se tudo estiver OK
        //esse metodo deverá retornar caso uma ou mais dessas condições sejam falsas, retorne uma mensagem,
        //se tiver mais que uma mensagem de erro retorne as mensagem em uma coleção, uma lista de strings
        //se todas as condições estão ok e o cachorro 100% validado, retorne null
        //mudar o retorno do metodo para list<>

        // public List<string>? Validar()
        // {
        //     var mensagens = new List<string>();
        //     //regras: Nome do cachorro é obrigatório
        //     //if (Nome == null || Nome == "" || Nome == "  ")
        //     //no string existe um metodo chamado IsNullOrEmpty que é util para verificar se a variavel é varia ou nula
        //     //no string existe o metodo chamado IsNullOrWhiteSpace verifica se é vazio, nulo ou se tem espaço em branco
        //     if (string.IsNullOrWhiteSpace(Nome)) // se for igual a vazio, nulo ou se tem espaço em branco vai retornar true neste caso a lista de mensagem vai ser preenchida
        //     {
        //         mensagens.Add("Nome do cachorro é obrigatório!");
        //     }
        // 
        //     if (Sexo != "Fêmea" && Sexo != "Macho")
        //     {
        //         mensagens.Add("Sexo do cachorro deve ser Fêmea ou Macho!");
        //     }
        // 
        //     if (DataNascimento > DateTime.Today )
        //     {
        //         mensagens.Add("Data de nascimento deve ser menor que data de hoje!");
        //     }
        // 
        // 
        //     if (Peso <= 0)
        //     {
        //         mensagens.Add("Peso do cachorro deve ser maior que Zero!");
        //     }
        // 
        // 
        //     return mensagens.Count == 0 ? null : mensagens;
        // }


        // Refatorando o Metodo validar com tray catch e não vamos mais retornar uma lista de mensagens, vamos retornar void
        public override void Validar() // Ja o Overriide, vc coloca no seu metodo filho onde vc quer que o metodo pai seja sobrecarregado, assim vc dis ao compilador
        {                     // usar obrigatoriamente o metodo que está implementado no metodo filho com suas proprias regras de negócio

            //regras: Nome do cachorro é obrigatório
            //if (Nome == null || Nome == "" || Nome == "  ")
            //no string existe um metodo chamado IsNullOrEmpty que é util para verificar se a variavel é varia ou nula
            //no string existe o metodo chamado IsNullOrWhiteSpace verifica se é vazio, nulo ou se tem espaço em branco

            // Este método de validar nome ja existe na classe Pai Animal.cs, vamos usar a Herança e comentar esse trexo, deixando aqui apenas para histórico das primeiras aulas onde não usamos a herança
            // if (string.IsNullOrWhiteSpace(Nome)) // se for igual a vazio, nulo ou se tem espaço em branco vai retornar true neste caso a lista de mensagem vai ser preenchida
            // {
            //     mensagens.Add("Nome do Pet é obrigatório!");
            // }

            var mensagens = ValidacoesComuns();

            // if (Sexo != "Fêmea" && Sexo != "Macho") // esta validação não é mais necessária pois transformamos o sexo em enum impedinque que exista um valor diferente na hora de selecionar o sexo, dispensando validação nesse campo
            // {
            //     mensagens.Add("Sexo do cachorro deve ser Fêmea ou Macho!");
            // }

            if (DataNascimento > DateTime.Today)
            {
                mensagens.Add("Data de nascimento deve ser menor que data de hoje!");
            }


            if (Peso <= 0)
            {
                mensagens.Add("Peso do cachorro deve ser maior que Zero!");
            }

            var ex = Helpers.ConvertStringListToException(mensagens);
            if (ex != null)
                throw ex;

        }

    }

 
}


// Detalhes da Aula, explicação para os alunos:
// Visibilidade do metodo:
//      /Public qualquer código com acesso a esta classe vai conseguir executar esse metoto
//      /Private: Um metodo privado só vai conseguir ser utilizado dentro da propria classe, não ficará visivel para outros codigos externos com acesso a essa classe.
//      /Visibilidades Public ou Private vai estão presentes em metodos ou atributos
//      /
//      /
// Retorno do Metodo:
//      /String= o metodo vai executar uma ação e vai retornar um valor do tipo string para quem pediu para executar esta ação/ o metodo quantodevocomer vai me dar uma resposta e ela será do tipo string, ela fica na ultima linha do seu metodo representado pelo "return"
//      /
// Nome do Metodo:
// 
// Parametros do Método:
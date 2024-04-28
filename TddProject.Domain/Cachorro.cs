using System;
using System.Security.Cryptography.X509Certificates;

namespace TddProject.Domain
{
    public class Cachorro
    {
        private string _nome;
        private string _sexo;
        private string _raca;
        private string _porte;
        private string _idade;
        private double _peso;
        private bool _vacinado;

        public string Latir() //metodo latir
        {
            return "Au! Au!";

            //throw new NotImplementedException(); // throw´significa lançar uma excessão, e uma excessão é todo erro que ocorre em nosso codigo, aqui significa que esta lancando uma nova excessão dizendo que este metodo não foi implementado ainda.. 
        }

        public string QuantoDevoComer() //metodo quanto devo comer
        {

            return "Coma no maximo 5 % do seu peso corporal, qual é seu peso?";
            //throw new NotImplementedException();


        }

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
        public string QuantoDevoComerPeso(int peso)
        {
            return $"Como tenho {peso}kg, devo comer {peso * 50}g por dia";
        }

        public double QuantoDevoComerMacho(int peso, bool macho)
        {
            //if ternario ( expressão booleana ? código 1 : código 2; ) exemplo resultado += media >= 7 ? "aprovado." : "reprovado.";
            //regra de comer 10% do peso corporal para macho e comer 5% do peso corporal para femea
            return macho ? peso * 0.10 : peso * 0.05;

        }

        public void SetNome(string nome)
        {
            _nome = nome;
        }

        public string GetNome()
        {
            return _nome;
        }

        public void SetPeso(double peso)
        {
            peso = peso < 0 ? peso = 0 : peso;
            _peso = peso;
        }

        public double GetPeso()
        {
            return _peso;
        }



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
            string latidos = "";

            for (int i = 1; i <= latindoFor; i++)
  //          {
               latidos += "Au! "; //apenas uma instrução no for não precisa usar abrir e fechar chaves
  //          }
            return latidos.TrimEnd();
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
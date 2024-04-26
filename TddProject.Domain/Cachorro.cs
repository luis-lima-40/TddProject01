using System;

namespace TddProject.Domain
{
    public class Cachorro
    {
        public double comida { get; private set; }

        public string Latir()
        {
            return "Au! Au!";

            //throw new NotImplementedException(); // throw´significa lançar uma excessão, e uma excessão é todo erro que ocorre em nosso codigo, aqui significa que esta lancando uma nova excessão dizendo que este metodo não foi implementado ainda.. 
        }

        public string QuantoDevoComer()
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
            return  $"Como tenho {peso}kg, devo comer {peso * 50}g por dia";
        }

        public double QuantoDevoComerMacho(int peso,bool macho)
        {
            if (macho)
            {
                comida = (peso * 1);
                //return comida;
            }
            else
            {
                comida = (peso * 0.5);
            }

            return comida;
            //throw new NotImplementedException();
        }


    }
}

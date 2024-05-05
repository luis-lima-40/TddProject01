using System;
using System.Collections.Generic;
using System.Text;

namespace TddProject.Domain
{
    public class Gato : Animal, IPet
    {
        public string Miar(int qtdMiados)
        {
            var miados = "";

            for (int i = 1; i <= qtdMiados; i++)
                //          {
                miados += "Miau! "; //apenas uma instrução no for não precisa usar abrir e fechar chaves
                                   //          }
            return miados.TrimEnd();
        }

        public override string QuantoDevoComer()
        {
            return $"Como tenho {Peso}kg, devo comer {Peso * 10}g por dia";// o gato como 1% do seu peso corporal / aqui ja fazemos a conversão de quilo para gramas
        }
    }
}

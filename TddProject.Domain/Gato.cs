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
    }
}

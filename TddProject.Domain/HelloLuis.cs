using System;

namespace TddProject.Domain
{


    public static class HelloLuis //CLASSE
    {


        //######################################################################################################################################//
        //  *** 12 - 13 - 14 - V12, V13, V14, - Classes e objetos, Metodos e Atributos ***
        //  
        //
        //  
        //######################################################################################################################################//


        public static void PassaReferencia(Cachorro cachorro)
        {
            cachorro.Nome="Tequila";
        }

        public static void PassaValor(int valor)
        {
            valor = 999;
        }

        public static string SayHello () //METODO sempre precisa de um tipo de retorno, todo metodo  vai executar alguma coisa e retornar alguma coisa
        {
            return "Hello Luis"; //RETORNO DO METODO
        }


        public static void AcessoMinhaClasse()
        { 
            var obj = new MinhaClasse();
            //obj.MeuMetodo(); o metodo está com nivel de proteção privado, não posso acessar esse metodo aqui
        }
    }
}


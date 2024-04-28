using System;

namespace TddProject.Domain
{
    public static class HelloLuis //CLASSE
    {
        public static void PassaReferencia(Cachorro cachorro)
        {
            cachorro.SetNome("Tequila");
        }

        public static void PassaValor(int valor)
        {
            valor = 999;
        }

        public static string SayHello () //METODO sempre precisa de um tipo de retorno, todo metodo  vai executar alguma coisa e retornar alguma coisa
        {
            return "Hello Luis"; //RETORNO DO METODO
        }
    }
}


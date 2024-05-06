using System;
using System.Collections.Generic;

namespace TddProject.Domain
{
    //public static class Helpers
    public static class ListExtensions 
    {
        // a ideia da classe Helpers é criar os metodos auxiliares de forma estatica e colocalos todos aqui nesta classe

        // este metodo vai converter uma lista de strings em uma exception
        public static Exception ToExceptions(this List<string> mensagens) //o retorno desse metodo é do tipo Exception e o nome será ConvertStringListToException() para denotar exatamente a o objetivo do metodo, ele vai receber como parametro de entrada uma List<string>
        {
            var exceptionMessage = "";
            foreach (var item in mensagens)
                exceptionMessage += item + Environment.NewLine;

            return string.IsNullOrWhiteSpace(exceptionMessage) ? null : new Exception(exceptionMessage);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TddProject.Domain
{
    public abstract class Animal
    {
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public string Foto { get; set; }
        public Dono Dono { get; set; }

        private double? _peso;
        public double? Peso
        {
            get { return _peso; }
            set { _peso = value < 0 ? _peso = 0 : _peso = value; }
        }

        public abstract string QuantoDevoComer(); // O Virtual podemos colocar nos metodos que a gente quer que os filhos herdem mas que opcionalmente eles podem sobrecarregar


        // ele não vai ser virtual pois ele não devera ser sobrecarregado, todas as classes que herdam de Animal que forem validar estes atributos devem usar eesse metodo
        // o Nivel de visibilidade protected deve ser usado especificamente quando temos herança, ele não deve ser privado senao so a classe animal pode velo, mas sendo protected, a classe animal e as filhas podem vêlo
        protected List<string> ValidacoesComuns() // este metodo vai ser protected, somente a classe animal e as classes filhas poderão usar este metodo ValidacoesComuns()
        {
            var mensagens = new List<string>();

            if (string.IsNullOrWhiteSpace(Nome))
                mensagens.Add("Nome do Pet é obrigatório!");

            return mensagens;
        }



        public virtual void Validar() // O Virtual podemos colocar nos metodos que a gente quer que os filhos herdem mas que opcionalmente eles podem sobrecarregar
        {
            var mensagens = ValidacoesComuns();// neste ponto do meu codigo, ele vai chamar o metodo acima, caso tenha alguma mensagem de erro ele vai retornar para este ponto e contimuar daqui pra baixo exibindo o erro enancando um throw new Exception para a classe que chamou o metodo validar

            var ex = Helpers.ConvertStringListToException(mensagens);
            if (ex != null)
                throw ex;

            // if (mensagens.Count > 0) 
            // {
            //     var exceptionMessage = "";
            //     foreach (var item in mensagens)
            //     {
            //         exceptionMessage += item + Environment.NewLine;
            //     }
            //     throw new Exception(exceptionMessage);
            // }
        }



    }
}


using System.Globalization;

namespace TddProject.Domain
{
    public class MinhaClasse// esta classe publica significa que eu a enchergo dentro do meu assembly em qualquer outra classe
    {

        private void MeuMetodo()
        { 

        }

        public void OutroMetodo()
        { 
            //um metodo privado so vai poder ser usado dentro da sua propria classe
            this.MeuMetodo(); //a palavra chave "this" mostra pra gente todos os metodos que podemos usar nessa instancia, nessa classe, ou seja vc descobre quais são todos os membros da sua classe que voce pode acessar nela mesma
        }

        protected void MetodoProtected()
        {
            //um metodo privado so vai poder ser usado dentro da sua propria classe
            this.MeuMetodo(); //a palavra chave "this" mostra pra gente todos os metodos que podemos usar nessa instancia, nessa classe, ou seja vc descobre quais são todos os membros da sua classe que voce pode acessar nela mesma
        }


        protected internal void MetodoProtectedInternal() // vai ser acessível - visivel pela classe filha
        {
            //um metodo protectec internal não pode ser acessado de outro assembly diferente mesmo que vc use a classe pai ou uma classe filho para tentar acessar esse nivel de proteção não será possivel
            //this.MeuMetodo(); 
        }


    }

    //não é uma boa pratica fazer outra classe dessa forma, uma classe filho junto com a classe pai, o certo é criar uma nova classe, vamos fazer aqui apenas como exemplo e para facil visualização, logo apos vamos criar as classes com suas classes filhas da forma correta:

    public class ClasseFilho : MinhaClasse //aqui estamos herdando a classe pai  MinhaClasse e todos os seus metodos 
    {
        //quando vc herda de uma classe pai, vc ganha todos os metodos / membros existentes na classe pai como herança e pode usalos
        public void MetodoFilho()
        {
            this.MetodoProtected(); // o metodo de nivel protected que está na classe pai pode ser acessado aqui na classe filha como herança
            //this.MeuMetodo(); //não pode ser acessada pois o nivel de proteção dela não pode ser acessada nem por uma classe filha que herda da classe pai. private so pode ser vista na propria classe origem onde ela foi declarada
        }

    }

}

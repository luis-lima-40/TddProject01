using System;
using System.Collections.Generic;
using System.Text;

namespace TddProject.Domain
{
    public class Animal
    {
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public string Foto { get; set; }
        public Dono Dono { get; set; }

        public virtual string QuantoDevoComer(int peso) // O Virtual podemos colocar nos metodos que a gente quer que os filhos herdem mas que opcionalmente eles podem sobrecarregar
        {
            throw new NotImplementedException();
        }

        public virtual void Validar() // O Virtual podemos colocar nos metodos que a gente quer que os filhos herdem mas que opcionalmente eles podem sobrecarregar
        {
            throw new NotImplementedException();
        }
    }
}

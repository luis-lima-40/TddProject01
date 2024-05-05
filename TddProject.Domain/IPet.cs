using System;
using System.Collections.Generic;
using System.Text;

namespace TddProject.Domain
{
    public interface IPet
    {
        // intercaces - vamos definir os elementos que todo pet deve ter
        // Diferente de uma classe o atributo de visibilidade não deve ser declarado na interface, 
        //a vibisilidade de cada atributo deve ser definido somente na classe que for implementar essa interface
        
        // propriedades
        string Nome { get; set; }
        Sexo Sexo { get; set; }
        String Foto { get; set; }
        Dono Dono { get; set; }
        double? Peso { get; set; }
    


        // fim pripriedades

        // Metodos - importante resaltar que a Interfaçe não pode ter nenhum tipo de implementação nos metodos
        // metodos
        string QuantoDevoComer(); //vc declara o meto e coloca o ; no final, dizendo que toda a classe que implementar a interface IPet precisa implementar os metodos aqui descritos
        void Validar();
        // fim metodos

        //Agora vamos no teste unitário ver como utilizar uma Interface

        //Interfaces, Exercícios

        // Na classe Dono, mudar o tipo da propriedade Pets, de chachorro para Ipet, para permitir que um dono
        // tenha cachorros e gatos
        //Fazer o mesmo com os parametros dos Métodos AddPet e RemovePet



    }
}

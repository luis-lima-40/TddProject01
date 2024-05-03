using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TddProject.Domain
{
    public class Dono
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public List<Cachorro>? Pets { get; set; }

        public void AddPet(Cachorro pet)
        {
            if (Pets == null)
                Pets = new List<Cachorro>();

            Pets.Add(pet);
            //como eu sei qual é o nome do dono desse pet que foi instanciado
            //lá na classe DonoTest.cs se eu estou aqui dentro da classe?   usando a palavra chave This.
            //a instancia dessa classe que fiz lá na classe DonoTests consigo capturar usando o this, ou seja
            // a instancia dessa classe no momento em que esse metodo foi chamado se chama Silvia ou qualquer nome que
            //vc deu para a instancia, assim o this capta esse nome (this = esta instancia) e vc pega no nome pada adicionar
            // ao cachorro.Dono
            pet.Dono = this; // This é a instancia da classe que está executando esse metodo,  o This e o proprio nome

        }

        public void AddPet(params Cachorro[] pets)
        {
            foreach (var pet in pets)
            {
                AddPet(pet);
            }
        }


        public void RemovePet(Cachorro pet)
        {
            if (Pets == null)
                return;

                //if (Pets.Remove(pet) == true) é o mesmo que a linha abaixo sem o == true
                if (Pets.Remove(pet)) // ao ececutar Pets.Remove(pet) o compilador ja executa a remoção no item da lista e retorna um true se removeu ou um false se não removeu
                pet.Dono = null;          // então estamos pondo Pets.Remove(pet) dentro de uma condição IF que vai validar se esse termo é verdadeiro ou falso, sendo verdadeiro o if vai ser valido e vai entrar
                                          // na execução da linha abaixo. o retorno desse if é booleano então se Pets.Remove(pet) é true já vai cair na condição abaixo, ou seja ele ja removeu o pet
        }

        public void RemovePet(params Cachorro[] pets)
        {
            foreach (var pet in pets)
            {
                RemovePet(pet);
            }
        }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity_library
{
    public class Player:Person
    {
        //Atributo
        private int number;
        //Propiedad
        [Range(1, 99)]
        public int Number { get => number; set => number = value; }
        public List<Team> ListaTeam { get; set; }

        //CONSTRUCTOR
        public Player(long id, string name, string? dni, int age, int number) : base(id, name, dni, age)
        {
            Number = number;
            ListaTeam = new List<Team>();
        }   
    }
}

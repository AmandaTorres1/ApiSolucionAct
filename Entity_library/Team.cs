using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity_library
{
    public class Team
    {
        private string name = "";
        private string categoty = "";
        private long id;

        //Propiedades
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get => name; set => name = value; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Categoty { get => categoty; set => categoty = value; }
        private List<Player> ListaTeam { get; set; }
        public long Id { get => id; set => id = value; }

        //CONSTRUCTOR
        public Team(string name, string categoty,long id)
        {
            Name = name;
            Categoty = categoty;
            Id = id;
            ListaTeam = new List<Player>();
        }

    }
}

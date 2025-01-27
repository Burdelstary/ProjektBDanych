namespace ProjektBDanych.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Dziennik
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public int numberOfVotes { get; set; }

        public string Voivodeship { get; set; }
        
        public Dziennik() { }
    }
}


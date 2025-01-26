namespace ProjektBDanych.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Dziennik
    {
        [Key]
        public int ID { get; set; } 

        [Required]
        [StringLength(50, ErrorMessage = "Imię nie może przekraczać 50 znaków.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Nazwisko nie może przekraczać 50 znaków.")]
        public string Surname { get; set; } 

        [Required]
        [Range(1, 6, ErrorMessage = "Ocena musi mieścić się w przedziale od 1 do 6.")]
        public int Grade { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime GradeDate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Nazwa przedmiotu nie może przekraczać 100 znaków.")]
        public string Subject { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Nazwa klasy nie może przekraczać 10 znaków.")]
        public string ClassName { get; set; }

        [Required]
        [Range(1, 8, ErrorMessage = "Rok nauki musi mieścić się w przedziale od 1 do 8.")]
        public int SchoolYear { get; set; }
    }
}


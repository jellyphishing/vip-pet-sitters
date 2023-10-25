﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace FullStackAuth_WebAPI.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; } 
       
        [Required]
        public string Text { get; set; }

        [ForeignKey("Client")] 
        public string ClientId { get; set; } 
        public User Client { get; set; }

        [ForeignKey("Sitter")]
        public string SitterId { get; set; }
        public User Sitter { get; set; }


    }
}

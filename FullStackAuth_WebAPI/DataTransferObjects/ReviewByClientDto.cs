﻿using System.ComponentModel.DataAnnotations;


namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ReviewByClientDto
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string SitterId { get; set; }    
        public string Text { get; set; } 

        public UserForDisplayDto User { get; set; }
    }
}

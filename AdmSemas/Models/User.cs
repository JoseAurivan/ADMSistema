﻿namespace AdmSemas.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Nome { get; set; }
        public string Email { get; set; }
        
        public Roles? Roles { get; set; }
    }
}
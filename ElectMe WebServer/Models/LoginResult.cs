using System;
using System.Collections.Generic;

namespace ElectMe_WebServer.Models
{
    public class LoginResult
    {
        public int Status { get; set; }
        public string? DeviceToken { get; set; }
        public string? VoteToken { get; set; }
        
        public List<string> Choices { get; set; }
    }
}
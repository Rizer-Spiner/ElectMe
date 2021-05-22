using System;

namespace ElectMe_WebClient.Models
{
    public class TestModel
    {
        public string message { get; set; }
        public Int64 integer { get; set; }
        
        public string ToString()
        {
            return integer + ": " + message;
        }
    }
    
   
}
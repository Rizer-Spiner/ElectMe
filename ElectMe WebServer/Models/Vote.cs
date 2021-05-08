namespace ElectMe_WebServer.Models
{
    public class Vote
    {
        public string VoteToken { get; set; }
        public string ChoiceEncrypted { get; set; }
    }
}
using System.Collections.Generic;
using ElectMe_WebServer.ECIES;
using ElectMe_WebServer.ECIES.KeyGeneration;
using ElectMe_WebServer.Models;

namespace ElectMe_WebServer.LoginServerMock
{
    public class ElectMeLoginServerImpl : ElectMeLoginServer
    {
        public LoginResult login(LoginPackage loginPackage)
        {
            return new LoginResult
            {
                Status = 200,
                AuthToken = PrivateKeyGenerator.generatePrivateKey().ToString(),
                ElectionPuk = EncryptionVariables.ElectionPuk,
                Choices = getChoices()
            };
        }

        private List<string> getChoices()
        {
            List<string> choices = new List<string>();
            choices.Add("Barrack Obama");
            choices.Add("Donald Trump");
            choices.Add("Hillary Clinton");

            return choices;
        }

        public LoginResult logout(byte[] token)
        {
            return new LoginResult
            {
                Status = 200,

            };
        }
    }
}
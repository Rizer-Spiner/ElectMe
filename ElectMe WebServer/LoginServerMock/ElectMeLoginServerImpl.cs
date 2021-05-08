using ElectMe_WebServer.KeyGeneration;

namespace ElectMe_WebServer.LoginServerMock
{
    public class ElectMeLoginServerImpl : ElectMeLoginServer
    {
        public NIOSLoginResult login(string encryptedCredentials)
        {
            return new NIOSLoginResult
            {
                Status = 200,
                Token = PrivateKeyGenerator.generatePrivateKey().ToString()
            };
        }

        public NIOSLoginResult logout(string token)
        {
            return new NIOSLoginResult
            {
                Status = 200,
                Token = "null"
            };
        }
    }
}
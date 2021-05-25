using ElectMe_WebServer.ECIES.KeyGeneration;

namespace ElectMe_WebServer.LoginServerMock
{
    public class ElectMeLoginServerImpl : ElectMeLoginServer
    {
        public NIOSLoginResult login(byte[] encryptedCredentials)
        {
            return new NIOSLoginResult
            {
                Status = 200,
                Token = PrivateKeyGenerator.generatePrivateKey().ToString()
            };
        }

        public NIOSLoginResult logout(byte[] token)
        {
            return new NIOSLoginResult
            {
                Status = 200,
                Token = "null"
            };
        }
    }
}
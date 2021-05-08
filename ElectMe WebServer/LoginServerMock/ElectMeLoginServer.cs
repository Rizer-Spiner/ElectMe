#nullable enable
using System;

namespace ElectMe_WebServer.LoginServerMock
{
    public interface ElectMeLoginServer
    {
        NIOSLoginResult login(String encryptedCredentials);
        NIOSLoginResult logout(String token);
    }

    public class NIOSLoginResult
    {
        public int Status { get; set; }
        public String? Token { get; set; }
    }
}
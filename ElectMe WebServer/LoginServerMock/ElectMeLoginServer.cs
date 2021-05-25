#nullable enable
using System;

namespace ElectMe_WebServer.LoginServerMock
{
    public interface ElectMeLoginServer
    {
        NIOSLoginResult login(byte[] encryptedCredentials);
        NIOSLoginResult logout(byte[] token);
    }

    public class NIOSLoginResult
    {
        public int Status { get; set; }
        public String? Token { get; set; }
    }
}
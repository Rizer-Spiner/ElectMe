#nullable enable
using System;
using ElectMe_WebServer.Models;

namespace ElectMe_WebServer.LoginServerMock
{
    public interface ElectMeLoginServer
    {
        LoginResult login(LoginPackage niosPackage);
    }
    
}
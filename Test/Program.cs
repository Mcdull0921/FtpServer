﻿using SmallFtpServer;
using SmallFtpServer.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
 
        static void Main(string[] args)
        {
            FtpServer ftpServer = new FtpServer(21, 3, new UserInfo { username = "test", password = "123", dir = "d:\\" });
            ftpServer.Listen();



            Console.ReadKey();
        }

    }
}
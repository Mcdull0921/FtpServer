﻿using SmallFtpServer.Exceptions;
using SmallFtpServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SmallFtpServer.Commands
{
    /// <summary>
    /// 删除文件
    /// </summary>
    [FtpCommand("DELE", 1, true)]
    class DeleCommand : Command
    {
        public DeleCommand(Client client) : base(client)
        {

        }

        public override void Process(params string[] args)
        {
            try
            {
                string path = client.LoginInfo.GetAbsolutePath(args[0]);
                FtpServer.Logger.Info("删除文件" + path);
                if (!File.Exists(path))
                    throw new InvalidFileException("文件不存在");
                File.Delete(path);
                client.Send(ResultCode.FileComplete.ConvertString("文件删除成功"));
            }
            catch (Exception ex)
            {
                throw new InvalidFileException(ex.Message);
            }
        }
    }
}

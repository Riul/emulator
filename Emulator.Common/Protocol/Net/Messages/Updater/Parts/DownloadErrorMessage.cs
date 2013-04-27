#region License
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//                Version 2, December 2004
//  
// Copyright (C) 2013 Phito <phito41@gmail.com>
//  
// Everyone is permitted to copy and distribute verbatim or modified
// copies of this license document, and changing it is allowed as long
// as the name is changed.
//  
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
// TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
//  
// 0. You just DO WHAT THE FUCK YOU WANT TO.
// 
// Created on 26/04/2013 at 16:45
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Updater.Parts
{
    public class DownloadErrorMessage : NetworkMessage
    {
        public const uint Id = 1513;

        public sbyte errorId;
        public string helpUrl;
        public string message;

        public override uint MessageId
        {
            get { return Id; }
        }


        public DownloadErrorMessage()
        {
        }

        public DownloadErrorMessage(sbyte errorId, string message, string helpUrl)
        {
            this.errorId = errorId;
            this.message = message;
            this.helpUrl = helpUrl;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(errorId);
            writer.WriteUTF(message);
            writer.WriteUTF(helpUrl);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            errorId = reader.ReadSByte();
            if (errorId < 0)
                throw new Exception("Forbidden value on errorId = " + errorId + ", it doesn't respect the following condition : errorId < 0");
            message = reader.ReadUTF();
            helpUrl = reader.ReadUTF();
        }
    }
}
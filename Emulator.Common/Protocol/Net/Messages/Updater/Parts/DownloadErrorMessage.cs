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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Updater.Parts
{
    public class DownloadErrorMessage : NetworkMessage
    {
        public const uint ID = 1513;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte ErrorId { get; set; }
        public string Message { get; set; }
        public string HelpUrl { get; set; }


        public DownloadErrorMessage()
        {
        }

        public DownloadErrorMessage(sbyte errorId, string message, string helpUrl)
        {
            ErrorId = errorId;
            Message = message;
            HelpUrl = helpUrl;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(ErrorId);
            writer.WriteUTF(Message);
            writer.WriteUTF(HelpUrl);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ErrorId = reader.ReadSByte();
            Message = reader.ReadUTF();
            HelpUrl = reader.ReadUTF();
        }
    }
}
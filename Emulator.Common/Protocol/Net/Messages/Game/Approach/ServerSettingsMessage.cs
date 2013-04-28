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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Approach
{
    public class ServerSettingsMessage : NetworkMessage
    {
        public const uint ID = 6340;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string Lang { get; set; }
        public sbyte Community { get; set; }
        public sbyte GameType { get; set; }


        public ServerSettingsMessage()
        {
        }

        public ServerSettingsMessage(string lang, sbyte community, sbyte gameType)
        {
            Lang = lang;
            Community = community;
            GameType = gameType;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(Lang);
            writer.WriteSByte(Community);
            writer.WriteSByte(GameType);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Lang = reader.ReadUTF();
            Community = reader.ReadSByte();
            GameType = reader.ReadSByte();
        }
    }
}
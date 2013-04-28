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

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildMemberOnlineStatusMessage : NetworkMessage
    {
        public const uint ID = 6061;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int MemberId { get; set; }
        public bool Online { get; set; }


        public GuildMemberOnlineStatusMessage()
        {
        }

        public GuildMemberOnlineStatusMessage(int memberId, bool online)
        {
            MemberId = memberId;
            Online = online;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(MemberId);
            writer.WriteBoolean(Online);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            MemberId = reader.ReadInt();
            Online = reader.ReadBoolean();
        }
    }
}
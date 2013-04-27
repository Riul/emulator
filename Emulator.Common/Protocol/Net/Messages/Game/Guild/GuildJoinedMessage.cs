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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildJoinedMessage : NetworkMessage
    {
        public const uint Id = 5564;
        public bool enabled;

        public GuildInformations guildInfo;
        public uint memberRights;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GuildJoinedMessage()
        {
        }

        public GuildJoinedMessage(GuildInformations guildInfo, uint memberRights, bool enabled)
        {
            this.guildInfo = guildInfo;
            this.memberRights = memberRights;
            this.enabled = enabled;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            guildInfo.Serialize(writer);
            writer.WriteUInt(memberRights);
            writer.WriteBoolean(enabled);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            guildInfo = new GuildInformations();
            guildInfo.Deserialize(reader);
            memberRights = reader.ReadUInt();
            if (memberRights < 0 || memberRights > 4294967295)
                throw new Exception("Forbidden value on memberRights = " + memberRights + ", it doesn't respect the following condition : memberRights < 0 || memberRights > 4294967295");
            enabled = reader.ReadBoolean();
        }
    }
}
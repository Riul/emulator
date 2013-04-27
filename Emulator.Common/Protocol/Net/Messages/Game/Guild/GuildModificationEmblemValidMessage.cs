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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Guild;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildModificationEmblemValidMessage : NetworkMessage
    {
        public const uint Id = 6328;

        public GuildEmblem guildEmblem;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GuildModificationEmblemValidMessage()
        {
        }

        public GuildModificationEmblemValidMessage(GuildEmblem guildEmblem)
        {
            this.guildEmblem = guildEmblem;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            guildEmblem.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            guildEmblem = new GuildEmblem();
            guildEmblem.Deserialize(reader);
        }
    }
}
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

namespace Emulator.Common.Protocol.Net.Messages.Game.Chat.Channel
{
    public class EnabledChannelsMessage : NetworkMessage
    {
        public const uint Id = 892;

        public sbyte[] channels;
        public sbyte[] disallowed;

        public override uint MessageId
        {
            get { return Id; }
        }


        public EnabledChannelsMessage()
        {
        }

        public EnabledChannelsMessage(sbyte[] channels, sbyte[] disallowed)
        {
            this.channels = channels;
            this.disallowed = disallowed;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) channels.Length);
            foreach (var entry in channels)
            {
                writer.WriteSByte(entry);
            }
            writer.WriteUShort((ushort) disallowed.Length);
            foreach (var entry in disallowed)
            {
                writer.WriteSByte(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            channels = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                channels[i] = reader.ReadSByte();
            }
            limit = reader.ReadUShort();
            disallowed = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                disallowed[i] = reader.ReadSByte();
            }
        }
    }
}
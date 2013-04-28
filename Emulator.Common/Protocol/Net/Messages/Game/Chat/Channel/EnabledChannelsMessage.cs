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

namespace Emulator.Common.Protocol.Net.Messages.Game.Chat.Channel
{
    public class EnabledChannelsMessage : NetworkMessage
    {
        public const uint ID = 892;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte[] Channels { get; set; }
        public sbyte[] Disallowed { get; set; }


        public EnabledChannelsMessage()
        {
        }

        public EnabledChannelsMessage(sbyte[] channels, sbyte[] disallowed)
        {
            Channels = channels;
            Disallowed = disallowed;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Channels.Length);
            foreach (var entry in Channels)
            {
                writer.WriteSByte(entry);
            }
            writer.WriteUShort((ushort) Disallowed.Length);
            foreach (var entry in Disallowed)
            {
                writer.WriteSByte(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Channels = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                Channels[i] = reader.ReadSByte();
            }
            limit = reader.ReadUShort();
            Disallowed = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                Disallowed[i] = reader.ReadSByte();
            }
        }
    }
}
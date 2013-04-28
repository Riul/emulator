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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Emote
{
    public class EmoteListMessage : NetworkMessage
    {
        public const uint ID = 5689;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte[] EmoteIds { get; set; }


        public EmoteListMessage()
        {
        }

        public EmoteListMessage(sbyte[] emoteIds)
        {
            EmoteIds = emoteIds;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) EmoteIds.Length);
            foreach (var entry in EmoteIds)
            {
                writer.WriteSByte(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            EmoteIds = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                EmoteIds[i] = reader.ReadSByte();
            }
        }
    }
}
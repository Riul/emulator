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
    public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
    {
        public const uint ID = 5691;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int[] ActorIds { get; set; }


        public EmotePlayMassiveMessage()
        {
        }

        public EmotePlayMassiveMessage(sbyte emoteId, double emoteStartTime, int[] actorIds)
                : base(emoteId, emoteStartTime)
        {
            ActorIds = actorIds;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) ActorIds.Length);
            foreach (var entry in ActorIds)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            ActorIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                ActorIds[i] = reader.ReadInt();
            }
        }
    }
}
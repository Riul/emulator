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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Npc
{
    public class EntityTalkMessage : NetworkMessage
    {
        public const uint Id = 6110;

        public int entityId;
        public string[] parameters;
        public short textId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public EntityTalkMessage()
        {
        }

        public EntityTalkMessage(int entityId, short textId, string[] parameters)
        {
            this.entityId = entityId;
            this.textId = textId;
            this.parameters = parameters;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(entityId);
            writer.WriteShort(textId);
            writer.WriteUShort((ushort) parameters.Length);
            foreach (var entry in parameters)
            {
                writer.WriteUTF(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            entityId = reader.ReadInt();
            textId = reader.ReadShort();
            if (textId < 0)
                throw new Exception("Forbidden value on textId = " + textId + ", it doesn't respect the following condition : textId < 0");
            var limit = reader.ReadUShort();
            parameters = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                parameters[i] = reader.ReadUTF();
            }
        }
    }
}
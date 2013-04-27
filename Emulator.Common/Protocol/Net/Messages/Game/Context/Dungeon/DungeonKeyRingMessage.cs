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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Dungeon
{
    public class DungeonKeyRingMessage : NetworkMessage
    {
        public const uint Id = 6299;

        public short[] availables;
        public short[] unavailables;

        public override uint MessageId
        {
            get { return Id; }
        }


        public DungeonKeyRingMessage()
        {
        }

        public DungeonKeyRingMessage(short[] availables, short[] unavailables)
        {
            this.availables = availables;
            this.unavailables = unavailables;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) availables.Length);
            foreach (var entry in availables)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) unavailables.Length);
            foreach (var entry in unavailables)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            availables = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                availables[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            unavailables = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                unavailables[i] = reader.ReadShort();
            }
        }
    }
}
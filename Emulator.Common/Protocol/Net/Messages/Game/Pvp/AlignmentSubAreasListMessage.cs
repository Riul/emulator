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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Pvp
{
    public class AlignmentSubAreasListMessage : NetworkMessage
    {
        public const uint ID = 6059;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short[] AngelsSubAreas { get; set; }
        public short[] EvilsSubAreas { get; set; }


        public AlignmentSubAreasListMessage()
        {
        }

        public AlignmentSubAreasListMessage(short[] angelsSubAreas, short[] evilsSubAreas)
        {
            AngelsSubAreas = angelsSubAreas;
            EvilsSubAreas = evilsSubAreas;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) AngelsSubAreas.Length);
            foreach (var entry in AngelsSubAreas)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) EvilsSubAreas.Length);
            foreach (var entry in EvilsSubAreas)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            AngelsSubAreas = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                AngelsSubAreas[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            EvilsSubAreas = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                EvilsSubAreas[i] = reader.ReadShort();
            }
        }
    }
}
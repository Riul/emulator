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

namespace Emulator.Common.Protocol.Net.Messages.Game.Tinsel
{
    public class TitlesAndOrnamentsListMessage : NetworkMessage
    {
        public const uint ID = 6367;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short[] Titles { get; set; }
        public short[] Ornaments { get; set; }
        public short ActiveTitle { get; set; }
        public short ActiveOrnament { get; set; }


        public TitlesAndOrnamentsListMessage()
        {
        }

        public TitlesAndOrnamentsListMessage(short[] titles, short[] ornaments, short activeTitle, short activeOrnament)
        {
            Titles = titles;
            Ornaments = ornaments;
            ActiveTitle = activeTitle;
            ActiveOrnament = activeOrnament;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Titles.Length);
            foreach (var entry in Titles)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) Ornaments.Length);
            foreach (var entry in Ornaments)
            {
                writer.WriteShort(entry);
            }
            writer.WriteShort(ActiveTitle);
            writer.WriteShort(ActiveOrnament);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Titles = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                Titles[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            Ornaments = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                Ornaments[i] = reader.ReadShort();
            }
            ActiveTitle = reader.ReadShort();
            ActiveOrnament = reader.ReadShort();
        }
    }
}
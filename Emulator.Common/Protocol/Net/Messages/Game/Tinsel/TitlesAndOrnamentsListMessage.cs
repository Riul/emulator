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

namespace Emulator.Common.Protocol.Net.Messages.Game.Tinsel
{
    public class TitlesAndOrnamentsListMessage : NetworkMessage
    {
        public const uint Id = 6367;

        public short activeOrnament;
        public short activeTitle;
        public short[] ornaments;
        public short[] titles;


        public TitlesAndOrnamentsListMessage()
        {
        }

        public TitlesAndOrnamentsListMessage(short[] titles, short[] ornaments, short activeTitle, short activeOrnament)
        {
            this.titles = titles;
            this.ornaments = ornaments;
            this.activeTitle = activeTitle;
            this.activeOrnament = activeOrnament;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) titles.Length);
            foreach (var entry in titles)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) ornaments.Length);
            foreach (var entry in ornaments)
            {
                writer.WriteShort(entry);
            }
            writer.WriteShort(activeTitle);
            writer.WriteShort(activeOrnament);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            titles = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                titles[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            ornaments = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                ornaments[i] = reader.ReadShort();
            }
            activeTitle = reader.ReadShort();
            if (activeTitle < 0)
                throw new Exception("Forbidden value on activeTitle = " + activeTitle + ", it doesn't respect the following condition : activeTitle < 0");
            activeOrnament = reader.ReadShort();
            if (activeOrnament < 0)
                throw new Exception("Forbidden value on activeOrnament = " + activeOrnament + ", it doesn't respect the following condition : activeOrnament < 0");
        }
    }
}
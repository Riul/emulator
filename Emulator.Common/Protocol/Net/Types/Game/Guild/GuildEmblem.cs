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
// Created on 26/04/2013 at 16:46
#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Guild
{
    public class GuildEmblem
    {
        public const short Id = 87;

        public int backgroundColor;
        public short backgroundShape;
        public int symbolColor;
        public short symbolShape;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public GuildEmblem()
        {
        }

        public GuildEmblem(short symbolShape, int symbolColor, short backgroundShape, int backgroundColor)
        {
            this.symbolShape = symbolShape;
            this.symbolColor = symbolColor;
            this.backgroundShape = backgroundShape;
            this.backgroundColor = backgroundColor;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(symbolShape);
            writer.WriteInt(symbolColor);
            writer.WriteShort(backgroundShape);
            writer.WriteInt(backgroundColor);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            symbolShape = reader.ReadShort();
            symbolColor = reader.ReadInt();
            backgroundShape = reader.ReadShort();
            backgroundColor = reader.ReadInt();
        }
    }
}
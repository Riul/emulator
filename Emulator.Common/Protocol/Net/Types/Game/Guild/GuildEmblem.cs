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

namespace Emulator.Common.Protocol.Net.Types.Game.Guild
{
    public class GuildEmblem
    {
        public const short ID = 87;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short SymbolShape { get; set; }
        public int SymbolColor { get; set; }
        public short BackgroundShape { get; set; }
        public int BackgroundColor { get; set; }


        public GuildEmblem()
        {
        }

        public GuildEmblem(short symbolShape, int symbolColor, short backgroundShape, int backgroundColor)
        {
            SymbolShape = symbolShape;
            SymbolColor = symbolColor;
            BackgroundShape = backgroundShape;
            BackgroundColor = backgroundColor;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(SymbolShape);
            writer.WriteInt(SymbolColor);
            writer.WriteShort(BackgroundShape);
            writer.WriteInt(BackgroundColor);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            SymbolShape = reader.ReadShort();
            SymbolColor = reader.ReadInt();
            BackgroundShape = reader.ReadShort();
            BackgroundColor = reader.ReadInt();
        }
    }
}
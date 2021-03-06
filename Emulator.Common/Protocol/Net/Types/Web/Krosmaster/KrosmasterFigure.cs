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

namespace Emulator.Common.Protocol.Net.Types.Web.Krosmaster
{
    public class KrosmasterFigure
    {
        public const short ID = 397;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public string Uid { get; set; }
        public short Figure { get; set; }
        public short Pedestal { get; set; }
        public bool Bound { get; set; }


        public KrosmasterFigure()
        {
        }

        public KrosmasterFigure(string uid, short figure, short pedestal, bool bound)
        {
            Uid = uid;
            Figure = figure;
            Pedestal = pedestal;
            Bound = bound;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(Uid);
            writer.WriteShort(Figure);
            writer.WriteShort(Pedestal);
            writer.WriteBoolean(Bound);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Uid = reader.ReadUTF();
            Figure = reader.ReadShort();
            Pedestal = reader.ReadShort();
            Bound = reader.ReadBoolean();
        }
    }
}
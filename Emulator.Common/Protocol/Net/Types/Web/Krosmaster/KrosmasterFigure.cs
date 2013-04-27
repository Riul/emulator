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

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Web.Krosmaster
{
    public class KrosmasterFigure
    {
        public const short Id = 397;
        public bool bound;

        public short figure;
        public short pedestal;
        public string uid;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public KrosmasterFigure()
        {
        }

        public KrosmasterFigure(string uid, short figure, short pedestal, bool bound)
        {
            this.uid = uid;
            this.figure = figure;
            this.pedestal = pedestal;
            this.bound = bound;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(uid);
            writer.WriteShort(figure);
            writer.WriteShort(pedestal);
            writer.WriteBoolean(bound);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            uid = reader.ReadUTF();
            figure = reader.ReadShort();
            if (figure < 0)
                throw new Exception("Forbidden value on figure = " + figure + ", it doesn't respect the following condition : figure < 0");
            pedestal = reader.ReadShort();
            if (pedestal < 0)
                throw new Exception("Forbidden value on pedestal = " + pedestal + ", it doesn't respect the following condition : pedestal < 0");
            bound = reader.ReadBoolean();
        }
    }
}
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

namespace Emulator.Common.Protocol.Net.Types.Game.Paddock
{
    public class PaddockInformations
    {
        public const short Id = 132;

        public short maxItems;
        public short maxOutdoorMount;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public PaddockInformations()
        {
        }

        public PaddockInformations(short maxOutdoorMount, short maxItems)
        {
            this.maxOutdoorMount = maxOutdoorMount;
            this.maxItems = maxItems;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(maxOutdoorMount);
            writer.WriteShort(maxItems);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            maxOutdoorMount = reader.ReadShort();
            if (maxOutdoorMount < 0)
                throw new Exception("Forbidden value on maxOutdoorMount = " + maxOutdoorMount + ", it doesn't respect the following condition : maxOutdoorMount < 0");
            maxItems = reader.ReadShort();
            if (maxItems < 0)
                throw new Exception("Forbidden value on maxItems = " + maxItems + ", it doesn't respect the following condition : maxItems < 0");
        }
    }
}
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

namespace Emulator.Common.Protocol.Net.Types.Game.Guild.Tax
{
    public class AdditionalTaxCollectorInformations
    {
        public const short Id = 165;

        public string collectorCallerName;
        public int date;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public AdditionalTaxCollectorInformations()
        {
        }

        public AdditionalTaxCollectorInformations(string collectorCallerName, int date)
        {
            this.collectorCallerName = collectorCallerName;
            this.date = date;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(collectorCallerName);
            writer.WriteInt(date);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            collectorCallerName = reader.ReadUTF();
            date = reader.ReadInt();
            if (date < 0)
                throw new Exception("Forbidden value on date = " + date + ", it doesn't respect the following condition : date < 0");
        }
    }
}
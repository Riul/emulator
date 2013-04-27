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
using Emulator.Common.Protocol.Net.Types.Game.Prism;

namespace Emulator.Common.Protocol.Net.Messages.Game.Prism
{
    public class PrismWorldInformationMessage : NetworkMessage
    {
        public const uint Id = 5854;

        public int conqsTotal;
        public VillageConquestPrismInformation[] conquetesInformation;
        public int maxSub;
        public int nbConqsOwned;
        public int nbSubOwned;
        public PrismSubAreaInformation[] subAreasInformation;
        public int subTotal;


        public PrismWorldInformationMessage()
        {
        }

        public PrismWorldInformationMessage(int nbSubOwned, int subTotal, int maxSub, PrismSubAreaInformation[] subAreasInformation, int nbConqsOwned, int conqsTotal, VillageConquestPrismInformation[] conquetesInformation)
        {
            this.nbSubOwned = nbSubOwned;
            this.subTotal = subTotal;
            this.maxSub = maxSub;
            this.subAreasInformation = subAreasInformation;
            this.nbConqsOwned = nbConqsOwned;
            this.conqsTotal = conqsTotal;
            this.conquetesInformation = conquetesInformation;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(nbSubOwned);
            writer.WriteInt(subTotal);
            writer.WriteInt(maxSub);
            writer.WriteUShort((ushort) subAreasInformation.Length);
            foreach (var entry in subAreasInformation)
            {
                entry.Serialize(writer);
            }
            writer.WriteInt(nbConqsOwned);
            writer.WriteInt(conqsTotal);
            writer.WriteUShort((ushort) conquetesInformation.Length);
            foreach (var entry in conquetesInformation)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            nbSubOwned = reader.ReadInt();
            if (nbSubOwned < 0)
                throw new Exception("Forbidden value on nbSubOwned = " + nbSubOwned + ", it doesn't respect the following condition : nbSubOwned < 0");
            subTotal = reader.ReadInt();
            if (subTotal < 0)
                throw new Exception("Forbidden value on subTotal = " + subTotal + ", it doesn't respect the following condition : subTotal < 0");
            maxSub = reader.ReadInt();
            if (maxSub < 0)
                throw new Exception("Forbidden value on maxSub = " + maxSub + ", it doesn't respect the following condition : maxSub < 0");
            var limit = reader.ReadUShort();
            subAreasInformation = new PrismSubAreaInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                subAreasInformation[i] = new PrismSubAreaInformation();
                subAreasInformation[i].Deserialize(reader);
            }
            nbConqsOwned = reader.ReadInt();
            if (nbConqsOwned < 0)
                throw new Exception("Forbidden value on nbConqsOwned = " + nbConqsOwned + ", it doesn't respect the following condition : nbConqsOwned < 0");
            conqsTotal = reader.ReadInt();
            if (conqsTotal < 0)
                throw new Exception("Forbidden value on conqsTotal = " + conqsTotal + ", it doesn't respect the following condition : conqsTotal < 0");
            limit = reader.ReadUShort();
            conquetesInformation = new VillageConquestPrismInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                conquetesInformation[i] = new VillageConquestPrismInformation();
                conquetesInformation[i].Deserialize(reader);
            }
        }
    }
}
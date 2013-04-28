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
using Emulator.Common.Protocol.Net.Types.Game.Prism;

namespace Emulator.Common.Protocol.Net.Messages.Game.Prism
{
    public class PrismWorldInformationMessage : NetworkMessage
    {
        public const uint ID = 5854;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int NbSubOwned { get; set; }
        public int SubTotal { get; set; }
        public int MaxSub { get; set; }
        public PrismSubAreaInformation[] SubAreasInformation { get; set; }
        public int NbConqsOwned { get; set; }
        public int ConqsTotal { get; set; }
        public VillageConquestPrismInformation[] ConquetesInformation { get; set; }


        public PrismWorldInformationMessage()
        {
        }

        public PrismWorldInformationMessage(int nbSubOwned, int subTotal, int maxSub, PrismSubAreaInformation[] subAreasInformation, int nbConqsOwned, int conqsTotal, VillageConquestPrismInformation[] conquetesInformation)
        {
            NbSubOwned = nbSubOwned;
            SubTotal = subTotal;
            MaxSub = maxSub;
            SubAreasInformation = subAreasInformation;
            NbConqsOwned = nbConqsOwned;
            ConqsTotal = conqsTotal;
            ConquetesInformation = conquetesInformation;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(NbSubOwned);
            writer.WriteInt(SubTotal);
            writer.WriteInt(MaxSub);
            writer.WriteUShort((ushort) SubAreasInformation.Length);
            foreach (var entry in SubAreasInformation)
            {
                entry.Serialize(writer);
            }
            writer.WriteInt(NbConqsOwned);
            writer.WriteInt(ConqsTotal);
            writer.WriteUShort((ushort) ConquetesInformation.Length);
            foreach (var entry in ConquetesInformation)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            NbSubOwned = reader.ReadInt();
            SubTotal = reader.ReadInt();
            MaxSub = reader.ReadInt();
            var limit = reader.ReadUShort();
            SubAreasInformation = new PrismSubAreaInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                SubAreasInformation[i] = new PrismSubAreaInformation();
                SubAreasInformation[i].Deserialize(reader);
            }
            NbConqsOwned = reader.ReadInt();
            ConqsTotal = reader.ReadInt();
            limit = reader.ReadUShort();
            ConquetesInformation = new VillageConquestPrismInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                ConquetesInformation[i] = new VillageConquestPrismInformation();
                ConquetesInformation[i].Deserialize(reader);
            }
        }
    }
}
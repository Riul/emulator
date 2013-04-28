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
using Emulator.Common.Protocol.Net.Types.Game.Guild.Tax;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild.Tax
{
    public class TaxCollectorListMessage : NetworkMessage
    {
        public const uint ID = 5930;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte NbcollectorMax { get; set; }
        public short TaxCollectorHireCost { get; set; }
        public TaxCollectorInformations[] Informations { get; set; }
        public TaxCollectorFightersInformation[] FightersInformations { get; set; }


        public TaxCollectorListMessage()
        {
        }

        public TaxCollectorListMessage(sbyte nbcollectorMax, short taxCollectorHireCost, TaxCollectorInformations[] informations, TaxCollectorFightersInformation[] fightersInformations)
        {
            NbcollectorMax = nbcollectorMax;
            TaxCollectorHireCost = taxCollectorHireCost;
            Informations = informations;
            FightersInformations = fightersInformations;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(NbcollectorMax);
            writer.WriteShort(TaxCollectorHireCost);
            writer.WriteUShort((ushort) Informations.Length);
            foreach (var entry in Informations)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) FightersInformations.Length);
            foreach (var entry in FightersInformations)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            NbcollectorMax = reader.ReadSByte();
            TaxCollectorHireCost = reader.ReadShort();
            var limit = reader.ReadUShort();
            Informations = new TaxCollectorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Informations[i] = Types.ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
                Informations[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            FightersInformations = new TaxCollectorFightersInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                FightersInformations[i] = new TaxCollectorFightersInformation();
                FightersInformations[i].Deserialize(reader);
            }
        }
    }
}
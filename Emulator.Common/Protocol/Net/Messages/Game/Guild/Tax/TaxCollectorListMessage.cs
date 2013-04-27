#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:45
// */
#endregion

using System;
using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Guild.Tax;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild.Tax
{
    public class TaxCollectorListMessage : NetworkMessage
    {
        public const uint Id = 5930;
        public TaxCollectorFightersInformation[] fightersInformations;
        public TaxCollectorInformations[] informations;

        public sbyte nbcollectorMax;
        public short taxCollectorHireCost;


        public TaxCollectorListMessage()
        {
        }

        public TaxCollectorListMessage(sbyte nbcollectorMax, short taxCollectorHireCost, TaxCollectorInformations[] informations, TaxCollectorFightersInformation[] fightersInformations)
        {
            this.nbcollectorMax = nbcollectorMax;
            this.taxCollectorHireCost = taxCollectorHireCost;
            this.informations = informations;
            this.fightersInformations = fightersInformations;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(nbcollectorMax);
            writer.WriteShort(taxCollectorHireCost);
            writer.WriteUShort((ushort) informations.Length);
            foreach (var entry in informations)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) fightersInformations.Length);
            foreach (var entry in fightersInformations)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            nbcollectorMax = reader.ReadSByte();
            if (nbcollectorMax < 0)
                throw new Exception("Forbidden value on nbcollectorMax = " + nbcollectorMax + ", it doesn't respect the following condition : nbcollectorMax < 0");
            taxCollectorHireCost = reader.ReadShort();
            if (taxCollectorHireCost < 0)
                throw new Exception("Forbidden value on taxCollectorHireCost = " + taxCollectorHireCost + ", it doesn't respect the following condition : taxCollectorHireCost < 0");
            var limit = reader.ReadUShort();
            informations = new TaxCollectorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                informations[i] = Types.ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
                informations[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            fightersInformations = new TaxCollectorFightersInformation[limit];
            for (int i = 0; i < limit; i++)
            {
                fightersInformations[i] = new TaxCollectorFightersInformation();
                fightersInformations[i].Deserialize(reader);
            }
        }
    }
}
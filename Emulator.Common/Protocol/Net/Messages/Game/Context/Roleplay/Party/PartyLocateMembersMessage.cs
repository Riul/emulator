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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyLocateMembersMessage : AbstractPartyMessage
    {
        public const uint Id = 5595;

        public PartyMemberGeoPosition[] geopositions;


        public PartyLocateMembersMessage()
        {
        }

        public PartyLocateMembersMessage(int partyId, PartyMemberGeoPosition[] geopositions)
            : base(partyId)
        {
            this.geopositions = geopositions;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) geopositions.Length);
            foreach (var entry in geopositions)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            geopositions = new PartyMemberGeoPosition[limit];
            for (int i = 0; i < limit; i++)
            {
                geopositions[i] = new PartyMemberGeoPosition();
                geopositions[i].Deserialize(reader);
            }
        }
    }
}
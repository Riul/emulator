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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyLocateMembersMessage : AbstractPartyMessage
    {
        public const uint ID = 5595;

        public override uint MessageId
        {
            get { return ID; }
        }

        public PartyMemberGeoPosition[] Geopositions { get; set; }


        public PartyLocateMembersMessage()
        {
        }

        public PartyLocateMembersMessage(int partyId, PartyMemberGeoPosition[] geopositions)
                : base(partyId)
        {
            Geopositions = geopositions;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) Geopositions.Length);
            foreach (var entry in Geopositions)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            Geopositions = new PartyMemberGeoPosition[limit];
            for (int i = 0; i < limit; i++)
            {
                Geopositions[i] = new PartyMemberGeoPosition();
                Geopositions[i].Deserialize(reader);
            }
        }
    }
}
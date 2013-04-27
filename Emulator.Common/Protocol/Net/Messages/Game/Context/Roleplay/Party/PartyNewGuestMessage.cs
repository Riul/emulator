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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyNewGuestMessage : AbstractPartyEventMessage
    {
        public const uint Id = 6260;

        public PartyGuestInformations guest;

        public override uint MessageId
        {
            get { return Id; }
        }


        public PartyNewGuestMessage()
        {
        }

        public PartyNewGuestMessage(int partyId, PartyGuestInformations guest)
            : base(partyId)
        {
            this.guest = guest;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            guest.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            guest = new PartyGuestInformations();
            guest.Deserialize(reader);
        }
    }
}
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
    public class PartyUpdateMessage : AbstractPartyEventMessage
    {
        public const uint ID = 5575;

        public override uint MessageId
        {
            get { return ID; }
        }

        public PartyMemberInformations MemberInformations { get; set; }


        public PartyUpdateMessage()
        {
        }

        public PartyUpdateMessage(int partyId, PartyMemberInformations memberInformations)
                : base(partyId)
        {
            MemberInformations = memberInformations;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MemberInformations.TypeId);
            MemberInformations.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            MemberInformations = Types.ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadShort());
            MemberInformations.Deserialize(reader);
        }
    }
}
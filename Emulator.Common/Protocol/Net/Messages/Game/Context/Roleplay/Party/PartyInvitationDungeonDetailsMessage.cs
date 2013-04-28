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
    public class PartyInvitationDungeonDetailsMessage : PartyInvitationDetailsMessage
    {
        public const uint ID = 6262;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short DungeonId { get; set; }
        public bool[] PlayersDungeonReady { get; set; }


        public PartyInvitationDungeonDetailsMessage()
        {
        }

        public PartyInvitationDungeonDetailsMessage(int partyId, sbyte partyType, int fromId, string fromName, int leaderId, PartyInvitationMemberInformations[] members, PartyGuestInformations[] guests, short dungeonId, bool[] playersDungeonReady)
                : base(partyId, partyType, fromId, fromName, leaderId, members, guests)
        {
            DungeonId = dungeonId;
            PlayersDungeonReady = playersDungeonReady;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(DungeonId);
            writer.WriteUShort((ushort) PlayersDungeonReady.Length);
            foreach (var entry in PlayersDungeonReady)
            {
                writer.WriteBoolean(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            DungeonId = reader.ReadShort();
            var limit = reader.ReadUShort();
            PlayersDungeonReady = new bool[limit];
            for (int i = 0; i < limit; i++)
            {
                PlayersDungeonReady[i] = reader.ReadBoolean();
            }
        }
    }
}
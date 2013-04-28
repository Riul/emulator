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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Party
{
    public class PartyUpdateLightMessage : AbstractPartyEventMessage
    {
        public const uint ID = 6054;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int Id { get; set; }
        public int LifePoints { get; set; }
        public int MaxLifePoints { get; set; }
        public short Prospecting { get; set; }
        public byte RegenRate { get; set; }


        public PartyUpdateLightMessage()
        {
        }

        public PartyUpdateLightMessage(int partyId, int id, int lifePoints, int maxLifePoints, short prospecting, byte regenRate)
                : base(partyId)
        {
            Id = id;
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            Prospecting = prospecting;
            RegenRate = regenRate;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Id);
            writer.WriteInt(LifePoints);
            writer.WriteInt(MaxLifePoints);
            writer.WriteShort(Prospecting);
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Id = reader.ReadInt();
            LifePoints = reader.ReadInt();
            MaxLifePoints = reader.ReadInt();
            Prospecting = reader.ReadShort();
            RegenRate = reader.ReadByte();
        }
    }
}
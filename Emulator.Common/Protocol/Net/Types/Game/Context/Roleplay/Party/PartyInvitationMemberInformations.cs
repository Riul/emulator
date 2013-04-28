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
using Emulator.Common.Protocol.Net.Types.Game.Character.Choice;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Party
{
    public class PartyInvitationMemberInformations : CharacterBaseInformations
    {
        public const short ID = 376;

        public override short TypeId
        {
            get { return ID; }
        }

        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }


        public PartyInvitationMemberInformations()
        {
        }

        public PartyInvitationMemberInformations(int id, byte level, string name, EntityLook entityLook, sbyte breed, bool sex, short worldX, short worldY, int mapId, short subAreaId)
                : base(id, level, name, entityLook, breed, sex)
        {
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
        }
    }
}
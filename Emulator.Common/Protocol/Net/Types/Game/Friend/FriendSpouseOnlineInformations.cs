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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Friend
{
    public class FriendSpouseOnlineInformations : FriendSpouseInformations
    {
        public const short ID = 93;

        public override short TypeId
        {
            get { return ID; }
        }

        public bool InFight { get; set; }
        public bool FollowSpouse { get; set; }
        public bool PvpEnabled { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }


        public FriendSpouseOnlineInformations()
        {
        }

        public FriendSpouseOnlineInformations(int spouseAccountId, int spouseId, string spouseName, byte spouseLevel, sbyte breed, sbyte sex, EntityLook spouseEntityLook, BasicGuildInformations guildInfo, sbyte alignmentSide, bool inFight, bool followSpouse, bool pvpEnabled, int mapId, short subAreaId)
                : base(spouseAccountId, spouseId, spouseName, spouseLevel, breed, sex, spouseEntityLook, guildInfo, alignmentSide)
        {
            InFight = inFight;
            FollowSpouse = followSpouse;
            PvpEnabled = pvpEnabled;
            MapId = mapId;
            SubAreaId = subAreaId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, InFight);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, FollowSpouse);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, PvpEnabled);
            writer.WriteByte(flag1);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            InFight = BooleanByteWrapper.GetFlag(flag1, 0);
            FollowSpouse = BooleanByteWrapper.GetFlag(flag1, 1);
            PvpEnabled = BooleanByteWrapper.GetFlag(flag1, 2);
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
        }
    }
}
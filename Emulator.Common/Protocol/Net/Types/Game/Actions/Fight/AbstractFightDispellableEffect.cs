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

namespace Emulator.Common.Protocol.Net.Types.Game.Actions.Fight
{
    public class AbstractFightDispellableEffect
    {
        public const short ID = 206;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int Uid { get; set; }
        public int TargetId { get; set; }
        public short TurnDuration { get; set; }
        public sbyte Dispelable { get; set; }
        public short SpellId { get; set; }
        public int ParentBoostUid { get; set; }


        public AbstractFightDispellableEffect()
        {
        }

        public AbstractFightDispellableEffect(int uid, int targetId, short turnDuration, sbyte dispelable, short spellId, int parentBoostUid)
        {
            Uid = uid;
            TargetId = targetId;
            TurnDuration = turnDuration;
            Dispelable = dispelable;
            SpellId = spellId;
            ParentBoostUid = parentBoostUid;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Uid);
            writer.WriteInt(TargetId);
            writer.WriteShort(TurnDuration);
            writer.WriteSByte(Dispelable);
            writer.WriteShort(SpellId);
            writer.WriteInt(ParentBoostUid);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Uid = reader.ReadInt();
            TargetId = reader.ReadInt();
            TurnDuration = reader.ReadShort();
            Dispelable = reader.ReadSByte();
            SpellId = reader.ReadShort();
            ParentBoostUid = reader.ReadInt();
        }
    }
}
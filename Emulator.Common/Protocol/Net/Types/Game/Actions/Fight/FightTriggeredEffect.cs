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
    public class FightTriggeredEffect : AbstractFightDispellableEffect
    {
        public const short ID = 210;

        public override short TypeId
        {
            get { return ID; }
        }

        public int Arg1 { get; set; }
        public int Arg2 { get; set; }
        public int Arg3 { get; set; }
        public short Delay { get; set; }


        public FightTriggeredEffect()
        {
        }

        public FightTriggeredEffect(int uid, int targetId, short turnDuration, sbyte dispelable, short spellId, int parentBoostUid, int arg1, int arg2, int arg3, short delay)
                : base(uid, targetId, turnDuration, dispelable, spellId, parentBoostUid)
        {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Delay = delay;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Arg1);
            writer.WriteInt(Arg2);
            writer.WriteInt(Arg3);
            writer.WriteShort(Delay);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Arg1 = reader.ReadInt();
            Arg2 = reader.ReadInt();
            Arg3 = reader.ReadInt();
            Delay = reader.ReadShort();
        }
    }
}
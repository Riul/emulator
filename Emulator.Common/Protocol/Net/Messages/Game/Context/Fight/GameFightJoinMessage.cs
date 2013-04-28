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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightJoinMessage : NetworkMessage
    {
        public const uint ID = 702;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool CanBeCancelled { get; set; }
        public bool CanSayReady { get; set; }
        public bool IsSpectator { get; set; }
        public bool IsFightStarted { get; set; }
        public int TimeMaxBeforeFightStart { get; set; }
        public sbyte FightType { get; set; }


        public GameFightJoinMessage()
        {
        }

        public GameFightJoinMessage(bool canBeCancelled, bool canSayReady, bool isSpectator, bool isFightStarted, int timeMaxBeforeFightStart, sbyte fightType)
        {
            CanBeCancelled = canBeCancelled;
            CanSayReady = canSayReady;
            IsSpectator = isSpectator;
            IsFightStarted = isFightStarted;
            TimeMaxBeforeFightStart = timeMaxBeforeFightStart;
            FightType = fightType;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, CanBeCancelled);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, CanSayReady);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, IsSpectator);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, IsFightStarted);
            writer.WriteByte(flag1);
            writer.WriteInt(TimeMaxBeforeFightStart);
            writer.WriteSByte(FightType);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            CanBeCancelled = BooleanByteWrapper.GetFlag(flag1, 0);
            CanSayReady = BooleanByteWrapper.GetFlag(flag1, 1);
            IsSpectator = BooleanByteWrapper.GetFlag(flag1, 2);
            IsFightStarted = BooleanByteWrapper.GetFlag(flag1, 3);
            TimeMaxBeforeFightStart = reader.ReadInt();
            FightType = reader.ReadSByte();
        }
    }
}
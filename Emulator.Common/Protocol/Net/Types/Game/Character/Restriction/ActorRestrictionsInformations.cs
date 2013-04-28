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

namespace Emulator.Common.Protocol.Net.Types.Game.Character.Restriction
{
    public class ActorRestrictionsInformations
    {
        public const short ID = 204;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public bool CantBeAggressed { get; set; }
        public bool CantBeChallenged { get; set; }
        public bool CantTrade { get; set; }
        public bool CantBeAttackedByMutant { get; set; }
        public bool CantRun { get; set; }
        public bool ForceSlowWalk { get; set; }
        public bool CantMinimize { get; set; }
        public bool CantMove { get; set; }
        public bool CantAggress { get; set; }
        public bool CantChallenge { get; set; }
        public bool CantExchange { get; set; }
        public bool CantAttack { get; set; }
        public bool CantChat { get; set; }
        public bool CantBeMerchant { get; set; }
        public bool CantUseObject { get; set; }
        public bool CantUseTaxCollector { get; set; }
        public bool CantUseInteractive { get; set; }
        public bool CantSpeakToNPC { get; set; }
        public bool CantChangeZone { get; set; }
        public bool CantAttackMonster { get; set; }
        public bool CantWalk8Directions { get; set; }


        public ActorRestrictionsInformations()
        {
        }

        public ActorRestrictionsInformations(bool cantBeAggressed, bool cantBeChallenged, bool cantTrade, bool cantBeAttackedByMutant, bool cantRun, bool forceSlowWalk, bool cantMinimize, bool cantMove, bool cantAggress, bool cantChallenge, bool cantExchange, bool cantAttack, bool cantChat, bool cantBeMerchant, bool cantUseObject, bool cantUseTaxCollector, bool cantUseInteractive, bool cantSpeakToNPC, bool cantChangeZone, bool cantAttackMonster, bool cantWalk8Directions)
        {
            CantBeAggressed = cantBeAggressed;
            CantBeChallenged = cantBeChallenged;
            CantTrade = cantTrade;
            CantBeAttackedByMutant = cantBeAttackedByMutant;
            CantRun = cantRun;
            ForceSlowWalk = forceSlowWalk;
            CantMinimize = cantMinimize;
            CantMove = cantMove;
            CantAggress = cantAggress;
            CantChallenge = cantChallenge;
            CantExchange = cantExchange;
            CantAttack = cantAttack;
            CantChat = cantChat;
            CantBeMerchant = cantBeMerchant;
            CantUseObject = cantUseObject;
            CantUseTaxCollector = cantUseTaxCollector;
            CantUseInteractive = cantUseInteractive;
            CantSpeakToNPC = cantSpeakToNPC;
            CantChangeZone = cantChangeZone;
            CantAttackMonster = cantAttackMonster;
            CantWalk8Directions = cantWalk8Directions;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, CantBeAggressed);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, CantBeChallenged);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, CantTrade);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, CantBeAttackedByMutant);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 4, CantRun);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 5, ForceSlowWalk);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 6, CantMinimize);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 7, CantMove);
            writer.WriteByte(flag1);
            byte flag2 = 0;
            flag2 = BooleanByteWrapper.SetFlag(flag2, 0, CantAggress);
            flag2 = BooleanByteWrapper.SetFlag(flag2, 1, CantChallenge);
            flag2 = BooleanByteWrapper.SetFlag(flag2, 2, CantExchange);
            flag2 = BooleanByteWrapper.SetFlag(flag2, 3, CantAttack);
            flag2 = BooleanByteWrapper.SetFlag(flag2, 4, CantChat);
            flag2 = BooleanByteWrapper.SetFlag(flag2, 5, CantBeMerchant);
            flag2 = BooleanByteWrapper.SetFlag(flag2, 6, CantUseObject);
            flag2 = BooleanByteWrapper.SetFlag(flag2, 7, CantUseTaxCollector);
            writer.WriteByte(flag2);
            byte flag3 = 0;
            flag3 = BooleanByteWrapper.SetFlag(flag3, 0, CantUseInteractive);
            flag3 = BooleanByteWrapper.SetFlag(flag3, 1, CantSpeakToNPC);
            flag3 = BooleanByteWrapper.SetFlag(flag3, 2, CantChangeZone);
            flag3 = BooleanByteWrapper.SetFlag(flag3, 3, CantAttackMonster);
            flag3 = BooleanByteWrapper.SetFlag(flag3, 4, CantWalk8Directions);
            writer.WriteByte(flag3);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            CantBeAggressed = BooleanByteWrapper.GetFlag(flag1, 0);
            CantBeChallenged = BooleanByteWrapper.GetFlag(flag1, 1);
            CantTrade = BooleanByteWrapper.GetFlag(flag1, 2);
            CantBeAttackedByMutant = BooleanByteWrapper.GetFlag(flag1, 3);
            CantRun = BooleanByteWrapper.GetFlag(flag1, 4);
            ForceSlowWalk = BooleanByteWrapper.GetFlag(flag1, 5);
            CantMinimize = BooleanByteWrapper.GetFlag(flag1, 6);
            CantMove = BooleanByteWrapper.GetFlag(flag1, 7);
            byte flag2 = reader.ReadByte();
            CantAggress = BooleanByteWrapper.GetFlag(flag2, 0);
            CantChallenge = BooleanByteWrapper.GetFlag(flag2, 1);
            CantExchange = BooleanByteWrapper.GetFlag(flag2, 2);
            CantAttack = BooleanByteWrapper.GetFlag(flag2, 3);
            CantChat = BooleanByteWrapper.GetFlag(flag2, 4);
            CantBeMerchant = BooleanByteWrapper.GetFlag(flag2, 5);
            CantUseObject = BooleanByteWrapper.GetFlag(flag2, 6);
            CantUseTaxCollector = BooleanByteWrapper.GetFlag(flag2, 7);
            byte flag3 = reader.ReadByte();
            CantUseInteractive = BooleanByteWrapper.GetFlag(flag3, 0);
            CantSpeakToNPC = BooleanByteWrapper.GetFlag(flag3, 1);
            CantChangeZone = BooleanByteWrapper.GetFlag(flag3, 2);
            CantAttackMonster = BooleanByteWrapper.GetFlag(flag3, 3);
            CantWalk8Directions = BooleanByteWrapper.GetFlag(flag3, 4);
        }
    }
}
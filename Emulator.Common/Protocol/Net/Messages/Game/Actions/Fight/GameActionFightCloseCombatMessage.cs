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

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Fight
{
    public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public const uint Id = 6116;

        public int weaponGenericId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameActionFightCloseCombatMessage()
        {
        }

        public GameActionFightCloseCombatMessage(short actionId, int sourceId, int targetId, short destinationCellId, sbyte critical, bool silentCast, int weaponGenericId)
            : base(actionId, sourceId, targetId, destinationCellId, critical, silentCast)
        {
            this.weaponGenericId = weaponGenericId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(weaponGenericId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            weaponGenericId = reader.ReadInt();
            if (weaponGenericId < 0)
                throw new Exception("Forbidden value on weaponGenericId = " + weaponGenericId + ", it doesn't respect the following condition : weaponGenericId < 0");
        }
    }
}
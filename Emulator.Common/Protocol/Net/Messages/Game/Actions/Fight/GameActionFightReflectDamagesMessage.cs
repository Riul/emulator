#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:45
// */
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Fight
{
    public class GameActionFightReflectDamagesMessage : AbstractGameActionMessage
    {
        public const uint Id = 5530;

        public int amount;
        public int targetId;


        public GameActionFightReflectDamagesMessage()
        {
        }

        public GameActionFightReflectDamagesMessage(short actionId, int sourceId, int targetId, int amount)
            : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.amount = amount;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteInt(amount);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            amount = reader.ReadInt();
            if (amount < 0)
                throw new Exception("Forbidden value on amount = " + amount + ", it doesn't respect the following condition : amount < 0");
        }
    }
}
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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Action.Fight;
using Emulator.Common.Protocol.Net.Types.Game.Actions.Fight;
using Emulator.Common.Protocol.Net.Types.Game.Context.Fight;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
    {
        public const uint Id = 6215;

        public GameFightResumeSlaveInfo[] slavesInfo;


        public GameFightResumeWithSlavesMessage()
        {
        }

        public GameFightResumeWithSlavesMessage(FightDispellableEffectExtendedInformations[] effects, GameActionMark[] marks, short gameTurn, GameFightSpellCooldown[] spellCooldowns, sbyte summonCount, sbyte bombCount, GameFightResumeSlaveInfo[] slavesInfo)
            : base(effects, marks, gameTurn, spellCooldowns, summonCount, bombCount)
        {
            this.slavesInfo = slavesInfo;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) slavesInfo.Length);
            foreach (var entry in slavesInfo)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            slavesInfo = new GameFightResumeSlaveInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                slavesInfo[i] = new GameFightResumeSlaveInfo();
                slavesInfo[i].Deserialize(reader);
            }
        }
    }
}
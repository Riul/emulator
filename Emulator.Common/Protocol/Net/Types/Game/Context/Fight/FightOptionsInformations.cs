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
//     Created on 26/04/2013 at 16:46
// */
#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightOptionsInformations
    {
        public const short Id = 20;

        public bool isAskingForHelp;
        public bool isClosed;
        public bool isRestrictedToPartyOnly;
        public bool isSecret;


        public FightOptionsInformations()
        {
        }

        public FightOptionsInformations(bool isSecret, bool isRestrictedToPartyOnly, bool isClosed, bool isAskingForHelp)
        {
            this.isSecret = isSecret;
            this.isRestrictedToPartyOnly = isRestrictedToPartyOnly;
            this.isClosed = isClosed;
            this.isAskingForHelp = isAskingForHelp;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isSecret);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isRestrictedToPartyOnly);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, isClosed);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, isAskingForHelp);
            writer.WriteByte(flag1);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            isSecret = BooleanByteWrapper.GetFlag(flag1, 0);
            isRestrictedToPartyOnly = BooleanByteWrapper.GetFlag(flag1, 1);
            isClosed = BooleanByteWrapper.GetFlag(flag1, 2);
            isAskingForHelp = BooleanByteWrapper.GetFlag(flag1, 3);
        }
    }
}
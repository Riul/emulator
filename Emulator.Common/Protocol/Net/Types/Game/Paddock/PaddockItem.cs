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
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;
using Emulator.Common.Protocol.Net.Types.Game.Mount;

namespace Emulator.Common.Protocol.Net.Types.Game.Paddock
{
    public class PaddockItem : ObjectItemInRolePlay
    {
        public const short Id = 185;

        public ItemDurability durability;


        public PaddockItem()
        {
        }

        public PaddockItem(short cellId, short objectGID, ItemDurability durability)
            : base(cellId, objectGID)
        {
            this.durability = durability;
        }

        public override short TypeId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            durability.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            durability = new ItemDurability();
            durability.Deserialize(reader);
        }
    }
}
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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class ObjectFoundWhileRecoltingMessage : NetworkMessage
    {
        public const uint Id = 6017;

        public int genericId;
        public int quantity;
        public int ressourceGenericId;


        public ObjectFoundWhileRecoltingMessage()
        {
        }

        public ObjectFoundWhileRecoltingMessage(int genericId, int quantity, int ressourceGenericId)
        {
            this.genericId = genericId;
            this.quantity = quantity;
            this.ressourceGenericId = ressourceGenericId;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(genericId);
            writer.WriteInt(quantity);
            writer.WriteInt(ressourceGenericId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            genericId = reader.ReadInt();
            if (genericId < 0)
                throw new Exception("Forbidden value on genericId = " + genericId + ", it doesn't respect the following condition : genericId < 0");
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
            ressourceGenericId = reader.ReadInt();
            if (ressourceGenericId < 0)
                throw new Exception("Forbidden value on ressourceGenericId = " + ressourceGenericId + ", it doesn't respect the following condition : ressourceGenericId < 0");
        }
    }
}
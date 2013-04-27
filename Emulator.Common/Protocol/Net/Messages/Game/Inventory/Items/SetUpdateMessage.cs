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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class SetUpdateMessage : NetworkMessage
    {
        public const uint Id = 5503;
        public ObjectEffect[] setEffects;

        public short setId;
        public short[] setObjects;


        public SetUpdateMessage()
        {
        }

        public SetUpdateMessage(short setId, short[] setObjects, ObjectEffect[] setEffects)
        {
            this.setId = setId;
            this.setObjects = setObjects;
            this.setEffects = setEffects;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(setId);
            writer.WriteUShort((ushort) setObjects.Length);
            foreach (var entry in setObjects)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) setEffects.Length);
            foreach (var entry in setEffects)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            setId = reader.ReadShort();
            if (setId < 0)
                throw new Exception("Forbidden value on setId = " + setId + ", it doesn't respect the following condition : setId < 0");
            var limit = reader.ReadUShort();
            setObjects = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                setObjects[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            setEffects = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                setEffects[i] = Types.ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                setEffects[i].Deserialize(reader);
            }
        }
    }
}
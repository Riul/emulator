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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects;

namespace Emulator.Common.Protocol.Net.Types.Game.Data.Items
{
    public class ObjectItemNotInContainer : Item
    {
        public const short ID = 134;

        public override short TypeId
        {
            get { return ID; }
        }

        public short ObjectGID { get; set; }
        public short PowerRate { get; set; }
        public bool OverMax { get; set; }
        public ObjectEffect[] Effects { get; set; }
        public int ObjectUID { get; set; }
        public int Quantity { get; set; }


        public ObjectItemNotInContainer()
        {
        }

        public ObjectItemNotInContainer(short objectGID, short powerRate, bool overMax, ObjectEffect[] effects, int objectUID, int quantity)
        {
            ObjectGID = objectGID;
            PowerRate = powerRate;
            OverMax = overMax;
            Effects = effects;
            ObjectUID = objectUID;
            Quantity = quantity;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(ObjectGID);
            writer.WriteShort(PowerRate);
            writer.WriteBoolean(OverMax);
            writer.WriteUShort((ushort) Effects.Length);
            foreach (var entry in Effects)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteInt(ObjectUID);
            writer.WriteInt(Quantity);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadShort();
            PowerRate = reader.ReadShort();
            OverMax = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            Effects = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                Effects[i] = Types.ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                Effects[i].Deserialize(reader);
            }
            ObjectUID = reader.ReadInt();
            Quantity = reader.ReadInt();
        }
    }
}
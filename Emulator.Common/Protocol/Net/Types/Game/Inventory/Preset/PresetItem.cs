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

namespace Emulator.Common.Protocol.Net.Types.Game.Inventory.Preset
{
    public class PresetItem
    {
        public const short ID = 354;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public byte Position { get; set; }
        public int ObjGid { get; set; }
        public int ObjUid { get; set; }


        public PresetItem()
        {
        }

        public PresetItem(byte position, int objGid, int objUid)
        {
            Position = position;
            ObjGid = objGid;
            ObjUid = objUid;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteByte(Position);
            writer.WriteInt(ObjGid);
            writer.WriteInt(ObjUid);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Position = reader.ReadByte();
            ObjGid = reader.ReadInt();
            ObjUid = reader.ReadInt();
        }
    }
}
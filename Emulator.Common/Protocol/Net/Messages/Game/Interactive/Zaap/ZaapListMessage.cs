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

namespace Emulator.Common.Protocol.Net.Messages.Game.Interactive.Zaap
{
    public class ZaapListMessage : TeleportDestinationsListMessage
    {
        public const uint ID = 1604;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int SpawnMapId { get; set; }


        public ZaapListMessage()
        {
        }

        public ZaapListMessage(sbyte teleporterType, int[] mapIds, short[] subAreaIds, short[] costs, int spawnMapId)
                : base(teleporterType, mapIds, subAreaIds, costs)
        {
            SpawnMapId = spawnMapId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(SpawnMapId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            SpawnMapId = reader.ReadInt();
        }
    }
}
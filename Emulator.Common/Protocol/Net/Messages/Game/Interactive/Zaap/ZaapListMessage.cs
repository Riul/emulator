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

namespace Emulator.Common.Protocol.Net.Messages.Game.Interactive.Zaap
{
    public class ZaapListMessage : TeleportDestinationsListMessage
    {
        public const uint Id = 1604;

        public int spawnMapId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ZaapListMessage()
        {
        }

        public ZaapListMessage(sbyte teleporterType, int[] mapIds, short[] subAreaIds, short[] costs, int spawnMapId)
            : base(teleporterType, mapIds, subAreaIds, costs)
        {
            this.spawnMapId = spawnMapId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(spawnMapId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            spawnMapId = reader.ReadInt();
            if (spawnMapId < 0)
                throw new Exception("Forbidden value on spawnMapId = " + spawnMapId + ", it doesn't respect the following condition : spawnMapId < 0");
        }
    }
}
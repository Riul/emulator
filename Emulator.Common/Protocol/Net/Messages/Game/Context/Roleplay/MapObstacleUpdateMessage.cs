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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Interactive;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay
{
    public class MapObstacleUpdateMessage : NetworkMessage
    {
        public const uint Id = 6051;

        public MapObstacle[] obstacles;

        public override uint MessageId
        {
            get { return Id; }
        }


        public MapObstacleUpdateMessage()
        {
        }

        public MapObstacleUpdateMessage(MapObstacle[] obstacles)
        {
            this.obstacles = obstacles;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) obstacles.Length);
            foreach (var entry in obstacles)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            obstacles = new MapObstacle[limit];
            for (int i = 0; i < limit; i++)
            {
                obstacles[i] = new MapObstacle();
                obstacles[i].Deserialize(reader);
            }
        }
    }
}
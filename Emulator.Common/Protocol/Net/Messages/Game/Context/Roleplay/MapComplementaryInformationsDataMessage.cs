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
using Emulator.Common.Protocol.Net.Types.Game.Context.Fight;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;
using Emulator.Common.Protocol.Net.Types.Game.House;
using Emulator.Common.Protocol.Net.Types.Game.Interactive;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay
{
    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {
        public const uint Id = 226;

        public GameRolePlayActorInformations[] actors;
        public FightCommonInformations[] fights;
        public HouseInformations[] houses;
        public InteractiveElement[] interactiveElements;
        public int mapId;
        public MapObstacle[] obstacles;
        public StatedElement[] statedElements;
        public short subAreaId;
        public sbyte subareaAlignmentSide;


        public MapComplementaryInformationsDataMessage()
        {
        }

        public MapComplementaryInformationsDataMessage(short subAreaId, int mapId, sbyte subareaAlignmentSide, HouseInformations[] houses, GameRolePlayActorInformations[] actors, InteractiveElement[] interactiveElements, StatedElement[] statedElements, MapObstacle[] obstacles, FightCommonInformations[] fights)
        {
            this.subAreaId = subAreaId;
            this.mapId = mapId;
            this.subareaAlignmentSide = subareaAlignmentSide;
            this.houses = houses;
            this.actors = actors;
            this.interactiveElements = interactiveElements;
            this.statedElements = statedElements;
            this.obstacles = obstacles;
            this.fights = fights;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(subAreaId);
            writer.WriteInt(mapId);
            writer.WriteSByte(subareaAlignmentSide);
            writer.WriteUShort((ushort) houses.Length);
            foreach (var entry in houses)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) actors.Length);
            foreach (var entry in actors)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) interactiveElements.Length);
            foreach (var entry in interactiveElements)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) statedElements.Length);
            foreach (var entry in statedElements)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) obstacles.Length);
            foreach (var entry in obstacles)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) fights.Length);
            foreach (var entry in fights)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            subAreaId = reader.ReadShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
            subareaAlignmentSide = reader.ReadSByte();
            var limit = reader.ReadUShort();
            houses = new HouseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                houses[i] = Types.ProtocolTypeManager.GetInstance<HouseInformations>(reader.ReadShort());
                houses[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            actors = new GameRolePlayActorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                actors[i] = Types.ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
                actors[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            interactiveElements = new InteractiveElement[limit];
            for (int i = 0; i < limit; i++)
            {
                interactiveElements[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadShort());
                interactiveElements[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            statedElements = new StatedElement[limit];
            for (int i = 0; i < limit; i++)
            {
                statedElements[i] = new StatedElement();
                statedElements[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            obstacles = new MapObstacle[limit];
            for (int i = 0; i < limit; i++)
            {
                obstacles[i] = new MapObstacle();
                obstacles[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            fights = new FightCommonInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                fights[i] = new FightCommonInformations();
                fights[i].Deserialize(reader);
            }
        }
    }
}
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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Fight;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;
using Emulator.Common.Protocol.Net.Types.Game.House;
using Emulator.Common.Protocol.Net.Types.Game.Interactive;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay
{
    public class MapComplementaryInformationsDataMessage : NetworkMessage
    {
        public const uint ID = 226;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short SubAreaId { get; set; }
        public int MapId { get; set; }
        public sbyte SubareaAlignmentSide { get; set; }
        public HouseInformations[] Houses { get; set; }
        public GameRolePlayActorInformations[] Actors { get; set; }
        public InteractiveElement[] InteractiveElements { get; set; }
        public StatedElement[] StatedElements { get; set; }
        public MapObstacle[] Obstacles { get; set; }
        public FightCommonInformations[] Fights { get; set; }


        public MapComplementaryInformationsDataMessage()
        {
        }

        public MapComplementaryInformationsDataMessage(short subAreaId, int mapId, sbyte subareaAlignmentSide, HouseInformations[] houses, GameRolePlayActorInformations[] actors, InteractiveElement[] interactiveElements, StatedElement[] statedElements, MapObstacle[] obstacles, FightCommonInformations[] fights)
        {
            SubAreaId = subAreaId;
            MapId = mapId;
            SubareaAlignmentSide = subareaAlignmentSide;
            Houses = houses;
            Actors = actors;
            InteractiveElements = interactiveElements;
            StatedElements = statedElements;
            Obstacles = obstacles;
            Fights = fights;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(SubAreaId);
            writer.WriteInt(MapId);
            writer.WriteSByte(SubareaAlignmentSide);
            writer.WriteUShort((ushort) Houses.Length);
            foreach (var entry in Houses)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) Actors.Length);
            foreach (var entry in Actors)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) InteractiveElements.Length);
            foreach (var entry in InteractiveElements)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) StatedElements.Length);
            foreach (var entry in StatedElements)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) Obstacles.Length);
            foreach (var entry in Obstacles)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) Fights.Length);
            foreach (var entry in Fights)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            SubAreaId = reader.ReadShort();
            MapId = reader.ReadInt();
            SubareaAlignmentSide = reader.ReadSByte();
            var limit = reader.ReadUShort();
            Houses = new HouseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Houses[i] = Types.ProtocolTypeManager.GetInstance<HouseInformations>(reader.ReadShort());
                Houses[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            Actors = new GameRolePlayActorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Actors[i] = Types.ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
                Actors[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            InteractiveElements = new InteractiveElement[limit];
            for (int i = 0; i < limit; i++)
            {
                InteractiveElements[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadShort());
                InteractiveElements[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            StatedElements = new StatedElement[limit];
            for (int i = 0; i < limit; i++)
            {
                StatedElements[i] = new StatedElement();
                StatedElements[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            Obstacles = new MapObstacle[limit];
            for (int i = 0; i < limit; i++)
            {
                Obstacles[i] = new MapObstacle();
                Obstacles[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            Fights = new FightCommonInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Fights[i] = new FightCommonInformations();
                Fights[i].Deserialize(reader);
            }
        }
    }
}
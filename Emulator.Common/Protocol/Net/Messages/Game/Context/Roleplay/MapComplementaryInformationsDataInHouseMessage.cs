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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Context.Fight;
using Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay;
using Emulator.Common.Protocol.Net.Types.Game.House;
using Emulator.Common.Protocol.Net.Types.Game.Interactive;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay
{
    public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
    {
        public const uint Id = 6130;

        public HouseInformationsInside currentHouse;


        public MapComplementaryInformationsDataInHouseMessage()
        {
        }

        public MapComplementaryInformationsDataInHouseMessage(short subAreaId, int mapId, sbyte subareaAlignmentSide, HouseInformations[] houses, GameRolePlayActorInformations[] actors, InteractiveElement[] interactiveElements, StatedElement[] statedElements, MapObstacle[] obstacles, FightCommonInformations[] fights, HouseInformationsInside currentHouse)
            : base(subAreaId, mapId, subareaAlignmentSide, houses, actors, interactiveElements, statedElements, obstacles, fights)
        {
            this.currentHouse = currentHouse;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            currentHouse.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            currentHouse = new HouseInformationsInside();
            currentHouse.Deserialize(reader);
        }
    }
}
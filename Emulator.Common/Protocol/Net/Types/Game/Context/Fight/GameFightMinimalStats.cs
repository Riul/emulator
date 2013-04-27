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
//     Created on 26/04/2013 at 16:46
// */
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class GameFightMinimalStats
    {
        public const short Id = 31;

        public short actionPoints;
        public short airElementReduction;
        public short airElementResistPercent;
        public int baseMaxLifePoints;
        public short criticalDamageFixedResist;
        public short dodgePALostProbability;
        public short dodgePMLostProbability;
        public short earthElementReduction;
        public short earthElementResistPercent;
        public short fireElementReduction;
        public short fireElementResistPercent;
        public sbyte invisibilityState;
        public int lifePoints;
        public short maxActionPoints;
        public int maxLifePoints;
        public short maxMovementPoints;
        public short movementPoints;
        public short neutralElementReduction;
        public short neutralElementResistPercent;
        public int permanentDamagePercent;
        public short pushDamageFixedResist;
        public int shieldPoints;
        public bool summoned;
        public int summoner;
        public short tackleBlock;
        public short tackleEvade;
        public short waterElementReduction;
        public short waterElementResistPercent;


        public GameFightMinimalStats()
        {
        }

        public GameFightMinimalStats(int lifePoints, int maxLifePoints, int baseMaxLifePoints, int permanentDamagePercent, int shieldPoints, short actionPoints, short maxActionPoints, short movementPoints, short maxMovementPoints, int summoner, bool summoned, short neutralElementResistPercent, short earthElementResistPercent, short waterElementResistPercent, short airElementResistPercent, short fireElementResistPercent, short neutralElementReduction, short earthElementReduction, short waterElementReduction, short airElementReduction, short fireElementReduction, short criticalDamageFixedResist, short pushDamageFixedResist, short dodgePALostProbability, short dodgePMLostProbability, short tackleBlock, short tackleEvade, sbyte invisibilityState)
        {
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
            this.baseMaxLifePoints = baseMaxLifePoints;
            this.permanentDamagePercent = permanentDamagePercent;
            this.shieldPoints = shieldPoints;
            this.actionPoints = actionPoints;
            this.maxActionPoints = maxActionPoints;
            this.movementPoints = movementPoints;
            this.maxMovementPoints = maxMovementPoints;
            this.summoner = summoner;
            this.summoned = summoned;
            this.neutralElementResistPercent = neutralElementResistPercent;
            this.earthElementResistPercent = earthElementResistPercent;
            this.waterElementResistPercent = waterElementResistPercent;
            this.airElementResistPercent = airElementResistPercent;
            this.fireElementResistPercent = fireElementResistPercent;
            this.neutralElementReduction = neutralElementReduction;
            this.earthElementReduction = earthElementReduction;
            this.waterElementReduction = waterElementReduction;
            this.airElementReduction = airElementReduction;
            this.fireElementReduction = fireElementReduction;
            this.criticalDamageFixedResist = criticalDamageFixedResist;
            this.pushDamageFixedResist = pushDamageFixedResist;
            this.dodgePALostProbability = dodgePALostProbability;
            this.dodgePMLostProbability = dodgePMLostProbability;
            this.tackleBlock = tackleBlock;
            this.tackleEvade = tackleEvade;
            this.invisibilityState = invisibilityState;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(lifePoints);
            writer.WriteInt(maxLifePoints);
            writer.WriteInt(baseMaxLifePoints);
            writer.WriteInt(permanentDamagePercent);
            writer.WriteInt(shieldPoints);
            writer.WriteShort(actionPoints);
            writer.WriteShort(maxActionPoints);
            writer.WriteShort(movementPoints);
            writer.WriteShort(maxMovementPoints);
            writer.WriteInt(summoner);
            writer.WriteBoolean(summoned);
            writer.WriteShort(neutralElementResistPercent);
            writer.WriteShort(earthElementResistPercent);
            writer.WriteShort(waterElementResistPercent);
            writer.WriteShort(airElementResistPercent);
            writer.WriteShort(fireElementResistPercent);
            writer.WriteShort(neutralElementReduction);
            writer.WriteShort(earthElementReduction);
            writer.WriteShort(waterElementReduction);
            writer.WriteShort(airElementReduction);
            writer.WriteShort(fireElementReduction);
            writer.WriteShort(criticalDamageFixedResist);
            writer.WriteShort(pushDamageFixedResist);
            writer.WriteShort(dodgePALostProbability);
            writer.WriteShort(dodgePMLostProbability);
            writer.WriteShort(tackleBlock);
            writer.WriteShort(tackleEvade);
            writer.WriteSByte(invisibilityState);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            lifePoints = reader.ReadInt();
            if (lifePoints < 0)
                throw new Exception("Forbidden value on lifePoints = " + lifePoints + ", it doesn't respect the following condition : lifePoints < 0");
            maxLifePoints = reader.ReadInt();
            if (maxLifePoints < 0)
                throw new Exception("Forbidden value on maxLifePoints = " + maxLifePoints + ", it doesn't respect the following condition : maxLifePoints < 0");
            baseMaxLifePoints = reader.ReadInt();
            if (baseMaxLifePoints < 0)
                throw new Exception("Forbidden value on baseMaxLifePoints = " + baseMaxLifePoints + ", it doesn't respect the following condition : baseMaxLifePoints < 0");
            permanentDamagePercent = reader.ReadInt();
            if (permanentDamagePercent < 0)
                throw new Exception("Forbidden value on permanentDamagePercent = " + permanentDamagePercent + ", it doesn't respect the following condition : permanentDamagePercent < 0");
            shieldPoints = reader.ReadInt();
            if (shieldPoints < 0)
                throw new Exception("Forbidden value on shieldPoints = " + shieldPoints + ", it doesn't respect the following condition : shieldPoints < 0");
            actionPoints = reader.ReadShort();
            maxActionPoints = reader.ReadShort();
            movementPoints = reader.ReadShort();
            maxMovementPoints = reader.ReadShort();
            summoner = reader.ReadInt();
            summoned = reader.ReadBoolean();
            neutralElementResistPercent = reader.ReadShort();
            earthElementResistPercent = reader.ReadShort();
            waterElementResistPercent = reader.ReadShort();
            airElementResistPercent = reader.ReadShort();
            fireElementResistPercent = reader.ReadShort();
            neutralElementReduction = reader.ReadShort();
            earthElementReduction = reader.ReadShort();
            waterElementReduction = reader.ReadShort();
            airElementReduction = reader.ReadShort();
            fireElementReduction = reader.ReadShort();
            criticalDamageFixedResist = reader.ReadShort();
            pushDamageFixedResist = reader.ReadShort();
            dodgePALostProbability = reader.ReadShort();
            if (dodgePALostProbability < 0)
                throw new Exception("Forbidden value on dodgePALostProbability = " + dodgePALostProbability + ", it doesn't respect the following condition : dodgePALostProbability < 0");
            dodgePMLostProbability = reader.ReadShort();
            if (dodgePMLostProbability < 0)
                throw new Exception("Forbidden value on dodgePMLostProbability = " + dodgePMLostProbability + ", it doesn't respect the following condition : dodgePMLostProbability < 0");
            tackleBlock = reader.ReadShort();
            tackleEvade = reader.ReadShort();
            invisibilityState = reader.ReadSByte();
        }
    }
}
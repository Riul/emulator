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

namespace Emulator.Common.Protocol.Net.Types.Game.Guild.Tax
{
    public class AdditionalTaxCollectorInformations
    {
        public const short Id = 165;

        public string collectorCallerName;
        public int date;


        public AdditionalTaxCollectorInformations()
        {
        }

        public AdditionalTaxCollectorInformations(string collectorCallerName, int date)
        {
            this.collectorCallerName = collectorCallerName;
            this.date = date;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(collectorCallerName);
            writer.WriteInt(date);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            collectorCallerName = reader.ReadUTF();
            date = reader.ReadInt();
            if (date < 0)
                throw new Exception("Forbidden value on date = " + date + ", it doesn't respect the following condition : date < 0");
        }
    }
}
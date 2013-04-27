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
using Emulator.Common.Protocol.Net.Types.Game.Mount;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class UpdateMountBoostMessage : NetworkMessage
    {
        public const uint Id = 6179;

        public UpdateMountBoost[] boostToUpdateList;
        public double rideId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public UpdateMountBoostMessage()
        {
        }

        public UpdateMountBoostMessage(double rideId, UpdateMountBoost[] boostToUpdateList)
        {
            this.rideId = rideId;
            this.boostToUpdateList = boostToUpdateList;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(rideId);
            writer.WriteUShort((ushort) boostToUpdateList.Length);
            foreach (var entry in boostToUpdateList)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            rideId = reader.ReadDouble();
            var limit = reader.ReadUShort();
            boostToUpdateList = new UpdateMountBoost[limit];
            for (int i = 0; i < limit; i++)
            {
                boostToUpdateList[i] = Types.ProtocolTypeManager.GetInstance<UpdateMountBoost>(reader.ReadShort());
                boostToUpdateList[i].Deserialize(reader);
            }
        }
    }
}
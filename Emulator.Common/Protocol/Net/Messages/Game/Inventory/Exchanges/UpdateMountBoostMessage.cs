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
using Emulator.Common.Protocol.Net.Types.Game.Mount;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class UpdateMountBoostMessage : NetworkMessage
    {
        public const uint ID = 6179;

        public override uint MessageId
        {
            get { return ID; }
        }

        public double RideId { get; set; }
        public UpdateMountBoost[] BoostToUpdateList { get; set; }


        public UpdateMountBoostMessage()
        {
        }

        public UpdateMountBoostMessage(double rideId, UpdateMountBoost[] boostToUpdateList)
        {
            RideId = rideId;
            BoostToUpdateList = boostToUpdateList;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(RideId);
            writer.WriteUShort((ushort) BoostToUpdateList.Length);
            foreach (var entry in BoostToUpdateList)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            RideId = reader.ReadDouble();
            var limit = reader.ReadUShort();
            BoostToUpdateList = new UpdateMountBoost[limit];
            for (int i = 0; i < limit; i++)
            {
                BoostToUpdateList[i] = Types.ProtocolTypeManager.GetInstance<UpdateMountBoost>(reader.ReadShort());
                BoostToUpdateList[i].Deserialize(reader);
            }
        }
    }
}
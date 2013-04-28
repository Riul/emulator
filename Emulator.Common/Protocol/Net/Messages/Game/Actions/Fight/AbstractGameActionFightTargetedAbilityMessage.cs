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

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Fight
{
    public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
    {
        public const uint ID = 6118;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int TargetId { get; set; }
        public short DestinationCellId { get; set; }
        public sbyte Critical { get; set; }
        public bool SilentCast { get; set; }


        public AbstractGameActionFightTargetedAbilityMessage()
        {
        }

        public AbstractGameActionFightTargetedAbilityMessage(short actionId, int sourceId, int targetId, short destinationCellId, sbyte critical, bool silentCast)
                : base(actionId, sourceId)
        {
            TargetId = targetId;
            DestinationCellId = destinationCellId;
            Critical = critical;
            SilentCast = silentCast;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(TargetId);
            writer.WriteShort(DestinationCellId);
            writer.WriteSByte(Critical);
            writer.WriteBoolean(SilentCast);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadInt();
            DestinationCellId = reader.ReadShort();
            Critical = reader.ReadSByte();
            SilentCast = reader.ReadBoolean();
        }
    }
}
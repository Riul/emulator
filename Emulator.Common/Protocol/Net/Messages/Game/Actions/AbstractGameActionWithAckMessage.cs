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

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions
{
    public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
    {
        public const uint Id = 1001;

        public short waitAckId;


        public AbstractGameActionWithAckMessage()
        {
        }

        public AbstractGameActionWithAckMessage(short actionId, int sourceId, short waitAckId)
            : base(actionId, sourceId)
        {
            this.waitAckId = waitAckId;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(waitAckId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            waitAckId = reader.ReadShort();
        }
    }
}
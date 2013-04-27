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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightTurnStartSlaveMessage : GameFightTurnStartMessage
    {
        public const uint Id = 6213;

        public int idSummoner;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameFightTurnStartSlaveMessage()
        {
        }

        public GameFightTurnStartSlaveMessage(int id, int waitTime, int idSummoner)
            : base(id, waitTime)
        {
            this.idSummoner = idSummoner;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(idSummoner);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            idSummoner = reader.ReadInt();
        }
    }
}
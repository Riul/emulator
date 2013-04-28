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
using Emulator.Common.Protocol.Net.Types.Game.Context;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context
{
    public class GameMapChangeOrientationsMessage : NetworkMessage
    {
        public const uint ID = 6155;

        public override uint MessageId
        {
            get { return ID; }
        }

        public ActorOrientation[] Orientations { get; set; }


        public GameMapChangeOrientationsMessage()
        {
        }

        public GameMapChangeOrientationsMessage(ActorOrientation[] orientations)
        {
            Orientations = orientations;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Orientations.Length);
            foreach (var entry in Orientations)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Orientations = new ActorOrientation[limit];
            for (int i = 0; i < limit; i++)
            {
                Orientations[i] = new ActorOrientation();
                Orientations[i].Deserialize(reader);
            }
        }
    }
}
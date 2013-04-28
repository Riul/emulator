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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay
{
    public class MapRunningFightListMessage : NetworkMessage
    {
        public const uint ID = 5743;

        public override uint MessageId
        {
            get { return ID; }
        }

        public FightExternalInformations[] Fights { get; set; }


        public MapRunningFightListMessage()
        {
        }

        public MapRunningFightListMessage(FightExternalInformations[] fights)
        {
            Fights = fights;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Fights.Length);
            foreach (var entry in Fights)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Fights = new FightExternalInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Fights[i] = new FightExternalInformations();
                Fights[i].Deserialize(reader);
            }
        }
    }
}
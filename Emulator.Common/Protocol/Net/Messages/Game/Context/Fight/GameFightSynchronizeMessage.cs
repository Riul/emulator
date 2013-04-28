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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightSynchronizeMessage : NetworkMessage
    {
        public const uint ID = 5921;

        public override uint MessageId
        {
            get { return ID; }
        }

        public GameFightFighterInformations[] Fighters { get; set; }


        public GameFightSynchronizeMessage()
        {
        }

        public GameFightSynchronizeMessage(GameFightFighterInformations[] fighters)
        {
            Fighters = fighters;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Fighters.Length);
            foreach (var entry in Fighters)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Fighters = new GameFightFighterInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Fighters[i] = Types.ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadShort());
                Fighters[i].Deserialize(reader);
            }
        }
    }
}
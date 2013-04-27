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
using Emulator.Common.Protocol.Net.Types.Game.Startup;

namespace Emulator.Common.Protocol.Net.Messages.Game.Startup
{
    public class StartupActionsListMessage : NetworkMessage
    {
        public const uint Id = 1301;

        public StartupActionAddObject[] actions;

        public override uint MessageId
        {
            get { return Id; }
        }


        public StartupActionsListMessage()
        {
        }

        public StartupActionsListMessage(StartupActionAddObject[] actions)
        {
            this.actions = actions;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) actions.Length);
            foreach (var entry in actions)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            actions = new StartupActionAddObject[limit];
            for (int i = 0; i < limit; i++)
            {
                actions[i] = new StartupActionAddObject();
                actions[i].Deserialize(reader);
            }
        }
    }
}
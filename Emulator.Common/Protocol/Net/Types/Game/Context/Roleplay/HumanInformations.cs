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
using Emulator.Common.Protocol.Net.Types.Game.Character.Restriction;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class HumanInformations
    {
        public const short ID = 157;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public ActorRestrictionsInformations Restrictions { get; set; }
        public bool Sex { get; set; }
        public HumanOption[] Options { get; set; }


        public HumanInformations()
        {
        }

        public HumanInformations(ActorRestrictionsInformations restrictions, bool sex, HumanOption[] options)
        {
            Restrictions = restrictions;
            Sex = sex;
            Options = options;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            Restrictions.Serialize(writer);
            writer.WriteBoolean(Sex);
            writer.WriteUShort((ushort) Options.Length);
            foreach (var entry in Options)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Deserialize(reader);
            Sex = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            Options = new HumanOption[limit];
            for (int i = 0; i < limit; i++)
            {
                Options[i] = Types.ProtocolTypeManager.GetInstance<HumanOption>(reader.ReadShort());
                Options[i].Deserialize(reader);
            }
        }
    }
}
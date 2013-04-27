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
// Created on 26/04/2013 at 16:46
#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Character.Restriction;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class HumanInformations
    {
        public const short Id = 157;
        public HumanOption[] options;

        public ActorRestrictionsInformations restrictions;
        public bool sex;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public HumanInformations()
        {
        }

        public HumanInformations(ActorRestrictionsInformations restrictions, bool sex, HumanOption[] options)
        {
            this.restrictions = restrictions;
            this.sex = sex;
            this.options = options;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            restrictions.Serialize(writer);
            writer.WriteBoolean(sex);
            writer.WriteUShort((ushort) options.Length);
            foreach (var entry in options)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            restrictions = new ActorRestrictionsInformations();
            restrictions.Deserialize(reader);
            sex = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            options = new HumanOption[limit];
            for (int i = 0; i < limit; i++)
            {
                options[i] = Types.ProtocolTypeManager.GetInstance<HumanOption>(reader.ReadShort());
                options[i].Deserialize(reader);
            }
        }
    }
}
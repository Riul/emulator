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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Types.Game.Startup
{
    public class StartupActionAddObject
    {
        public const short ID = 52;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int Uid { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string DescUrl { get; set; }
        public string PictureUrl { get; set; }
        public ObjectItemInformationWithQuantity[] Items { get; set; }


        public StartupActionAddObject()
        {
        }

        public StartupActionAddObject(int uid, string title, string text, string descUrl, string pictureUrl, ObjectItemInformationWithQuantity[] items)
        {
            Uid = uid;
            Title = title;
            Text = text;
            DescUrl = descUrl;
            PictureUrl = pictureUrl;
            Items = items;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Uid);
            writer.WriteUTF(Title);
            writer.WriteUTF(Text);
            writer.WriteUTF(DescUrl);
            writer.WriteUTF(PictureUrl);
            writer.WriteUShort((ushort) Items.Length);
            foreach (var entry in Items)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Uid = reader.ReadInt();
            Title = reader.ReadUTF();
            Text = reader.ReadUTF();
            DescUrl = reader.ReadUTF();
            PictureUrl = reader.ReadUTF();
            var limit = reader.ReadUShort();
            Items = new ObjectItemInformationWithQuantity[limit];
            for (int i = 0; i < limit; i++)
            {
                Items[i] = new ObjectItemInformationWithQuantity();
                Items[i].Deserialize(reader);
            }
        }
    }
}
using System;

namespace Emulator.Common.Extentions
{
    public static class DateTimeExtention
    {
        public static int ToUnixTimestamp(this DateTime dateTime)
        {
            return (int)(dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }
    }
}

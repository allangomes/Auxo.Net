using System;

namespace Auxo.Extensions
{
    public static class GuidExtension
    {
        public static bool IsEmpty(this Guid self) => self == default(Guid);
    }
}
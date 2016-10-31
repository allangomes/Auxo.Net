using System;

namespace Auxo.Core.Extensions
{
    public static class IntExtension
    {
        public static DateTime Years(this int self) => DateTime.Today.AddYears(self);
        public static DateTime Months(this int self) => DateTime.Today.AddMonths(self);
        public static DateTime Days(this int self) => DateTime.Today.AddDays(self);
    }
}
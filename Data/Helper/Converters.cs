using Data.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Helper
{
    public static class Converters
    {
        private static readonly string[] PT = { "dom", "seg", "ter", "qua", "qui", "sex", "sab" };

        // --- helpers (fora das expression trees)
        private static string MapWeekdayToPt(Weekday d)
        {
            return PT[(int)d];
        }

        private static Weekday MapPtToWeekday(string? s)
        {
            switch ((s ?? "").ToLowerInvariant())
            {
                case "dom": return Weekday.Dom;
                case "seg": return Weekday.Seg;
                case "ter": return Weekday.Ter;
                case "qua": return Weekday.Qua;
                case "qui": return Weekday.Qui;
                case "sex": return Weekday.Sex;
                case "sab": return Weekday.Sab;
                default: return Weekday.Seg;
            }
        }

        private static string ItemTipoToLowerStr(ItemTipo v) => v.ToString().ToLowerInvariant();

        private static ItemTipo ParseItemTipo(string? s)
        {
            if (Enum.TryParse<ItemTipo>(s ?? "", ignoreCase: true, out var value))
                return value;
            return ItemTipo.Carne;
        }

        private static string WeekdayArrayToSetStr(Weekday[]? arr)
        {
            if (arr == null || arr.Length == 0) return "";
            return string.Join(",", arr.Select(d => MapWeekdayToPt(d)).Distinct());
        }

        private static Weekday[] SetStrToWeekdayArray(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return Array.Empty<Weekday>();
            return s.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => MapPtToWeekday(x.Trim()))
                    .Distinct()
                    .ToArray();
        }

        public static readonly ValueConverter<Weekday, string> WeekdayToPt =
            new(v => MapWeekdayToPt(v),
                s => MapPtToWeekday(s));

        public static readonly ValueConverter<ItemTipo, string> ItemTipoToLower =
            new(v => ItemTipoToLowerStr(v),
                s => ParseItemTipo(s));

        public static readonly ValueConverter<Weekday[], string> WeekdayArrayToSet =
            new(v => WeekdayArrayToSetStr(v),
                s => SetStrToWeekdayArray(s));

        public static readonly ValueComparer<Weekday[]> WeekdayArrayComparer =
                 new((a, b) =>
                     (a ?? Array.Empty<Weekday>()).SequenceEqual(b ?? Array.Empty<Weekday>()),
                     v => (v ?? Array.Empty<Weekday>()).Aggregate(17, (h, d) => unchecked(h * 23 + d.GetHashCode())),
                     v => (v ?? Array.Empty<Weekday>()).ToArray());
    }
}

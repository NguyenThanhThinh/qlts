using System;

namespace qlts.Datas
{
    public class DropdownModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public static string ValueField => nameof(Id);
        public static string DisplayField => nameof(Text);
    }
}
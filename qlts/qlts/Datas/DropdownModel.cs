namespace qlts.Datas
{
    public class DropdownModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public static string ValueField => nameof(Id);
        public static string DisplayField => nameof(Text);
    }
}
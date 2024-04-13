namespace TagScanner.Commands
{
    using Models;

    public class Command
    {
        public Command(Work work, Tag tag, object value)
        {
            Work = work;
            Tag = tag;
            Value = value;
        }

        private Work Work { get; set; }
        private Tag Tag { get; set; }
        private object Value { get; set; }

        public string UndoAction { get; }
        public string RedoAction { get; }

        public void Invert() { }

        public bool Do()
        {
                var result = Run();
                if (result)
                    PropertyChanged();
                Invert();
                return result;
        }

        public bool Run()
        {
            var value = Work.GetPropertyValue(Tag);
            var result = !Equals(value, Value);
            if (result)
            {
                Work.SetPropertyValue(Tag, value);
                Value = value;
            }
            return result;
        }

        private void PropertyChanged() { }
    }
}

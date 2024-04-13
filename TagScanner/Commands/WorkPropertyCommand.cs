namespace TagScanner.Commands
{
    using Models;
    using Terms;

    public class WorkPropertyCommand : Command
    {
        public WorkPropertyCommand(int index, Tag tag, object value) : base()
        {
            Index = index;
            Tag = tag;
            Value = value;
        }

        public int Index { get; set; }
        public Tag Tag { get; set; }
        public object Value { get; set; }

        public override bool Do(Model model)
        {
            var result = base.Do(model);
            if (result)
                PropertyChanged(model, Tag);
            return result;
        }

        public override bool Run(Model model)
        {
            var work = model.Works[Index];
            var value = work.GetPropertyValue(Tag);
            var result = !Equals(value, Value);
            if (result)
            {
                work.SetPropertyValue(Tag, value);
                Value = value;
            }
            return result;
        }

        protected override void PropertyChanged(Model model, Tag tag)
        {
            // model.???
        }

        public override string RedoAction => Action;
        public override string UndoAction => Action;

        private string Action => $"{Tag.DisplayName()} change";
    }
}

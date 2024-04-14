namespace TagScanner.Commands
{
    using Models;
    using Terms;

    public class WorkPropertyCommand : Command
    {
        public WorkPropertyCommand(Work work, Tag tag, object value) : base()
        {
            Work = work;
            Tag = tag;
            Value = value;
        }

        public Work Work { get; set; }
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
            var value = Work.GetPropertyValue(Tag);
            var result = !Equals(value, Value);
            if (result)
            {
                Work.SetPropertyValue(Tag, Value);
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

        public override string ToString() => $"{Tag.DisplayName()} = {Value}";
    }
}

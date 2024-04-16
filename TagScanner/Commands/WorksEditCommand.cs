namespace TagScanner.Commands
{
    using System.Collections.Generic;
    using Models;
    using Terms;

    public class WorksEditCommand : Command
    {
        public WorksEditCommand(Tag tag, List<Work> works, List<object> values) : base()
        {
            Tag = tag;
            Works = works;
            Values = values;
        }

        public Tag Tag { get; set; }
        public List<Work> Works { get; set; }
        public List<object> Values { get; set; }

        public override bool Do(Model model)
        {
            var result = base.Do(model);
            if (result)
                PropertyChanged();
            return result;
        }

        public override bool Run(Model model)
        {
            var result = false;
            for (var index = 0; index < Works.Count; index++)
            {
                var work = Works[index];
                var oldValue = work.GetPropertyValue(Tag);
                var newValue = Values[index];
                result |= !Equals(oldValue, newValue);
                if (result)
                {
                    work.SetPropertyValue(Tag, newValue);
                    Values[index] = oldValue;
                }
            }
            return result;
        }

        protected void PropertyChanged()
        {
            // model.???
        }

        public override string RedoAction => Action;
        public override string UndoAction => Action;

        private string Action => $"{Tag.DisplayName()} change";

        public override string ToString() => Action;
    }
}

namespace TagScanner.Commands
{
    using Models;
    using System.Collections.Generic;
    using System.Windows.Media;
    using Terms;
    using Utils;

    public class WorksEditedCommand : Command
    {
        public WorksEditedCommand(Tag tag, List<Work> works, List<object> values) : base()
        {
            Tag = tag;
            Works = works;
            Values = values;
        }

        public Tag Tag { get; set; }
        public List<Work> Works { get; set; }
        public List<object> Values { get; set; }

        public override bool Do()
        {
            var result = base.Do();
            if (result)
                PropertyChanged();
            return result;
        }

        public override bool Run()
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

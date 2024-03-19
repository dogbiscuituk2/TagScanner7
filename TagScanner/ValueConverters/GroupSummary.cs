namespace TagScanner.ValueConverters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;
    using Models;
    using Utils;

    public class GroupSummary : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ReadOnlyObservableCollection<object> group))
                return string.Empty;
            var works = new List<Work>();
            AddWorks(works, group);
            var summary = new Selection(works);
            var workCount = works.Count;
            return $" ({workCount:n0} {(workCount == 1 ? "work" : "works")}, {summary.FileSize.AsString(false)}, {summary.Duration.AsString(false)})";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;

        private void AddWorks(List<Work> works, ReadOnlyObservableCollection<object> group)
        {
            if (group.Any())
                if (group[0] is Work)
                    works.AddRange(group.Cast<Work>());
                else
                    foreach (var item in group.Cast<CollectionViewGroup>())
                        AddWorks(works, item.Items);
        }
    }
}

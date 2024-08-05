namespace TagScanner.ValueConverters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;
    using Core;
    using Models;

    public class GroupSummary : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ReadOnlyObservableCollection<object> group))
                return string.Empty;
            var tracks = new List<Track>();
            AddTracks(tracks, group);
            var summary = new Selection(tracks);
            var trackCount = tracks.Count;
            return $" ({trackCount:n0} {(trackCount == 1 ? "track" : "tracks")}, {summary.FileSize.AsString(false)}, {summary.Duration.AsString(false)})";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;

        private static void AddTracks(List<Track> tracks, IReadOnlyList<object> group)
        {
            if (!group.Any()) return;
            if (group[0] is Track)
                tracks.AddRange(group.Cast<Track>());
            else
                foreach (var item in group.Cast<CollectionViewGroup>())
                    AddTracks(tracks, item.Items);
        }
    }
}

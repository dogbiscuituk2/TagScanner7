namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Terms;

    public class FileOptions
    {
        #region Constructor

        public FileOptions()
        {
            CreatedMin = ModifiedMin = AccessedMin =
                CreatedMax = ModifiedMax = AccessedMax =
                DateTime.Today;
        }

        #endregion

        #region Public Properties

        public FileFlags Flags { get; set; }

        public DateTime CreatedMax { get; set; }
        public DateTime CreatedMin { get; set; }

        public DateTime ModifiedMax { get; set; }
        public DateTime ModifiedMin { get; set; }

        public DateTime AccessedMax { get; set; }
        public DateTime AccessedMin { get; set; }

        public decimal FileSizeMax { get; set; }
        public decimal FileSizeMin { get; set; }
        public int FileSizeUnit { get; set; }

        #endregion

        #region Public Methods

        public Conjunction GetFilter(bool useTimes, out string filterString)
        {
            var conjunction = new Conjunction();
            var conditions = conjunction.Operands;
            var filterText = new StringBuilder();
            AddDates(FileFlags.Created, Tag.FileCreated, Tag.FileCreatedUtc, CreatedMin, CreatedMax);
            AddDates(FileFlags.Modified, Tag.FileModified, Tag.FileModifiedUtc, ModifiedMin, ModifiedMax);
            AddDates(FileFlags.Accessed, Tag.FileAccessed, Tag.FileAccessedUtc, AccessedMin, AccessedMax);
            useTimes = true;
            AddFileSize();
            AddAttribute(FileFlags.ReadOnly, FileAttributes.ReadOnly);
            AddAttribute(FileFlags.Hidden, FileAttributes.Hidden);
            AddAttribute(FileFlags.System, FileAttributes.System);
            AddAttribute(FileFlags.Archive, FileAttributes.Archive);
            AddAttribute(FileFlags.Compressed, FileAttributes.Compressed);
            AddAttribute(FileFlags.Encrypted, FileAttributes.Encrypted);
            filterString = filterText.ToString();
            return conjunction;

            void AddAttribute(FileFlags flags, FileAttributes attribute)
            {
                flags &= Flags;
                if (flags != 0)
                {
                    Term function = new Function(Tag.FileAttributes, Fn.Contains, $"{attribute}", false);
                    var text = $"{Tag.FileAttributes.DisplayName()} contains \"{attribute}\"";
                    if ((flags & FileFlags.False) != 0)
                    {
                        function = !function;
                        text = $"!({text})";
                    }
                    AddCondition(function, text);
                }
            }

            void AddCondition(Term term, string text = null)
            {
                conditions.Add(term);
                filterText.AppendLine(text ?? term.ToString());
            }

            void AddDates(FileFlags flags, Tag tag, Tag tagUtc, DateTime min, DateTime max) =>
                AddRelation(flags, (flags & Flags & FileFlags.Utc) == 0 ? tag : tagUtc, min, max);

            void AddFileSize() => AddRelation(FileFlags.FileSize, Tag.FileSize, FileSizeMin * FileSizeMultiplier, FileSizeMax * FileSizeMultiplier);

            void AddOperation(Op op, params Term[] args) => AddCondition(new Operation(op, args));

            void AddRelation(FileFlags flags, Tag tag, Term min, Term max)
            {
                flags &= Flags;
                bool
                    useMin = (flags & FileFlags.Min) != 0,
                    useMax = (flags & FileFlags.Max) != 0;
                if (!useMin && !useMax)
                    return;
                if (useTimes)
                {
                    var operands = new List<Term>();
                    if (useMin) operands.Add(min);
                    operands.Add(tag);
                    if (useMax) operands.Add(max);
                    AddOperation(Op.NotGreaterThan, operands.ToArray());
                }
                else
                {
                    min = StripTime(min, 0);
                    max = StripTime(max, 1);
                    var length = filterText.Length;
                    if (useMin)
                        AddOperation(Op.NotGreaterThan, min, tag);
                    if (useMax)
                        AddOperation(Op.LessThan, tag, max);
                    if (useMin && useMax)
                    {
                        filterText.Remove(length, filterText.Length - length);
                        filterText.AppendLine($"{min} ≤ {tag.DisplayName()} < {max}");
                    }
                }

                Term StripTime(Term term, int bump) => ((Constant<DateTime>)term).Value.Date.AddDays(bump);
            }
        }

        #endregion

        #region Private Properties

        private ulong FileSizeMultiplier => 1UL << (10 * FileSizeUnit);

        #endregion
    }
}

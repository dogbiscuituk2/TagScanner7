namespace TagScanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Terms;
    using Terms.Parsing;

    public class FileChecks
    {
        #region Constructor

        public FileChecks()
        {
            CreatedMin = ModifiedMin = AccessedMin =
                CreatedMax = ModifiedMax = AccessedMax =
                DateTime.Today;
        }

        #endregion

        #region Public Fields

        public FileFlags Flags;

        public DateTime
            CreatedMin, CreatedMax,
            ModifiedMin, ModifiedMax,
            AccessedMin, AccessedMax;

        public decimal
            FileSizeMin, FileSizeMax;

        public int FileSizeUnit;

        #endregion

        #region Public Methods

        public Term GetFilter(bool useTimes, out string filterString)
        {
            var conjunction = new Conjunction();
            var conditions = conjunction.Operands;
            var filterText = new StringBuilder();
            AddDates(FileFlags.Created, Tag.FileCreated, Tag.FileCreatedUtc, CreatedMin, CreatedMax);
            AddDates(FileFlags.Modified, Tag.FileModified, Tag.FileModifiedUtc, ModifiedMin, ModifiedMax);
            AddDates(FileFlags.Accessed, Tag.FileAccessed, Tag.FileAccessedUtc, AccessedMin, AccessedMax);
            useTimes = true;
            AddFileSize();
            var attrs = AddAttributes().Where(p => p != null);
            if (attrs.Any())
                filterText.AppendLine(attrs.Aggregate((p, q) => $"{p}, {q}"));
            filterString = filterText.ToString();
            return conjunction.Fix();

            IEnumerable<string> AddAttributes()
            {
                yield return AddAttribute(FileFlags.ReadOnly, Tag.FileAttrReadOnly);
                yield return AddAttribute(FileFlags.Hidden, Tag.FileAttrHidden);
                yield return AddAttribute(FileFlags.System, Tag.FileAttrSystem);
                yield return AddAttribute(FileFlags.Archive, Tag.FileAttrArchive);
                yield return AddAttribute(FileFlags.Compressed, Tag.FileAttrCompressed);
                yield return AddAttribute(FileFlags.Encrypted, Tag.FileAttrEncrypted);
                yield break;

                string AddAttribute(FileFlags flags, Tag tag)
                {
                    flags &= Flags;
                    if (flags == 0)
                        return null;
                    Term term = tag;
                    if ((flags & FileFlags.False) != 0)
                        term = !term;
                    return AddCondition(term);
                }
            }

            string AddCondition(Term term)
            {
                conditions.Add(term);
                return term.ToString();
            }

            void AddDates(FileFlags flags, Tag tag, Tag tagUtc, DateTime min, DateTime max) =>
                AddRelation(flags, (flags & Flags & FileFlags.Utc) == 0 ? tag : tagUtc, min, max);

            void AddFileSize() => AddRelation(FileFlags.FileSize, Tag.FileSize, GetFileSize(FileSizeMin), GetFileSize(FileSizeMax));

            string AddOperation(Op op, params Term[] args) => AddCondition(new Operation(op, args));

            void AddRelation(FileFlags flags, Tag tag, Term min, Term max)
            {
                flags &= Flags;
                bool
                    useMin = (flags & FileFlags.Min) != 0,
                    useMax = (flags & FileFlags.Max) != 0;
                if (!useMin && !useMax)
                    return;
                var text = string.Empty;
                if (useTimes)
                {
                    var operands = new List<Term>();
                    if (useMin) operands.Add(min);
                    operands.Add(tag);
                    if (useMax) operands.Add(max);
                    text = AddOperation(Op.NotGreaterThan, operands.ToArray());
                }
                else
                {
                    min = StripTime(min, 0);
                    max = StripTime(max, 1);
                    var length = filterText.Length;
                    if (useMin)
                        text = AddOperation(Op.NotGreaterThan, min, tag);
                    if (useMax)
                    {
                        text = AddOperation(Op.LessThan, tag, max);
                        if (useMin)
                            text = $"{min} ≤ {tag.DisplayName()} < {max}";
                    }
                }
                filterText.AppendLine(text);

                Term StripTime(Term term, int bump) => ((Constant<DateTime>)term).Value.Date.AddDays(bump);
            }

            Term GetFileSize(decimal fileSize)
            {
                fileSize = Math.Round(fileSize * FileSizeMultiplier);
                return
                    fileSize <= int.MaxValue ? (int)fileSize :
                    fileSize <= long.MaxValue ? (long)fileSize :
                    fileSize <= ulong.MaxValue ? (ulong)fileSize :
                    (Term)ulong.MaxValue;
            }
        }

        #endregion

        #region Private Properties

        private ulong FileSizeMultiplier => 1UL << (10 * FileSizeUnit);

        #endregion
    }
}

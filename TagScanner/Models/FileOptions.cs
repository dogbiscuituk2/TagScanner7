﻿namespace TagScanner.Models
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
            AddAttribute(FileFlags.ReadOnly, Tag.FileAttrReadOnly);
            AddAttribute(FileFlags.Hidden, Tag.FileAttrHidden);
            AddAttribute(FileFlags.System, Tag.FileAttrSystem);
            AddAttribute(FileFlags.Archive, Tag.FileAttrArchive);
            AddAttribute(FileFlags.Compressed, Tag.FileAttrCompressed);
            AddAttribute(FileFlags.Encrypted, Tag.FileAttrEncrypted);
            filterString = filterText.ToString();
            return conjunction;

            void AddAttribute(FileFlags flags, Tag tag)
            {
                flags &= Flags;
                if (flags != 0)
                {
                    Term term = tag;
                    if ((flags & FileFlags.False) != 0)
                        term = !term;
                    AddCondition(term);
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

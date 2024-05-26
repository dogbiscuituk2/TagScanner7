namespace TagScanner.Controls
{
    using System.Windows.Forms;

    public interface IAutoComplete
    {
        AutoCompleteStringCollection AutoCompleteCustomSource { get; set; }
        AutoCompleteMode AutoCompleteMode { get; set; }
        AutoCompleteSource AutoCompleteSource { get; set; }
    }

    public class AutoCompleteComboBox : ComboBox, IAutoComplete { }
    public class AutoCompleteTextBox : TextBox, IAutoComplete { }
    public class AutoCompleteToolStripComboBox : ToolStripComboBox, IAutoComplete { }
    public class AutoCompleteToolStripTextBox : ToolStripTextBox, IAutoComplete { }
}

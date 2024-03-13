namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    internal class OperatorPickerController
    {
        internal OperatorPickerController(ComboBox comboBox)
        {
            ComboBox = comboBox;
            Init();
        }

        private readonly ComboBox ComboBox;

        private void Init()
        {
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.Items.Clear();
            //ComboBox.Items.AddRange(Core.Operators.Select(p => p.Key.ToString()).ToArray());
            //ComboBox.Items.AddRange(Core.Methods.Select(p => $"{p.Value.ReturnType.Name} {p.Key}").ToArray());
        }
    }
}

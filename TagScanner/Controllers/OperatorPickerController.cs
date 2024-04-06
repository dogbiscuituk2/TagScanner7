namespace TagScanner.Controllers
{
    using System.Windows.Forms;

    public class OperatorPickerController
    {
        public OperatorPickerController(ComboBox comboBox)
        {
            ComboBox = comboBox;
            Init();
        }

        private readonly ComboBox ComboBox;

        private void Init()
        {
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.Items.Clear();
        }
    }
}

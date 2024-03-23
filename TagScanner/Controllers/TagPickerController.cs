namespace TagScanner.Controllers
{
    using System.Linq;
    using System.Windows.Forms;
    using Terms;

    public class TagPickerController
    {
        public TagPickerController(ComboBox comboBox)
        {
            _comboBox = comboBox;
            Init();
        }

        private readonly ComboBox _comboBox;

        private void Init()
        {
            _comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboBox.Items.Clear();
            _comboBox.Items.AddRange(Tags.Values.OrderBy(p => p.DisplayName).ToArray());
        }
    }
}

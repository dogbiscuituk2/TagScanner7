namespace TagScanner.Controllers
{
    using System.Linq;
    using System.Windows.Forms;
    using TagScanner.Models;

    public class TagPickerController
    {
        public TagPickerController(ComboBox comboBox)
        {
            ComboBox = comboBox;
            Init();
        }

        private readonly ComboBox ComboBox;

        private void Init()
        {
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.Items.Clear();
            ComboBox.Items.AddRange(Tags.AllTags.OrderBy(p => p.DisplayName).ToArray());
        }
    }
}

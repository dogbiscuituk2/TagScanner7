namespace TagScanner.Controllers.Mru
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Utils;
    using Win32 = Microsoft.Win32;

    public class MruController : Controller
    {
        #region Constructor

        protected MruController(Controller parent, string subKeyName) : base(parent)
        {
            if (string.IsNullOrWhiteSpace(subKeyName))
                throw new ArgumentNullException(nameof(subKeyName));
            _subKeyName = $@"Software\{Application.CompanyName}\{Application.ProductName}\{subKeyName}";
        }

        #endregion

        #region Protected Fields & Properties

        protected readonly string _subKeyName;

        protected static Win32.RegistryKey User => Win32.Registry.CurrentUser;

        #endregion

        #region Methods

        protected void ClearItems()
        {
            try
            {
                var key = OpenSubKey(true);
                if (key == null)
                    return;
                foreach (var name in key.GetValueNames())
                    key.DeleteValue(name, true);
                key.Close();
            }
            catch (Exception exception) { LogException(exception); }
        }

        protected Win32.RegistryKey CreateSubKey() =>
            User.CreateSubKey(_subKeyName, Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);

        protected static void DeleteItem(Win32.RegistryKey key, string item)
        {
            var name = key.GetValueNames().FirstOrDefault(n => key.GetValue(n, null) as string == item);
            if (name != null)
                key.DeleteValue(name);
        }

        protected virtual object GetValue(string name)
        {
            object value = null;
            if (TryReadKey(out Win32.RegistryKey key))
            {
                value = key.GetValue(name);
                key.Close();
            }
            return value;
        }

        protected void LogException(Exception exception) => Console.WriteLine(exception.GetAllInformation());

        protected Win32.RegistryKey OpenSubKey(bool writable) => User.OpenSubKey(_subKeyName, writable);

        protected virtual void RemoveItem(string item)
        {
            try
            {
                var key = OpenSubKey(true);
                if (key == null)
                    return;
                try { DeleteItem(key, item); }
                finally { key.Close(); }
            }
            catch (Exception exception) { LogException(exception); }
        }

        protected virtual void SetValue(string value) => SetValue($"{DateTime.Now:yyyyMMddHHmmssFF}", value);

        protected virtual void SetValue(string name, string value)
        {
            try
            {
                var key = CreateSubKey();
                if (key == null)
                    return;
                try
                {
                    DeleteItem(key, value);
                    key.SetValue(name, value);
                }
                finally { key.Close(); }
            }
            catch (Exception exception) { LogException(exception); }
        }

        protected bool TryReadKey(out Win32.RegistryKey key)
        {
            key = null;
            try
            {
                key = OpenSubKey(false);
                return key != null;
            }
            catch (Exception exception)
            {
                LogException(exception);
                return false;
            }
        }

        #endregion
    }
}

namespace TagScanner.Controllers.Mru
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Utils;
    using Win32 = Microsoft.Win32;

    public class MruController
    {
        #region Constructor

        public MruController(string subKeyName)
        {
            if (string.IsNullOrWhiteSpace(subKeyName))
                throw new ArgumentNullException(nameof(subKeyName));
            _subKeyName = $@"Software\{Application.CompanyName}\{Application.ProductName}\{subKeyName}";
        }

        #endregion

        #region Fields & Properties

        protected readonly string _subKeyName;

        protected Win32.RegistryKey User => Win32.Registry.CurrentUser;

        #endregion

        #region Methods

        protected virtual void AddItem(string value) => AddItem($"{DateTime.Now:yyyyMMddHHmmssFF}", value);

        protected virtual void AddItem(string name, string value)
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

        protected Win32.RegistryKey CreateSubKey() => User.CreateSubKey(_subKeyName, Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);

        protected static void DeleteItem(Win32.RegistryKey key, string item)
        {
            var name = key.GetValueNames().FirstOrDefault(n => key.GetValue(n, null) as string == item);
            if (name != null)
                key.DeleteValue(name);
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

        protected bool TryReadKey(out Win32.RegistryKey key)
        {
            key = null;
            try
            {
                key = OpenSubKey(false);
                return true;
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

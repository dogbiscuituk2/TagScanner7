﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TagScanner.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Playlists|*.wpl|All Files (*.*)|*.*")]
        public string PlayerFilter {
            get {
                return ((string)(this["PlayerFilter"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Text Files|*.txt|All Files (*.*)|*.*")]
        public string SearchFilter {
            get {
                return ((string)(this["SearchFilter"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ID3 Library Files|*.Binary|Json files|*.Json|XML Files|*.XML|All Files (*.*)|*.*")]
        public string LibraryFilter {
            get {
                return ((string)(this["LibraryFilter"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"ʞɯɾ Files (*.ʞɯɾ)|*.ʞɯɾ|C# Files (*.cs)|*.cs|Visual Basic Files (*.vb)|*.vb|HTML Files (*.htm;*.html)|*.htm;*.html|XML Files (*.xml)|*.xml|SQL Files (*.sql)|*.sql|PHP Files (*.php)|*.php|JavaScript Files (*.js)|*.js|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*")]
        public string ScriptFilter {
            get {
                return ((string)(this["ScriptFilter"]));
            }
        }
    }
}

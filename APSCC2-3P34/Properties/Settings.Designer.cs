﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ordenador.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection ListaBancosDeDados {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ListaBancosDeDados"]));
            }
            set {
                this["ListaBancosDeDados"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection ListaConnectionStringsBancosDeDados {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ListaConnectionStringsBancosDeDados"]));
            }
            set {
                this["ListaConnectionStringsBancosDeDados"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LocalProjeto {
            get {
                return ((string)(this["LocalProjeto"]));
            }
            set {
                this["LocalProjeto"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DiretorioProjeto {
            get {
                return ((string)(this["DiretorioProjeto"]));
            }
            set {
                this["DiretorioProjeto"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DiretorioBancoDeDados {
            get {
                return ((string)(this["DiretorioBancoDeDados"]));
            }
            set {
                this["DiretorioBancoDeDados"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>BDOriginal.sqlite3</string>
  <string>BDBubleSort.sqlite3</string>
  <string>BDInsertionSort.sqlite3</string>
  <string>BDHeapSort.sqlite3</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection ListaNomesBancosDeDados {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ListaNomesBancosDeDados"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("data source=C:\\Users\\hegemn0\\Documents\\DBImagens")]
        public string DBImagensConnectionString {
            get {
                return ((string)(this["DBImagensConnectionString"]));
            }
        }
    }
}

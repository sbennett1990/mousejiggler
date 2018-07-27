#region header

// MouseJiggle - AboutBox.cs
//
// Alistair J. R. Young
// Arkane Systems
//
// Copyright Arkane Systems 2012-2013.
//
// Created: 2013-08-24 12:41 PM

#endregion

using System;
using System.Reflection;
using System.Windows.Forms;

namespace ArkaneSystems.MouseJiggle {
    partial class AboutBox : Form {
        public AboutBox() {
            this.InitializeComponent();

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs
            this.Text = $"About {this.AssemblyTitle}";
            this.labelProductName.Text = this.AssemblyProduct;
            this.labelVersion.Text = $"Version {this.AssemblyVersion}";
            this.labelCopyright.Text = this.AssemblyCopyright;
            this.labelCompanyName.Text = this.AssemblyCompany;
            this.textBoxDescription.Text = this.AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle {
            get {
                // Get all Title attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), inherit: false);
                // If there is at least one Title attribute
                if (attributes.Length > 0) {
                    // Select the first one
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion {
            get {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription {
            get {
                // Get all Description attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), inherit: false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute) attributes[0]).Description;
            }
        }

        public string AssemblyProduct {
            get {
                // Get all Product attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        public string AssemblyCopyright {
            get {
                // Get all Copyright attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), inherit: false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany {
            get {
                // Get all Company attributes on this assembly
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute) attributes[0]).Company;
            }
        }

        #endregion

        private void okButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}

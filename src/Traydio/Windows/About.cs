using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Traydio.Windows
{
    partial class About : Form
    {
        public Utilities _utilities { get; set; }

        public About()
        {
            _utilities = new Utilities();

            InitializeComponent();

            var version = AssemblyVersion.Substring(0, AssemblyVersion.LastIndexOf("."));

            this.Text = String.Format("About {0}", AssemblyTitle);
            this.ProductNameLabel.Text = AssemblyProduct;
            this.VersionLabel.Text = String.Format("Version {0}", version);
            this.CopyrightLabel.Text = AssemblyCopyright;
            this.CompanyNameLabel.Text = AssemblyCompany;
            this.DescriptionTextBox.Text = AssemblyDescription;

            if(AssemblyCompany.StartsWith("http"))
            {
                this.CompanyNameLabel.Cursor = Cursors.Hand;
                this.CompanyNameLabel.Font = new Font(CompanyNameLabel.Font.Name, CompanyNameLabel.Font.SizeInPoints, FontStyle.Underline);
                this.CompanyNameLabel.ForeColor = Color.Blue;
            }
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CompanyNameLabel_Click(object sender, EventArgs e)
        {
            if (AssemblyCompany.StartsWith("http"))
            {
                _utilities.OpenWebsite(AssemblyCompany);
            }
        }
    }
}

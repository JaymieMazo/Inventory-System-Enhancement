﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Word = Microsoft.Office.Interop.Word;
namespace BOI_Inventory_System
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        void ImportWord()
        {
            //Microsoft.Office.Interop.Word.ApplicationClass wordObject = new Microsoft.Office.Interop.Word.ApplicationClass();
            //object File = "c:\\Test.docx"; //this is the path
            //object nullobject = System.Reflection.Missing.Value; Microsoft.Office.Interop.Word.Application wordobject = new Microsoft.Office.Interop.Word.Application();
            //wordobject.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone; Microsoft.Office.Interop.Word._Document docs = wordObject.Documents.Open(ref File, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject); docs.ActiveWindow.Selection.WholeStory();
            //docs.ActiveWindow.Selection.Copy();
            //this.richTextBox1.Paste();
            //docs.Close(ref nullobject, ref nullobject, ref nullobject);
            //wordobject.Quit(ref nullobject, ref nullobject, ref nullobject);
        }
    }
}

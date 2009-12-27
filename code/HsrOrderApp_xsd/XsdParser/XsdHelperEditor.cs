using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;

namespace XParser
{
	/// <summary>
	/// Summary description for XsdHelperEditor.
	/// </summary>
	public class XHelperEditor : UITypeEditor
	{
		public XHelperEditor() : base() { }

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object obj)
		{
			if ( provider != null )
			{
				OpenFileDialog fileDialog = new OpenFileDialog();
				if(fileDialog.ShowDialog() == DialogResult.OK)
				{
					if(!(obj is XHelper)) 
					{
						obj = new XHelper();
					}
					((XHelper)obj).FileName = fileDialog.FileName;
				}
			}
			return obj;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
	}
}

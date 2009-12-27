using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;

namespace Storm.Loader
{
	/// <summary>
	/// Summary description for AssemblyGenEditor.
	/// </summary>
	public class AssemblyLoaderEditor : UITypeEditor
	{
		public AssemblyLoaderEditor() : base() {}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object obj)
		{
			if ( provider != null )
			{
				OpenFileDialog fileDialog = new OpenFileDialog();
				fileDialog.Filter = "C# source files (*.cs)|*.cs|All files (*.*)|*.*" ;
				fileDialog.FilterIndex = 2 ;
				fileDialog.RestoreDirectory = true ;
				if(fileDialog.ShowDialog() == DialogResult.OK)
				{
					if(!(obj is AssemblyLoader)) 
					{
						obj = new AssemblyLoader();
					}
					((AssemblyLoader)obj).SourceAssembly = fileDialog.FileName;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace transformer_generator.src.Utils.FileExplorer
{
    internal class Files
    {
        static public string GetFilePath(string param_title, string param_filter)
        {
            var dialogo = new OpenFileDialog();
            dialogo.Title = param_title;
            dialogo.Filter = param_filter;
            dialogo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialogo.Multiselect = false;

            if (dialogo.ShowDialog() != DialogResult.OK)
            {
                return string.Empty;
            }

            return dialogo.FileName;
        }
    }
}

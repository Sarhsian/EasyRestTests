using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace Tests
{
    public class DataBaseHelper
    {

        public void ResetDB()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd";
            psi.Arguments = @"/c cd /d E:\1\easyrest & %VENV%\Scripts\activate & initialize_easyrest_db --reset --fill development.ini";
            Process.Start(psi);
        }
    }   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankBattle
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        // ************************************************************ //
        //                                                              //
        //                     暂时告一段落                             //
        //                      2018/01/23                              //
        //                                                              //
        // ************************************************************ //
    }
}

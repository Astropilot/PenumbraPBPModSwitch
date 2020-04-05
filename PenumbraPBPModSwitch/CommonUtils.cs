using Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenumbraPBPModSwitch
{
    public class CommonUtils
    {
        public static string StringToAoB(string str, bool zeroTerminated = false)
        {
            return Mem.ByteArrayToString(System.Text.UTF8Encoding.ASCII.GetBytes(str + (zeroTerminated ? "\0" : ""))).ToUpper().Trim();
        }

        public static  IEnumerable<string> FilterFiles(string path, params string[] exts)
        {
            return
                exts.Select(x => "*." + x)
                .SelectMany(x =>
                    Directory.EnumerateFiles(path, x)
                    );
        }
    }
}

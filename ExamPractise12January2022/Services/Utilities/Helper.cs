using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPractise12January2022.Services.Utilities
{
    public class Helper
    {
        public static void RemoveFile(string root, string image, params string[] folders)
        {
            string path = Path.Combine(root, folders[0], folders[1], image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}

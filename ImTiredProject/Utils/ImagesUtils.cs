using AppiumTestProject.Utils;
using ImTiredProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImTiredProject.Utils
{
    public static class ImagesUtils
    {
        public static string GetImageWay(string variableName)
        {
            return Directory.GetCurrentDirectory() + ConfigUtils.GetAndroidConfig(variableName);
        }
    }
}

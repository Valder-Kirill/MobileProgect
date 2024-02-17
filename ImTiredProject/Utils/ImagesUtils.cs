using AppiumTestProject.Utils;
using Aquality.WinAppDriver.Applications;
using OpenQA.Selenium.Appium;
using System.Drawing;

namespace ImTiredProject.Utils
{
    public static class ImagesUtils
    {
        public static string GetImageWay(string variableName)
        {
            return Directory.GetCurrentDirectory() + ConfigUtils.GetAndroidConfig(variableName);
        }

        public static Image CaptureElementScreenShot(AppiumWebElement element, string filename)
        {
            var windowWidth = AqualityServices.Application.Driver.Manage().Window.Size.Width;
            var windowHeight = AqualityServices.Application.Driver.Manage().Window.Size.Height;
            var printscreen = new Bitmap(windowWidth, windowHeight);
            var graphics = Graphics.FromImage(printscreen);
            graphics.CopyFromScreen(0, 0, 0, 0, new Size(windowWidth, windowHeight));

            printscreen.Save(filename);

            var img = Image.FromFile(filename);
            var rect = new Rectangle();

            if (element != null)
            {
                var width = element.Size.Width;
                var height = element.Size.Height;
                var point = element.Location;
                rect = new Rectangle(point.X, point.Y, width, height);
            }

            var bmpImage = new Bitmap(img);
            var cropedImag = bmpImage.Clone(rect, bmpImage.PixelFormat);

            printscreen.Dispose();

            return cropedImag;
        }
    }
}

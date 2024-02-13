using AppiumTestProject.Utils;
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

        /// <summary>
        /// Captures the element screen shot.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>returns the screenshot  image </returns>
        public static Image CaptureElementScreenShot(AppiumWebElement element, string filename)
        {
            var printscreen = new Bitmap(1920, 1080);
            var graphics = Graphics.FromImage(printscreen);
            graphics.CopyFromScreen(0, 0, 0, 0, new Size(1920, 1080));

            printscreen.Save(filename);

            var img = Image.FromFile(filename);
            var rect = new Rectangle();

            if (element != null)
            {
                int width = element.Size.Width;
                int height = element.Size.Height;
                var p = element.Location;
                rect = new Rectangle(p.X, p.Y, width, height);
            }

            var bmpImage = new Bitmap(img);
            var cropedImag = bmpImage.Clone(rect, bmpImage.PixelFormat);

            return cropedImag;
        }
    }
}

using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Ascii_Art
{
    class Program
    {
        static void Main(string[] args)
        {
            var ascii  = new string[] { "@", "@", "#", "%", "=", "+", "*", "-", ":", ".", " " };
            

            for (int i = 0; i < 6800; i++)
            {
                var path = $"images/frame{i}.png";
                Bitmap image = new Bitmap(path);
                image = ResizeBitmap(image, 480/2, 360/4);

                var sb = new StringBuilder();
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        var pixel = image.GetPixel(x, y);
                        int r = (pixel.R + pixel.G + pixel.B) / 3;

                        Color greyColour = Color.FromArgb(r, 0, 0);
                        sb.Append(ascii[greyColour.R * 10 / 255]);
                    }
                    sb.Append("\r\n");
                }
                var asciiImage = ConvertTextToImage(sb.ToString(), "Consolas", 6, Color.FromArgb(255, 255, 255), Color.FromArgb(0, 0, 0), (int)((image.Height * 10)*1.3f), image.Height*10);
                asciiImage.Save($"ascii/frame{i}.png");
            }

            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        public static Bitmap ConvertTextToImage(string txt, string fontname, int fontsize, Color bgcolor, Color fcolor, int width, int Height)
        {
            Bitmap bmp = new Bitmap(width, Height);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                Font font = new Font(fontname, fontsize);
                graphics.FillRectangle(new SolidBrush(bgcolor), 0, 0, bmp.Width, bmp.Height);
                graphics.DrawString(txt, font, new SolidBrush(fcolor), 0, 0);
                graphics.Flush();
                font.Dispose();
                graphics.Dispose();
            }
            return bmp;
        }
    }
}

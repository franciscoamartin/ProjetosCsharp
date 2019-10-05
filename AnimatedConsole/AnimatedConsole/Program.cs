using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thank you Сергей Кровлин
            //His Youtube link is under my video. 
            Image image = Image.FromFile(@"C:\Users\franc\OneDrive\Área de Trabalho\1KILE.gif");
            FrameDimension dimension = new FrameDimension(image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);    
            StringBuilder sb;

            int left = Console.WindowLeft, top = Console.WindowTop;

            char[] chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };

            for (int i = 0; ; i = (i + 1) % frameCount)
            {
                sb = new StringBuilder();
                image.SelectActiveFrame(dimension, i);

                for (int h = 0; h < image.Height; h++)
                {
                    for (int w = 0; w < image.Width; w++)
                    {
                        Color cl = ((Bitmap)image).GetPixel(w, h);
                        int gray = (cl.R + cl.R + cl.B) / 3;
                        int index = (gray * (chars.Length - 1)) / 255;

                        sb.Append(chars[index]);
                    }
                    sb.Append('\n');
                }

                Console.SetCursorPosition(left, top);
                Console.Write(sb.ToString());

                System.Threading.Thread.Sleep(600);
            }
        }

        static Image ScaleImage(Image source, int width, int height)
        {
            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.White, 0, 0, width, height);
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;

                if (srcwidth <= dstwidth && srcheight <= dstheight)
                {
                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                else if (srcwidth / srcheight > dstwidth * dstheight)
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                else
                {
                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, 0, left, cx, dstheight);
                }
                return dest;
            }
        }
    }
}

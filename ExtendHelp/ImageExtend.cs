using ExtendHelp.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ExtendHelp
{
    public static class ImageExtend
    {
        /// <summary>
        /// 图片二值化
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="num">阈值</param>
        /// <returns>第一高，第二宽</returns>
        public static byte[,] ToBinaryArray(this Bitmap bitmap, int num = 50)
        {
            byte[,] bs = new byte[bitmap.Height, bitmap.Width];
            Color c = Color.Empty;
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    c = bitmap.GetPixel(x, y);
                    if ((c.R + c.G + c.B) > num)
                        bs[y, x] = 0;
                    else
                        bs[y, x] = 255;
                }
            }
            return bs;
        }//
        /// <summary>
        /// 获取内存锁定对象
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static LockBitmap LockBitmap(this Bitmap bitmap)
        {
            LockBitmap lockBitmap = new LockBitmap(bitmap);
            lockBitmap.LockBits();
            return lockBitmap;
        }
        /// <summary>
        /// 图片数组化
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Color[,] ToColorArray(this Bitmap bitmap)
        {
            Color[,] cs = new Color[bitmap.Height, bitmap.Width];
            Color c = Color.Empty;
            var bd = bitmap.LockBitmap();
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    cs[y, x] = bd.GetPixel(x, y);
                }
            }
            bd.UnlockBits();
            return cs;
        }
        public static Bitmap ColorArrayToBitmap(this Color[,] colorData)
        {
            Bitmap bi = new Bitmap(colorData.GetLength(1), colorData.GetLength(0));
            for (int y = 0; y < colorData.GetLength(0); y++)
            {
                for (int x = 0; x < colorData.GetLength(1); x++)
                {
                    bi.SetPixel(x, y, colorData[y, x]);
                }
            }
            return bi;
        }
        public static Bitmap BinaryArrayToBinaryBitmap(this byte[,] bitData)
        {
            Bitmap bi = new Bitmap(bitData.GetLength(1), bitData.GetLength(0));
            for (int y = 0; y < bitData.GetLength(0); y++)
            {
                for (int x = 0; x < bitData.GetLength(1); x++)
                {
                    bi.SetPixel(x, y, Color.FromArgb(bitData[y, x], bitData[y, x], bitData[y, x]));
                }
            }
            return bi;
        }
        public static Graphics GetGraphics(this Bitmap bitmap)
        {
            return Graphics.FromImage(bitmap);
        }
        /// <summary>
        /// 剪贴
        /// </summary>
        /// <param name="img"></param>
        /// <param name="erc"></param>
        /// <returns></returns>
        public static Bitmap Clip(this Image img, Rectangle erc)
        {
            Bitmap bitmap1 = new Bitmap(erc.Width, erc.Height);
            Graphics graphics = Graphics.FromImage(bitmap1);
            graphics.DrawImage(img, new Rectangle(0, 0, erc.Width, erc.Height), erc, GraphicsUnit.Pixel);
            //graphics.Dispose();
            return bitmap1;
        }
        #region 调整光暗  
        /// <summary>  
        /// 调整光暗  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        /// <param name="val">增加或减少的光暗值</param>  
        public static Bitmap LDPic(this Bitmap mybm, int val)
        {
            Bitmap bm = new Bitmap(mybm.Width, mybm.Height);//初始化一个记录经过处理后的图片对象  
            int x, y, resultR, resultG, resultB;//x、y是循环次数，后面三个是记录红绿蓝三个值的  
            Color pixel;
            for (x = 0; x < mybm.Width; x++)
            {
                for (y = 0; y < mybm.Height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前像素的值  
                    resultR = pixel.R + val;//检查红色值会不会超出[0, 255]  
                    resultG = pixel.G + val;//检查绿色值会不会超出[0, 255]  
                    resultB = pixel.B + val;//检查蓝色值会不会超出[0, 255]  
                    bm.SetPixel(x, y, Color.FromArgb(GetColorInt(resultR), GetColorInt(resultG), GetColorInt(resultB)));//绘图  
                }
            }
            return bm;
        }
        public static int GetColorInt(int i)
        {
            if (i > 255)
            {
                return 255;
            }
            else if (i < 0)
            {
                return 0;
            }
            else
            {
                return i;
            }
        }
        #endregion
        /// <summary>
        /// 柔化：当前像素点与周围像素点的颜色差距较大时取其平均值.
        /// </summary>
        /// <param name="mybm"></param>
        /// <returns></returns>
        public static Bitmap Soften(this Bitmap mybm)
        {
            Bitmap bitmap = new Bitmap(mybm.Width, mybm.Height);
            Color pixel;
            //高斯模板
            int[] Gauss = { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
            for (int x = 1; x < mybm.Width - 1; x++)
            {
                for (int y = 1; y < mybm.Height - 1; y++)
                {
                    int r = 0, g = 0, b = 0;
                    int Index = 0;
                    for (int col = -1; col <= 1; col++)
                    {
                        for (int row = -1; row <= 1; row++)
                        {
                            pixel = mybm.GetPixel(x + row, y + col);
                            r += pixel.R * Gauss[Index];
                            g += pixel.G * Gauss[Index];
                            b += pixel.B * Gauss[Index];
                            Index++;
                        }
                    }
                    r /= 16;
                    g /= 16;
                    b /= 16;
                    //处理颜色值溢出
                    r = r > 255 ? 255 : r;
                    r = r < 0 ? 0 : r;
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;
                    b = b > 255 ? 255 : b;
                    b = b < 0 ? 0 : b;
                    bitmap.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
                }
            }
            return bitmap;

        }
        /// <summary>
        /// 锐化效果 突出显示颜色值大(即形成形体边缘)的像素点.
        /// </summary>
        /// <param name="mybm"></param>
        /// <returns></returns>
        public static Bitmap Sharpening(this Bitmap mybm)
        {
            Bitmap newBitmap = new Bitmap(mybm.Width, mybm.Height);
            Color pixel;
            //拉普拉斯模板
            int[] Laplacian = { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
            for (int x = 1; x < mybm.Width - 1; x++)
                for (int y = 1; y < mybm.Height - 1; y++)
                {
                    int r = 0, g = 0, b = 0;
                    int Index = 0;
                    for (int col = -1; col <= 1; col++)
                        for (int row = -1; row <= 1; row++)
                        {
                            pixel = mybm.GetPixel(x + row, y + col); r += pixel.R * Laplacian[Index];
                            g += pixel.G * Laplacian[Index];
                            b += pixel.B * Laplacian[Index];
                            Index++;
                        }
                    //处理颜色值溢出
                    r = r > 255 ? 255 : r;
                    r = r < 0 ? 0 : r;
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;
                    b = b > 255 ? 255 : b;
                    b = b < 0 ? 0 : b;
                    newBitmap.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
                }
            return newBitmap;
        }

        /// <summary>
        /// 雾化效果 在图像中引入一定的随机值, 打乱图像中的像素值
        /// </summary>
        /// <param name="mybm"></param>
        /// <returns></returns>
        public static Bitmap Atomization(this Bitmap mybm)
        {
            Bitmap newBitmap = new Bitmap(mybm.Width, mybm.Height);
            Color pixel;
            for (int x = 1; x < mybm.Width - 1; x++)
                for (int y = 1; y < mybm.Height - 1; y++)
                {
                    System.Random MyRandom = new Random();
                    int k = MyRandom.Next(123456);
                    //像素块大小
                    int dx = x + k % 19;
                    int dy = y + k % 19;
                    if (dx >= mybm.Width)
                        dx = mybm.Width - 1;
                    if (dy >= mybm.Height)
                        dy = mybm.Height - 1;
                    pixel = mybm.GetPixel(dx, dy);
                    newBitmap.SetPixel(x, y, pixel);
                }

            return newBitmap;
        }

        #region 反色处理  
        /// <summary>  
        /// 反色处理  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        public static Bitmap RePic(this Bitmap mybm)
        {
            Bitmap bm = new Bitmap(mybm.Width, mybm.Height);//初始化一个记录处理后的图片的对象  
            int x, y, resultR, resultG, resultB;
            Color pixel;
            for (x = 0; x < mybm.Width; x++)
            {
                for (y = 0; y < mybm.Height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值  
                    resultR = 255 - pixel.R;//反红  
                    resultG = 255 - pixel.G;//反绿  
                    resultB = 255 - pixel.B;//反蓝  
                    bm.SetPixel(x, y, Color.FromArgb(resultR, resultG, resultB));//绘图  
                }
            }
            return bm;
        }
        #endregion

        #region 浮雕处理  
        /// <summary>
        /// 浮雕处理
        /// </summary>
        /// <param name="oldBitmap">原始图片</param>
        /// <returns></returns>
        public static Bitmap FD(this Bitmap oldBitmap)
        {
            Bitmap newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);
            Color color1, color2;
            for (int x = 0; x < oldBitmap.Width - 1; x++)
            {
                for (int y = 0; y < oldBitmap.Height - 1; y++)
                {
                    int r = 0, g = 0, b = 0;
                    color1 = oldBitmap.GetPixel(x, y);
                    color2 = oldBitmap.GetPixel(x + 1, y + 1);
                    r = Math.Abs(color1.R - color2.R + 128);
                    g = Math.Abs(color1.G - color2.G + 128);
                    b = Math.Abs(color1.B - color2.B + 128);
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    newBitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return newBitmap;
        }
        #endregion

        #region 拉伸图片  
        /// <summary>  
        /// 拉伸图片  
        /// </summary>  
        /// <param name="bmp">原始图片</param>  
        /// <param name="newW">新的宽度</param>  
        /// <param name="newH">新的高度</param>  
        public static Bitmap ResizeImage(this Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap bap = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(bap);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(bap, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bap.Width, bap.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return bap;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 滤色处理
        /// <summary>  
        /// 滤色处理  
        /// </summary>  
        /// <param name="mybm">原始图片</param> 
        public static Bitmap FilPic(this Bitmap mybm)
        {
            Bitmap bm = new Bitmap(mybm.Width, mybm.Height);//初始化一个记录滤色效果的图片对象  
            int x, y;
            Color pixel;

            for (x = 0; x < mybm.Width; x++)
            {
                for (y = 0; y < mybm.Height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值  
                    bm.SetPixel(x, y, Color.FromArgb(0, pixel.G, pixel.B));//绘图  
                }
            }
            return bm;
        }
        #endregion

        #region 左右翻转  
        /// <summary>  
        /// 左右翻转  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        /// <param name="mybm.Width">原始图片的长度</param>  
        /// <param name="mybm.Height">原始图片的高度</param>  
        public static Bitmap RevPicLR(this Bitmap mybm)
        {
            Bitmap bm = new Bitmap(mybm.Width, mybm.Height);
            int x, y, z; //x,y是循环次数,z是用来记录像素点的x坐标的变化的  
            Color pixel;
            for (y = mybm.Height - 1; y >= 0; y--)
            {
                for (x = mybm.Width - 1, z = 0; x >= 0; x--)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前像素的值  
                    bm.SetPixel(z++, y, Color.FromArgb(pixel.R, pixel.G, pixel.B));//绘图  
                }
            }
            return bm;
        }
        #endregion

        #region 上下翻转  
        /// <summary>  
        /// 上下翻转  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        public static Bitmap RevPicUD(this Bitmap mybm)
        {
            Bitmap bm = new Bitmap(mybm.Width, mybm.Height);
            int x, y, z;
            Color pixel;
            for (x = 0; x < mybm.Width; x++)
            {
                for (y = mybm.Height - 1, z = 0; y >= 0; y--)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前像素的值  
                    bm.SetPixel(x, z++, Color.FromArgb(pixel.R, pixel.G, pixel.B));//绘图  
                }
            }
            return bm;
        }
        #endregion

        #region 压缩图片  
        /// <summary>  
        /// 压缩到指定尺寸  
        /// </summary>  
        /// <param name="oldfile">原文件</param>  
        /// <param name="newfile">新文件</param>  
        public static bool Compress(string oldfile, string newfile)
        {
            try
            {
                Image img = Image.FromFile(oldfile);
                ImageFormat thisFormat = img.RawFormat;
                Bitmap outBmp = Compress(img as Bitmap, new Size(100, 52));
                outBmp.Save(newfile, ImageFormat.Jpeg);
                img.Dispose();
                outBmp.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>  
        /// 压缩到指定尺寸  
        /// </summary>  
        /// <param name="oldfile">原文件</param>  
        /// <param name="newfile">新文件</param>  
        public static Bitmap Compress(this Bitmap bitmap, Size newSize)
        {
            try
            {
                ImageFormat thisFormat = bitmap.RawFormat;
                Bitmap outBmp = new Bitmap(newSize.Width, newSize.Height);
                Graphics g = Graphics.FromImage(outBmp);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bitmap, new Rectangle(0, 0, newSize.Width, newSize.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
                g.Dispose();
                EncoderParameters encoderParams = new EncoderParameters();
                long[] quality = new long[1];
                quality[0] = 100;
                EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                encoderParams.Param[0] = encoderParam;
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICI = null;
                for (int x = 0; x < arrayICI.Length; x++)
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICI = arrayICI[x]; //设置JPEG编码  
                        break;
                    }
                return outBmp;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 图片灰度化  
        /// <summary>
        /// 灰度化  
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Color Gray(Color c)
        {
            int rgb = Convert.ToInt32((double)(((0.3 * c.R) + (0.59 * c.G)) + (0.11 * c.B)));
            return Color.FromArgb(rgb, rgb, rgb);
        }
        /// <summary>
        /// 图片灰度化  
        /// </summary>
        /// <param name="mybm"></param>
        /// <returns></returns>
        public static Bitmap Gray(this Bitmap mybm)
        {
            Bitmap bm = new Bitmap(mybm.Width, mybm.Height);
            int x, y;
            for (x = 0; x < mybm.Width; x++)
            {
                for (y = 0; y < mybm.Height; y++)
                {
                    bm.SetPixel(x, y, Gray(mybm.GetPixel(x, y)));
                }
            }
            return bm;
        }
        #endregion

        #region 转换为黑白图片  
        /// <summary>  
        /// 转换为黑白图片  
        /// </summary>  
        /// <param name="mybt">要进行处理的图片</param>  
        /// <param name="type">处理类型0平均值法，1最大值法，2加权平均值法</param>  
        public static Bitmap BWPic(this Bitmap mybm, int type = 2)
        {
            Bitmap bm = new Bitmap(mybm.Width, mybm.Height);
            int Height = mybm.Height;
            int Width = mybm.Width;
            Color pixel;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    pixel = mybm.GetPixel(x, y);
                    int r, g, b, Result = 0;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    switch (type)
                    {
                        case 0://平均值法
                            Result = ((r + g + b) / 3);
                            break;
                        case 1://最大值法
                            Result = r > g ? r : g;
                            Result = Result > b ? Result : b;
                            break;
                        case 2://加权平均值法
                            Result = ((int)(0.7 * r) + (int)(0.2 * g) + (int)(0.1 * b));
                            break;
                    }
                    bm.SetPixel(x, y, Color.FromArgb(Result, Result, Result));
                }
            }
            return bm;
        }
        #endregion

        #region 获取图片中的各帧  
        /// <summary>  
        /// 获取图片中的各帧  
        /// </summary>  
        /// <param name="pPath">图片路径</param>  
        /// <param name="pSavePath">保存路径</param>  
        public static void GetFrames(string pPath, string pSavedPath)
        {
            Image gif = Image.FromFile(pPath);
            FrameDimension fd = new FrameDimension(gif.FrameDimensionsList[0]);
            int count = gif.GetFrameCount(fd); //获取帧数(gif图片可能包含多帧，其它格式图片一般仅一帧)  
            for (int i = 0; i < count; i++)    //以Jpeg格式保存各帧  
            {
                gif.SelectActiveFrame(fd, i);
                gif.Save(pSavedPath + "\\frame_" + i + ".jpg", ImageFormat.Jpeg);
            }
        }
        #endregion

        #region 识别图片验证码
        public static string GeyCode(this Stream Stream, string url = "140.143.243.240", int port = 7656)
        {
            MemoryStream memory = new MemoryStream();
            Stream.CopyTo(memory);
            return GeyCode(Convert.ToBase64String(memory.GetBuffer()), url, port);
        }
        public static string GeyCode(this Image image, string url = "140.143.243.240", int port = 7656)
        {
            MemoryStream memory = new MemoryStream();
            image.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
            return GeyCode(Convert.ToBase64String(memory.GetBuffer()), url, port);
        }
        public static string GeyCode(this string data, string url = "140.143.243.240", int port = 7656)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse(url), port));
            var bs = Encoding.ASCII.GetBytes("image=" + data + "$");//
            socket.Send(bs);
            string recvStr = "";
            byte[] recvBytes = new byte[1024];
            int bytes;
            bytes = socket.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息
            recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);
            socket.Close();
            return recvStr;
        }
        #endregion
    }
}

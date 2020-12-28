using System.IO;
using System.Text;

namespace ExtendHelp
{
    public static class StreamExtend
    {
        public static string DefaultServerUrl = "http://192.168.1.78:7677/getVerifyCode?type=1";
        /// <summary>
        /// 识别验证码
        /// </summary>
        /// <param name="memoryStream"></param>
        /// <param name="serverUrl"></param>
        /// <returns></returns>
        public static string IdentificationVerifyCode(this MemoryStream memoryStream, string serverUrl = null)
        {
            return (serverUrl ?? DefaultServerUrl).Post(memoryStream.GetBuffer(), Encoding.UTF8);
        }
        /// <summary>
        /// 识别验证码
        /// </summary>
        /// <param name="memoryStream"></param>
        /// <param name="serverUrl"></param>
        /// <returns></returns>
        public static string IdentificationVerifyCode(this Stream stream, string serverUrl = null)
        {
            MemoryStream memoryStream = null;
            if (stream is MemoryStream)
            {
                memoryStream = stream as MemoryStream;
            }
            else
            {
                memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
            }
            return IdentificationVerifyCode(memoryStream, serverUrl);
        }
        /// <summary>
        /// 以UTF-8写入string数据
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="data">要写入的数据</param>
        public static void Write(this Stream stream, string data)
        {
            Write(stream, data, Encoding.UTF8);
        }
        /// <summary>
        /// 写入string数据
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="data">要写入的数据</param>
        /// <param name="encoding">要写入的数据的编码</param>
        public static void Write(this Stream stream, string data, Encoding encoding)
        {
            var bs = Encoding.UTF8.GetBytes(data);
            stream.Write(bs, 0, bs.Length);
        }
    }
}

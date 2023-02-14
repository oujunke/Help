using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using ExtendHelp.Model;
using HtmlAgilityPack;

namespace ExtendHelp
{
    public static class StringExtend
    {
        public static Encoding GBK = Encoding.GetEncoding("GBK");
        #region 正则表达式
        /// <summary>
        /// 正则获取匹配的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <param name="retuenIndex"></param>
        /// <returns></returns>
        public static string RegexGetString(this string str, string pattern, int retuenIndex = 1)
        {
            Regex r = new Regex(pattern, RegexOptions.None);
            return r.Match(str).Groups[retuenIndex].Value;
        }
        /// <summary>
        /// 获取正则匹配的所有字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <param name="retuenIndex"></param>
        /// <returns></returns>
        public static List<List<string>> RegexGetAllString(this string str, string pattern)
        {
            Regex r = new Regex(pattern, RegexOptions.None);
            var mat = r.Matches(str);
            var res = new List<List<string>>();
            mat.ForEach<Match>(t =>
            {
                var sl = new List<string>();
                t.Groups.ForEach<Group>(g =>
                {
                    sl.Add(g.Value);
                });
                res.Add(sl);
            });
            return res;
        }
        /// <summary>
        /// 判断字符串是否匹配
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <param name="retuenIndex"></param>
        /// <returns></returns>
        public static bool IsMatch(this string str, string pattern)
        {
            Regex r = new Regex(pattern, RegexOptions.None);
            return r.IsMatch(str);
        }
        #endregion
        #region 加密
        #region  Base64加密解密
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <returns></returns>
        public static string Base64Encrypt(this string input)
        {
            return Base64Encrypt(input, Encoding.UTF8);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <param name="encode">字符编码</param>
        /// <returns></returns>
        public static string Base64Encrypt(this string input, Encoding encode)
        {
            return Convert.ToBase64String(encode.GetBytes(input));
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="input">需要解密的字符串</param>
        /// <returns></returns>
        public static string Base64Decrypt(this string input)
        {
            return Base64Decrypt(input, Encoding.UTF8);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="input">需要解密的字符串</param>
        /// <param name="encode">字符的编码</param>
        /// <returns></returns>
        public static string Base64Decrypt(this string input, Encoding encode)
        {
            return encode.GetString(Convert.FromBase64String(input));
        }
        #endregion

        #region DES加密解密
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="input">加密数据</param>
        /// <param name="key">8位字符的密钥字符串</param>
        /// <param name="iv">8位字符的初始化向量字符串</param>
        /// <returns></returns>
        public static string DesEncrypt(this string input, string key, string iv)
        {
            var byKey = Encoding.ASCII.GetBytes(key);
            var byIv = Encoding.ASCII.GetBytes(iv);

            var cryptoProvider = new DESCryptoServiceProvider();
            using (var ms = new MemoryStream())
            {
                using (var cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIv), CryptoStreamMode.Write))
                {
                    using (var sw = new StreamWriter(cst))
                    {
                        sw.Write(input);
                        sw.Flush();
                        cst.FlushFinalBlock();
                        return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                    }
                }
            }
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <param name="key">8位字符的密钥字符串(需要和加密时相同)</param>
        /// <param name="iv">8位字符的初始化向量字符串(需要和加密时相同)</param>
        /// <returns></returns>
        public static string DesDecrypt(this string data, string key, string iv)
        {
            var byKey = Encoding.ASCII.GetBytes(key);
            var byIv = Encoding.ASCII.GetBytes(iv);

            var byEnc = Convert.FromBase64String(data);
            var cryptoProvider = new DESCryptoServiceProvider();

            using (var ms = new MemoryStream(byEnc))
            {
                using (var cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIv), CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cst))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
        #endregion

        #region AES加密解密
        /// <summary>
        /// 有密码的AES加密 
        /// </summary>
        /// <param name="input">加密字符</param>
        /// <param name="key">加密的密码</param>
        /// <param name="iv">密钥</param>
        /// <returns></returns>
        public static string AesEncrypt(this string input, string key, string iv)
        {
            var rijndaelCipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128
            };

            var pwdBytes = Encoding.UTF8.GetBytes(key);
            var keyBytes = new byte[16];
            Array.Copy(pwdBytes, keyBytes, Math.Min(pwdBytes.Length, keyBytes.Length));
            rijndaelCipher.Key = keyBytes;
            var ivBytes = Encoding.UTF8.GetBytes(iv);
            var ivDatas = new byte[16];
            Array.Copy(ivBytes, ivDatas, Math.Min(ivBytes.Length, ivDatas.Length));
            rijndaelCipher.IV = ivDatas;

            var transform = rijndaelCipher.CreateEncryptor();
            var plainText = Encoding.UTF8.GetBytes(input);
            var cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);

            return Convert.ToBase64String(cipherBytes);
        }
        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static async Task AesEncrypt(this Stream input, Stream output, string key, string iv)
        {
            var pwdBytes = Encoding.UTF8.GetBytes(key);
            var keyBytes = new byte[16];
            Array.Copy(pwdBytes, keyBytes, Math.Min(pwdBytes.Length, keyBytes.Length));
            var ivBytes = Encoding.UTF8.GetBytes(iv);
            var ivData = new byte[16];
            Array.Copy(ivBytes, ivData, Math.Min(ivData.Length, ivBytes.Length));
            await AesEncrypt(input, output, keyBytes, ivData);
        }
        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static async Task AesEncrypt(this Stream input, Stream output, byte[] key, byte[] iv)
        {
            var rijndaelCipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128
            };
            rijndaelCipher.Key = key;
            rijndaelCipher.IV = iv;

            var transform = rijndaelCipher.CreateEncryptor();
            var length = input.Length;
            var inputLength = transform.InputBlockSize;
            byte[] inputBytes = new byte[inputLength];
            byte[] outBytes = new byte[transform.OutputBlockSize];
            bool isFast = true;
            while (input.Position < length)
            {
                int tempLength;
                if (isFast)
                {
                    isFast = false;
                    var sizes = BitConverter.GetBytes(length);
                    Array.Copy(sizes, inputBytes, sizes.Length);
                    tempLength = await input.ReadAsync(inputBytes, sizes.Length, inputBytes.Length - sizes.Length);
                    tempLength += sizes.Length;
                }
                else
                {
                    tempLength = await input.ReadAsync(inputBytes, 0, inputBytes.Length);
                }
                if (inputBytes.Length - tempLength > 0)
                {
                    Array.Clear(inputBytes, tempLength, inputBytes.Length - tempLength);
                }
                int tempOutLength = transform.TransformBlock(inputBytes, 0, inputBytes.Length, outBytes, 0);
                await output.WriteAsync(outBytes, 0, tempOutLength);
            }
        }
        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static byte[] AesEncrypt(this byte[] data, byte[] key, byte[] iv, CipherMode mode = CipherMode.CBC)
        {
            var rijndaelCipher = new RijndaelManaged
            {
                Mode = mode,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128
            };
            rijndaelCipher.Key = key;
            rijndaelCipher.IV = iv;

            var transform = rijndaelCipher.CreateEncryptor();
            return transform.TransformFinalBlock(data, 0, data.Length);
        }
        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string AesEncrypt(this string data, byte[] key, byte[] iv)
        {
            return Convert.ToBase64String(AesEncrypt(Encoding.UTF8.GetBytes(data), key, iv));
        }
        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static async Task AesDecrypt(this Stream input, Stream output, string key, string iv)
        {

            var pwdBytes = Encoding.UTF8.GetBytes(key);
            var keyBytes = new byte[16];
            Array.Copy(pwdBytes, keyBytes, Math.Min(pwdBytes.Length, keyBytes.Length));
            var ivBytes = Encoding.UTF8.GetBytes(iv);
            var ivData = new byte[16];
            Array.Copy(ivBytes, ivData, Math.Min(ivData.Length, ivBytes.Length));
            await AesDecrypt(input, output, keyBytes, ivData);
        }
        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static async Task AesDecrypt(this Stream input, Stream output, byte[] key, byte[] iv)
        {
            var rijndaelCipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128
            };
            rijndaelCipher.Key = key;
            rijndaelCipher.IV = iv;
            var transform = rijndaelCipher.CreateDecryptor();
            var inputLength = transform.InputBlockSize;
            byte[] inputBytes = new byte[inputLength];
            byte[] outBytes = new byte[transform.OutputBlockSize];
            long optLength = 1;
            bool isFast = true;
            long post = 0;
            while (output.Position < optLength)
            {
                int tempLength = await input.ReadAsync(inputBytes, 0, inputBytes.Length);
                if (inputBytes.Length - tempLength > 0)
                {
                    Array.Clear(inputBytes, tempLength, inputBytes.Length - tempLength);
                }
                int tempOutLength = transform.TransformBlock(inputBytes, 0, inputBytes.Length, outBytes, 0);
                if (tempOutLength == 0)
                {
                    continue;
                }
                if (isFast)
                {
                    isFast = false;
                    optLength = BitConverter.ToInt64(outBytes, 0);
                    post += tempOutLength - 8;
                    await output.WriteAsync(outBytes, 8, tempOutLength - 8);
                }
                else
                {
                    post += tempOutLength;
                    if (post > optLength)
                    {
                        tempOutLength -= (int)(post - optLength);
                    }
                    await output.WriteAsync(outBytes, 0, tempOutLength);
                }
            }
        }

        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static byte[] AesDecrypt(this byte[] data, byte[] key, byte[] iv, CipherMode mode = CipherMode.CBC)
        {
            var rijndaelCipher = new RijndaelManaged
            {
                Mode = mode,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128
            };
            rijndaelCipher.Key = key;
            if (mode != CipherMode.ECB)
            {
                rijndaelCipher.IV = iv;
            }
            var transform = rijndaelCipher.CreateDecryptor();
            return transform.TransformFinalBlock(data, 0, data.Length);
        }

        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string AesDecrypt(this string data, byte[] key, byte[] iv, CipherMode mode)
        {
            return Encoding.UTF8.GetString(AesDecrypt(Convert.FromBase64String(data), key, iv, mode));
        }
        /// <summary>
        /// 随机生成密钥(获取指定位数的字母(大小写)，数字)
        /// </summary>
        /// <returns></returns>
        public static string GetIv(this int n)
        {
            var arrChar = new[]
            {
                'a', 'b', 'd', 'c', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 'q', 's', 't', 'u', 'v','w', 'z', 'y', 'x','0', '1', '2', '3', '4', '5', '6', '7', '8', '9','A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Q', 'P', 'R', 'T', 'S', 'V', 'U','W', 'X', 'Y', 'Z'
            };

            var num = new StringBuilder();
            var rnd = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < n; i++)
            {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }

            return num.ToString();
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="password"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string AesDecrypt(this string text, string password, string iv)
        {
            var rijndaelCipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128
            };

            var encryptedData = Convert.FromBase64String(text);
            var pwdBytes = Encoding.UTF8.GetBytes(password);
            var keyBytes = new byte[16];
            Array.Copy(pwdBytes, keyBytes, Math.Min(pwdBytes.Length, keyBytes.Length));
            rijndaelCipher.Key = keyBytes;
            var ivBytes = Encoding.UTF8.GetBytes(iv);
            var ivDatas = new byte[16];
            Array.Copy(ivBytes, ivDatas, Math.Min(ivBytes.Length, ivDatas.Length));
            rijndaelCipher.IV = ivDatas;

            var transform = rijndaelCipher.CreateDecryptor();
            var plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);

            return Encoding.UTF8.GetString(plainText);
        }


        #endregion
        #region RSA加密解密
        /// <summary>
        /// Rsa加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="modulusBase64"></param>
        /// <param name="exponentBase64"></param>
        /// <returns></returns>
        public static string RsaEncryptBase64(this string data, string modulusBase64, string exponentBase64)
        {
            return RsaEncrypt(data, Convert.FromBase64String(modulusBase64), Convert.FromBase64String(exponentBase64));
        }
        /// <summary>
        /// Rsa加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="modulusBase64"></param>
        /// <param name="exponentBase64"></param>
        /// <returns></returns>
        public static string RsaEncryptHex(this string data, string modulusHex, string exponentHex)
        {
            return RsaEncrypt(data, modulusHex.StringToHexByte(), exponentHex.StringToHexByte());
        }
        /// <summary>
        /// Rsa加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="modulus"></param>
        /// <param name="exponent"></param>
        /// <returns></returns>
        public static string RsaEncrypt(this string data, int[] modulus, int[] exponent)
        {
            return RsaEncrypt(data, modulus.IntArrayToByteArray(), exponent.IntArrayToByteArray());
        }
        /// <summary>
        /// Rsa加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="modulusBase64"></param>
        /// <param name="exponentBase64"></param>
        /// <returns></returns>
        public static string RsaEncrypt(this string data, byte[] modulus, byte[] exponent)
        {
            var dataBs = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(RsaEncrypt(dataBs, modulus, exponent));
        }
        /// <summary>
        /// Rsa加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="modulusBase64"></param>
        /// <param name="exponentBase64"></param>
        /// <returns></returns>
        public static byte[] RsaEncrypt(this byte[] dataBs, byte[] modulus, byte[] exponent)
        {
            List<byte> resultList = new List<byte>();

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(new RSAParameters
                {
                    Modulus = modulus,
                    Exponent = exponent,
                });
                int MaxBlockSize = rsa.KeySize / 8 - 12;//加密块最大长度限制
                int num = 0;
                for (int i = 0; i < dataBs.Length;)
                {
                    num = Math.Min(dataBs.Length - i, MaxBlockSize);
                    resultList.AddRange(rsa.Encrypt(dataBs.Substring(i, num), false));
                    i += num;
                }
            }
            return resultList.Skip(1).ToArray();
        }
        #endregion
        #region MD5加密
        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5Encrypt(this string input)
        {
            return Md5Encrypt(input, Encoding.UTF8);
        }

        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="enc"></param>
        /// <returns></returns>
        public static string Md5Encrypt(this string input, Encoding enc)
        {
            var md5 = new MD5CryptoServiceProvider();
            var buffer = md5.ComputeHash(enc.GetBytes(input));
            var builder = new StringBuilder(32);
            foreach (var t in buffer)
            {
                builder.Append(t.ToString("x").PadLeft(2, '0'));
            }
            return builder.ToString();
        }

        /// <summary>
        /// MD5对文件流加密
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string Md5Encrypt(this Stream stream)
        {
            var md5 = new MD5CryptoServiceProvider();
            var buffer = md5.ComputeHash(stream);
            var builder = new StringBuilder();
            foreach (var t in buffer)
            {
                builder.Append(t.ToString("x").PadLeft(2, '0'));
            }
            //stream.Close();
            return builder.ToString();
        }
        /// <summary>
        /// MD5对文件流加密
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string Md5EncryptFile(this string path)
        {
            return Md5Encrypt(new StreamReader(path).BaseStream);
        }
        /// <summary>
        /// MD5加密(返回16位加密串)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5Encrypt16(this string input)
        {
            return Md5Encrypt16(input, Encoding.UTF8);
        }

        /// <summary>
        /// MD5加密(返回16位加密串)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string Md5Encrypt16(this string input, Encoding encode)
        {
            var md5 = new MD5CryptoServiceProvider();
            var buffer = md5.ComputeHash(encode.GetBytes(input));
            var result = BitConverter.ToString(buffer, 4, 8);
            result = result.Replace("-", "");
            return result;
        }
        #endregion

        #region DES3加密解密
        /// <summary>
        /// DES3加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Des3Encrypt(this string input, string key, string iv = null)
        {
            var des = new TripleDESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(key.Substring(0, 24)),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                IV = Encoding.UTF8.GetBytes((iv ?? key).Substring(0, 8))
            };

            var desEncrypt = des.CreateEncryptor();
            var buffer = Encoding.UTF8.GetBytes(input);

            return Convert.ToBase64String(desEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));
        }

        /// <summary>
        /// DES3解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Des3Decrypt(this string input, string key, string iv = null)
        {
            var des = new TripleDESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(key.Substring(0, 24)),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                IV = Encoding.UTF8.GetBytes((iv ?? key).Substring(0, 8))
            };

            var desDecrypt = des.CreateDecryptor();
            var buffer = Convert.FromBase64String(input);
            var result = Encoding.UTF8.GetString(desDecrypt.TransformFinalBlock(buffer, 0, buffer.Length));

            return result;
        }

        #endregion
        #region  SHA1加密
        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SHA1_Encrypt(this string input)
        {
            var strRes = Encoding.Default.GetBytes(input);
            HashAlgorithm iSha = new SHA1CryptoServiceProvider();
            strRes = iSha.ComputeHash(strRes);
            var enText = new StringBuilder();
            foreach (var iByte in strRes)
            {
                enText.AppendFormat("{0:x2}", iByte);
            }
            return enText.ToString();
        }
        #endregion
        #region  SHA256加密
        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SHA256_Encrypt(this string input)
        {
            var strRes = Encoding.Default.GetBytes(input);
            HashAlgorithm iSha = new SHA256CryptoServiceProvider();
            strRes = iSha.ComputeHash(strRes);
            var enText = new StringBuilder();
            foreach (var iByte in strRes)
            {
                enText.AppendFormat("{0:x2}", iByte);
            }
            return enText.ToString();
        }
        #endregion
        #endregion
        #region http请求
        /// <summary>
        /// 使用webclient进行post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="enc"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public static string Post(this string url, string data, Encoding enc = null, WebProxy proxy = null)
        {
            var postdata = Encoding.UTF8.GetBytes(data);
            return Post(url, postdata, enc, proxy); //解码  
        }
        /// <summary>
        /// 使用webclient进行post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="enc"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public static string Post(this string url, byte[] data, Encoding enc = null, WebProxy proxy = null)
        {
            if (enc == null) enc = Encoding.UTF8;
            var webClient = new WebClient()
            {
                Encoding = enc,
                Proxy = proxy
            };
            webClient.Headers.Add(HttpRequestHeader.KeepAlive, "False");
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var response = webClient.UploadData(url, "POST", data); //得到返回字符流  
            return enc.GetString(response); //解码  
        }
        /// <summary>
        /// 使用webclient进行get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="enc"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public static string Get(this string url, Encoding enc = null, WebProxy proxy = null)
        {
            if (enc == null) enc = Encoding.UTF8;
            var webClient = new WebClient()
            {
                Encoding = enc,
                Proxy = proxy,
            };
            var response = webClient.DownloadString($"{url}");
            return response;
        }
        public static Stream GetStream(this string url, Encoding enc = null, WebProxy proxy = null)
        {
            if (enc == null) enc = Encoding.UTF8;
            var webClient = new WebClient()
            {
                Encoding = enc,
                Proxy = proxy,
            };
            var response = webClient.OpenRead($"{url}");
            return response;
        }
        /// <summary>
        /// 获取代理IP
        /// </summary>
        /// <param name="url"></param>
        /// <param name="port"></param>
        /// <param name="usr"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static WebProxy GetProxy(this string url, string port, string usr, string pwd)
        {
            try
            {
                var client = new WebClient { Encoding = Encoding.UTF8 };
                var ip = client.DownloadString(url).Trim();
                var proxy = new WebProxy($"{ip}:{port}")
                {
                    Credentials = new NetworkCredential(usr, pwd)
                };
                return proxy;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region 文件操作
        /// <summary>
        /// 读取该文件的所有内容
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ReadFile(this string file, Encoding en = null)
        {
            en = en ?? Encoding.UTF8;
            using (StreamReader sr = new StreamReader(file, en))
            {
                return sr.ReadToEnd();
            }
        }
        /// <summary>
        /// 写入数据到文本
        /// </summary>
        /// <param name="file">文件名</param>
        /// <param name="data">写入数据</param>
        /// <param name="append">ture追加，false覆盖(默认覆盖)</param>
        /// <param name="en">编码(默认utf8)</param>
        public static void WriterFile(this string file, string data, bool append = false, Encoding en = null)
        {
            en = en ?? Encoding.UTF8;
            using (StreamWriter sr = new StreamWriter(file, append, en))
            {
                sr.Write(data);
            }
        }
        #endregion
        #region 字符串操作
        /// <summary>
        /// 转换成url数据集
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToUrlData(this string str)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            var ss = str.Split('&');
            foreach (var s in ss)
            {
                var ts = s.IndexOf('=');
                if (ts > -1)
                {
                    dictionary.Add(s.Substring(0, ts), s.Substring(ts + 1));
                }
            }
            return dictionary;
        }
        /// <summary>
        /// 去除字符串末尾指定的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public static string TrimEnd(this string str, string par)
        {
            return str.EndsWith(par) ? str.Remove(str.Length - par.Length) : str;
        }
        /// <summary>
        /// 字符串分割
        /// </summary>
        /// <param name="str">要分割的字符串</param>
        /// <param name="sp">分割字符串</param>
        /// <param name="isRetain">是否保留分割字符串</param>
        /// <returns></returns>
        public static string[] Split(this string str, string sp, bool isRetain = true)
        {
            List<string> ls = new List<string>();
            int i = 0;
            int index;
            int length = isRetain ? 0 : sp.Length;
            while (true && i + 1 <= str.Length)
            {
                index = str.IndexOf(sp, i + 1);
                if (index == -1)
                {
                    ls.Add(str.Substring(i));
                    break;
                }
                ls.Add(str.Substring(i, index - i));
                i = index + length;
            }
            return ls.ToArray();
        }
        /// <summary>
        /// 判断字符串里面开头是否是字符串组中的一个
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ss"></param>
        /// <returns></returns>
        public static bool StartsWithIn(this string str, params string[] ss)
        {
            bool b = false;
            ss.ForEachT(s => b = b || str.StartsWith(s));
            return b;
        }
        /// <summary>
        /// 获取一个字符串指定位置的字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static char[] GetChars(this string str, int length = -1, int start = 0)
        {
            var cs = str.ToArray().Skip(start);
            if (length >= 0)
            {
                cs = cs.Take(length);
            }
            return cs.ToArray();
        }
        /// <summary>
        /// 字节转字节字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes)
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
        /// <summary>
        /// 字节字符串转字节
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] StringToHexByte(this string hexString)
        {
            hexString = hexString.Replace(@"\x", "").Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString = "0" + hexString;
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        /// <summary>
        /// Base64转图片
        /// </summary>
        /// <param name="base64Str"></param>
        /// <returns></returns>
        public static Bitmap Base64StringToBitmap(this string base64Str)
        {
            var datas = base64Str.Split(';');
            byte[] imageBs = null;
            imageBs = Convert.FromBase64String((datas.Length == 2 ? datas[1] : datas[0]).Replace("base64,", ""));
            MemoryStream memory = new MemoryStream(imageBs);
            return Image.FromStream(memory) as Bitmap;
        }
        #endregion
        #region 字符串扩展
        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        #endregion
        #region 编码
        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(this string str) => HttpUtility.UrlEncode(str);
        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string UrlEncode(this string str, Encoding encoding) => HttpUtility.UrlEncode(str, encoding);
        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlDecode(this string str) => HttpUtility.UrlDecode(str);
        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string UrlDecode(this string str, Encoding encoding) => HttpUtility.UrlDecode(str, encoding);
        /// <summary>
        /// Html解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlDecode(this string str) => HttpUtility.HtmlDecode(str);
        /// <summary>
        /// Html编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlEncode(this string str) => HttpUtility.HtmlEncode(str);
        #endregion
        #region Html操作
        /// <summary>
        /// 获取表单数据
        /// </summary>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetInputValue(this string html, string name)
        {
            var doc = new HtmlDocument();
            try
            {
                doc.LoadHtml(html);
                var node = doc.DocumentNode.SelectSingleNode($"//input[@name='{name}']");
                return node?.Attributes["value"].Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// 获得该html页面所有的标签
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static HtmlNodes GetAllHtmlNodes(this string html)
        {
            var doc = new HtmlDocument();
            try
            {
                doc.LoadHtml(html);
                return new HtmlNodes(doc.DocumentNode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// 获得该html页面的指定标签
        /// </summary>
        /// <param name="html"></param>
        /// <param name="selectXPath">选择标签开始路径，null则从根目录开始</param>
        /// <param name="where">判断标签是否符合，返回是则符合</param>
        /// <returns></returns>
        public static HtmlNodes GetHtmlNodesWhere(this string html, string selectXPath = null, Func<HtmlNodes, bool> where = null)
        {
            var doc = new HtmlDocument();
            try
            {
                doc.LoadHtml(html);
                var node = selectXPath == null ? doc.DocumentNode : doc.DocumentNode.SelectSingleNode(selectXPath);
                var hd = new HtmlNodes(node);
                if (where == null || where(hd))
                {
                    return hd;
                }
                HtmlNodes result = null;
                hd.RecursionAllChildNodes(where, ref result);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;

        }
        public class HtmlNodes
        {
            public string Name { set; get; }
            public string Text { set; get; }
            public string Html { set; get; }
            private HtmlNodes _parent;
            public HtmlNodes Parent
            {
                get
                {
                    if (_parent == null)
                        _parent = new HtmlNodes(node.ParentNode);
                    return _parent;
                }
            }
            private List<HtmlNodes> _child;
            public List<HtmlNodes> Child
            {
                get
                {
                    if (_child == null)
                    {
                        _child = new List<HtmlNodes>();
                        foreach (var nd in node.ChildNodes)
                        {
                            _child.Add(new HtmlNodes(nd));
                        }
                    }
                    return _child;
                }
            }
            private Dictionary<string, string> _attributes;
            public Dictionary<string, string> Attributes
            {
                get
                {
                    if (_attributes == null)
                    {
                        _attributes = new Dictionary<string, string>();

                        foreach (var na in node.Attributes)
                        {
                            _attributes.Add(na.Name, na.Value);
                        }
                    }
                    return _attributes;
                }
            }
            private HtmlNode node;
            public HtmlNodes(HtmlNode node)
            {
                this.node = node;
                Name = node.Name;
                Text = node.InnerText;
                Html = node.OuterHtml;
            }
            public void RecursionAllChildNodes(Func<HtmlNodes, bool> where, ref HtmlNodes result)
            {
                foreach (var nd in Child)
                {
                    if (result != null) return;
                    if (where == null || where(nd))
                    {
                        result = nd;
                        return;
                    }
                    else
                    {
                        nd.RecursionAllChildNodes(where, ref result);
                    }
                }
            }
        }
        /// <summary>
        /// 获取所有表单数据
        /// </summary>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllInputValue(this string html, string selectXPath = null)
        {
            var dict = new Dictionary<string, string>();
            var doc = new HtmlDocument();
            try
            {
                doc.LoadHtml(html);
                HtmlNodeCollection nodes = null;
                if (selectXPath.IsNullOrWhiteSpace())
                {
                    nodes = doc.DocumentNode.SelectNodes($"//input");
                }
                else
                {
                    nodes = doc.DocumentNode.SelectNodes(selectXPath + $"//input");
                }
                foreach (var n in nodes)
                {
                    var attr = n?.Attributes["value"];
                    if (n != null && !dict.ContainsKey(n.Attributes["name"].Value)) dict.Add(n.Attributes["name"].Value, attr?.Value.HtmlDecode());
                }

                //
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return dict;
        }
        #endregion
        #region CMD
        /// <summary>
        /// 执行cmb命令
        /// </summary>
        /// <param name="str"></param>
        /// <param name="waitTime">等待多少秒超时(waitTime<=0时不超时)</param>
        /// <returns></returns>
        public static string RunCmb(this string str, int waitTime = 10)
        {
            //return Cmb.DefaultCmb.RunWaitReturn(str, 10);
            return str;
        }
        /// <summary>
        /// 执行cmb命令并返回cmb对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Cmb RunNewCmb(this string str)
        {
            var cmb = new Cmb();
            cmb.Run(str);
            return cmb;
        }
        /// <summary>
        /// 执行cmb命令并返回执行结果，输出Cmb对象
        /// </summary>
        /// <param name="str"></param>
        /// <param name="cmb"></param>
        /// <param name="waitTime">等待多少秒超时(waitTime<=0时不超时)</param>
        /// <returns></returns>
        public static string RunNewCmb(this string str, out Cmb cmb, int waitTime = 10)
        {
            cmb = new Cmb();
            //return cmb.RunWaitReturn(str, 10);
            return str;
        }
        #endregion
    }
}

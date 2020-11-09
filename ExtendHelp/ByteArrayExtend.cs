using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace ExtendHelp
{
    public static class ByteArrayExtend
    {
        /// <summary>
        /// 使用HMACSHA256进行加密
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] HMACSHA256_Encrypt(this byte[] bs, byte[] key)
        {
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                byte[] computedHash = hmac.ComputeHash(bs);
                return computedHash;
            }
        }
        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static byte[] SHA256_Encrypt(this byte[] bs)
        {
            HashAlgorithm iSha = new SHA256CryptoServiceProvider();
            return iSha.ComputeHash(bs);
        }
        /// <summary>
        /// 判断是否相同
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="bs2"></param>
        /// <returns></returns>
        public static bool ValueEquals(this byte[] bs, byte[] bs2)
        {
            if (bs.Length != bs.Length)
            {
                return false;
            }
            for (int i = 0; i < bs.Length; i++)
            {
                if (bs[i] != bs2[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static byte[] AesCbcDecrypt(this byte[] data, byte[] key, byte[] iv)
        {
            var rijndaelCipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = key.Length * 8,
                BlockSize = iv.Length * 8
            };
            rijndaelCipher.Key = key;
            rijndaelCipher.IV = iv;
            var transform = rijndaelCipher.CreateDecryptor();
            var plainText = transform.TransformFinalBlock(data, 0, data.Length);
            return plainText;
        }
        public static byte[] AesCbcEncrypt(this byte[] data, byte[] key, byte[] iv)
        {
            var rijndaelCipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = key.Length * 8,
                BlockSize = iv.Length * 8
            };
            rijndaelCipher.Key = key;
            rijndaelCipher.IV = iv;
            var transform = rijndaelCipher.CreateEncryptor();
            var plainText = transform.TransformFinalBlock(data, 0, data.Length);
            return plainText;
        }
        public static byte[] AesCbcDecrypt(this byte[] data, byte[] key)
        {
            return AesCbcDecrypt(data.Skip(16).ToArray(), key, data.Take(16).ToArray());
        }
    }
}

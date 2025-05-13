using GRE.Shared.Model;
using GRE.Shared.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.CommonMethods
{
    public static class CommonMethods
    {
        

        public static TokenModel GetTokenDataModel(HttpContext request)
        {
            TokenModel token = new TokenModel();
            StringValues authorizationToken;
            StringValues ipAddress;
            JsonModel response = new JsonModel();
            var authHeader = request.Request.Headers.TryGetValue("Authorization", out authorizationToken);
            var authToken = authorizationToken.ToString().Replace("Bearer", "").Trim();
            //ipAddress = request.Connection.LocalIpAddress.ToString();
            ipAddress = request.Connection.RemoteIpAddress?.ToString();


            try
            {
                if (authToken != null)
                {
                    var encryptData = GetDataFromToken(authToken);

                    if (encryptData != null && encryptData.Claims != null)
                    {
                        string AccessToken = GetRefreshToken(encryptData);

                        token = new TokenModel();
                        token.UserID = Convert.ToString(encryptData.Claims[0].Value);
                        //token.LocationID = !string.IsNullOrEmpty(locationID) ? Convert.ToInt32(locationID) : !string.IsNullOrEmpty(encryptData.Claims[5].Value) ? Convert.ToInt32(encryptData.Claims[5].Value) : 0; //it should be from front end
                        token.IPAddress = ipAddress;
                        token.AccessToken = AccessToken;

                    }
                }
                token.Request = request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return token;
        }


        /// <summary>
        /// get user data from token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static dynamic GetDataFromToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                return handler.ReadToken(token);
            }
            catch (Exception)
            {
                return null;
            }

        }


        public static string GetRefreshToken(dynamic encryptData)
        {
            JwtIssuerOptions _jwtOptions = new JwtIssuerOptions();
            //create claim for login user
            var claims = encryptData.Claims;

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SigningCredentials);

            //add login user's role in token
            //jwt.Payload["roles"] = encryptData.Claims[5].Value; //array of user roles

            //token.LocationID = defaultLocation;
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public static class GREConnectionStringEnum
        {
            /// <summary>
            /// Production
            /// </summary>
            //public const string Server = "";
            //public const string Database = "";
            //public const string User = "";                       
            //public const string Password = ""; 

        }


        public static string Encrypt(string clearText)
        {
            string EncryptionKey = EncryptDecryptKey.Key;
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Dispose();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        /// <summary>
        /// decrypt the encrypt data
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return "";
            string EncryptionKey = EncryptDecryptKey.Key;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Dispose();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static class EncryptDecryptKey
        {
            public  static string Key { get; set; }
            public  static string PHIKey { get; set; }
            public static void Initialize(IConfiguration configuration)
            {
                Key = configuration["EncryptionKeys:Key"];
                PHIKey = configuration["EncryptionKeys:PHIKey"];
            }
        }






        //public static string EncryptString(string text)
        //{
        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        //        aesAlg.IV = Encoding.UTF8.GetBytes(iv);

        //        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
        //        using (MemoryStream msEncrypt = new MemoryStream())
        //        {
        //            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
        //            {
        //                swEncrypt.Write(text);
        //            }
        //            return Convert.ToBase64String(msEncrypt.ToArray());
        //        }
        //    }
        //}

        //public static string DecryptString(string cipherText)
        //{
        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        //        aesAlg.IV = Encoding.UTF8.GetBytes(iv);

        //        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
        //        using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
        //        {
        //            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        //            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
        //            {
        //                return srDecrypt.ReadToEnd();
        //            }
        //        }
        //    }
        //}
        



    }
}

using Common.Contract;
using Common.Models;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;

namespace DataLogic
{
    /// <summary>
    /// This uses a simple text so store some data. It can be extended to a database.
    /// </summary>
    public class DataHelper : IDataHelper
    {
        private readonly IConfigurations configurations;
        private readonly ILog logger;

        public DataHelper(IConfigurations configurations, ILog logger)
        {
            this.configurations = configurations;
            this.logger = logger;
        }

        public CredentialCache GetCredential(string url, string userName, string password)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential(userName, password));
            return credentialCache;
        }

        /// <summary>
        /// Can be extended for a db.
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public bool SaveCredentials(Credentials credentials)
        {
            try
            {
                Encrypt(credentials);
                return true;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex);
                return false;
            }
        }

        public void Encrypt<T>(T data)
        {
            var credentialsJson = JsonConvert.SerializeObject(data);
            var keyGenerator = new Rfc2898DeriveBytes(this.configurations.CommonSettings.EncryptPassword, this.configurations.CommonSettings.SaltSize);
            var rijndael = Rijndael.Create();

            // BlockSize, KeySize in bit --> divide by 8  
            rijndael.IV = keyGenerator.GetBytes(rijndael.BlockSize / 8);
            rijndael.Key = keyGenerator.GetBytes(rijndael.KeySize / 8);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                // write random salt
                memoryStream.Write(keyGenerator.Salt, 0, this.configurations.CommonSettings.SaltSize);

                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(credentialsJson);
                    }

                    File.WriteAllBytes(this.configurations.CommonSettings.FileName, memoryStream.ToArray());
                }
            }
        }

        public string Decrypt(FileInfo sourceFile)
        {
            // read salt  
            try
            {
                var fileStream = sourceFile.OpenRead();
                var salt = new byte[this.configurations.CommonSettings.SaltSize];
                fileStream.Read(salt, 0, this.configurations.CommonSettings.SaltSize);

                // initialize algorithm with salt  
                var keyGenerator = new Rfc2898DeriveBytes(this.configurations.CommonSettings.EncryptPassword, salt);
                var rijndael = Rijndael.Create();
                rijndael.IV = keyGenerator.GetBytes(rijndael.BlockSize / 8);
                rijndael.Key = keyGenerator.GetBytes(rijndael.KeySize / 8);

                // decrypt  
                using (var cryptoStream = new CryptoStream(fileStream, rijndael.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    // read data
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex);
                return "{UserName:\"\", Password:\"\"}";
            }

        }

        public Credentials GetCredentials()
        {
            return JsonConvert.DeserializeObject<Credentials>(Decrypt(new FileInfo(this.configurations.CommonSettings.FileName)));
        }

        public void SaveInFile(string fileName, string data)
        {
            using (StreamWriter save = new StreamWriter(fileName, true))
            {
                save.WriteLine(data);
            }
        }

        public List<string> GetSavedFileDataInEachLine(string fileName)
        {
            List<string> result = new List<string>();

            using (var sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }
            return File.ReadAllLines(fileName).ToList();
        }
    }
}

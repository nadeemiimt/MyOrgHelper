using Common.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Common.Contract
{
    public interface IDataHelper
    {
        CredentialCache GetCredential(string url, string userName, string password);

        bool SaveCredentials(Credentials credentials);

        void Encrypt<T>(T data);

        string Decrypt(FileInfo sourceFiled);

        Credentials GetCredentials();

        void SaveInFile(string fileName, string data);

        List<string> GetSavedFileDataInEachLine(string fileName);
    }
}

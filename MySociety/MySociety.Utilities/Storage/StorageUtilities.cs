namespace MySociety.Utilities.Storage
{
    using System.IO;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Auth;
    using Microsoft.Azure.Storage.File;

    public class StorageUtilities : IStorageUtilities
    {
        private StorageConfiguration _storageConfiguration;

        public StorageUtilities(StorageConfiguration storageConfiguration)
        {
            this._storageConfiguration = storageConfiguration;
        }

        public string UploadStorageFile(string fileName, Stream fileStream)
        {
            CloudFileDirectory rootDirectory = this.StorageCredentialConfigure();
            CloudFile archivo = rootDirectory.GetFileReference(string.Concat(fileName, ".jpg"));

            archivo.UploadFromStream(fileStream);
            if (archivo.Exists())
            {
                return archivo.StorageUri.PrimaryUri.AbsoluteUri;
            }

            return null;
        }

        public bool ValidateFileExistStorage(string urlFile)
        {
            if (!string.IsNullOrEmpty(urlFile))
            {
                CloudFileDirectory rootDirectory = this.StorageCredentialConfigure();
                CloudFile archivo = rootDirectory.GetFileReference(urlFile);

                return archivo.Exists();
            }

            return false;
        }

        private CloudFileDirectory StorageCredentialConfigure()
        {
            StorageCredentials storageCredential = new StorageCredentials(this._storageConfiguration.StorageAccount, this._storageConfiguration.StorageSuscriptionKey);
            CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredential, true);

            CloudFileClient storageClient = storageAccount.CreateCloudFileClient();
            CloudFileShare sharedFolder = storageClient.GetShareReference(this._storageConfiguration.ApplicationFolder.ToLower());

            CloudFileDirectory rootDirectory = sharedFolder.GetRootDirectoryReference();
            return rootDirectory;
        }
    }
}

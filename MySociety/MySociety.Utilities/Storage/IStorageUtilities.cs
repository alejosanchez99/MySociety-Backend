namespace MySociety.Utilities.Storage
{
    using System.IO;

    public interface IStorageUtilities
    {
        string UploadStorageFile(string fileName, Stream fileStream);

        bool ValidateFileExistStorage(string urlFile);
    }
}

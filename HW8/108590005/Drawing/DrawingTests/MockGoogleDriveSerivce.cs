using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;

namespace DrawingTests
{
    public class MockGoogleDriveSerivce : IGoogleDriveService
    {
        // Delete File
        public void DeleteFile(string fileId)
        {
            File.Delete(fileId);
        }

        // Download File
        public void DownloadFile(string fileName, string downloadPath)
        {
            
        }

        // Upload File
        public void UploadFile(string uploadFileName, string contentType)
        {

        }
    }
}

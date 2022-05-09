    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;

namespace DrawingModel
{
    public interface IGoogleDriveService
    {
        /*
        /// <summary>
        /// 查詢Google Drive 根目錄的檔案
        /// </summary>
        /// <returns>Google Drive File List</returns>
        List<Google.Apis.Drive.v2.Data.File> ListRootFileAndFolder();*/

        /// <summary>
        /// 上傳檔案
        /// </summary>
        /// <param name="uploadFileName">上傳的檔案名稱 </param>
        /// <param name="contentType">上傳的檔案種類，請參考MIME Type : http://www.iana.org/assignments/media-types/media-types.xhtml </param>
        /// <param name="uploadProgressEventHandler"> 上傳進度改變時呼叫的函式</param>
        /// <param name="responseReceivedEventHandler">收到回應時呼叫的函式 </param>
        /// <returns>上傳成功，回傳上傳成功的 Google Drive 格式之File</returns>
        void UploadFile(string uploadFileName, string contentType);

        /// <summary>
        /// 下載檔案
        /// </summary>
        /// <param name="fileToDownload">欲下載的檔案(Google Drive File) 一般會從List取得</param>
        /// <param name="downloadPath">下載到路徑</param>
        /// <param name="downloadProgressChangedEventHandler">當下載進度改變時，呼叫這個函式</param>
        void DownloadFile(string fileName, string downloadPath);

        /// <summary>
        /// 刪除符合FileID的檔案
        /// </summary>
        /// <param name="fileId">欲刪除檔案的FileID</param>
        void DeleteFile(string fileId);

        /*
        /// <summary>
        /// 更新指定FileID的檔案
        /// </summary>
        /// <param name="fileName">欲上傳至Google Drive並覆蓋在Google Drive上舊版檔案的檔案位置 </param>
        /// <param name="fileId">存在於Google Drive 舊版檔案的FileID </param>
        /// <param name="contentType">MIME Type</param>
        /// <returns>如更新成功，回傳更新後的Google Drive File</returns>
        Google.Apis.Drive.v2.Data.File UpdateFile(string fileName, string fileId, string contentType);*/
    }
}

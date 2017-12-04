using System.Text;
using System.Web;

/// <summary>
/// 拡張メソッドを実装
/// </summary>
public static class DownloadExtension
{
    /// <summary>
    /// ダウンロード
    /// </summary>
    /// <param name="response"></param>
    /// <param name="downloadHandler"></param>
    public static void Download(this HttpResponse response, IDownloadHandler downloadHandler)
    {
        response.HeaderEncoding = downloadHandler.Encode;
        response.ContentEncoding = downloadHandler.Encode;
        response.ContentType = downloadHandler.ContentType;
        response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(downloadHandler.FileName, Encoding.UTF8));
        downloadHandler.SetWriteData(response);
        response.Flush();
        response.End();
    }
}

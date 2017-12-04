using System.Text;
using System.Web;

/// <summary>
/// ダウンロード用インターフェース
/// </summary>
public interface IDownloadHandler
{
    /// <summary>
    /// ダウンロード時のエンコード
    /// </summary>
    Encoding Encode { get; }

    /// <summary>
    /// ファイル名
    /// </summary>
    string FileName { get; set; }

    /// <summary>
    /// DL時のタイプ
    /// </summary>
    string ContentType { get; }

    /// <summary>
    /// 書込内容
    /// </summary>
    /// <returns></returns>
    void SetWriteData(HttpResponse response);
}
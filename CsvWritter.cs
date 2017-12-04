using System.Data;
using System.Text;
using System.Web;

/// <summary>
/// CsvWritter の概要の説明です
/// </summary>
public class CsvWritter : IDownloadHandler
{
    #region property

    /// <summary>
    /// CSV内容
    /// </summary>
    private StringBuilder CsvText { get; set; }

    /// <summary>
    /// ファイル名
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// DLタイプ
    /// </summary>
    public string ContentType
    {
        get { return "text/comma-separated-values"; }
    }

    /// <summary>
    /// ダウンロード時のエンコード
    /// </summary>
    public Encoding Encode
    {
        get { return Encoding.GetEncoding("Shift_JIS"); }
    }

    #endregion

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public CsvWritter()
    {
        this.CsvText = new StringBuilder();

    }

    #region method

    /// <summary>
    /// テーブル内容書込
    /// </summary>
    /// <param name="dataTable"></param>
    public void Write(DataTable dataTable)
    {
        foreach (DataRow dataRow in dataTable.Rows)
            this.CsvText.AppendLine("\"" + string.Join("\",\"", dataRow.ItemArray) + "\"");
    }

    /// <summary>
    /// CSVデータ書込
    /// </summary>
    /// <param name="csvDataHandler"></param>
    public void Write(ICsvDataHandler csvDataHandler, string condition)
    {
        this.Write(csvDataHandler.GetCsvData(condition));
    }

    /// <summary>
    /// レスポンスにデータを書込
    /// </summary>
    /// <returns></returns>
    void IDownloadHandler.SetWriteData(HttpResponse response)
    {
        response.Write(this.CsvText.ToString());
    }

    #endregion

}
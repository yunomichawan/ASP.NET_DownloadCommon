using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// CSVデータ取得インターフェース
/// </summary>
public interface ICsvDataHandler
{
    /// <summary>
    /// CSVデータ取得
    /// </summary>
    /// <param name="condition">取得条件</param>
    /// <returns></returns>
    DataTable GetCsvData(string condition);
}
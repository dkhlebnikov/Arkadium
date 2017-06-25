using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; 
using HtmlAgilityPack;

namespace ArkadiumTest
{
    public class HtmlTableParser
    {
        /// <summary>
        /// Возвращает DataSet со всеми таблицми, которые найдет на указанной странице по указанному пути
        /// </summary>
        /// <param name="urlString">URL страницы откуда собирать таблицы</param> 
        /// <param name="xPath">xPath до таблицы, по умолчанию @"//table" - соберет все таблицы что найдет на странице</param>
        /// <returns></returns>
        public static DataSet GetDataTablesFromHtml(string urlString, string xPath = @"//table")
        {
            var ds = new DataSet();
            var url = urlString;
            var web = new HtmlWeb();
            var htmlDocument = web.Load(url);
 
            // var tableNodes = htmlDocument.DocumentNode.SelectNodes(@"//*[@id=""mw-content-text""]/div/table[3]"); // xPath до таблицы на тестовой странице по умолчанию

            var tableNodes = htmlDocument.DocumentNode.SelectNodes(xPath);
         
            if (tableNodes != null)
            {
                foreach (var item in tableNodes)
                {
                    var dt = new DataTable();

                    IEnumerable<HtmlNode> trNodes;
                    var theadbodyNodes = item.ChildNodes.Where(x => x.Name == "thead" || x.Name == "tbody"); 

                    if (theadbodyNodes.Any())
                    {
                        trNodes = null;
                        foreach (var thb in theadbodyNodes)
                        {
                            if (trNodes == null)
                            {
                                trNodes = thb.ChildNodes.Where(x => x.Name == "tr" || x.Name == "th");
                            }
                            else
                            {
                                trNodes = trNodes.Concat(thb.ChildNodes.Where(x => x.Name == "tr" || x.Name == "th"));
                            }
                        }
                    }
                    else
                    {
                        trNodes = item.ChildNodes.Where(x => x.Name == "tr" || x.Name == "th");
                    } 

                    if (trNodes != null && trNodes.Any())
                    { 
                        var colCount = 0;
                        var headerNode =
                            trNodes.First().ChildNodes.Where(x => x.Name == "td" || x.Name == "th").ToArray();

                        foreach (var header in headerNode)
                        {
                            if (header.Attributes.Contains("colspan"))
                            {
                                colCount += Convert.ToInt32(header.Attributes["colspan"].Value);
                            }
                            else
                            {
                                colCount++;
                            }
                        } 

                        while (dt.Columns.Count < colCount)
                        {
                            dt.Columns.Add();
                        }

                        for (var t = 0; t < trNodes.Count(); t++)
                        {
                            var dr = dt.NewRow();
                            dt.Rows.Add(dr);
                        }

                        int i = 0;
                        foreach (var item2 in trNodes)
                        {
                            var tdNodes = item2.ChildNodes.Where(x => x.Name == "td" || x.Name == "th").ToArray();
                            var j = 0;
                            foreach (var td in tdNodes)  
                            { 
                                for (; j < colCount; j++)
                                {
                                    if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                                    {
                                        dt.Rows[i][j] = td.InnerText; 
                                        break;
                                    }
                                }

                                if (td.Attributes.Contains("colspan") && td.Attributes.Contains("rowspan"))
                                {
                                    for (var k = 0; k < Convert.ToInt32(td.Attributes["colspan"].Value); k++)
                                    {
                                        for (var n = 0;  n < Convert.ToInt32(td.Attributes["rowspan"].Value) &&  j + k < dt.Columns.Count; n++)
                                        {  
                                            dt.Rows[i + n][j + k] = "&#160;"; 
                                        } 
                                    }

                                    dt.Rows[i][j] = td.InnerText;
                                    j = Convert.ToInt32(td.Attributes["colspan"].Value) + j - 1;
                                }

                                if (td.Attributes.Contains("colspan") && !td.Attributes.Contains("rowspan"))
                                {
                                    for (var k = 0; k < Convert.ToInt32(td.Attributes["colspan"].Value) && j + k < dt.Columns.Count; k++)
                                    {
                                        dt.Rows[i][j + k] = "&#160;";
                                    }

                                    dt.Rows[i][j] = td.InnerText;
                                    j = Convert.ToInt32(td.Attributes["colspan"].Value) + j - 1; 
                                }

                                if (td.Attributes.Contains("rowspan") && !td.Attributes.Contains("colspan"))
                                {
                                    for (var k = 0; k < Convert.ToInt32(td.Attributes["rowspan"].Value); k++)
                                    { 
                                        dt.Rows[i + k][j] = "&#160;";
                                    }
                                    dt.Rows[i][j] = td.InnerText;
                                } 
                                j++;
                            }
                            i++;
                        }
                    }
                    PrepereDataTable(dt);
                    ds.Tables.Add(dt);
                } 
            }
            return ds;
        }

        /// <summary>
        /// Процедура преобразовывает таблицу с результатами к требуемому по заданию виду
        /// </summary>
        /// <param name="boxDataTable">изначальная таблица возвращаемая процедурой GetDataTablesFromHtml</param>
        /// <returns></returns>
        public static DataTable BoxResultPrepare(DataTable boxDataTable)
        {
            if(boxDataTable == null || boxDataTable.Rows == null || boxDataTable.Columns == null)
                throw new Exception("таблица пуста, подготовка невозможна");

            var dt = new DataTable();
            dt.Columns.Add("Round name");
            dt.Columns.Add("Boxer name");
            dt.Columns.Add("Country");
            dt.Columns.Add("Result");

            for (var j = 0; j < boxDataTable.Columns.Count - 1; j = j + 2)
            { 
                for (var i = 1; i < boxDataTable.Rows.Count; i++)
                {  
                    if (!string.IsNullOrEmpty(boxDataTable.Rows[i][j].ToString()) && boxDataTable.Rows[i][j].ToString().IndexOf("(") > 0)
                    {
                        var dr = dt.NewRow();
                        var roundName = boxDataTable.Rows[0][j].ToString();
                        var boxerName = boxDataTable.Rows[i][j].ToString().Substring(0, boxDataTable.Rows[i][j].ToString().IndexOf("("));
                        var country = boxDataTable.Rows[i][j].ToString().Substring(boxDataTable.Rows[i][j].ToString().IndexOf("(") + 1, 3);
                        var result = string.IsNullOrEmpty(boxDataTable.Rows[i][j + 1].ToString())
                            ? "lose"
                            : "win " + boxDataTable.Rows[i][j + 1];

                        dr["Round name"] = roundName;
                        dr["Boxer name"] = boxerName;
                        dr["Country"] = country;
                        dr["Result"] = result;
                        dt.Rows.Add(dr);
                    } 
                } 
            }

            return dt;
        }

        /// <summary>
        /// Вспомогательный метод. Удаляет пустые строки и столбцы в таблице
        /// </summary>
        /// <param name="dt">таблица для обработки</param>
        private static void PrepereDataTable(DataTable dt)
        { 
            bool isEmpty;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                isEmpty = true;
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()) &&
                        !dt.Rows[i][j].ToString().Equals("&#160;"))
                    {
                        isEmpty = false;
                        break;
                    }

                }
                if (isEmpty)
                {
                    dt.Rows.RemoveAt(i);
                    i--;
                }
            }

            for (var j = 0; j < dt.Columns.Count; j++)
            {
                isEmpty = true;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()) &&
                        !dt.Rows[i][j].ToString().Equals("&#160;"))
                    {
                        isEmpty = false;
                        break;
                    }

                }
                if (isEmpty)
                {
                    dt.Columns.RemoveAt(j);
                    j--;
                }
            }

            for (var i = 0; i < dt.Rows.Count; i++)
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j].ToString().Equals("&#160;"))
                    {
                        dt.Rows[i][j] = string.Empty;
                    }

                    if (dt.Rows[i][j].ToString().StartsWith("&#160;"))
                        dt.Rows[i][j] = dt.Rows[i][j].ToString().Substring(6);

                    dt.Rows[i][j] = dt.Rows[i][j].ToString().Replace("&#160;", " ");
                    dt.Rows[i][j] = dt.Rows[i][j].ToString().Replace("&nbsp;", " ");
                }

            for (var j = 1; j < dt.Columns.Count; j++)
            {
                if (string.IsNullOrEmpty(dt.Rows[0][j].ToString()))
                {
                    dt.Rows[0][j] = dt.Rows[0][j - 1];
                }
            }
        } 
    }
} 

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ArkadiumTest
{
    public class DataWriter
    {
        public static bool SaveDGVToCSVfile(string filename, DataGridView table)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filename, false, Encoding.Unicode);

                List<int> col_n = new List<int>();
                foreach (DataGridViewColumn col in table.Columns)
                    if (col.Visible)
                    {
                        sw.Write(col.HeaderText + "\t");
                        col_n.Add(col.Index);
                    }
                sw.WriteLine();
                int x = table.RowCount;
                if (table.AllowUserToAddRows) x--;

                for (int i = 0; i < x; i++)
                {
                    for (int y = 0; y < col_n.Count; y++)
                        sw.Write(table[col_n[y], i].Value + "\t");
                    sw.Write(" \r\n");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }
    }
}
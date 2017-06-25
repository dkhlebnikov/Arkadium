using System; 
using System.Data; 
using System.Windows.Forms; 

namespace ArkadiumTest
{
    public partial class MainForm : Form
    {
        private  DataSet dataSet = new DataSet();
        public MainForm()
        {
            InitializeComponent();
        }
         
        private void btnGetBoxResults_Click(object sender, EventArgs e)
        {
            var strURL = @"https://en.wikipedia.org/wiki/Boxing_at_the_1948_Summer_Olympics_%E2%80%93_Men%27s_heavyweight";
            dgvBoxResult.DataSource = HtmlTableParser.BoxResultPrepare(HtmlTableParser.GetDataTablesFromHtml(tbxURL.Text).Tables[3]);
            //  dgvBoxResult.DataSource = (HtmlTableParser.GetDataTablesFromHtml(strURL).Tables[3]); 

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataWriter.SaveDGVToCSVfile(saveFileDialog.FileName, dgvBoxResult);
                MessageBox.Show("Данные сохранены");
            }
        }
         

        private void btnGetTabs_Click(object sender, EventArgs e)
        {
            dataSet = HtmlTableParser.GetDataTablesFromHtml(tbxURL.Text);
            cbxTabNumber.Items.Clear();
            while (cbxTabNumber.Items.Count < dataSet.Tables.Count)
                cbxTabNumber.Items.Add(cbxTabNumber.Items.Count + 1);

            if (cbxTabNumber.Items.Count > 0)
                cbxTabNumber.SelectedIndex = 0;

        }

        private void btnSowTable_Click(object sender, EventArgs e)
        {
            if (cbxTabNumber.Text != null && dataSet.Tables.Count > 0)
                dgvSomeTable.DataSource = dataSet.Tables[Convert.ToInt32(cbxTabNumber.Text)-1];
            else
            {
                MessageBox.Show(@"Таблицы не получены со страницы или отсутсвуют на ней");
            } 
        }

        private void tbxURL_TextChanged(object sender, EventArgs e)
        {
            cbxTabNumber.Items.Clear();
        }
    }
}

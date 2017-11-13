using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WaterSimDCDC;
using WaterSimDCDC.Controls.Dotspatial;


namespace TestDotSpatialControl
{
    
    public partial class Form1 : Form
    {
        WaterSimManager WSim;
        OleDbConnection DbConnect;
        public Form1()
        {

            InitializeComponent();
            WSim = new WaterSimManager("", "");
            mapDashboardControl1.ParameterManager = WSim.ParamManager;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dbTool.SQLServer Server = WaterSimManager_DB.SQLServer;
                try
                {
                    DbConnect = dbTool.OpenDatabase(openFileDialog1.FileName, dbTool.OleDbConnectionStringForSQLServer(Server));
                    mapDashboardControl1.DbConnection = DbConnect;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not open database " + openFileDialog1.FileName + " Error: " + ex.Message);
                }
            }
  
        }
    }
}

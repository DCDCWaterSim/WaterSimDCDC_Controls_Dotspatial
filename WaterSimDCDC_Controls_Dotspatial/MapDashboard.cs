using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using DotSpatial.Controls.Header;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using WaterSimDCDC;

using UniDB;


namespace WaterSimDCDC.Controls.Dotspatial
{

    public partial class MapDashboardControl : UserControl
    {
        string FCurrentScenario = "";
        DataTable FMapDataTable;
        string FDataDirectory = "";
        string FShapeFilename =    "";
        bool BaseShapeLoaded = false;
        UniDbConnection FDbConnection;
        bool FShowTablenameToolBar = true;
        List<string> FTableNames = new List<string>();
        const string NOSCENARIOS = "No Scenarios Names In Table";
        const string FIRSTSCENARIO = "First Scenario in Table";
        internal SQLServer SQLServer = SQLServer.stAccess;
        string FCurrentTablename = "";
      
        WaterSimDCDC.ShadowParameterManager ParmManager;

        MapProgressClass MapProgressHandler;

        public MapDashboardControl()
        {
            InitializeComponent();

            // create progress handler and assign to map and legend
            MapProgressHandler = new MapProgressClass();
            MapProgressHandler.SetControls( MapDashboardStatusLabel1, MapDashboardSatusProgressBar, MapDashboardStatusLabel2);
            ProviderMap.ProgressHandler = MapProgressHandler;
            ProviderMapLegend.ProgressHandler = MapProgressHandler;
            
            // if map is in default location load it now
            if (File.Exists(FDataDirectory + FShapeFilename))
            {
                try
                {
                    AddProviderShapeFileLayers();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Loading Shape File " + FDataDirectory + FShapeFilename + "  : " + e.Message);
                }
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary> Gets or sets the pathname of the data directory where Shapefile can be found. </summary>
        ///<remarks>This must be set if the Shapefile files are locate some place other than the defualt, which is in a directory "MapData" in the executing directory ofthe application</remarks>
        /// <value> The pathname of the data directory. </value>
        ///-------------------------------------------------------------------------------------------------

        public string DataDirectory
        {
            get { return FDataDirectory; }
            set
            {
                FDataDirectory = value;
                string temp = UniDB.FileSupport.AddPaths(value, FShapeFilename);

                if (File.Exists(temp))
                {
                    AddProviderShapeFileLayers();
                }
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary> Gets or sets the filename of the shape file. </summary>
        /// <remarks>This must be set to the name of the provider shape file if it is different than the default filename.</remarks>
         
        /// <value> The filename of the shape file. </value>
        ///-------------------------------------------------------------------------------------------------

        public string ShapeFilename
        {
            get { return FShapeFilename; }
            set
            {
                // if valid file, load it, otherwise ignore
                string temp = "";
                if (FDataDirectory != "")
                    temp = UniDB.FileSupport.AddPaths(FDataDirectory, value);
                else
                    temp = value;
                if (File.Exists(temp))
                {
                    FDataDirectory = Path.GetDirectoryName(value);// .GetPathRoot(value); // Path.GetFullPath(value);

                    FShapeFilename = Path.GetFileName(value);
                    AddProviderShapeFileLayers();
                }
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary> Gets or sets the database connection. </summary>
        /// <remarks>This must be set in order to create a map based on fieldname</remarks>
        /// <value> The database connection. </value>
        ///-------------------------------------------------------------------------------------------------

        public UniDbConnection DbConnection
        {
            get { return FDbConnection; }
            set 
            { 
                bool iserr = false;
                string errMessage = "";
                if (value != null)
                {
                    if (value.State != ConnectionState.Open)
                    {
                        throw new Exception("Database connection must be open");
                    }
                    if (FShowTablenameToolBar)
                    {
                        TableNames = value.GetTableNames(ref iserr, ref errMessage);
                        if (iserr)
                        {
                            throw new Exception("Unable to get a list of tables from the database. " + errMessage);
                        }
                    }
                    FDbConnection = value;
                }
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary> Gets or sets the WatewSim parameter manager. </summary>
        ///
        /// <value> The parameter manager. </value>
        ///-------------------------------------------------------------------------------------------------

        public WaterSimDCDC.ParameterManagerClass ParameterManager
        {
            get {return ParmManager; }
            set
            {
                if (value!=null)
                {
                    ParmManager = new WaterSimDCDC.ShadowParameterManager(value);
                }
            }
        }

        public string SelectedScenario
        {
            get { return FCurrentScenario; }
            set
            {
                FCurrentScenario = value;
            }
        }
        ///-------------------------------------------------------------------------------------------------
        /// <summary> Sets up the data table. </summary>
        ///
        /// <param name="Tablename">    The tablename. </param>
        /// <param name="TheDataTable"> the data table. </param>
        /// <param name="ParmList">     List of parameters. </param>
        /// <param name="YearList">     List of years. </param>
        ///-------------------------------------------------------------------------------------------------

        public void SetUpDataTable(string Tablename, DataTable TheDataTable, List<string> ParmList, List<string> YearList)
        {
            ShowTablenameToolbar = false;
            
            FCurrentTablename = Tablename;
            FMapDataTable = TheDataTable;
            
            MapParameterListBox.Items.Clear();
            foreach (string str in ParmList)
                MapParameterListBox.Items.Add(str);

            comboBoxYear.Items.Clear();
            foreach (string str in YearList)
                comboBoxYear.Items.Add(str);
            comboBoxYear.SelectedIndex = comboBoxYear.Items.Count - 1;

        }
        ///-------------------------------------------------------------------------------------------------
        /// <summary> Gets the DataTable that contains data to be mapped. </summary>
        ///<remarks> The DataTable can either be referenced using this property, or the Tablename combobox can be used to load a DataTable</remarks>
        /// <value> DataTable. </value>
        ///-------------------------------------------------------------------------------------------------

        public DataTable MapData
        {
            get { return FMapDataTable; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary> Gets or sets a list of names of the tdata ables in the database. </summary>
        ///
        /// <value> A list of names of the tables. </value>
        ///-------------------------------------------------------------------------------------------------

        public List<string> TableNames
        {
            get { return FTableNames; }
            set
            {
                FTableNames.Clear();
                ComboBoxMapTablename.Items.Clear();
                foreach (string str in value)
                {
                    FTableNames.Add(str);
                    ComboBoxMapTablename.Items.Add(str);
                }
            }
        }
        ///-------------------------------------------------------------------------------------------------
        /// <summary> Gets or sets a value indicating whether the tablename toolbar is shown.
        ///     </summary>
        ///
        /// <value> true if show tablename toolbar, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool ShowTablenameToolbar
        {
            get { return FShowTablenameToolBar; }
            set
            {
                FShowTablenameToolBar = value;
                RefreshTablenameToolBar();
            }
        }
        //----------------------------------------------------
        int TBPanelTop = 0;
        int MPPanelTop = 32;
        private void RefreshTablenameToolBar()
        {
            if (FShowTablenameToolBar)
            {

                TableNameToolBar.Show();
                
                //TableNameToolBar.Visible = true;
                //TableNameToolBar.Enabled = true;
                PanelMap.Location = new Point(PanelMap.Location.X, MPPanelTop);
                panelParameters.Location = new Point(panelParameters.Location.X,MPPanelTop);    
            }
            else
            {
                TBPanelTop = TableNameToolBar.Location.Y;
                MPPanelTop = PanelMap.Location.Y;

                TableNameToolBar.Hide();
                
                PanelMap.Location = new Point(PanelMap.Location.X, 0);
                panelParameters.Location = new Point(panelParameters.Location.X,0);
//                TableNameToolBar.Visible = false;
  //              TableNameToolBar.Enabled = false;

            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary> Gets or sets the current tablename. </summary>
        ///
        /// <value> The current tablename. </value>
        ///-------------------------------------------------------------------------------------------------

        public string CurrentTablename
        {
            get { return FCurrentTablename; }
            set
            {
                FCurrentTablename = value;
            }
        }

  
        //-------------------------------------------------------------------------
        private void MapParameterListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // canot do this until Base shape loaded
            if (!BaseShapeLoaded)
            {
                MessageBox.Show("A valid directory and base shape filename must be specified!");
            }
            else
            {
                // get item index
                int index = e.Index;
                // get item text
                string Fieldname = MapParameterListBox.Items[index].ToString();
                int SepIndex = Fieldname.IndexOf(" : ");
                Fieldname = Fieldname.Substring(0, SepIndex);
                // if check then delete from map
                
                if (MapParameterListBox.GetItemCheckState(index) == CheckState.Checked)
                {
                    for (int i = 0; i < ProviderMap.Layers.Count; i++)
                    {
                        string Target = ProviderMap.Layers[i].LegendText;
                        int mindex = Target.IndexOf(" : ");
                        string ParmFieldname = "";
                        if (mindex > 0)
                            ParmFieldname = Target.Substring(0, SepIndex);
                        else
                            ParmFieldname = Target;
                        if (ParmFieldname == Fieldname)
                        {
                            ProviderMap.Layers.Remove(ProviderMap.Layers[i]);
                            break;
                        }
                    }
                }
                else
                {
                    int year = Convert.ToInt32(comboBoxYear.Text);
                    System.Windows.Forms.Cursor CurrentCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    ReportStatus(0, 0, "Loading Map", FCurrentScenario + " : " + Fieldname);

                    AddFieldLayer(Fieldname, year, FCurrentScenario);
                    this.Cursor = CurrentCursor;
                    ReportStatus(0, 0, "Done Loading Map", "");

                }
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Map Routines
        // +++++++++++++++++++++++++++++++++++++++++++++++++++++
        // 
        public void ClearMapLayers()
        {
            for (int i = ProviderMap.Layers.Count - 1; i > 0; i--)
            {
                IMapLayer item = ProviderMap.Layers[i];
                ProviderMap.Layers.Remove(item);
            }

        }
        //------------------------------------------
        internal MapPolygonLayer AddProviderShapeFile(string Name)
        {
            MapPolygonLayer MyLayer = null;
            if (BaseShapeLoaded)
            {
                try
                {
                    string FullPath = UniDB.FileSupport.AddPaths(FDataDirectory, FShapeFilename);
                    MyLayer = (MapPolygonLayer)ProviderMap.AddLayer(FullPath);
                    MyLayer.LegendText = Name;
                    DataTable LayerDT = MyLayer.DataSet.DataTable;

                    if (MyLayer == null)
                    {
                        MessageBox.Show("The Base ShapeFile is not a polygon layer.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Loading Shape File:[ " + FDataDirectory + FShapeFilename + "] :" + e.Message);
                }
            }
            return MyLayer;
        }

        

        public MapPolygonLayer AddFieldLayer(string Fieldname, int year, string ScenarioName)
        {
            MapPolygonLayer MyLayer = null;
            string MapTargetYear = year.ToString();
            ScenarioName = ScenarioName.Trim().ToUpper();
            if (FMapDataTable != null)
                if (FMapDataTable.Columns.Contains(Fieldname))
                {
                    try
                    {
                        DataColumn DC = FMapDataTable.Columns[Fieldname];
                       
                        MyLayer = AddProviderShapeFile(Fieldname + " : " + ScenarioName); 
                        if (MyLayer == null)
                        {
                            MessageBox.Show("Error loading the Base ShapeFile.");
                        }
                        else
                        {
                            // Get the years
                            string yrfield = WaterSimManager_DB.rdbfSimYear;
                            string scnfield = WaterSimManager_DB.rdbfScenarioName;
                            // MyLayer.DataSet.FillAttributes();

                            DataTable LayerDT = MyLayer.DataSet.DataTable;
                            DataColumn AddColumn = new DataColumn(DC.ColumnName, DC.DataType);
                            LayerDT.Columns.Add(AddColumn);

                            if ((ScenarioName == FIRSTSCENARIO)||(ScenarioName==""))
                            {
                                ScenarioName = FMapDataTable.Rows[0][WaterSimManager_DB.rdbfScenarioName].ToString().ToUpper().Trim();
                            }
                            if (year == 0)
                            {
                                MapTargetYear = FMapDataTable.Rows[0][WaterSimManager_DB.rdbfSimYear].ToString();
                            }
                            //int lowval = 999999999;
                            //int highval = -999999999;

                            MyLayer.Name = ScenarioName + " " + Fieldname;
                            foreach (DataRow DR in LayerDT.Rows)
                            {
                                Boolean found = false;
                                string pfcode = DR["Provider"].ToString().Trim();  // Get the Provider Field code for this SHape File Record
                                // find this code in Scenario DataTable
                                foreach (DataRow ScnDR in FMapDataTable.Rows)
                                {
                                    string ScnName = ScnDR[scnfield].ToString().Trim().ToUpper();
                                    string TheYear = ScnDR[yrfield].ToString().Trim();
                                    if ((TheYear == MapTargetYear) && (ScnName == ScenarioName))
                                    {
                                        string Scnpfcode = ScnDR[WaterSimManager_DB.rdbfProviderCode].ToString().Trim();  
                                        if (pfcode == Scnpfcode)
                                        {
                                            DR[Fieldname] = ScnDR[Fieldname].ToString();
                                            found = true;
                                            break;
                                        }
                                        if (!found)
                                        {
                                            if (DC.DataType == System.Type.GetType("System.String"))
                                            {
                                                DR[Fieldname] = "";// System.DBNull.Value;
                                            }
                                            else
                                            {
                                                DR[Fieldname] = 0;// System.DBNull.Value;// SpecialValues.MissingIntValue;
                                            }
                                        }
                                    } //= provider
                                } // = target year
                            }
                            //MyLayer.DataSet.FillAttributes();

                            if (DC.DataType == System.Type.GetType("System.String"))
                            {
                                PolygonScheme FldScheme = new PolygonScheme();
                                FldScheme.EditorSettings.ClassificationType = ClassificationType.UniqueValues;
                                ////Set the UniqueValue field name
                                FldScheme.EditorSettings.FieldName = Fieldname;
                                // Create Catagories based on data
                                FldScheme.CreateCategories(LayerDT);
                                MyLayer.Symbology = FldScheme;
                            }
                            else
                            {
                                    PolygonScheme FldScheme = new PolygonScheme();
                                    
                                    FldScheme.EditorSettings.ClassificationType = ClassificationType.Quantities;
                                    FldScheme.EditorSettings.IntervalMethod = IntervalMethod.NaturalBreaks;
                                    FldScheme.EditorSettings.NumBreaks = 7;
                                    FldScheme.EditorSettings.FieldName = Fieldname;
                                    FldScheme.AppearsInLegend = true;
                                    FldScheme.CreateCategories(LayerDT);

                                    PolygonCategory NullCat = new PolygonCategory(Color.WhiteSmoke, Color.DarkBlue, 1);
                                    NullCat.FilterExpression = "[" + Fieldname + "] = NULL";
                                    NullCat.LegendText = "[" + Fieldname + "] = NULL";
                                    FldScheme.AddCategory(NullCat);

                                    MyLayer.Symbology = FldScheme;

                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error Loading Shape File:[ " + FDataDirectory + FShapeFilename + "] :" + e.Message);
                    }
                }
            return MyLayer;
        }
        //-------------------------------------------------------
        internal void AddProviderShapeFileLayers()
        {

                ProviderMap.Layers.Clear();
                try
                {
                    // Add Base with ADWR Names
                    string FullPath = UniDB.FileSupport.AddPaths(FDataDirectory, FShapeFilename);
                    ProviderMap.AddLayer(FullPath);

                    //Assign the mappolygon layer from the map
                    MapPolygonLayer BaseLayer = default(MapPolygonLayer);
                    BaseLayer = (MapPolygonLayer)ProviderMap.Layers[0];

                    if (BaseLayer == null)
                    {
                        MessageBox.Show("The Base Layer of Provider Map is not a polygon layer.");
                    }
                    else
                    {
                        //Get the shapefile's attribute table to our datatable dt
                        DataTable DT = BaseLayer.DataSet.DataTable;

                        // Create a Scheme
                        PolygonScheme BaseScheme = new PolygonScheme();
                        //Set the ClassificationType for the PolygonScheme via EditorSettings
                        BaseScheme.EditorSettings.ClassificationType = ClassificationType.UniqueValues;
                        //Set the UniqueValue field name
                        BaseScheme.EditorSettings.FieldName = "ADWR_NAME";
                        // Create Catagories based on data
                        BaseScheme.CreateCategories(DT);
                        // Set the Symbology to this Scheme
                        BaseLayer.Symbology = BaseScheme;


                    }
                    // Add Base with  Provider Codes
                    ProviderMap.AddLayer(FullPath);

                    //Assign the mappolygon layer from the map
                    BaseLayer = (MapPolygonLayer)ProviderMap.Layers[1];

                    if (BaseLayer == null)
                    {
                        MessageBox.Show("The Base Layer of Provider Map is not a polygon layer.");
                    }
                    else
                    {
                        //Get the shapefile's attribute table to our datatable dt
                        DataTable DT = BaseLayer.DataSet.DataTable;

                        // Create a Scheme
                        PolygonScheme BaseScheme = new PolygonScheme();
                        //Set the ClassificationType for the PolygonScheme via EditorSettings
                        BaseScheme.EditorSettings.ClassificationType = ClassificationType.UniqueValues;
                        //Set the UniqueValue field name
                        BaseScheme.EditorSettings.FieldName = "Provider";
                        // Create Catagories based on data
                        BaseScheme.CreateCategories(DT);
                        // Set the Symbology to this Scheme
                        BaseLayer.Symbology = BaseScheme;


                    }
                    BaseShapeLoaded = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Loading Shape File:[ " + FDataDirectory + FShapeFilename + "] :" + e.Message);
                }
            
        }

        internal void ReportStatus(int MaxProgress, int Progress, string StatMessage1, string StatMessage2)
        {
            // hide progress bar if MaxProgress = 0 otherwise show
            if (MaxProgress == 0)
            {
                MapDashboardSatusProgressBar.Visible = false;
            }
            else
            {
                MapDashboardSatusProgressBar.Visible = true;
                MapDashboardSatusProgressBar.Maximum = MaxProgress;
                MapDashboardSatusProgressBar.Value = Progress;
            }
            MapDashboardStatusLabel1.Text = StatMessage1;
            MapDashboardStatusLabel2.Text = StatMessage2;
            Application.DoEvents();
        }

        internal bool LoadDataTable(DataTable NewTable)
        {
            ReportStatus(6, 2, "Loading Table", "Parameters");
            List<string> ParmsInTable = new List<string>();
            // get all the different paramters in order
            List<string> parmlist = WaterSimManager_DB.ParamtersInTable(NewTable, ParmManager, false, false, true, modelParamtype.mptOutputBase);
            foreach (string str in parmlist)
            {
                ParmsInTable.Add(str);
            }

            parmlist = WaterSimManager_DB.ParamtersInTable(NewTable, ParmManager, false, false, true, modelParamtype.mptOutputProvider);
            foreach (string str in parmlist)
            {
                ParmsInTable.Add(str);
            }
            parmlist = WaterSimManager_DB.ParamtersInTable(NewTable, ParmManager, false, false, true, modelParamtype.mptInputBase);
            foreach (string str in parmlist)
            {
                ParmsInTable.Add(str);
            }
            parmlist = WaterSimManager_DB.ParamtersInTable(NewTable, ParmManager, false, false, true, modelParamtype.mptInputProvider);
            foreach (string str in parmlist)
            {
                ParmsInTable.Add(str);
            }
            MapParameterListBox.Items.Clear();
            foreach (string str in ParmsInTable)
                MapParameterListBox.Items.Add(str);

            ReportStatus(6, 3, "Loading Table", "Scenarios Names");
            //            // Get the scenario names, if they are there
            List<string> Scnlist = WaterSimManager_DB.ScenarioNamesInTable(NewTable);
            Scnlist.Add(FIRSTSCENARIO);
            ComboBoxMapScenarioName.Items.Clear();
            foreach (string SCN in Scnlist)
            {
                ComboBoxMapScenarioName.Items.Add(SCN);
            }


            ReportStatus(6, 5, "Loading Table", "Map Setup");
            List<string> YearsList = new List<string>();
            YearsList = WaterSimManager_DB.YearsInTable(NewTable);
            comboBoxYear.Items.Clear();
            foreach (string str in YearsList)
                comboBoxYear.Items.Add(str);
            comboBoxYear.SelectedIndex = comboBoxYear.Items.Count - 1;

            return true;
        }
        public bool LoadCurrentTable(string tablename, DataTable NewTable)
        {
            System.Windows.Forms.Cursor CurrentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            FCurrentTablename = tablename;

            ReportStatus(6, 0, "Loading Table", "Loading Data");
            LoadDataTable(NewTable);
            ReportStatus(0, 6, "Done Loading Table", "");
            this.Cursor = CurrentCursor;
            return true;
        }
        public bool LoadCurrentTable(string tablename)
        {
            bool iserror = false;
            string ErrMessage = "";
                System.Windows.Forms.Cursor CurrentCursor = this.Cursor;
                 this.Cursor = Cursors.WaitCursor;
                FCurrentTablename = tablename;
 
                ReportStatus(6, 0, "Loading Table", "Loading Data");
                 FMapDataTable = UniDB.Tools.LoadTable(DbConnection, FCurrentTablename, ref iserror, ref ErrMessage);

                 LoadDataTable(FMapDataTable);

        //        ReportStatus(6, 2, "Loading Table", "Parameters");
        //        List<string> ParmsInTable = new List<string>();
        //       // get all the different paramters in order
        //         List<string> parmlist = WaterSimManager_DB.ParamtersInTable(FMapDataTable, ParmManager, false, false, true, modelParamtype.mptOutputBase);
        //         foreach (string str in parmlist)
        //         {
        //             ParmsInTable.Add(str);
        //         }

        //         parmlist = WaterSimManager_DB.ParamtersInTable(FMapDataTable, ParmManager, false, false, true, modelParamtype.mptOutputProvider);
        //         foreach (string str in parmlist)
        //         {
        //             ParmsInTable.Add(str);
        //         }
        //         parmlist = WaterSimManager_DB.ParamtersInTable(FMapDataTable, ParmManager, false, false, true, modelParamtype.mptInputBase);
        //         foreach (string str in parmlist)
        //         {
        //             ParmsInTable.Add(str);
        //         }
        //         parmlist = WaterSimManager_DB.ParamtersInTable(FMapDataTable, ParmManager, false, false, true, modelParamtype.mptInputProvider);
        //         foreach (string str in parmlist)
        //         {
        //             ParmsInTable.Add(str);
        //         }
        //         MapParameterListBox.Items.Clear();
        //        foreach(string str in ParmsInTable)
        //            MapParameterListBox.Items.Add(str);

        //         ReportStatus(6, 3, "Loading Table", "Scenarios Names");
        ////            // Get the scenario names, if they are there
        //         List<string> Scnlist = WaterSimManager_DB.ScenarioNamesInTable(FMapDataTable);
        //         Scnlist.Add(FIRSTSCENARIO);
        //         ComboBoxMapScenarioName.Items.Clear();
        //          foreach (string SCN in Scnlist)
        //            {
        //                ComboBoxMapScenarioName.Items.Add(SCN);
        //            }


        //            ReportStatus(6, 5, "Loading Table", "Map Setup");            
        //            List<string> YearsList = new List<string>();
        //            YearsList = WaterSimManager_DB.YearsInTable(FMapDataTable);
        //            comboBoxYear.Items.Clear();
        //            foreach(string str in YearsList)
        //                comboBoxYear.Items.Add(str);
        //            comboBoxYear.SelectedIndex = comboBoxYear.Items.Count - 1;
        //            //SetMapTablename(FCurrentTableName, ViewerDataTable, ParmsInTable, YearsList);

                  
                ReportStatus(0, 6, "Done Loading Table", "");
                this.Cursor = CurrentCursor;
            return true;

        }
        //internal void AddProviderBaseShapeFile()
        //{
        //    try
        //    {
        //        ProviderMap.AddLayer(FDataDirectory + FShapeFilename);

        //        //Assign the mappolygon layer from the map
        //        MapPolygonLayer BaseLayer = default(MapPolygonLayer);
        //        BaseLayer = (MapPolygonLayer)ProviderMap.Layers[0];

        //        if (BaseLayer == null)
        //        {
        //            MessageBox.Show("The Base Layer of Provider Map is not a polygon layer.");
        //        }
        //        else
        //        {
        //            //Get the shapefile's attribute table to our datatable dt
        //            DataTable DT = BaseLayer.DataSet.DataTable;

        //            // Create a Scheme
        //            PolygonScheme BaseScheme = new PolygonScheme();
        //            //Set the ClassificationType for the PolygonScheme via EditorSettings
        //            BaseScheme.EditorSettings.ClassificationType = ClassificationType.UniqueValues;
        //            //Set the UniqueValue field name
        //            BaseScheme.EditorSettings.FieldName = "ADWR_NAME";
        //            // Create Catagories based on data
        //            BaseScheme.CreateCategories(DT);
        //            // Set the Symbology to this Scheme
        //            BaseLayer.Symbology = BaseScheme;


        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Error Loading Shape File:[ " + FDataDirectory + FShapeFilename + "] :" + e.Message);
        //    }
        //}


        //==================================================================
        private void CopyChartMenuItem_Click(object sender, EventArgs e)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap b = new Bitmap(ProviderMap.Width, ProviderMap.Height);
                Graphics g = Graphics.FromImage(b);
                Rectangle r = new Rectangle(0, 0, ProviderMap.Width, ProviderMap.Height);
                ProviderMap.MapFrame.Print(g, r);
                Clipboard.SetImage(b);
                ReportStatus(0, 0, "", "Map image copied to clipboard.");

            }

        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            // filter Bitmap|*.bmp|Jpeg|*.jpg;*.jpeg|Portable Network Graphic|*.png|Enhanced Metafile|*.emf|Windows Metafile|*.wmf|Tagged Image File Format|*.tif;*.tiff
            Bitmap b = new Bitmap(ProviderMap.Width, ProviderMap.Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle r = new Rectangle(0, 0, ProviderMap.Width, ProviderMap.Height);
            ProviderMap.MapFrame.Print(g, r);
            if (SaveMapToFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = SaveMapToFileDialog.FileName;
                string ext = Path.GetExtension(filename).ToUpper();
                //b.Save(filename);
                if (ext == ".BMP")
                {  b.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp); }
                else
                    if ((ext == ".JPG") || (ext == ".JPEG"))
                    { b.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg); }
                    else
                        if (ext == ".EMF")
                        { b.Save(filename, System.Drawing.Imaging.ImageFormat.Emf); }
                        else
                            if (ext == ".PNG")
                            { b.Save(filename, System.Drawing.Imaging.ImageFormat.Png); }
                            else
                                if ((ext == ".TIF") || (ext == ".TIFF"))
                                { b.Save(filename, System.Drawing.Imaging.ImageFormat.Tiff);}
                                else
                                if (ext == ".WMF") 
                                {
                                    b.Save(filename, System.Drawing.Imaging.ImageFormat.Wmf);
                                }
                                


            }

        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        // ToolstripMap  Button Events
        // 
        private void toolStripButtonZoomIn_Click(object sender, EventArgs e)
        {
            ProviderMap.FunctionMode = FunctionMode.ZoomIn;
        }

        private void ToolstripButtonZoomOut_Click(object sender, EventArgs e)
        {
            ProviderMap.ZoomOut();
        }

        private void toolStripButtonFullExtent_Click(object sender, EventArgs e)
        {
            ProviderMap.ZoomToMaxExtent();
        }

        private void toolStripButtonLastExtent_Click(object sender, EventArgs e)
        {
            ProviderMap.ZoomToPrevious();
        }

        private void toolStripButtonIdentify_Click(object sender, EventArgs e)
        {
            ProviderMap.FunctionMode = FunctionMode.Info;
        }
        private void toolStripButtonPan_Click(object sender, EventArgs e)
        {
            ProviderMap.FunctionMode = FunctionMode.Pan;
        }
    
        private void ComboBoxMapScenarioName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FCurrentScenario = ComboBoxMapScenarioName.Text;
        }

        private void ComboBoxMapTablename_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCurrentTable(ComboBoxMapTablename.SelectedItem.ToString());
            // Load Table
            
            // Get Parameters
            
            // Get Scenarios
        }

        private void ClearAllParmsButton_Click(object sender, EventArgs e)
        {
            foreach (int indexChecked in MapParameterListBox.CheckedIndices)
            {
                MapParameterListBox.SetItemCheckState(indexChecked, CheckState.Unchecked);
            }
        }

    }


    internal class MapProgressClass : IProgressHandler
    {
        ToolStripStatusLabel FKeyLabel;
        ToolStripStatusLabel FMessageLabel;
        ToolStripProgressBar FMapProgressBar;

        public void SetControls(ToolStripStatusLabel KeyLabel, ToolStripProgressBar MapProgressBar, ToolStripStatusLabel MessageLabel)
        {
            FKeyLabel = KeyLabel;
            FMessageLabel = MessageLabel;
            FMapProgressBar = MapProgressBar;
        }

        public void Progress(string key, int percent, string message)
        {
            FKeyLabel.Text = key;
            FMessageLabel.Text = message;
            FMapProgressBar.Maximum = 100;
            FMapProgressBar.Value = percent;
        }


    }
}

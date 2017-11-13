namespace WaterSimDCDC.Controls.Dotspatial
{
    partial class MapDashboardControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapDashboardControl));
            this.MapPopUpMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableNameToolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ComboBoxMapTablename = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ComboBoxMapScenarioName = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MapDashboardStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.MapDashboardSatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.MapDashboardStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SaveMapToFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.PanelDashboardContent = new System.Windows.Forms.Panel();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.YearLabel = new System.Windows.Forms.Label();
            this.ClearAllParmsButton = new System.Windows.Forms.Button();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.MapParameterListBox = new System.Windows.Forms.CheckedListBox();
            this.PanelMap = new System.Windows.Forms.Panel();
            this.PanelMapLegend = new System.Windows.Forms.Panel();
            this.ProviderMapLegend = new DotSpatial.Controls.Legend();
            this.ProviderMap = new DotSpatial.Controls.Map();
            this.ToolstripMap = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPan = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.ToolstripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFullExtent = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLastExtent = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonIdentify = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.MapPopUpMenu.SuspendLayout();
            this.TableNameToolBar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.PanelDashboardContent.SuspendLayout();
            this.panelParameters.SuspendLayout();
            this.PanelMap.SuspendLayout();
            this.PanelMapLegend.SuspendLayout();
            this.ToolstripMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapPopUpMenu
            // 
            this.MapPopUpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyMapMenuItem,
            this.SaveMapMenuItem});
            this.MapPopUpMenu.Name = "MapPopUpMenu";
            this.MapPopUpMenu.Size = new System.Drawing.Size(201, 48);
            this.MapPopUpMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // CopyMapMenuItem
            // 
            this.CopyMapMenuItem.Name = "CopyMapMenuItem";
            this.CopyMapMenuItem.Size = new System.Drawing.Size(200, 22);
            this.CopyMapMenuItem.Text = "Copy Map To Clipboard";
            // 
            // SaveMapMenuItem
            // 
            this.SaveMapMenuItem.Name = "SaveMapMenuItem";
            this.SaveMapMenuItem.Size = new System.Drawing.Size(200, 22);
            this.SaveMapMenuItem.Text = "Save Map As";
            // 
            // TableNameToolBar
            // 
            this.TableNameToolBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TableNameToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ComboBoxMapTablename,
            this.toolStripLabel2,
            this.ComboBoxMapScenarioName});
            this.TableNameToolBar.Location = new System.Drawing.Point(0, 0);
            this.TableNameToolBar.Name = "TableNameToolBar";
            this.TableNameToolBar.Size = new System.Drawing.Size(875, 25);
            this.TableNameToolBar.TabIndex = 4;
            this.TableNameToolBar.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel1.Text = "Table Name";
            // 
            // ComboBoxMapTablename
            // 
            this.ComboBoxMapTablename.Name = "ComboBoxMapTablename";
            this.ComboBoxMapTablename.Size = new System.Drawing.Size(250, 25);
            this.ComboBoxMapTablename.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMapTablename_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel2.Text = "Scenario Name";
            // 
            // ComboBoxMapScenarioName
            // 
            this.ComboBoxMapScenarioName.Name = "ComboBoxMapScenarioName";
            this.ComboBoxMapScenarioName.Size = new System.Drawing.Size(250, 25);
            this.ComboBoxMapScenarioName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMapScenarioName_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapDashboardStatusLabel1,
            this.MapDashboardSatusProgressBar,
            this.MapDashboardStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(355, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MapDashboardStatusLabel1
            // 
            this.MapDashboardStatusLabel1.Name = "MapDashboardStatusLabel1";
            this.MapDashboardStatusLabel1.Size = new System.Drawing.Size(118, 20);
            this.MapDashboardStatusLabel1.Text = "toolStripStatusLabel2";
            // 
            // MapDashboardSatusProgressBar
            // 
            this.MapDashboardSatusProgressBar.Name = "MapDashboardSatusProgressBar";
            this.MapDashboardSatusProgressBar.Size = new System.Drawing.Size(100, 19);
            // 
            // MapDashboardStatusLabel2
            // 
            this.MapDashboardStatusLabel2.Name = "MapDashboardStatusLabel2";
            this.MapDashboardStatusLabel2.Size = new System.Drawing.Size(118, 20);
            this.MapDashboardStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // SaveMapToFileDialog
            // 
            this.SaveMapToFileDialog.Filter = "Bitmap|*.bmp|Jpeg|*.jpg;*.jpeg|Portable Network Graphic|*.png|Enhanced Metafile|*" +
    ".emf|Windows Metafile|*.wmf|Tagged Image File Format |*.tif;*.tiff";
            // 
            // PanelDashboardContent
            // 
            this.PanelDashboardContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDashboardContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelDashboardContent.Controls.Add(this.panelParameters);
            this.PanelDashboardContent.Controls.Add(this.PanelMap);
            this.PanelDashboardContent.Location = new System.Drawing.Point(3, 38);
            this.PanelDashboardContent.Name = "PanelDashboardContent";
            this.PanelDashboardContent.Size = new System.Drawing.Size(874, 490);
            this.PanelDashboardContent.TabIndex = 7;
            // 
            // panelParameters
            // 
            this.panelParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelParameters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelParameters.Controls.Add(this.YearLabel);
            this.panelParameters.Controls.Add(this.ClearAllParmsButton);
            this.panelParameters.Controls.Add(this.comboBoxYear);
            this.panelParameters.Controls.Add(this.MapParameterListBox);
            this.panelParameters.Location = new System.Drawing.Point(3, 3);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(264, 484);
            this.panelParameters.TabIndex = 8;
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearLabel.Location = new System.Drawing.Point(10, 10);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(38, 17);
            this.YearLabel.TabIndex = 12;
            this.YearLabel.Text = "Year";
            // 
            // ClearAllParmsButton
            // 
            this.ClearAllParmsButton.Location = new System.Drawing.Point(13, 41);
            this.ClearAllParmsButton.Name = "ClearAllParmsButton";
            this.ClearAllParmsButton.Size = new System.Drawing.Size(68, 23);
            this.ClearAllParmsButton.TabIndex = 13;
            this.ClearAllParmsButton.Text = "Clear All";
            this.ClearAllParmsButton.UseVisualStyleBackColor = true;
            this.ClearAllParmsButton.Click += new System.EventHandler(this.ClearAllParmsButton_Click);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(57, 10);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(174, 21);
            this.comboBoxYear.TabIndex = 11;
            // 
            // MapParameterListBox
            // 
            this.MapParameterListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MapParameterListBox.FormattingEnabled = true;
            this.MapParameterListBox.Location = new System.Drawing.Point(13, 70);
            this.MapParameterListBox.Name = "MapParameterListBox";
            this.MapParameterListBox.Size = new System.Drawing.Size(247, 364);
            this.MapParameterListBox.TabIndex = 10;
            this.MapParameterListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.MapParameterListBox_ItemCheck);
            // 
            // PanelMap
            // 
            this.PanelMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelMap.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanelMap.Controls.Add(this.PanelMapLegend);
            this.PanelMap.Controls.Add(this.ToolstripMap);
            this.PanelMap.Location = new System.Drawing.Point(270, 3);
            this.PanelMap.Name = "PanelMap";
            this.PanelMap.Size = new System.Drawing.Size(599, 484);
            this.PanelMap.TabIndex = 7;
            // 
            // PanelMapLegend
            // 
            this.PanelMapLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMapLegend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelMapLegend.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanelMapLegend.Controls.Add(this.ProviderMapLegend);
            this.PanelMapLegend.Controls.Add(this.ProviderMap);
            this.PanelMapLegend.Location = new System.Drawing.Point(3, 42);
            this.PanelMapLegend.Name = "PanelMapLegend";
            this.PanelMapLegend.Size = new System.Drawing.Size(593, 439);
            this.PanelMapLegend.TabIndex = 3;
            // 
            // ProviderMapLegend
            // 
            this.ProviderMapLegend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ProviderMapLegend.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ProviderMapLegend.ControlRectangle = new System.Drawing.Rectangle(0, 0, 263, 435);
            this.ProviderMapLegend.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProviderMapLegend.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 187, 428);
            this.ProviderMapLegend.HorizontalScrollEnabled = true;
            this.ProviderMapLegend.Indentation = 30;
            this.ProviderMapLegend.IsInitialized = false;
            this.ProviderMapLegend.Location = new System.Drawing.Point(3, 1);
            this.ProviderMapLegend.MinimumSize = new System.Drawing.Size(5, 5);
            this.ProviderMapLegend.Name = "ProviderMapLegend";
            this.ProviderMapLegend.ProgressHandler = null;
            this.ProviderMapLegend.ResetOnResize = false;
            this.ProviderMapLegend.SelectionFontColor = System.Drawing.Color.Black;
            this.ProviderMapLegend.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.ProviderMapLegend.Size = new System.Drawing.Size(263, 435);
            this.ProviderMapLegend.TabIndex = 3;
            this.ProviderMapLegend.Text = "Map Legend";
            this.ProviderMapLegend.VerticalScrollEnabled = true;
            // 
            // ProviderMap
            // 
            this.ProviderMap.AllowDrop = true;
            this.ProviderMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProviderMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProviderMap.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProviderMap.CollectAfterDraw = false;
            this.ProviderMap.CollisionDetection = false;
            this.ProviderMap.ContextMenuStrip = this.MapPopUpMenu;
            this.ProviderMap.ExtendBuffer = false;
            this.ProviderMap.FunctionMode = DotSpatial.Controls.FunctionMode.None;
            this.ProviderMap.IsBusy = false;
            this.ProviderMap.Legend = this.ProviderMapLegend;
            this.ProviderMap.Location = new System.Drawing.Point(272, 3);
            this.ProviderMap.Name = "ProviderMap";
            this.ProviderMap.ProgressHandler = null;
            this.ProviderMap.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.ProviderMap.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.ProviderMap.RedrawLayersWhileResizing = false;
            this.ProviderMap.SelectionEnabled = true;
            this.ProviderMap.Size = new System.Drawing.Size(318, 437);
            this.ProviderMap.TabIndex = 2;
            // 
            // ToolstripMap
            // 
            this.ToolstripMap.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ToolstripMap.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolstripMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPan,
            this.toolStripButtonZoomIn,
            this.ToolstripButtonZoomOut,
            this.toolStripButtonFullExtent,
            this.toolStripButtonLastExtent,
            this.toolStripButtonIdentify,
            this.toolStripButtonCopy,
            this.toolStripButtonSaveAs});
            this.ToolstripMap.Location = new System.Drawing.Point(0, 0);
            this.ToolstripMap.Name = "ToolstripMap";
            this.ToolstripMap.Size = new System.Drawing.Size(599, 39);
            this.ToolstripMap.TabIndex = 2;
            this.ToolstripMap.Text = "Map Toolstrip";
            // 
            // toolStripButtonPan
            // 
            this.toolStripButtonPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPan.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPan.Image")));
            this.toolStripButtonPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPan.Name = "toolStripButtonPan";
            this.toolStripButtonPan.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonPan.Text = "Pan Map";
            this.toolStripButtonPan.Click += new System.EventHandler(this.toolStripButtonPan_Click);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomIn.Image")));
            this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonZoomIn.Text = "Zoom In";
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.toolStripButtonZoomIn_Click);
            // 
            // ToolstripButtonZoomOut
            // 
            this.ToolstripButtonZoomOut.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ToolstripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolstripButtonZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("ToolstripButtonZoomOut.Image")));
            this.ToolstripButtonZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolstripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolstripButtonZoomOut.Name = "ToolstripButtonZoomOut";
            this.ToolstripButtonZoomOut.Size = new System.Drawing.Size(36, 36);
            this.ToolstripButtonZoomOut.Text = "Zoom Out";
            this.ToolstripButtonZoomOut.Click += new System.EventHandler(this.ToolstripButtonZoomOut_Click);
            // 
            // toolStripButtonFullExtent
            // 
            this.toolStripButtonFullExtent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFullExtent.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFullExtent.Image")));
            this.toolStripButtonFullExtent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFullExtent.Name = "toolStripButtonFullExtent";
            this.toolStripButtonFullExtent.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonFullExtent.Text = "Zoom Full Extent";
            this.toolStripButtonFullExtent.Click += new System.EventHandler(this.toolStripButtonFullExtent_Click);
            // 
            // toolStripButtonLastExtent
            // 
            this.toolStripButtonLastExtent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLastExtent.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLastExtent.Image")));
            this.toolStripButtonLastExtent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLastExtent.Name = "toolStripButtonLastExtent";
            this.toolStripButtonLastExtent.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonLastExtent.Text = "Zoom Last Extent";
            this.toolStripButtonLastExtent.Click += new System.EventHandler(this.toolStripButtonLastExtent_Click);
            // 
            // toolStripButtonIdentify
            // 
            this.toolStripButtonIdentify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIdentify.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonIdentify.Image")));
            this.toolStripButtonIdentify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIdentify.Name = "toolStripButtonIdentify";
            this.toolStripButtonIdentify.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonIdentify.Text = "Identify";
            this.toolStripButtonIdentify.Click += new System.EventHandler(this.toolStripButtonIdentify_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopy.Image")));
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonCopy.Text = "Copy To Clipboard";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.CopyChartMenuItem_Click);
            // 
            // toolStripButtonSaveAs
            // 
            this.toolStripButtonSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveAs.Image")));
            this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            this.toolStripButtonSaveAs.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSaveAs.Text = "Save to File";
            this.toolStripButtonSaveAs.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // MapDashboardControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.PanelDashboardContent);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TableNameToolBar);
            this.Name = "MapDashboardControl";
            this.Size = new System.Drawing.Size(875, 556);
            this.MapPopUpMenu.ResumeLayout(false);
            this.TableNameToolBar.ResumeLayout(false);
            this.TableNameToolBar.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.PanelDashboardContent.ResumeLayout(false);
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            this.PanelMap.ResumeLayout(false);
            this.PanelMap.PerformLayout();
            this.PanelMapLegend.ResumeLayout(false);
            this.ToolstripMap.ResumeLayout(false);
            this.ToolstripMap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TableNameToolBar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ComboBoxMapTablename;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox ComboBoxMapScenarioName;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel MapDashboardStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar MapDashboardSatusProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel MapDashboardStatusLabel2;
        private System.Windows.Forms.ContextMenuStrip MapPopUpMenu;
        private System.Windows.Forms.ToolStripMenuItem CopyMapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMapMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveMapToFileDialog;
        private System.Windows.Forms.Panel PanelDashboardContent;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Button ClearAllParmsButton;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.CheckedListBox MapParameterListBox;
        private System.Windows.Forms.Panel PanelMap;
        private System.Windows.Forms.Panel PanelMapLegend;
        private DotSpatial.Controls.Legend ProviderMapLegend;
        private DotSpatial.Controls.Map ProviderMap;
        private System.Windows.Forms.ToolStrip ToolstripMap;
        private System.Windows.Forms.ToolStripButton toolStripButtonPan;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton ToolstripButtonZoomOut;
        private System.Windows.Forms.ToolStripButton toolStripButtonFullExtent;
        private System.Windows.Forms.ToolStripButton toolStripButtonLastExtent;
        private System.Windows.Forms.ToolStripButton toolStripButtonIdentify;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveAs;
    }
}

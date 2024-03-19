﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace T250DynoScout_v2024
{
    public partial class UpdateDatabase : Form
    {
        public UpdateDatabase(List<string> teamlist, List<int> MatchNumbers)
        {
            InitializeComponent();
            this.comboTeamNumber.DataSource = teamlist;
            this.comboMatchNumber.DataSource = MatchNumbers;
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            if (checkEndAuto.Checked || checkActivities.Checked || checkEndMatch.Checked || checkMatchEvent.Checked)
            {
                using (var db = new SeasonContext())
                {
                    string cbEA = "";
                    string cbA = "";
                    string cbEM = "";
                    string cbME = "";
                    string first = "";

                    if (checkEndAuto.Checked)
                    {
                        cbEA = first + "'EndAuto'";
                        first = ",";
                    }
                    if (checkActivities.Checked)
                    {
                        cbA = first + "'Activities'";
                        first = ",";
                    }
                    if (checkEndMatch.Checked)
                    {
                        cbEM = first + "'EndMatch'";
                        first = ",";
                    }
                    if (checkMatchEvent.Checked)
                    {
                        cbME = first + "'Match_Event'";
                    }

                    string teamNumber = this.comboTeamNumber.Text;
                    string matchNumber = this.comboMatchNumber.Text;
                    bool isNumeric = int.TryParse(comboMatchNumber.Text, out _);
                    if (isNumeric)
                    {
                        string Query = "Select * INTO UpdatePreviews FROM Activities WHERE Team = 'frc" + teamNumber + "' AND Match = '" + matchNumber + "' AND RecordType IN (" + cbEA + cbA + cbEM + cbME + ")";
                        SeasonContext seasonframework = new SeasonContext();
                        seasonframework.Database.ExecuteSqlCommand("IF OBJECT_ID ('UpdatePreviews') IS NOT NULL DROP TABLE UpdatePreviews");
                        seasonframework.Database.ExecuteSqlCommand(Query);
                        this.updatePreviewsTableAdapter.Fill(this._2024seasondbDataSet.UpdatePreviews);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Team Number");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select at least one record type");
            }
        }

        private void UpdateDatabase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_2024seasondbDataSet.UpdatePreviews' table. You can move, or remove it, as needed.
            this.updatePreviewsTableAdapter.Fill(this._2024seasondbDataSet.UpdatePreviews);

        }

        private void btnFetchValues_Click(object sender, EventArgs e)
        {
            using (var db = new SeasonContext())
            {
                bool isNumeric = int.TryParse(txtID.Text, out _);
                if (isNumeric)
                {
                    var IDNumber = int.Parse(txtID.Text);
                    var result = db.UpdatePreviewSet.FirstOrDefault(b => b.Id == IDNumber);
                    if (result != null)
                    {
                        comboAcqLoc.Text = result.AcqLoc.ToString();
                        comboAcqCenter.Text = result.AcqCenter.ToString();
                        txtAcqDis.Text = result.AcqDis.ToString();
                        txtAcqDrp.Text = result.AcqDrp.ToString();

                        comboDelDest.Text = result.DelDest.ToString();
                        comboDelOrg.Text = result.DelOrig.ToString();
                        txtDelMiss.Text = result.DelMiss.ToString();
                        txtAZTime.Text = result.AZTime.ToString();
                        txtNZTime.Text = result.NZTime.ToString();
                        txtOZTime.Text = result.OZTime.ToString();

                        comboStageStat.Text = result.StageStat.ToString();
                        comboStageAtt.Text = result.StageAtt.ToString();
                        comboStageLoc.Text = result.StageLoc.ToString();
                        txtHarm.Text = result.Harmony.ToString();
                        txtLit.Text = result.Spotlit.ToString();
                        txtMics.Text = result.Mics.ToString();
                        txtClimbTime.Text = result.ClimbT.ToString();

                        txtHPAmp.Text = result.HPAmp.ToString();
                        txtRobotSetup.Text = result.RobotSta.ToString();
                        txtLeave.Text = result.Leave.ToString();
                       
                        comboMode.Text = result.Mode.ToString();
                        comboMatchEvent.Text = result.match_event.ToString();
                        
                        txtDefense.Text = result.Defense.ToString();
                        txtAvoidance.Text = result.Avoidance.ToString();
                        comboStrategy.Text = result.Strategy.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid ID");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a number for the ID");
                }
            }
        }

        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            using (var db = new SeasonContext())
            {
                SeasonContext seasonframework = new SeasonContext();                               
                bool isNumeric = int.TryParse(txtID.Text, out _);
                if (isNumeric)
                {
                    var IDNumber = int.Parse(txtID.Text);
                    var result = db.UpdatePreviewSet.FirstOrDefault(b => b.Id == IDNumber);
                    if (result != null)
                    {
                        string query = "UPDATE Activities SET AcqLoc = '" + comboAcqLoc.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET AcqCenter = '" + comboAcqCenter.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET AcqDis = '" + txtAcqDis.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET AcqDrp = '" + txtAcqDrp.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET DelDest = '" + comboDelDest.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET DelOrig = '" + comboDelOrg.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET DelMiss = '" + txtDelMiss.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET AZTime = '" + txtAZTime.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET NZTime = '" + txtNZTime.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET OZTime = '" + txtOZTime.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET StageAtt = '" + comboStageAtt.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET StageLoc = '" + comboStageLoc.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET StageStat = '" + comboStageStat.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Harmony = '" + txtHarm.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Spotlit = '" + txtLit.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Mics = '" + txtMics.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET ClimbT = '" + txtClimbTime.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET HPAmp = '" + txtHPAmp.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET RobotSta = '" + txtRobotSetup.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Leave = '" + txtLeave.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);
                        
                        query = "UPDATE Activities SET Mode = '" + comboMode.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET match_event = '" + comboMatchEvent.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Defense = '" + txtDefense.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Avoidance = '" + txtAvoidance.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Strategy = '" + comboStrategy.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a number for the ID");
                }
            }
        }
    }
}

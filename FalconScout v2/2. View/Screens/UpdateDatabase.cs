using System;
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

                        //txtSub1.Text = result.AcqSub1.ToString();
                        //txtSub2.Text = result.AcqSub2.ToString();
                        //txtComm.Text = result.AcqFComm.ToString();
                        //txtLoad.Text = result.AcqFLoad.ToString();
                        //txtOpps.Text = result.AcqFOpps.ToString();
                        //txtOther.Text = result.AcqFOther.ToString();
                        //txtTop.Text = result.DelTop.ToString();
                        //txtMid.Text = result.DelMid.ToString();
                        //txtHyb.Text = result.DelBot.ToString();
                        //txtOut.Text = result.DelOut.ToString();
                        //txtCoop.Text = result.DelCoop.ToString();
                        //txtFloor.Text = result.DelFloor.ToString();
                        //txtDrop.Text = result.DelDrop.ToString();
                        //txtCone.Text = result.Cone.ToString();
                        //txtCube.Text = result.Cube.ToString();
                        //string Pa = result.Parked.ToString();
                        //string Do = result.Docked.ToString();
                        //string En = result.Engaged.ToString();
                        //string TAF = result.Tried_And_Failed.ToString();
                        //string NA = result.No_Attempt.ToString();
                        //if (Pa == "1")
                        //{
                        //    comboCSStatus.Text = "P";
                        //}
                        //else if (Do == "1")
                        //{
                        //    comboCSStatus.Text = "D";
                        //}
                        //else if (En == "1")
                        //{
                        //    comboCSStatus.Text = "E";
                        //}
                        //else if (TAF == "1")
                        //{
                        //    comboCSStatus.Text = "T";
                        //}
                        //else if (NA == "1")
                        //{
                        //    comboCSStatus.Text = "N";
                        //}
                        //txtPartners.Text = result.ChargePart.ToString();
                        //comboFailReason.Text = result.EngageFail.ToString();
                        //txtTime.Text = result.EngageT.ToString();
                        comboMode.Text = result.Mode.ToString();
                        comboMatchEvent.Text = result.match_event.ToString();
                        //txtMobility.Text = result.Mobility.ToString();
                        //txtSetup.Text = result.Setup.ToString();
                        //txtAutoPts.Text = result.AutoPts.ToString();
                        //txtGridPts.Text = result.GridPts.ToString();
                        //txtChargePts.Text = result.ChargePts.ToString();
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

                        //query = "UPDATE Activities SET AcqSub1 = '" + txtSub1.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET AcqSub2 = '" + txtSub2.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET AcqFComm = '" + txtComm.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET AcqFLoad = '" + txtLoad.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET AcqFOpps = '" + txtOpps.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET AcqFOther = '" + txtOther.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET DelTop = '" + txtTop.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET DelMid = '" + txtMid.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET DelBot = '" + txtHyb.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET DelOut = '" + txtOut.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET DelCoop = '" + txtCoop.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET DelFloor = '" + txtFloor.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET DelDrop = '" + txtDrop.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET Cone = '" + txtCone.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET Cube = '" + txtCube.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        int Pa = 0;
                        int Do = 0;
                        int En = 0;
                        int TAF = 0;
                        int NA = 0;
                        //if (comboCSStatus.Text == "P")
                        //{
                        //    Pa = 1;
                        //    Do = 0;
                        //    En = 0;
                        //    TAF = 0;
                        //    NA = 0;
                        //}
                        //else if (comboCSStatus.Text == "D")
                        //{
                        //    Pa = 0;
                        //    Do = 1;
                        //    En = 0;
                        //    TAF = 0;
                        //    NA = 0;
                        //}
                        //else if (comboCSStatus.Text == "E")
                        //{
                        //    Pa = 0;
                        //    Do = 0;
                        //    En = 1;
                        //    TAF = 0;
                        //    NA = 0;
                        //}
                        //else if (comboCSStatus.Text == "T")
                        //{
                        //    Pa = 0;
                        //    Do = 0;
                        //    En = 0;
                        //    TAF = 1;
                        //    NA = 0;
                        //}
                        //else if (comboCSStatus.Text == "N")
                        //{
                        //    Pa = 0;
                        //    Do = 0;
                        //    En = 0;
                        //    TAF = 0;
                        //    NA = 1;
                        //}

                        //query = "UPDATE Activities SET Parked = '" + Pa + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET Docked = '" + Do + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET Engaged = '" + En + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET Tried_And_Failed = '" + TAF + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET No_Attempt = '" + NA + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET ChargePart = '" + txtPartners.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET EngageFail = '" + comboFailReason.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET EngageT = '" + txtTime.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Mode = '" + comboMode.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET match_event = '" + comboMatchEvent.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET Mobility = '" + txtMobility.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET Setup = '" + txtSetup.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET AutoPts = '" + txtAutoPts.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET GridPts = '" + txtGridPts.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

                        //query = "UPDATE Activities SET ChargePts = '" + txtChargePts.Text + "' WHERE Id = '" + result.Id + "';";
                        //seasonframework.Database.ExecuteSqlCommand(query);

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

        private void comboAcqLoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboAcqCenter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

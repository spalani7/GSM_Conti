using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using NetworksApi.TCP.CLIENT;
using System.Configuration;
using System.Net;

namespace Client_Application
{
    public delegate void UpdateTextBox(string txt);
    public delegate void UpdateDGV(int RowIndex, string txt, string val);
    public delegate void UpdateSStatusButtonText(string txt);
    public delegate void AddRowTracerDGV(string[] txt);
    public delegate void AddRowLineDGV(int RowIndex, string[] txt);
    public delegate void UpdateButEnaDisable();
    public partial class Form1 : Form
    {
        Client Clien = new Client();
        string MsgID = "";
        Button mySelectedButton;
        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        DataTable TempDT = new DataTable();
        Dictionary<string, string> StationStatus = new Dictionary<string, string>();
        Dictionary<string, string> StationDT = new Dictionary<string, string>();
        //bool updateMobNo = false;
        string LineNameGlobal = "";
        int rowInd = 0;
        int colInd = 0;
        string LastCMDMess = "";
        List<string> MessQueue = new List<string>();
        string[] MachineStatusTXT = new string[] { "RUNNING", "BREAKDOWN", "UNDER ANALYSIS", "PLANNED DOWN" };
        Color[] MachineStatusColor = new Color[] { Color.LawnGreen, Color.Red, Color.Yellow, Color.Orange };
        public Form1()
        {
            InitializeComponent();
            ClientNameTB.Text = config.AppSettings.Settings["ClientName"].Value.ToString();
            //StationNameL.Text = "TO BE SET";
            //MachineStaB.BackColor = Color.Red;
            ResendMessB.Enabled = false;

            string[] Lines = config.AppSettings.Settings["Lines"].Value.Split(',');

            foreach (string line in Lines)
                SelLineCB.Items.Add(line);

            //TempDT.Columns.Add("Station Name", typeof(string));
            //TempDT.Columns.Add("Status", typeof(string));
            //TempDT.Columns.Add("No of DT(s)", typeof(string));
            //TempDT.Columns.Add("Longest DT", typeof(string));
            //TempDT.Columns.Add("Total DT", typeof(string));

        }

        void UpdateLineDGV(int rInd, string txt, string val)
        {
            if (RecMessTB.InvokeRequired)
            {
                Invoke(new UpdateDGV(UpdateLineDGV), new object[] { rInd, txt, val });
            }
            else
            {
                LineDGV.Rows[rInd].Cells[txt].Value = val;
            }
        }

        void ChangeTextBox(string txt)
        {
            if (RecMessTB.InvokeRequired)
            {
                Invoke(new UpdateTextBox(ChangeTextBox), new object[] { txt });
            }
            else
            {
                RecMessTB.Text = RecMessTB.Text + DateTime.Now.ToString("dd-MM-yy HH:mm:ss - ") + txt + "\r\n";
            }
        }

        void LastCmdTextBox(string txt)
        {
            if (LastCmdTB.InvokeRequired)
            {
                Invoke(new UpdateTextBox(LastCmdTextBox), new object[] { txt });
            }
            else
            {
                LastCmdTB.Text = txt;
            }
        }

        void StationNameLabel(string txt)
        {
            if (StationNameL.InvokeRequired)
            {
                Invoke(new UpdateTextBox(StationNameLabel), new object[] { txt });
            }
            else
            {
                StationNameL.Text = txt;
            }
        }

        void LastRespTextBox(string txt)
        {
            if (LastRespTB.InvokeRequired)
            {
                Invoke(new UpdateTextBox(LastRespTextBox), new object[] { txt });
            }
            else
            {
                LastRespTB.Text = txt;
            }
        }

        void sStatusButtonText(string txt)
        {
            if (ServerStatus.InvokeRequired)
            {
                Invoke(new UpdateSStatusButtonText(sStatusButtonText), new object[] { txt });
            }
            else
            {
                ServerStatus.Text = txt;
            }
        }

        public void AddRowTracerDGV(string[] txt)
        {
            if (TracerDGV.InvokeRequired)
            {
                Invoke(new AddRowTracerDGV(AddRowTracerDGV), new object[] { txt });
            }
            else
            {
                TracerDGV.Rows.Add(txt);
                File.AppendAllText(Path.Combine(Application.StartupPath, "Tracer.txt"), String.Join("        ", txt) + Environment.NewLine);
            }
        }

        public void AddRowLineDGV(int RowIndex, string[] txt)
        {
            if (LineDGV.InvokeRequired)
            {
                Invoke(new AddRowLineDGV(AddRowLineDGV), new object[] { RowIndex, txt });
            }
            else
            {
                LineDGV.Rows.Add();
                UpdateLineDGV(RowIndex, "StationName", txt[0]);
                UpdateLineDGV(RowIndex, "Status", txt[1].Split(',')[0]);
                //LineDGV.Rows[RowIndex].Cells["StationName"].Value = txt[0];
                //LineDGV.Rows[RowIndex].Cells["Status"].Value = txt[1];

                for (int i=0; i<MachineStatusColor.Length; i++)
                    if (txt[1].Split(',')[0] == MachineStatusTXT[i])
                    LineDGV.Rows[RowIndex].Cells["Status"].Style.BackColor = MachineStatusColor[i];
                
                File.AppendAllText(Path.Combine(Application.StartupPath, "Tracer.txt"), String.Join("        ", txt) + Environment.NewLine);
            }
        }

        void RunningButEnab()
        {
            if (RunningB.InvokeRequired)
            {
                Invoke(new UpdateButEnaDisable(RunningButEnab));
            }
            else
            {
                RunningB.Enabled = true;
                RunningB.BackColor = Color.LawnGreen;
            }
        }

        void RunningButDisab()
        {
            if (RunningB.InvokeRequired)
            {
                Invoke(new UpdateButEnaDisable(RunningButDisab));
            }
            else
            {
                RunningB.Enabled = false;
                RunningB.BackColor = Color.LightGray;
            }
        }

        void BreakdownButEnab()
        {
            if (BreakdownB.InvokeRequired)
            {
                Invoke(new UpdateButEnaDisable(BreakdownButEnab));
            }
            else
            {
                BreakdownB.Enabled = true;
                BreakdownB.BackColor = Color.Red;
            }
        }

        void BreakdownButDisab()
        {
            if (BreakdownB.InvokeRequired)
            {
                Invoke(new UpdateButEnaDisable(BreakdownButDisab));
            }
            else
            {
                BreakdownB.Enabled = false;
                BreakdownB.BackColor = Color.LightGray;
            }
        }

        void UnderAnalysisButEnab()
        {
            if (UnderAnalysisB.InvokeRequired)
            {
                Invoke(new UpdateButEnaDisable(UnderAnalysisButEnab));
            }
            else
            {
                UnderAnalysisB.Enabled = true;
                UnderAnalysisB.BackColor = Color.Yellow;
            }
        }

        void UnderAnalysisButDisab()
        {
            if (UnderAnalysisB.InvokeRequired)
            {
                Invoke(new UpdateButEnaDisable(UnderAnalysisButDisab));
            }
            else
            {
                UnderAnalysisB.Enabled = false;
                UnderAnalysisB.BackColor = Color.LightGray;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clien.EncryptionEnabled = false;
            Clien.OnClientConnected += new OnClientConnectedDelegate(Clien_OnClientConnected);
            Clien.OnClientConnecting += new OnClientConnectingDelegate(Clien_OnClientConnecting);
            Clien.OnClientDisconnected += new OnClientDisconnectedDelegate(Clien_OnClientDisconnected);
            Clien.OnClientError += new OnClientErrorDelegate(Clien_OnClientError);
            Clien.OnClientFileSending += new OnClientFileSendingDelegate(Clien_OnClientFileSending);
            Clien.OnDataReceived += new OnClientReceivedDelegate(Clien_OnDataReceived);
            try
            {
                Clien.ClientName = ClientNameTB.Text;
                Clien.ServerIp = GetIPAddress(Dns.GetHostEntry(config.AppSettings.Settings["ServerIP"].Value.ToString())); //ss Environment.MachineName;
                Clien.ServerPort = config.AppSettings.Settings["ServerPort"].Value.ToString(); ;
                Clien.Connect();
                if (Clien.IsConnected)
                {
                    //ButEnab();
                    ServerStatus.BackColor = Color.LawnGreen;
                    sStatusButtonText("Server Connected..");
                }
                else
                {
                    //ButDisab();
                    ServerStatus.BackColor = Color.Red;
                    sStatusButtonText("Server not connected..");
                }
            }
            catch (Exception ex)
            {
                ServerStatus.BackColor = Color.Red;
                sStatusButtonText("Server not connected..");
                ChangeTextBox("Error in Connecting");
            }

            mySelectedButton = new Button();
            //mySelectedButton = Line1_ConScr;
            GlobalVar.myTxtBox = RecMessTB;
            TimeStamp.Text = DateTime.Now.ToString("ddddd, dd:MM:yy HH:mm:ss");
            RunningButDisab();
            BreakdownButDisab();
            UnderAnalysisButDisab();
           
        }

        private void ClienSend(string mess)
        {
            if (Clien.IsConnected)
            {
                Clien.Send(mess);
                AddRowTracerDGV(new string[] { DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", mess });
                LastCmdTextBox("["+DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] [" + "CMD" + "] [" + mess + "]");
                LastCMDMess = mess;
            }
            else
            {
                MessQueue.Add(mess);
                ServerStatus.BackColor = Color.Red;
                MessageBox.Show("Could not connect to server!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sStatusButtonText("Server not connected..");
                ChangeTextBox("Error in Connecting");
            }
        }


        void Clien_OnDataReceived(object Sender, ClientReceivedArguments R)
        {
            ChangeTextBox(R.ReceivedData);
            AddRowTracerDGV(new string[] {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "RES", R.ReceivedData});
            LastRespTextBox("[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] [" + "RES" + "] [" + R.ReceivedData + "]");
            string[] ReceivedDataArr = R.ReceivedData.Split(new string[] { "<|>" }, StringSplitOptions.None);
               // MsgID = DateTime.Now.ToString("yyMMddHHmmss");
                switch (ReceivedDataArr[0])
                {
                    case "SendSMS":
                        
                        ChangeTextBox(ReceivedDataArr[4]);
                        //switch (ReceivedDataArr[1])
                        //{
                        //    case "AT":
                        //        if (ReceivedDataArr[2] == MsgID)
                        //            if (ReceivedDataArr[3] == "ACK")
                        //                SendToServer("GSM,AT+CREG?," + MsgID);
                        //            else
                        //                SendToServer("GSM,AT," + MsgID);
                        //        break;

                        //    case "AT+CREG?":
                        //        if (ReceivedDataArr[2] == MsgID)
                        //            if (ReceivedDataArr[3] == "ACK")
                        //                SendToServer("GSM,AT+CREG?," + MsgID);
                        //            else
                        //                SendToServer("GSM,AT," + MsgID);
                        //        break;

                        //    default:
                        //        break;
                        //}
                        break;

                    case "STDT":
                        if (R.ReceivedData.Contains("ACK"))
                            MessQueue.Remove(R.ReceivedData.Substring(0,R.ReceivedData.IndexOf("<|>ACK")));
                            break;

                    case "GETDT":
                            if (R.ReceivedData.Contains("ACK"))
                            {
                                string[] myDTDet = ReceivedDataArr[3].Split(new string[] { "::" }, StringSplitOptions.None);
                                //dataGridView1.Rows[1].Cells[1].Value = myDTDet[1];
                                //dataGridView1.Rows[2].Cells[1].Value = myDTDet[2];
                                //dataGridView1.Rows[3].Cells[1].Value = myDTDet[3];
                                MessQueue.Remove(R.ReceivedData.Substring(0, R.ReceivedData.IndexOf("<|>ACK")));
                                
                                switch (myDTDet[0])
                                {
                                    case "RUNNING":
                                        UpdateLineDGV(rowInd, "Status", "RUNNING");
                                        //LineDGV.Rows[rowInd].Cells["Status"].Value = "RUNNING";
                                        RunningButDisab();
                                        BreakdownButEnab();
                                        UnderAnalysisButDisab();
                                        LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.LawnGreen;
                                        //PlannedDownB.Enabled = true;
                                        break;
                                    case "BREAKDOWN":
                                        UpdateLineDGV(rowInd, "Status", "BREAKDOWN");
                                        //LineDGV.Rows[rowInd].Cells["Status"].Value = "BREAKDOWN";
                                        RunningButDisab();
                                        BreakdownButDisab();
                                        UnderAnalysisButEnab();
                                        LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.Red;
                                        //PlannedDownB.Enabled = false;
                                        break;
                                    case "UNDER ANALYSIS":
                                        UpdateLineDGV(rowInd, "Status", "UNDER ANALYSIS");
                                        //LineDGV.Rows[rowInd].Cells["Status"].Value = "UNDER ANALYSIS";
                                        RunningButEnab();
                                        BreakdownButDisab();
                                        UnderAnalysisButDisab();
                                        LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.Yellow;
                                        //PlannedDownB.Enabled = false;
                                        break;
                                    case "PLANNED DT":
                                        UpdateLineDGV(rowInd, "Status", "PLANNED DT");
                                        //LineDGV.Rows[rowInd].Cells["Status"].Value = "PLANNED DT";
                                        RunningButEnab();
                                        BreakdownButDisab();
                                        UnderAnalysisButDisab();
                                        LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.Orange;
                                        //PlannedDownB.Enabled = false;
                                        break;
                                    default:
                                        break;

                                }

                                /*  Skipped 06-May-2016 -- Doesnt need to send and update downtime timestamps in client application
                                 *  downtimes should be updated in server side database
                                for (int i = 0; i<LineDGV.Rows.Count ; i++)
                                {
                                    if (LineDGV.Rows[i].Cells["StationName"].Value.ToString() == ReceivedDataArr[1].Split('@')[0].ToString())
                                    {
                                        UpdateLineDGV(i, "No_of_DT", myDTDet[1]);
                                        UpdateLineDGV(i, "LongestDT", myDTDet[3]);
                                        UpdateLineDGV(i, "TotalDT", myDTDet[2]);
                                        UpdateLineDGV(i, "LastDT", myDTDet[4]);
                                        break;
                                    }
                                }
                                 * 
                                 */

                                //MachineStaTB.Text = mySelectedButton.AccessibleDescription;
                            }
                            break;

                    case "GETEXP":
                            if (R.ReceivedData.Contains("ACK"))
                            {
                                MessQueue.Remove(R.ReceivedData.Substring(0, R.ReceivedData.IndexOf("<|>ACK")));
                                GlobalVar.GlobalDeptArr.Clear();
                                foreach (string expert in ReceivedDataArr[2].Split(','))
                                    GlobalVar.GlobalDeptArr.Add(expert);
                                //updateMobNo = true;
                            }
                            break;
                    case "GETLINECONFIG":
                            if (R.ReceivedData.Contains("ACK"))
                            {
                                MessQueue.Remove(R.ReceivedData.Substring(0, R.ReceivedData.IndexOf("<|>ACK")));
                                int LDGVR = 0;
                                StationStatus.Clear();
                                StationDT.Clear();
                                foreach (string stations in ReceivedDataArr[3].Split(new string[] { "::" }, StringSplitOptions.None))
                                {
                                    string[] values = stations.Split(new string[] { "@" }, StringSplitOptions.None);
                                    StationStatus.Add(values[0], values[1].Split(',')[0]);
                                    StationDT.Add(values[0], values[1].Split(',')[1]);

                                    AddRowLineDGV(LDGVR, values);

                                    //foreach (DataGridViewRow row in LineDGV.Rows)
                                    //{
                                    //    if (row.Cells[0].Value.ToString().Equals(values[0]))
                                    //    {
                                    //        rowInd = row.Index;
                                    //        break;
                                    //    }
                                    //}
                                    //switch (values[1].Split(',')[0])
                                    //{
                                    //    case "RUNNING":
                                    //        UpdateLineDGV(rowInd, "Status", "RUNNING");
                                    //        //LineDGV.Rows[rowInd].Cells["Status"].Value = "RUNNING";
                                    //        RunningButDisab();
                                    //        BreakdownButEnab();
                                    //        UnderAnalysisButDisab();
                                    //        LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.LawnGreen;
                                    //        //PlannedDownB.Enabled = true;
                                    //        break;
                                    //    case "BREAKDOWN":
                                    //        UpdateLineDGV(rowInd, "Status", "BREAKDOWN");
                                    //        //LineDGV.Rows[rowInd].Cells["Status"].Value = "BREAKDOWN";
                                    //        RunningButDisab();
                                    //        BreakdownButDisab();
                                    //        UnderAnalysisButEnab();
                                    //        LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.Red;
                                    //        //PlannedDownB.Enabled = false;
                                    //        break;
                                    //    case "UNDER ANALYSIS":
                                    //        UpdateLineDGV(rowInd, "Status", "UNDER ANALYSIS");
                                    //        //LineDGV.Rows[rowInd].Cells["Status"].Value = "UNDER ANALYSIS";
                                    //        RunningButEnab();
                                    //        BreakdownButDisab();
                                    //        UnderAnalysisButDisab();
                                    //        LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.Yellow;
                                    //        //PlannedDownB.Enabled = false;
                                    //        break;
                                    //    case "PLANNED DT":
                                    //        UpdateLineDGV(rowInd, "Status", "PLANNED DT");
                                    //        //LineDGV.Rows[rowInd].Cells["Status"].Value = "PLANNED DT";
                                    //        RunningButEnab();
                                    //        BreakdownButDisab();
                                    //        UnderAnalysisButDisab();
                                    //        LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.Orange;
                                    //        //PlannedDownB.Enabled = false;
                                    //        break;
                                    //    default:
                                    //        break;

                                    //}

                                    switch (values[1].Split(',')[0])
                                    {
                                        case "RUNNING":
                                            UpdateLineDGV(rowInd, "Status", "RUNNING");
                                            //LineDGV.Rows[rowInd].Cells["Status"].Value = "RUNNING";
                                            RunningButDisab();
                                            BreakdownButEnab();
                                            UnderAnalysisButDisab();
                                            LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.LawnGreen;
                                            //PlannedDownB.Enabled = true;
                                            break;
                                        case "BREAKDOWN":
                                            UpdateLineDGV(rowInd, "Status", "BREAKDOWN");
                                            //LineDGV.Rows[rowInd].Cells["Status"].Value = "BREAKDOWN";
                                            RunningButDisab();
                                            BreakdownButDisab();
                                            UnderAnalysisButEnab();
                                            LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.Red;
                                            //PlannedDownB.Enabled = false;
                                            break;
                                        case "UNDER ANALYSIS":
                                            UpdateLineDGV(rowInd, "Status", "UNDER ANALYSIS");
                                            //LineDGV.Rows[rowInd].Cells["Status"].Value = "UNDER ANALYSIS";
                                            RunningButEnab();
                                            BreakdownButDisab();
                                            UnderAnalysisButDisab();
                                            LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.Yellow;
                                            //PlannedDownB.Enabled = false;
                                            break;
                                        case "PLANNED DT":
                                            UpdateLineDGV(rowInd, "Status", "PLANNED DT");
                                            //LineDGV.Rows[rowInd].Cells["Status"].Value = "PLANNED DT";
                                            RunningButEnab();
                                            BreakdownButDisab();
                                            UnderAnalysisButDisab();
                                            LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = Color.Orange;
                                            //PlannedDownB.Enabled = false;
                                            break;
                                        default:
                                            break;

                                    }
                                    
                                    //ss ClienSend("GETDT<|>" + values[0]+"@"+LineNameGlobal);
                                    LineDGV.ClearSelection();
                                    LDGVR++;
                                }
                                StationNameLabel(LineDGV.Rows[0].Cells["StationName"].Value.ToString());
                                rowInd = 0;
                                colInd = 0;
                                ClienSend("GETEXP");
                                ClienSend("GETDT<|>" + LineDGV.Rows[0].Cells["StationName"].Value.ToString() + "@" + LineNameGlobal);
                            }
                            break;
                    default:
                        break;

                }

        }

        void Clien_OnClientFileSending(object Sender, ClientFileSendingArguments R)
        {
            // use this if you want to send a file
        }

        void Clien_OnClientError(object Sender, ClientErrorArguments R)
        {
            ChangeTextBox(R.ErrorMessage);
        }

        void Clien_OnClientDisconnected(object Sender, ClientDisconnectedArguments R)
        {
            //ButDisab();
            ChangeTextBox(R.EventMessage);
            ServerStatus.BackColor = Color.Red;
            sStatusButtonText("Server disconnected..");
        }

        void Clien_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
            ChangeTextBox(R.EventMessage);
        }

        void Clien_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            //ButEnab();
            ChangeTextBox(R.EventMessage);
            ServerStatus.BackColor = Color.LawnGreen;
            sStatusButtonText("Server Connected..");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            File.AppendAllText(Path.Combine(Application.StartupPath, "Log.txt"), RecMessTB.Text + Environment.NewLine);
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            //textBox4.Clear();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //textBox1.Clear();
        }
              

        //private void Station_Click_Init()
        //{
            
            //Line1_ConScr.Click += new EventHandler(this.Call_Sendmess);
            //Line1_SelSol.Click += new EventHandler(this.Call_Sendmess);
            //Line1_AOI.Click += new EventHandler(this.Call_Sendmess);
            //Line1_Flashing.Click += new EventHandler(this.Call_Sendmess);
            //Line1_ICT.Click += new EventHandler(this.Call_Sendmess);
            //Line1_ConCoating.Click += new EventHandler(this.Call_Sendmess);
            //Line1_CurOven.Click += new EventHandler(this.Call_Sendmess);
            //Line1_ThermalPasting.Click += new EventHandler(this.Call_Sendmess);
            //Line1_HSS.Click += new EventHandler(this.Call_Sendmess);
            //Line1_CoverClinching.Click += new EventHandler(this.Call_Sendmess);
            //Line1_HT.Click += new EventHandler(this.Call_Sendmess);
            //Line1_ColdChamber.Click += new EventHandler(this.Call_Sendmess);
            //Line1_FT.Click += new EventHandler(this.Call_Sendmess);
            //Line2_ConScr.Click += new EventHandler(this.Call_Sendmess);
            //Line2_SelSol.Click += new EventHandler(this.Call_Sendmess);
            //Line2_AOI.Click += new EventHandler(this.Call_Sendmess);
            //Line2_Flashing.Click += new EventHandler(this.Call_Sendmess);
            //Line2_ICT.Click += new EventHandler(this.Call_Sendmess);
            //Line2_ConCoating.Click += new EventHandler(this.Call_Sendmess);
            //Line2_CurOven.Click += new EventHandler(this.Call_Sendmess);
            //Line2_ThermalPasting.Click += new EventHandler(this.Call_Sendmess);
            //Line2_HSS.Click += new EventHandler(this.Call_Sendmess);
            //Line2_CoverClinching.Click += new EventHandler(this.Call_Sendmess);
            //Line2_HT.Click += new EventHandler(this.Call_Sendmess);
            //Line2_ColdChamber.Click += new EventHandler(this.Call_Sendmess);
            //Line2_FT.Click += new EventHandler(this.Call_Sendmess);

            //Line1_ConScr.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_SelSol.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_AOI.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_Flashing.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_ICT.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_ConCoating.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_CurOven.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_ThermalPasting.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_HSS.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_CoverClinching.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_HT.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_ColdChamber.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line1_FT.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_ConScr.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_SelSol.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_AOI.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_Flashing.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_ICT.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_ConCoating.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_CurOven.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_ThermalPasting.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_HSS.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_CoverClinching.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_HT.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_ColdChamber.MouseHover += new EventHandler(this.Change_ToolTip);
            //Line2_FT.MouseHover += new EventHandler(this.Change_ToolTip);
        //}       

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Call_Sendmess(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
        }

        private void Change_ToolTip(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToolTip1.SetToolTip(clickedButton, clickedButton.Text);
        }


        //private void MachineStaB_Click(object sender, EventArgs e)
        //{
            //ResendMessB.Enabled = false;
            //if (MachineStaB.Text.ToUpper() == "BREAKDOWN")
            //{
            //    GlobalVar.SendMessConfirm = true;              
            //    SendMessage newMessForm = new SendMessage(ref Clien, mySelectedButton.Text + " is down!");
            //    newMessForm.ShowDialog();
            //    if (GlobalVar.SendMessConfirm)
            //    {
            //        mySelectedButton.BackColor = Color.Red;
            //        mySelectedButton.AccessibleDescription = mySelectedButton.AccessibleDescription + "BreakDown Started:" + DateTime.Now.ToString("dd-MM-yy HH:mm:ss") + Environment.NewLine;
            //        // MachineStaTB.AppendText("BreakDown Started:" + DateTime.Now.ToString("yyMMddHHmmss") + Environment.NewLine);
            //        MachineStaTB.Text = mySelectedButton.AccessibleDescription;
            //        MachineStaB.Text = "ATTENDED";
            //        dataGridView1.Rows[0].Cells[1].Value = "WAITING FOR EXPERT";
            //        StationStatus[mySelectedButton.Name] = 2;
            //        StationDT[mySelectedButton.Name] = DateTime.Now.ToString("yyMMddHHmmss");
            //        MachineStaB.BackColor = Color.Yellow;
            //        PlannedDownB.Enabled = false;
            //        ResendMessB.Enabled = true;
            //    }

            //    AddRowTracerDGV(new string[] { DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", GlobalVar.myTxtBox.Text });
            //    return;
            //}

            //if (MachineStaB.Text.ToUpper() == "ATTENDED")
            //{                
            //    GlobalVar.SendMessConfirm = true;
            //    SendMessage newMessForm = new SendMessage(ref Clien, mySelectedButton.Text + " is under analysis!");
            //    newMessForm.ShowDialog();
            //    if (GlobalVar.SendMessConfirm)
            //    {
            //        mySelectedButton.BackColor = Color.Yellow;
            //        mySelectedButton.AccessibleDescription = mySelectedButton.AccessibleDescription + "Attended:" + DateTime.Now.ToString("dd-MM-yy HH:mm:ss") + Environment.NewLine;
            //        //MachineStaTB.AppendText("Attended:" + DateTime.Now.ToString("yyMMddHHmmss") + Environment.NewLine);
            //        MachineStaTB.Text = mySelectedButton.AccessibleDescription;
            //        MachineStaB.Text = "RUNNING";
            //        dataGridView1.Rows[0].Cells[1].Value = "UNDER ANALYSIS";
            //        StationStatus[mySelectedButton.Name] = 3;
            //        StationDT[mySelectedButton.Name] = StationDT[mySelectedButton.Name] + ";" + DateTime.Now.ToString("yyMMddHHmmss");
            //        MachineStaB.BackColor = Color.LawnGreen;
            //        PlannedDownB.Enabled = false;
            //    }

            //    AddRowTracerDGV(new string[] { DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", GlobalVar.myTxtBox.Text });
            //    return;
            //}

            //if (MachineStaB.Text.ToUpper() == "RUNNING")
            //{             
            //    GlobalVar.SendMessConfirm = true;
            //    SendMessage newMessForm = new SendMessage(ref Clien, mySelectedButton.Text + " is OK");
            //    newMessForm.ShowDialog();
            //    if (GlobalVar.SendMessConfirm)
            //    {
            //        mySelectedButton.BackColor = Color.LawnGreen;
            //        mySelectedButton.AccessibleDescription = mySelectedButton.AccessibleDescription + "RUNNING:" + DateTime.Now.ToString("dd-MM-yy HH:mm:ss") + Environment.NewLine;
            //        //MachineStaTB.AppendText("RUNNING:" + DateTime.Now.ToString("yyMMddHHmmss") + Environment.NewLine);
            //        MachineStaTB.Text = mySelectedButton.AccessibleDescription;
            //        MachineStaB.Text = "BREAKDOWN";
            //        dataGridView1.Rows[0].Cells[1].Value = "RUNNING";
            //        StationStatus[mySelectedButton.Name] = 1;
            //        StationDT[mySelectedButton.Name] = StationDT[mySelectedButton.Name] + ";" + DateTime.Now.ToString("yyMMddHHmmss");
            //        MachineStaB.BackColor = Color.Red;
            //        string cmdtext = "STDT<|>" + mySelectedButton.Name + "<|>" + "U" + "<|>" + StationDT[mySelectedButton.Name].Split(';')[0] + "<|>" + StationDT[mySelectedButton.Name].Split(';')[1] + "<|>" + StationDT[mySelectedButton.Name].Split(';')[2];
            //        if (Clien.IsConnected)
            //        {
            //            Clien.Send(cmdtext);
            //            AddRowTracerDGV(new string[] {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", cmdtext});
            //        }
            //        else
            //            MessQueue.Add(cmdtext);
            //        mySelectedButton.AccessibleDescription = "";
            //        PlannedDownB.Enabled = true;
            //    }

            //    AddRowTracerDGV(new string[] { DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", GlobalVar.myTxtBox.Text });
            //    return;
            //}

            //if (MachineStaB.Text.ToUpper() == "PLANNED DT DONE")
            //{
            //    GlobalVar.SendMessConfirm = true;
            //    SendMessage newMessForm = new SendMessage(ref Clien, mySelectedButton.Text + " is OK");
            //    newMessForm.ShowDialog();
            //    if (GlobalVar.SendMessConfirm)
            //    {
            //        mySelectedButton.BackColor = Color.LawnGreen;
            //        mySelectedButton.AccessibleDescription = mySelectedButton.AccessibleDescription + "PLANNED DT DONE:" + DateTime.Now.ToString("dd-MM-yy HH:mm:ss") + Environment.NewLine;
            //        //MachineStaTB.AppendText("PLAANED DT DONE:" + DateTime.Now.ToString("yyMMddHHmmss") + Environment.NewLine);
            //        MachineStaTB.Text = mySelectedButton.AccessibleDescription;
            //        MachineStaB.Text = "BREAKDOWN";
            //        dataGridView1.Rows[0].Cells[1].Value = "RUNNING";
            //        StationStatus[mySelectedButton.Name] = 1;
            //        StationDT[mySelectedButton.Name] = StationDT[mySelectedButton.Name] + ";" + DateTime.Now.ToString("yyMMddHHmmss");
            //        MachineStaB.BackColor = Color.Red;

            //        // both DT starting time and attending time same.
            //        string cmdtext = "STDT<|>" + mySelectedButton.Name + "<|>" + "P" + "<|>" + StationDT[mySelectedButton.Name].Split(';')[0] + "<|>" + StationDT[mySelectedButton.Name].Split(';')[0] + "<|>" + StationDT[mySelectedButton.Name].Split(';')[1];
                        
            //        if (Clien.IsConnected)
            //        {
            //            Clien.Send(cmdtext);
            //            AddRowTracerDGV(new string[] {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", cmdtext});
            //        }
            //        else
            //            MessQueue.Add(cmdtext);
            //        mySelectedButton.AccessibleDescription = "";
            //        PlannedDownB.Enabled = true;
            //    }

            //    AddRowTracerDGV(new string[] { DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", GlobalVar.myTxtBox.Text });
            //    return;
            //}
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Clien.IsConnected)
            {
                ServerStatus.BackColor = Color.LawnGreen;
                sStatusButtonText("Server Connected..");
                //ButEnab();
                if (MessQueue.Count > 0)
                {
                    Clien.Send(MessQueue[0]);
                    AddRowTracerDGV(new string[] {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", MessQueue[0]});
                }
            }
            else
            {
                //ButDisab();
                ServerStatus.BackColor = Color.Red;
                sStatusButtonText("Server not connected..");
                ChangeTextBox("No Server connection!");
                try
                {                    
                    Clien.Connect();
                    if (Clien.IsConnected)
                    {
                        //ButEnab();
                        ServerStatus.BackColor = Color.LawnGreen;
                        sStatusButtonText("Server Connected..");
                        if (MessQueue.Count > 0)
                        {
                            Clien.Send(MessQueue[0]);
                            AddRowTracerDGV(new string[] {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", MessQueue[0]});
                        }
                    }
                    else
                    {
                        //ButDisab();
                        ServerStatus.BackColor = Color.Red;
                        sStatusButtonText("Server not connected..");
                    }
                }
                catch (Exception ex)
                {
                    //ButDisab();
                    ServerStatus.BackColor = Color.Red;
                    sStatusButtonText("Server not connected..");
                    ChangeTextBox("Error in Connecting");
                }
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    mySelectedButton.BackColor = Color.LightGray;
        //    mySelectedButton.AccessibleDescription = mySelectedButton.AccessibleDescription + "Planned DT:" + DateTime.Now.ToString("dd-MM-yy HH:mm:ss") + Environment.NewLine;
        //    //MachineStaTB.AppendText("Planned DT:" + DateTime.Now.ToString("yyMMddHHmmss") + Environment.NewLine);
        //    MachineStaTB.Text = mySelectedButton.AccessibleDescription;
        //    MachineStaB.Text = "PLANNED DT DONE";
        //    dataGridView1.Rows[0].Cells[1].Value = "PLANNED M/C DOWN";
        //    StationStatus[mySelectedButton.Name] = 4;
        //    StationDT[mySelectedButton.Name] = DateTime.Now.ToString("yyMMddHHmmss"); 
        //    MachineStaB.BackColor = Color.LawnGreen;
        //    PlannedDownB.Enabled = false;
        //    ResendMessB.Enabled = false;
        //}

        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeStamp.Text = DateTime.Now.ToString("ddddd, dd-MM-yy HH:mm:ss");            
        }

        private void ResendMessB_Click(object sender, EventArgs e)
        {
            ClienSend(GlobalVar.myTxtBox.Text);
        }

        private void LineDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {

                rowInd = e.RowIndex;
                colInd = e.ColumnIndex;
                    string StatusText = LineDGV.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                    string StationName = LineDGV.Rows[e.RowIndex].Cells["StationName"].Value.ToString();

                    StationNameL.Text = StationName;

                   ClienSend("GETDT<|>" + StationName + "@" + LineNameGlobal);                    

                    ResendMessB.Enabled = false;

                        //Clien.Send("GETEXP<|>" + StationNameL.Text);
                        //AddRowTracerDGV(new string[] { DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", "GETEXP<|>" + StationNameL.Text });

                        //updateMobNo = false;

                        //while (updateMobNo) ;

                        //int staCode = StationStatus[StationNameL.Text];
                        //switch (StatusText.ToUpper())
                        //{
                        //    case "RUNNING":
                        //        LineDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "BREAKDOWN";
                        //        MachineStaTB.Text = mySelectedButton.AccessibleDescription;
                        //        LineDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                        //        //PlannedDownB.Enabled = true;
                        //        break;
                        //    case "BREAKDOWN":
                        //        LineDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "ATTENDED";
                        //        MachineStaTB.Text = mySelectedButton.AccessibleDescription;
                        //        LineDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                        //        //PlannedDownB.Enabled = false;
                        //        break;
                        //    case "ATTENDED":
                        //        LineDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "RUNNING";
                        //        MachineStaTB.Text = mySelectedButton.AccessibleDescription;
                        //        LineDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LawnGreen;
                        //        //PlannedDownB.Enabled = false;
                        //        break;
                        //    case "PLANNED DT":
                        //        LineDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "PLANNED DT DONE";
                        //        MachineStaTB.Text = mySelectedButton.AccessibleDescription;
                        //        LineDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LawnGreen;
                        //        //PlannedDownB.Enabled = false;
                        //        break;
                        //    default:
                        //        break;

                        //}
                        // dataGridView1.Rows[0].Cells[1].Value = MachineStatusTXT[staCode - 1];
                    


                    //if (StatusText.ToUpper() == "BREAKDOWN")
                    //{
                        
                    //}

                    //if (StatusText.ToUpper() == "ATTENDED")
                    //{
                        
                    //}

                    //if (StatusText.ToUpper() == "RUNNING")
                    //{
                        
                    //}

                    //if (StatusText.ToUpper() == "PLANNED DT DONE")
                    //{
                    //    GlobalVar.SendMessConfirm = true;
                    //    SendMessage newMessForm = new SendMessage(ref Clien, StationName + " is OK");
                    //    newMessForm.ShowDialog();
                    //    if (GlobalVar.SendMessConfirm)
                    //    {
                    //        mySelectedButton.BackColor = Color.LawnGreen;
                    //        mySelectedButton.AccessibleDescription = mySelectedButton.AccessibleDescription + "PLANNED DT DONE:" + DateTime.Now.ToString("dd-MM-yy HH:mm:ss") + Environment.NewLine;
                    //        //MachineStaTB.AppendText("PLAANED DT DONE:" + DateTime.Now.ToString("yyMMddHHmmss") + Environment.NewLine);
                    //        MachineStaTB.Text = mySelectedButton.AccessibleDescription;
                    //        LineDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "BREAKDOWN";
                    //        //dataGridView1.Rows[0].Cells[1].Value = "RUNNING";
                    //        StationStatus[StationName] = "RUNNING";
                    //        StationDT[StationName] = StationDT[StationName] + ";" + DateTime.Now.ToString("yyMMddHHmmss");
                    //        LineDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;

                    //        // both DT starting time and attending time same.
                    //        string cmdtext = "STDT<|>" + StationName + "<|>" + "P" + "<|>" + StationDT[StationName].Split(';')[0] + "<|>" + StationDT[StationName].Split(';')[0] + "<|>" + StationDT[StationName].Split(';')[1];

                    //        ClienSend(cmdtext);

                    //        mySelectedButton.AccessibleDescription = "";
                    //        //PlannedDownB.Enabled = true;
                    //    }

                    //    AddRowTracerDGV(new string[] { DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", GlobalVar.myTxtBox.Text });
                    //    return;
                    
                //}
            }
        }

        private void SelLineCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            StationStatus.Clear();
            StationDT.Clear();
            LineDGV.Rows.Clear();
            LineNameGlobal = SelLineCB.Text;
            ClienSend("GETLINECONFIG<|>" + LineNameGlobal);
        }
        
        private void Running_Click(object sender, EventArgs e)
        {
            GlobalVar.SendMessConfirm = true;
            SendMessage newMessForm = new SendMessage(ref Clien, LineNameGlobal + ":" + StationNameL.Text + " is OK");
            newMessForm.ShowDialog();
            if (GlobalVar.SendMessConfirm)
            {
                mySelectedButton.BackColor = Color.LawnGreen;
                mySelectedButton.AccessibleDescription = mySelectedButton.AccessibleDescription + "RUNNING:" + DateTime.Now.ToString("dd-MM-yy HH:mm:ss") + Environment.NewLine;
                //MachineStaTB.AppendText("RUNNING:" + DateTime.Now.ToString("yyMMddHHmmss") + Environment.NewLine);
                //ssMachinestaTB.Text = mySelectedButton.AccessibleDescription;
                UpdateLineDGV(rowInd, "Status", "RUNNING");
                //LineDGV.Rows[rowInd].Cells["Status"].Value = "RUNNING";
                //dataGridView1.Rows[0].Cells[1].Value = "RUNNING";
                RunningButDisab();
                BreakdownButEnab();
                UnderAnalysisButDisab();
                StationStatus[StationNameL.Text] = "RUNNING";
                StationDT[StationNameL.Text] = StationDT[StationNameL.Text] + ";" + DateTime.Now.ToString("yyMMddHHmmss");
                LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = LineDGV.DefaultCellStyle.SelectionBackColor = Color.LawnGreen;
                ClienSend("UPDATE_STATUS<|>" + StationNameL.Text + "@" + LineNameGlobal + "<|>" + "RUNNING" + "<|>" + "");
                string cmdtext = "STDT<|>" + StationNameL.Text + "@" + LineNameGlobal + "<|>" + "U" + "<|>" + StationDT[StationNameL.Text].Split(';')[0] + "<|>" + StationDT[StationNameL.Text].Split(';')[1] + "<|>" + StationDT[StationNameL.Text].Split(';')[2];
                ClienSend(cmdtext);
                mySelectedButton.AccessibleDescription = "";
                //PlannedDownB.Enabled = true;
                ResendMessB.Enabled = true;
                //ss ClienSend("GETDT<|>" + StationNameL.Text + "@" + LineNameGlobal);
            }

            AddRowTracerDGV(new string[] { DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", GlobalVar.myTxtBox.Text });
            return;
        }

        private void Breakdown_Click(object sender, EventArgs e)
        {
            GlobalVar.SendMessConfirm = true;
            SendMessage newMessForm = new SendMessage(ref Clien, LineNameGlobal + ":" + StationNameL.Text + " is down!");
            newMessForm.ShowDialog();
            if (GlobalVar.SendMessConfirm)
            {
                mySelectedButton.BackColor = Color.Red;
                mySelectedButton.AccessibleDescription = mySelectedButton.AccessibleDescription + "BreakDown Started:" + DateTime.Now.ToString("dd-MM-yy HH:mm:ss") + Environment.NewLine;
                // MachineStaTB.AppendText("BreakDown Started:" + DateTime.Now.ToString("yyMMddHHmmss") + Environment.NewLine);
                //ssMachinestaTB.Text = mySelectedButton.AccessibleDescription;
                UpdateLineDGV(rowInd, "Status", "BREAKDOWN");
                //LineDGV.Rows[rowInd].Cells["Status"].Value = "UNDER ANALYSIS";
                //dataGridView1.Rows[0].Cells[1].Value = "UNDER ANALYSIS";
                RunningButDisab();
                BreakdownButDisab();
                UnderAnalysisButEnab();
                StationStatus[StationNameL.Text] = "BREAKDOWN";
                StationDT[StationNameL.Text] = DateTime.Now.ToString("yyMMddHHmmss");
                LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = LineDGV.DefaultCellStyle.SelectionBackColor = Color.Red;
                ClienSend("UPDATE_STATUS<|>" + StationNameL.Text + "@" + LineNameGlobal + "<|>" + "BREAKDOWN" + "<|>" + StationDT[StationNameL.Text].Trim(';'));
                //PlannedDownB.Enabled = false;
                ResendMessB.Enabled = true;
            }

            AddRowTracerDGV(new string[] { DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", GlobalVar.myTxtBox.Text });
            return;
        }

        private void UnderAnalysis_Click(object sender, EventArgs e)
        {
            GlobalVar.SendMessConfirm = true;
            SendMessage newMessForm = new SendMessage(ref Clien, LineNameGlobal + ":" + StationNameL.Text + " is under analysis!");
            newMessForm.ShowDialog();
            if (GlobalVar.SendMessConfirm)
            {
                mySelectedButton.BackColor = Color.Yellow;
                mySelectedButton.AccessibleDescription = mySelectedButton.AccessibleDescription + "Attended:" + DateTime.Now.ToString("dd-MM-yy HH:mm:ss") + Environment.NewLine;
                //MachineStaTB.AppendText("Attended:" + DateTime.Now.ToString("yyMMddHHmmss") + Environment.NewLine);
                //ssMachinestaTB.Text = mySelectedButton.AccessibleDescription;
                UpdateLineDGV(rowInd, "Status", "UNDER ANALYSIS");
                //LineDGV.Rows[rowInd].Cells["Status"].Value = "UNDER ANALYSIS";
                //dataGridView1.Rows[0].Cells[1].Value = "UNDER ANALYSIS";
                RunningButEnab();
                BreakdownButDisab();
                UnderAnalysisButDisab();
                StationStatus[StationNameL.Text] = "UNDER ANALYSIS";
                StationDT[StationNameL.Text] = StationDT[StationNameL.Text] + ";" + DateTime.Now.ToString("yyMMddHHmmss");
                LineDGV.Rows[rowInd].Cells["Status"].Style.BackColor = LineDGV.DefaultCellStyle.SelectionBackColor = Color.Yellow;
                ClienSend("UPDATE_STATUS<|>" + StationNameL.Text + "@" + LineNameGlobal + "<|>" + "UNDER ANALYSIS" + "<|>" + StationDT[StationNameL.Text].Trim(';'));
                //PlannedDownB.Enabled = false;
                ResendMessB.Enabled = true;
            }

            AddRowTracerDGV(new string[] { DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "CMD", GlobalVar.myTxtBox.Text });
            return;
        }

        private void LineDGV_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                LineDGV.ClearSelection();
                LineDGV.DefaultCellStyle.SelectionBackColor = LineDGV.Rows[e.RowIndex].Cells["Status"].Style.BackColor;
                LineDGV.DefaultCellStyle.SelectionForeColor = Color.Black;
                //LineDGV.Rows[e.RowIndex].Selected = true;
            }
            else
            {
                LineDGV.ClearSelection();
                LineDGV.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            }

        }

        private void RefreshStatus_Click(object sender, EventArgs e)
        {
            if (LineNameGlobal != null && LineNameGlobal != "")
            {
                StationStatus.Clear();
                StationDT.Clear();
                LineDGV.Rows.Clear();
                LineNameGlobal = SelLineCB.Text;
                ClienSend("GETLINECONFIG<|>" + LineNameGlobal);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlobalVar.SendMessConfirm = true;
            SendMessage newMessForm = new SendMessage(ref Clien, "");
            newMessForm.ShowDialog();
            if (GlobalVar.SendMessConfirm)
            {
                MessageBox.Show("Message Sent to server!", "Send Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static private string GetIPAddress(IPHostEntry host)
        {
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    //System.Diagnostics.Debug.WriteLine("LocalIPadress: " + ip);
                    return ip.ToString();
                }
            }
            return "";
        }
                
    }
}

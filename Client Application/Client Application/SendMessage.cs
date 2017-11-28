using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetworksApi.TCP.CLIENT;

namespace Client_Application
{
    public partial class SendMessage : Form
    {
        Client myClient;
        string Default_Message = "";
        public SendMessage(ref Client Clien, string DefMes)
        {
            InitializeComponent();
            myClient = Clien;
            Default_Message = textBox1.Text = DefMes;
            GlobalVar.SendMessConfirm = false;
            GlobalVar.myTxtBox = textBox1;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlobalVar.SendMessConfirm = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ChoseMob = "";
            if (ChooseContactsCLB.CheckedItems.Count > 0)
            {
                foreach (string cbText in ChooseContactsCLB.CheckedItems)
                    ChoseMob = ChoseMob + cbText + "::";

                ChoseMob = ChoseMob.Trim(':');

                GlobalVar.myTxtBox.Text = "SendSMS<|>" + ChoseMob + "<|>" + textBox1.Text;

                if (myClient.IsConnected)
                {
                    myClient.Send(GlobalVar.myTxtBox.Text);
                }
                GlobalVar.SendMessConfirm = true;
                this.Close();
            }
            else
                MessageBox.Show("Please select atleast 1 contact!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SendMessage_Load(object sender, EventArgs e)
        {
            foreach (string str in GlobalVar.GlobalDeptArr)
                if (str != "")
                ChooseContactsCLB.Items.Add(str);

            for (int i = 0; i < ChooseContactsCLB.Items.Count; i++)
                ChooseContactsCLB.SetItemChecked(i, false);

            if (ChooseContactsCLB.Items.Count > 0)
                button1.Enabled = true;
            SelAllB.Text = "Select All";
        }

        private void SelAllB_Click(object sender, EventArgs e)
        {
            if (SelAllB.Text.ToLower() == "select all")
            {
                for (int x = 0; x < ChooseContactsCLB.Items.Count; x++)
                {
                    ChooseContactsCLB.SetItemCheckState(x, CheckState.Checked);
                }
                SelAllB.Text = "Deselect All";
                return;
            }

            if (SelAllB.Text.ToLower() == "deselect all")
            {
                for (int x = 0; x < ChooseContactsCLB.Items.Count; x++)
                {
                    ChooseContactsCLB.SetItemCheckState(x, CheckState.Unchecked);
                }
                SelAllB.Text = "Select All";
            }
        }

      
    }

    public static class GlobalVar
    {
        static bool _globalValue;
        static TextBox _myTB = new TextBox();
        static List<string> _MobNoArr = new List<string>();
        public static bool SendMessConfirm
        {
            get
            {
                return _globalValue;
            }
            set
            {
                _globalValue = value;
            }
        }

        public static List<string> GlobalDeptArr
        {
            get
            {
                return _MobNoArr;
            }
            set
            {
                _MobNoArr = value;
            }
        }

        public static TextBox myTxtBox
        {
            get
            {
                return _myTB;
            }
            set
            {
                _myTB = value;
            }
        }

    }
}

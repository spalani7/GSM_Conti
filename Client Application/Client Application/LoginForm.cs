using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Client_Application
{
    public partial class LoginForm : Form
    {
        //ssprivate OleDbConnection myCon;
        //sspublic OleDbCommand command, command1;
        //ssstring empName = "", empID = "";
        public LoginForm()
        {
            //ssmyCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\uidw8018\Documents\ICTDB.mdb;Persist Security Info=False");
            InitializeComponent();
            menuStrip1.Visible = false;
            //Create_DBTable();
            KeyPreview = true;
            //sscommand = new OleDbCommand("SELECT * FROM Login", myCon);
            PasswordTB.Clear();
            AcceptButton = LoginB;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //myCon.Open();
                //using (OleDbDataReader reader = command.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        UsernameCB.Items.Add(reader.GetString(0).ToString());
                //    }
                //    reader.Close();
                //}
                UsernameCB.Items.Add("MDPSLine");
                if (UsernameCB.Items.Count == 0)
                {
                    MessageBox.Show("No users found in database. Check the database. Bye till then!");
                    //Application.Exit();
                }
                else
                {
                    UsernameCB.SelectedIndex = 0;
                    ActiveControl = PasswordTB;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void LoginB_Click(object sender, EventArgs e)
        {
            try
            {
                //using (OleDbDataReader reader = command.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                        //MessageBox.Show(reader.GetString(1) + ";" + UsernameCB.SelectedItem);
                        if (UsernameCB.SelectedItem.ToString() != "")
                        {
                            if (PasswordTB.Text == "MDPSBE@123")
                            {
                                //ssMessageBox.Show("Login Success");
                                //ssempName = reader.GetString(1).ToString();
                                //ssempID = reader.GetString(0).ToString();
                                Form1 MForm = new Form1();
                                MForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Password.");
                                PasswordTB.Clear();
                                ActiveControl = PasswordTB;
                            }
                           //ss break;
                       }
                  //ss  }

                    //ssreader.Close();
               //ss }
            }
            catch (Exception exct)
            {
                MessageBox.Show(exct.Message);
            }
            
        }
        

        private void ExitB_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to exit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
                Application.Exit();
            else
                PasswordTB.Clear();
        }

        private void UsernameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            menuToolStripMenuItem.PerformClick();
           PasswordTB.Clear();
           //ActiveControl = PasswordTB;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to exit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
                Application.Exit();
        }

        //private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    NewUserForm NUForm = new NewUserForm();
        //    NUForm.Show();
        //    this.Hide();
        //}

        //private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ChangePassword CPForm = new ChangePassword(UsernameCB.SelectedItem.ToString());
        //    CPForm.Show();
        //    this.Hide();
        //}

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                LoginB.PerformClick();
            if (e.KeyCode == Keys.F6)
                ExitB.PerformClick();
        }

        //private void Create_DBTable()
        //{
        //    //command = new OleDbCommand("CREATE TABLE Login (Emp_ID varchar(255) NOT NULL,Emp_Name varchar(255) NOT NULL,Emp_Dept varchar(255) NOT NULL,Emp_MobNo varchar(255) NOT NULL,Emp_Password varchar(255) NOT NULL,Emp_SecAns varchar(255) NOT NULL,Emp_SecQuesNo varchar(255) NOT NULL, PRIMARY KEY (Emp_ID))", myCon);
        //    //command1 = new OleDbCommand("INSERT INTO Login (Emp_ID,Emp_Name,Emp_Dept,Emp_MobNo,Emp_Password,Emp_SecAns,Emp_SecQuesNo) VALUES ('" + "6254" + "','" + "Sundar" + "','" + "TE" + "','" + "9611899373" + "','" + "Ganesh" + "','"+ "Sundar" + "','" + "3"+"')", myCon);
        //    //command1 = new OleDbCommand("DROP TABLE Login", myCon);
        //    command1 = new OleDbCommand("CREATE TABLE SecQues (Sec_ID varchar(255) NOT NULL, Security_Questions varchar(255) NOT NULL, PRIMARY KEY (Sec_ID))", myCon);
            
        //    string[] mySecQues = { "What is the name of the place your wedding reception was held?","In what city or town did you meet your spouse/partner?",
        //                             "Which is your most longest serving company till now ?","What was the make and model of your first car?",
        //                             "What was the name of your elementary / primary school?","What was your favorite place to visit as a child?",
        //                             "What was your first company ?","What is your pet’s name?","In what year was your father born?","What is your favourite sports team?",
        //                             "Who is your favourite bollywood actress?","What is the name of your first crush ?","Which place did your mother born?",
        //                             "Which is the native place for your father?","Who is your favourite primary school teacher?"};
        //    try
        //    {
        //        myCon.Open();
        //        command1.ExecuteNonQuery();
        //        //MessageBox.Show("Table Login Deleted successfully");
        //        //command.ExecuteNonQuery();
        //        //MessageBox.Show("Table Created successfully");
        //        int SecCNT = 0;
        //        foreach (string s in mySecQues)
        //        {
        //            SecCNT += 1;
        //            command = new OleDbCommand("INSERT INTO SecQues (Sec_ID,Security_Questions) VALUES ('" + SecCNT.ToString() +"','" + s + "')",myCon);
        //            command.ExecuteNonQuery();
        //        }
        //        myCon.Close();
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message);
        //    }
        //}

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}

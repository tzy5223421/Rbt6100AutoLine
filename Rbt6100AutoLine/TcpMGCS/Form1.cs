using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rbt6100AutoLine.TcpMachine;
namespace TcpMGCS
{
    public partial class Form1 : Form
    {
        TcpMachine tcpm = new TcpMachine();
        byte[] Light1_on = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 00, 0xFF, 00 };
        byte[] Light2_on = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 01, 0xFF, 00 };
        byte[] Light3_on = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 02, 0xFF, 00 };
        byte[] Light4_on = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 03, 0xFF, 00 };
        byte[] Light5_on = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 04, 0xFF, 00 };
        byte[] Light6_on = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 05, 0xFF, 00 };
        byte[] Light7_on = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 06, 0xFF, 00 };
        byte[] Light8_on = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 07, 0xFF, 00 };
        byte[] Light9_on = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 08, 0xFF, 00 };

        byte[] Light1_off = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 00, 00, 00 };
        byte[] Light2_off = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 01, 00, 00 };
        byte[] Light3_off = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 02, 00, 00 };
        byte[] Light4_off = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 03, 00, 00 };
        byte[] Light5_off = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 04, 00, 00 };
        byte[] Light6_off = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 05, 00, 00 };
        byte[] Light7_off = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 06, 00, 00 };
        byte[] Light8_off = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 07, 00, 00 };
        byte[] Light9_off = new byte[] { 00, 00, 00, 00, 00, 06, 01, 05, 00, 08, 00, 00 };

        public Form1()
        {
            InitializeComponent();
            tcpm.StartListen(3000);
            tcpm.reciveSocketData += Tcpm_reciveSocketData;
        }

        private void Tcpm_reciveSocketData(System.Net.EndPoint RemoteEndPoint, byte[] data)
        {
            //  throw new NotImplementedException();
            //    if (data.Length == 12)
            //   {
            if (data[5] == 0x06 && data[10] == 255 && data[9] == 0x0)
            {
                panel1.Invoke(new Action(() => { panel1.BackgroundImage = Properties.Resources.green_Light; }));
         //       tcpm.Send_Byte(Light1_off);
            }
            if (data[5] == 0x06 && data[10] == 0x00 && data[9] == 0x0)
            {
                panel1.Invoke(new Action(() => { panel1.BackgroundImage = Properties.Resources.red_Light; }));
            }

            if (data[5] == 0x06 && data[10] == 255 && data[9] == 0x1)
            {
                panel2.Invoke(new Action(() => { panel2.BackgroundImage = Properties.Resources.green_Light; }));
            }
            if (data[5] == 0x06 && data[10] == 0x00 && data[9] == 0x1)
            {
                panel2.Invoke(new Action(() => { panel2.BackgroundImage = Properties.Resources.red_Light; }));
            }
            if (data[5] == 0x06 && data[10] == 255 && data[9] == 0x2)
            {
                panel3.Invoke(new Action(() => { panel3.BackgroundImage = Properties.Resources.green_Light; }));
            }
            if (data[5] == 0x06 && data[10] == 0x00 && data[9] == 0x2)
            {
                panel3.Invoke(new Action(() => { panel3.BackgroundImage = Properties.Resources.red_Light; }));
            }

            if (data[5] == 0x06 && data[10] == 255 && data[9] == 0x3)
            {
                panel4.Invoke(new Action(() => { panel4.BackgroundImage = Properties.Resources.green_Light; }));
            }
            if (data[5] == 0x06 && data[10] == 0x00 && data[9] == 0x3)
            {
                panel4.Invoke(new Action(() => { panel4.BackgroundImage = Properties.Resources.red_Light; }));
            }

            if (data[5] == 0x06 && data[10] == 255 && data[9] == 0x4)
            {
                panel5.Invoke(new Action(() => { panel5.BackgroundImage = Properties.Resources.green_Light; }));
            }
            if (data[5] == 0x06 && data[10] == 0x00 && data[9] == 0x4)
            {
                panel5.Invoke(new Action(() => { panel5.BackgroundImage = Properties.Resources.red_Light; }));
            }

            if (data[5] == 0x06 && data[10] == 255 && data[9] == 0x5)
            {
                panel6.Invoke(new Action(() => { panel6.BackgroundImage = Properties.Resources.green_Light; }));
            }
            if (data[5] == 0x06 && data[10] == 0x00 && data[9] == 0x5)
            {
                panel6.Invoke(new Action(() => { panel6.BackgroundImage = Properties.Resources.red_Light; }));
            }

            if (data[5] == 0x06 && data[10] == 255 && data[9] == 0x6)
            {
                panel7.Invoke(new Action(() => { panel7.BackgroundImage = Properties.Resources.green_Light; }));
            }
            if (data[5] == 0x06 && data[10] == 0x00 && data[9] == 0x6)
            {
                panel7.Invoke(new Action(() => { panel7.BackgroundImage = Properties.Resources.red_Light; }));
            }

            if (data[5] == 0x06 && data[10] == 255 && data[9] == 0x7)
            {
                panel8.Invoke(new Action(() => { panel8.BackgroundImage = Properties.Resources.green_Light; }));
            }
            if (data[5] == 0x06 && data[10] == 0x00 && data[9] == 0x7)
            {
                panel8.Invoke(new Action(() => { panel8.BackgroundImage = Properties.Resources.red_Light; }));
            }

            if (data[5] == 0x06 && data[10] == 255 && data[9] == 0x8)
            {
                panel9.Invoke(new Action(() => { panel9.BackgroundImage = Properties.Resources.green_Light; }));
            }
            if (data[5] == 0x06 && data[10] == 0x00 && data[9] == 0x8)
            {
                panel9.Invoke(new Action(() => { panel9.BackgroundImage = Properties.Resources.red_Light; }));
            }
            //    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light1_on);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light1_off);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light2_on);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light2_off);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light3_on);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light3_off);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light4_on);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light4_off);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light5_on);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light5_off);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light6_on);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light6_off);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light7_on);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light7_off);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light8_on);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light8_off);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light9_on);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tcpm.Send_Byte(Light9_off);
        }
    }
}

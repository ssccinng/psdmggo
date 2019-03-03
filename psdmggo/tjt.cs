using PglLinkPs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace psdmggo
{
    public partial class tjt : Form
    {
        resstruct[,] icefairy;
        int flag;
        public tjt(resstruct[,] icefairy, int flag)
        {
            this.flag = flag;
            this.icefairy = icefairy;
            InitializeComponent();
        }
        public class zhuzhuang1
        {
            Label min = new Label(), max = new Label();
            Label minimg = new Label();//maximg = new Label();
            Label dmgdec = new Label();
            Label statdec = new Label();

            public zhuzhuang1(resstruct[] heidi, int x, int y, tjt main)
            {


                min.BorderStyle = BorderStyle.FixedSingle;
                //min.BackColor = Color.Blue;
                min.BackColor = Color.FromArgb(Pokemondata.MOVEDATA[(int)Pokemondata.EngMoveID[heidi[0].move]].color1 + (0xff << 24));
                max.BorderStyle = BorderStyle.FixedSingle;
                //max.BackColor = Color.Red;
                max.BackColor = Color.FromArgb(Pokemondata.MOVEDATA[(int)Pokemondata.EngMoveID[heidi[0].move]].color2 + (0xff << 24));
                
                //Color.FromArgb(0xaaaaaa);
                string[] sci = heidi[1].damagebfb.Substring(0, heidi[0].damagebfb.Length - 1).Split('-');

                min.SetBounds(x, y, (int)(5 * double.Parse(sci[0])), 25);
                min.Text = Pokemondata.GetMoveName(Pokemondata.EnglishNametoMoveID(heidi[0].move));
                min.TextAlign = ContentAlignment.MiddleCenter;
                max.SetBounds(x, y, (int)(5 * double.Parse(sci[1])), 25);
                minimg.SetBounds(x + 10, y + 25, 40, 40);
                minimg.Image = (Image)pokeimg.ResourceManager.GetObject(Pokemondata.GetPokemonBase(Pokemondata.EnglishNametopokeID(heidi[1].pokemon)).name.Replace('-', 'T'));
                dmgdec.Location = new Point(x + 50, y + 40);
                statdec.Location = new Point(x + 50, y + 60);
                dmgdec.Text = Pokemondata.GetPokemonBase(Pokemondata.EnglishNametopokeID(heidi[1].pokemon)).name;
                if (heidi[1].item != null)
                {
                    dmgdec.Text += " " + Pokemondata.GetItemName(Pokemondata.EnglishNametoItemID(heidi[1].item));
                }
                dmgdec.Text += "(";
                if (heidi[1].stat > 0)
                {
                    dmgdec.Text += "+";
                    dmgdec.Text += heidi[1].stat.ToString() + " ";
                }
                else if (heidi[1].stat < 0)
                {
                    dmgdec.Text += heidi[1].stat.ToString() + " ";
                }
                if (heidi[1].IVs.Value[2] != -1)
                {
                    string scixing = (heidi[1].IVs.Value[2]).ToString();
                    if (heidi[1].defplus == 1)
                    {
                        scixing += "+";
                    }
                    else if (heidi[1].defplus == -1)
                    {
                        scixing += "-";
                    }
                    dmgdec.Text += string.Format("{0} HP {1} 物防)", heidi[1].IVs.Value[0], scixing);
                }
                else
                {
                    string scixing = (heidi[1].IVs.Value[4]).ToString();
                    if (heidi[1].spaplus == 1)
                    {
                        scixing += "+";
                    }
                    else if (heidi[1].spaplus == -1)
                    {
                        scixing += "-";
                    }
                    dmgdec.Text += string.Format("{0} HP {1} 特防)", heidi[1].IVs.Value[0], scixing);
                }
                dmgdec.Text += "受到 " + Pokemondata.GetMoveName(Pokemondata.EnglishNametoMoveID(heidi[0].move));
                if (heidi[0].movepow != 0)
                {
                    dmgdec.Text += string.Format("({0} 威力)", heidi[0].movepow);
                }
                dmgdec.Text += " " + heidi[0].damagenum.Trim();
                dmgdec.Text += string.Format(" ({0})", heidi[0].damagebfb);
                dmgdec.AutoSize = true;
                statdec.AutoSize = true;
                if (heidi[0].burn)
                {
                    statdec.Text += ",灼伤";
                }
                if (heidi[0].helpinghand)
                {
                    statdec.Text += ",帮助";
                }
                if (heidi[1].reflect)
                {
                    statdec.Text += ",反射壁";
                }
                if (heidi[1].lightscreen)
                {
                    statdec.Text += ",光墙";
                }
                if (heidi[1].auroraveil)
                {
                    statdec.Text += ",极光幕";
                }
                if (heidi[1].friendguard)
                {
                    statdec.Text += ",友情防守";
                }
                if (heidi[1].crit)
                {
                    statdec.Text += ",CT";
                }
                if (heidi[1].protect)
                {
                    statdec.Text += ",保护";
                }
                if (statdec.Text != "")
                    statdec.Text = "其他附加状态: " + statdec.Text.Substring(1);
                if (heidi[0].damagedec.Contains("HKO"))
                {
                    string mipha = Regex.Split(heidi[0].damagedec, "HKO")[0] + "HKO ";
                    statdec.Text = mipha + statdec.Text;
                }
                main.Controls.Add(min);
                main.Controls.Add(dmgdec);
                main.Controls.Add(statdec);
                main.Controls.Add(max);
                main.Controls.Add(minimg);

                //main.Controls.Add(new Button());
            }

        }
        public class zhuzhuang {
            Label min = new Label(), max = new Label();
            Label minimg = new Label();//maximg = new Label();
            Label dmgdec = new Label();
            Label statdec = new Label();

            public zhuzhuang(resstruct[] heidi, int x, int y, tjt main)
            {
                

                min.BorderStyle = BorderStyle.FixedSingle;
                min.BackColor = Color.FromArgb(Pokemondata.MOVEDATA[(int)Pokemondata.EngMoveID[heidi[0].move]].color1 + (0xff << 24));
                max.BorderStyle = BorderStyle.FixedSingle;
                //max.BackColor = Color.Red;
                max.BackColor = Color.FromArgb(Pokemondata.MOVEDATA[(int)Pokemondata.EngMoveID[heidi[0].move]].color2 + (0xff << 24));
                string[] sci = heidi[1].damagebfb.Substring(0, heidi[0].damagebfb.Length - 1).Split('-');
                min.Text = Pokemondata.GetMoveName(Pokemondata.EnglishNametoMoveID(heidi[0].move));
                min.TextAlign = ContentAlignment.MiddleCenter;
                min.SetBounds(x, y, (int)(5 * double.Parse(sci[0])), 25);
                max.SetBounds(x, y, (int)(5 * double.Parse(sci[1])), 25);
                minimg.SetBounds(x + 10, y + 25, 40, 40);
                minimg.Image = (Image)pokeimg.ResourceManager.GetObject(Pokemondata.GetPokemonBase(Pokemondata.EnglishNametopokeID(heidi[0].pokemon)).name.Replace('-','T'));
                dmgdec.Location = new Point(x + 50, y + 40);
                statdec.Location = new Point(x + 50, y + 60);
                dmgdec.Text = Pokemondata.GetPokemonBase(Pokemondata.EnglishNametopokeID(heidi[0].pokemon)).name;
                if (heidi[0].item != null)
                {
                    dmgdec.Text += " " + Pokemondata.GetItemName(Pokemondata.EnglishNametoItemID(heidi[0].item));
                }
                dmgdec.Text += "(";
                if (heidi[0].stat > 0)
                {
                    dmgdec.Text += "+";
                    dmgdec.Text += heidi[0].stat.ToString() + " ";
                }
                else if (heidi[0].stat < 0)
                {
                    dmgdec.Text += heidi[0].stat.ToString() + " ";
                }
                if (heidi[0].IVs.Value[1] != -1)
                {
                    string scixing = (heidi[0].IVs.Value[1]).ToString();
                    if (heidi[0].atkplus == 1)
                    {
                        scixing += "+";
                    }
                    else if (heidi[0].atkplus == -1)
                    {
                        scixing += "-";
                    }
                    dmgdec.Text += string.Format("{0} 攻击)", scixing);
                }
                else
                {
                    string scixing = (heidi[0].IVs.Value[3]).ToString();
                    if (heidi[0].spaplus == 1)
                    {
                        scixing += "+";
                    }
                    else if (heidi[0].spaplus == -1)
                    {
                        scixing += "-";
                    }
                    dmgdec.Text += string.Format("{0} 特攻)", scixing);
                }
                dmgdec.Text += "的 " + Pokemondata.GetMoveName(Pokemondata.EnglishNametoMoveID(heidi[0].move));
                if (heidi[0].movepow != 0)
                {
                    dmgdec.Text += string.Format("({0} 威力)", heidi[0].movepow);
                }
                dmgdec.Text +=  " " + heidi[0].damagenum.Trim();
                dmgdec.Text += string.Format(" ({0})", heidi[0].damagebfb);
                dmgdec.AutoSize = true;
                statdec.AutoSize = true;
                if (heidi[0].burn)
                {
                    statdec.Text += ",灼伤";
                }
                if (heidi[0].helpinghand)
                {
                    statdec.Text += ",帮助";
                }
                if (heidi[1].reflect)
                {
                    statdec.Text += ",反射壁";
                }
                if (heidi[1].lightscreen)
                {
                    statdec.Text += ",光墙";
                }
                if (heidi[1].auroraveil)
                {
                    statdec.Text += ",极光幕";
                }
                if (heidi[1].friendguard)
                {
                    statdec.Text += ",友情防守";
                }
                if (heidi[1].crit)
                {
                    statdec.Text += ",CT";
                }
                if (heidi[1].protect)
                {
                    statdec.Text += ",保护";
                }
                if (statdec.Text != "")
                    statdec.Text =  "其他附加状态: " + statdec.Text.Substring(1);
                if (heidi[0].damagedec.Contains("HKO"))
                {
                    string mipha = Regex.Split(heidi[0].damagedec, "HKO")[0] + "HKO ";
                    statdec.Text = mipha + statdec.Text;
                }
                main.Controls.Add(min);
                main.Controls.Add(dmgdec);
                main.Controls.Add(statdec);
                main.Controls.Add(max);
                main.Controls.Add(minimg);

                //main.Controls.Add(new Button());
            }
            
        }
        int basex = 70, basey = 50;

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void 条形图_Paint(object sender, PaintEventArgs e)
        {
            Pen pen2 = new Pen(Color.Blue, 3);
            pen2.DashStyle = DashStyle.Custom;
            pen2.DashPattern = new float[] { 1f, 1f };
            Graphics g2 = bd.CreateGraphics();
            //g2.DrawLine(pen2, 125, 0, 125, 1000);
        }
        Label bd;
        private void tjt_Load(object sender, EventArgs e)
        {
            bd = new Label();

            bd.Paint += Bd_Paint;
            bd.BorderStyle = BorderStyle.FixedSingle;
            bd.SetBounds(basex, basey, 500, 20 + icefairy.GetLength(0) * 100);
            this.Height = 150 + icefairy.GetLength(0) * 100;


            //g2.DrawLine(p, 0, 100, 100, 100);
            Label[] markx = new Label[11];

            for (int i = 0; i<= 10; ++i)
            {
                markx[i] = new Label();
                markx[i].Text = string.Format("{0}%", 10 * i);
                markx[i].Location = new Point(basex + 50 * i - 5, 20 + icefairy.GetLength(0) * 100 + basey);
                markx[i].AutoSize = true;
                Controls.Add(markx[i]);
            }
            for (int i = 0; i < icefairy.GetLength(0); ++i)
            {
                if (flag == 0)
                {
                    zhuzhuang aa = new zhuzhuang(new resstruct[] { icefairy[i, 0], icefairy[i, 1] }, basex, basey + 20 + 100 * i, this);
                }
                else
                {
                    zhuzhuang1 aa = new zhuzhuang1(new resstruct[] { icefairy[i, 0], icefairy[i, 1] }, basex, basey + 20 + 100 * i, this);
                }
            }
            
            Controls.Add(bd);
            Pen pen2 = new Pen(Color.Blue, 3);
            pen2.DashStyle = DashStyle.Custom;
            pen2.DashPattern = new float[] { 1f, 1f };
            Graphics g2 = bd.CreateGraphics();
            g2.DrawLine(pen2, 125, 0, 125, 3000);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Pen pen2 = new Pen(Color.Blue, 3);
            pen2.DashStyle = DashStyle.Custom;
            pen2.DashPattern = new float[] { 1f, 1f };
            Graphics g2 = bd.CreateGraphics();
            g2.DrawLine(pen2, 125, 0, 125, 3000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Pen pen2 = new Pen(Color.Red, 3);
            pen2.DashStyle = DashStyle.Custom;
            pen2.DashPattern = new float[] { 1f, 1f };
            Graphics g2 = bd.CreateGraphics();
            g2.DrawLine(pen2, 375, 0, 375, 3000);
            pen2.Color = Color.SaddleBrown;

            g2.DrawLine(pen2, 250, 0, 250, 3000);
            pen2.Color = Color.Black;
            pen2 = new Pen(Color.Red, 1);
            pen2.Color = Color.Black;
            for (int i = 1; i <=10; ++i)
            {
                g2.DrawLine(pen2, i * 50, bd.Height - 7, i * 50, bd.Height);
            }
            timer1.Enabled = false;
        }

        private void Bd_Paint(object sender, PaintEventArgs e)
        {
            // 特别感谢艾斯菲力聚聚 另外牛逼花姐
        }
    }
}

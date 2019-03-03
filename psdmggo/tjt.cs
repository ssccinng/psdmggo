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
                while (!Pokemondata.EngPokemonID.Contains(heidi[1].pokemon))
                {
                    heidi[1].pokemon = heidi[1].pokemon.Substring(0, heidi[1].pokemon.LastIndexOf('-'));
                }

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
                if (heidi[1].weather != null)
                {
                    statdec.Text += "," + heidi[1].weather;
                }
                if (heidi[1].terrain != null)
                {
                    statdec.Text += "," + heidi[1].terrain;
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
                while (!Pokemondata.EngPokemonID.Contains(heidi[0].pokemon))
                {
                    heidi[0].pokemon = heidi[0].pokemon.Substring(0, heidi[0].pokemon.LastIndexOf('-'));
                }
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
                if (heidi[1].weather != null)
                {
                    statdec.Text += "," + heidi[1].weather;
                }
                if (heidi[1].terrain != null)
                {
                    statdec.Text += "," + heidi[1].terrain;
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
        Panel pic;
        private void tjt_Load(object sender, EventArgs e)
        {
            bd = new Label();
            pic = new Panel();
            bd.Paint += Bd_Paint;
            bd.BorderStyle = BorderStyle.FixedSingle;
            bd.SetBounds(basex, basey, 500, 20 + icefairy.GetLength(0) * 100);
            //pic.Controls.Add(bd);
            this.Height = 150 + icefairy.GetLength(0) * 100;
            pic.SetBounds(0, 0, this.Width, this.Height);

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
            Label heidi0821 = new Label();
            Label gazeru = new Label();
            heidi0821.SetBounds(basex + 60, basey - 40, 40, 40);
            gazeru.Location = new Point(basex + 100, basey - 25);
            gazeru.AutoSize = true;
            if (flag == 0)
            {
         
                heidi0821.Image = (Image)pokeimg.ResourceManager.GetObject(Pokemondata.GetPokemonBase(Pokemondata.EnglishNametopokeID(icefairy[0,1].pokemon)).name.Replace('-', 'T'));
                gazeru.Text = "防守方: " + Pokemondata.GetPokemonBase(Pokemondata.EnglishNametopokeID(icefairy[0, 1].pokemon)).name;
                int tempwg = 0;
                string item = "";
                for(int i = 0; i < icefairy.GetLength(0); ++i)
                {
                    tempwg = Math.Max(tempwg, icefairy[i, 1].IVs.Value[2]);
                    if (icefairy[i, 1].item != "" && icefairy[i, 1].item != null)
                    {
                        item = icefairy[i, 1].item;
                    }
                }
                string wg = tempwg.ToString();
                if (icefairy[0, 1].defplus == 1)
                {
                    wg += "+";
                }
                else if (icefairy[0, 1].defplus == -1)
                {
                    wg += "-";
                }
                int temptg = 0;
                for (int i = 0; i < icefairy.GetLength(0); ++i)
                {
                    temptg = Math.Max(temptg, icefairy[i, 1].IVs.Value[4]);
                }
                string tg = temptg.ToString();
                if (icefairy[0, 1].spdplus   == 1)
                {
                    tg += "+";
                }
                else if (icefairy[0, 1].spdplus == -1)
                {
                    tg += "-";
                }

                gazeru.Text += string.Format("({2} HP {0} 物防 {1} 特防)", wg, tg, icefairy[0, 1].IVs.Value[0]);
                if (item != "")
                    gazeru.Text += " @ " + Pokemondata.GetItemName(Pokemondata.EnglishNametoItemID(item));
            }
            else
            {
                heidi0821.Image = (Image)pokeimg.ResourceManager.GetObject(Pokemondata.GetPokemonBase(Pokemondata.EnglishNametopokeID(icefairy[0, 0].pokemon)).name.Replace('-', 'T'));
                //heidi0821.Image = (Image)pokeimg.ResourceManager.GetObject(Pokemondata.GetPokemonBase(Pokemondata.EnglishNametopokeID(icefairy[0, 1].pokemon)).name.Replace('-', 'T'));
                gazeru.Text = "进攻方: " + Pokemondata.GetPokemonBase(Pokemondata.EnglishNametopokeID(icefairy[0, 0].pokemon)).name;
                int tempwg = 0;
                string item = "";
                for (int i = 0; i < icefairy.GetLength(0); ++i)
                {
                    tempwg = Math.Max(tempwg, icefairy[i, 0].IVs.Value[1]);
                    if (icefairy[i, 0].item != "" && icefairy[i, 0].item != null)
                    {
                        item = icefairy[i, 0].item;
                    }
                }
                string wg = tempwg.ToString();
                if (icefairy[0, 0].atkplus == 1)
                {
                    wg += "+";
                }
                else if (icefairy[0, 0].atkplus == -1)
                {
                    wg += "-";
                }
                int temptg = 0;
                for (int i = 0; i < icefairy.GetLength(0); ++i)
                {
                    temptg = Math.Max(temptg, icefairy[i, 0].IVs.Value[3]);
                }
                string tg = temptg.ToString();
                if (icefairy[0, 1].spaplus == 1)
                {
                    tg += "+";
                }
                else if (icefairy[0, 1].spaplus == -1)
                {
                    tg += "-";
                }
                gazeru.Text += string.Format("({0} 攻击 {1} 特攻)", wg, tg);
                if (item != "")
                    gazeru.Text += " @ " + Pokemondata.GetItemName(Pokemondata.EnglishNametoItemID(item));
            }
            Controls.Add(heidi0821);
            Controls.Add(gazeru);
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
            //Controls.Add(pic);
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(this.Width, this.Height);//实例化一个和窗体一样大的bitmap
            Graphics g = Graphics.FromImage(bit);
            g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
            g.CopyFromScreen(this.Left, this.Top, 3, 20, new Size(this.Width, this.Height));//保存整个窗体为图片
                                                                                           //g.CopyFromScreen(panel游戏区 .PointToScreen(Point.Empty), Point.Empty, panel游戏区.Size);//只保存某个控件（这里是panel游戏区）
            bit.Save("weiboTemp.png");//默认保存格式为PNG，保存成jpg格式质量不是很好
        }

        private void tjt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\u0003')
            {
                Bitmap bit = new Bitmap(this.Width - 14, this.Height - 50);//实例化一个和窗体一样大的bitmap
                Graphics g = Graphics.FromImage(bit);
                g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
                g.CopyFromScreen(this.Left, this.Top, -7, -40, new Size(this.Width - 7, this.Height - 10));//保存整个窗体为图片
                DateTime.Now.ToLocalTime().ToString();
                Clipboard.SetDataObject(bit);

                //g.CopyFromScreen(panel游戏区 .PointToScreen(Point.Empty), Point.Empty, panel游戏区.Size);//只保存某个控件（这里是panel游戏区）
                //Bitmap bmp = new Bitmap(pic.Width, pic.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                //pic.DrawToBitmap(bmp, new Rectangle(0, 0, pic.Width, pic.Height));
                //Clipboard.SetDataObject(bit);
                //bmp.Save("led.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                e.Handled = true;
            }
            if (e.KeyChar == '\u0013')
            {
                Bitmap bit = new Bitmap(this.Width-14, this.Height-50);//实例化一个和窗体一样大的bitmap
                Graphics g = Graphics.FromImage(bit);
                g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
                g.CopyFromScreen(this.Left, this.Top, -7, -40, new Size(this.Width - 7, this.Height - 10));//保存整个窗体为图片
                DateTime.Now.ToLocalTime().ToString();        // 2008-9-4 20:12:12    
                //pic.DrawToBitmap(bit, new Rectangle(0, 0, pic.Width, pic.Height));
                //g.CopyFromScreen(panel游戏区 .PointToScreen(Point.Empty), Point.Empty, panel游戏区.Size);//只保存某个控件（这里是panel游戏区）
                string qq = DateTime.Now.ToLocalTime().ToString().Replace(':', '-').Replace('/','-');
                bit.Save(qq + ".png");

                e.Handled = true;
            }
        }

        private void Bd_Paint(object sender, PaintEventArgs e)
        {
            // 特别感谢艾斯菲力聚聚 另外牛逼花姐
        }
    }
}

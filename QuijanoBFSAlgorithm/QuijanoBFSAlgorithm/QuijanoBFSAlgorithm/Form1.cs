using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace PathfindingVisualizer
{
    public partial class Form1 : Form
    {
        //Global Variable:
        int height = 20, width = 20;
        bool[,] graph = new bool[31, 51];
        bool Drawing = false;
        char Item = 'z';
        Color Cpoc = Color.FromArgb(170, 204, 0);
        Color Ckraj = Color.FromArgb(186, 24, 27);
        Color Czid = Color.FromArgb(43, 23, 28); 
        Color BG = Color.FromArgb(200, 170, 90);
        Color Node1 = Color.FromArgb(248, 95, 69); 
        Color Path = Color.FromArgb(90, 9, 108); 
        
        Color Visited2 = Color.FromArgb(225, 125, 97); 
        Color Node2 = Color.FromArgb(226, 49, 49); 

        struct Node
        {
            public int IndexX, IndexY;
            public void SetYX(int Y,int X)
            {
                IndexX = X;
                IndexY = Y;
            }
        };
        Node StartNode = new Node(), EndNode = new Node();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = 51 * width + 1;
            pictureBox1.Height = 31 * height + 1;
            StartNode.SetYX(15, 9);
            EndNode.SetYX(15, 41);
            this.BackColor = Color.FromArgb(225, 125, 97); 
            this.Width = 32 + pictureBox1.Width;
            this.Height = 160 + pictureBox1.Height;
            timer1.Start();
        }
        
        void Draw()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen Olovka = new Pen(Color.Black);
            SolidBrush Spot = new SolidBrush(Color.White);

            g.FillRectangle(Spot, 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < pictureBox1.Height; i += height)
                g.DrawLine(Olovka, 0, i, pictureBox1.Width, i);
            for (int i = 0; i < pictureBox1.Width; i += width)
                g.DrawLine(Olovka, i, 0, i, pictureBox1.Height);

            Spot.Color = Cpoc;
            g.FillRectangle(Spot, StartNode.IndexX * width + 1, StartNode.IndexY * height + 1, width - 1, height - 1);
            Spot.Color = Ckraj;
            g.FillRectangle(Spot, EndNode.IndexX * width + 1, EndNode.IndexY * height + 1, width - 1, height - 1);
        }
        
        private void Visualize_button_click(object sender, EventArgs e)
        {
            if (EndNode.IndexX == -1)
            {
                MessageBox.Show("Drop the Node end");
                return;
            }
            if (StartNode.IndexX == -1)
            {
                MessageBox.Show("Drop the Start Node");
                return;
            }
            string Algorithm = "";
            try
            {
                Algorithm = comboBox1.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pick BFS from DropBox");
                return;
            }

            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush Path = new SolidBrush(Ckraj);

            bool[,] bio = new bool[31, 51], bio2 = new bool[31, 51];;
            for (int i = 0; i < 51; i++) 
                for (int j = 0; j < 31; j++) 
                { 
                    bio[j, i] = false;
                    bio2[j, i] = false;
                }
            bio[StartNode.IndexY, StartNode.IndexX] = true;
            bio2[EndNode.IndexY, EndNode.IndexX] = true;

            int[] smjerY = new int[4] { 0, 0, 1, -1 }, smjerX = new int[4] { 1, -1, 0, 0};
            string[] smjer = new string[4] { "r", "l", "d", "u" };
            int Visited = 1;
            LinkedList<Tuple<int, int, string>> lista = new LinkedList<Tuple<int, int, string>>(), lista2 = new LinkedList<Tuple<int, int, string>>();
            lista.AddFirst(new Tuple<int, int, string>(StartNode.IndexY, StartNode.IndexX, ""));
            lista2.AddFirst(new Tuple<int, int, string>(EndNode.IndexY, EndNode.IndexX, ""));//za biderectoinal algoritme
            string put = "", put2 = "";

            while (lista.Count > 0)
            {
                Tuple<int, int, string> Node = new Tuple<int, int, string>(10000, 10000, "");
                Tuple<int, int, string> Node2 = new Tuple<int, int, string>(10000, 10000, "");
                if (Algorithm == "BFS" || Algorithm == "Bidirectional BFS")
                {
                    Node = lista.Last.Value;
                }
                int x = Node.Item2, x2 = Node2.Item2;
                int y = Node.Item1, y2 = Node2.Item1;
                put = Node.Item3; put2 = Node2.Item3;

                if (x == EndNode.IndexX && y == EndNode.IndexY)
                {
                    Path.Color = Ckraj; ;
                    g.FillRectangle(Path, EndNode.IndexX * width + 1, EndNode.IndexY * height + 1, width - 1, height - 1);
                    break;
                }

                for (int i = 0; i < 4; i++)
                {
                    int noviX = x + smjerX[i];
                    int noviY = y + smjerY[i];
                    if (noviX >= 0 && noviY >= 0 && noviY < 31 && noviX < 51 && !bio[noviY, noviX] && !graph[noviY, noviX])
                    {
                        lista.AddFirst(new Tuple<int, int, string>(noviY, noviX, put + smjer[i]));
                        bio[noviY, noviX] = true;
                        Path.Color = Node1;
                        g.FillRectangle(Path, noviX * width + 1, noviY * height + 1, width - 1, height - 1);
                    }
                    if(Algorithm == "Bidirectional BFS" || Algorithm == "Bidirectional Swarm Algoritham")
                    {
                        noviX = x2 + smjerX[i];
                        noviY = y2 + smjerY[i];
                        if (noviX >= 0 && noviY >= 0 && noviY < 31 && noviX < 51 && !bio2[noviY, noviX] && !graph[noviY, noviX])
                        {
                            lista2.AddFirst(new Tuple<int, int, string>(noviY, noviX, put2 + smjer[i]));
                            bio2[noviY, noviX] = true;
                            Path.Color = this.Node2;
                            g.FillRectangle(Path, noviX * width + 1, noviY * height + 1, width - 1, height - 1);
                        }
                    }
                }
                if(Algorithm == "Bidirectional BFS" || Algorithm == "Bidirectional Swarm Algoritham")
                {
                    bool NasaoPut = false;
                    foreach (var k in lista2)
                        foreach (var p in lista)
                            if (k.Item1 == p.Item1 && k.Item2 == p.Item2)
                            {
                                put = p.Item3;
                                for (int i = k.Item3.Length - 1; i >= 0; i--)
                                {
                                    if (k.Item3[i] == 'r') put += 'l';
                                    else if (k.Item3[i] == 'l') put += 'r';
                                    else if (k.Item3[i] == 'u') put += 'd';
                                    else if (k.Item3[i] == 'd') put += 'u';
                                }
                                NasaoPut = true;
                            }
                    if (NasaoPut) break;
                }
                lista2.Remove(Node2);
                lista.Remove(Node);

                if (StartNode.IndexX != x || StartNode.IndexY != y)
                {
                    Path.Color = this.BG;
                    g.FillRectangle(Path, x * width + 1, y * height + 1, width - 1, height - 1);
                    NoVisited_label.Text = "BG: " + Visited++;
                }
                if ((EndNode.IndexX != x2 || EndNode.IndexY != y2) && Algorithm.Substring(0, 2) == "Bi")
                {
                    Path.Color = Visited2;
                    g.FillRectangle(Path, x2 * width + 1, y2 * height + 1, width - 1, height - 1);
                    NoVisited_label.Text = "BG: " + Visited++;
                }
                NoVisited_label.Refresh();
                NoNode_label.Text = "Nodes: " + (lista.Count() + lista2.Count() - 1);
                NoNode_label.Refresh();
                put = "";
            }
            int xx = StartNode.IndexX * width, yy = StartNode.IndexY * height;
            Path.Color = this.Path;
            for (int i = 0; i < put.Length - 1; i++)
            {
                if (put[i] == 'r') xx += width;
                if (put[i] == 'l') xx -= width;
                if (put[i] == 'd') yy += width;
                if (put[i] == 'u') yy -= width;
                g.FillRectangle(Path, xx + 1, yy + 1, height - 1, height - 1);
                System.Threading.Thread.Sleep(1);
            }
            PathLength_label.Text = "Duzina puta: " + put.Length;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int X = e.X - e.X % height;
            int Y = e.Y - e.Y % width;
            if (X >= pictureBox1.Width - 1 || Y >= pictureBox1.Height - 1) return;

            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush Cetka = new SolidBrush(Czid);

            if (Item == 'z' && Y == height * StartNode.IndexY && X == width * StartNode.IndexX)
            {
                Item = 'p';
                StartNode.SetYX(-1, -1);
            }
            else if (Item == 'z' && Y == EndNode.IndexY * height && X == EndNode.IndexX * width)
            {
                Item = 'k';
                EndNode.SetYX(-1, -1);
            }
            else if (Item == 'p' && !(Y == EndNode.IndexY * height && X == EndNode.IndexX * width))
            {
                Cetka.Color = Cpoc;
                StartNode.SetYX(Y / height, X / width);
                Item = 'z';
                graph[(Y / height), (X / width)] = false;
            }
            else if (Item == 'k' && !(Y == StartNode.IndexY * height && X == StartNode.IndexX * width))
            {
                Cetka.Color = Ckraj;
                EndNode.SetYX(Y / height, X / width);
                Item = 'z';     
                graph[(Y / height), (X / width)] = false;
            }
            else
            {
                if (Item == 'p' || Item == 'k') return;
                if (graph[(Y / height), (X / width)] == true)
                {
                    Cetka.Color = Color.White;
                    graph[(Y / height), (X / width)] = false;
                }
                else
                {
                    Cetka.Color = Czid;
                    graph[(Y / height), (X / width)] = true;
                }
            }
            if (Item == 'p' || Item == 'k')
            {
                Cursor = Cursors.Hand;
                Cetka.Color=Color.White;
            }
            else Cursor = Cursors.Default;
            g.FillRectangle(Cetka, X + 1, Y + 1, height - 1, height - 1);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int X = e.X - e.X % height;
            int Y = e.Y - e.Y % width;
            if (X >= pictureBox1.Width - 1 || Y >= pictureBox1.Height - 1   ) return;
            if (graph[Y / height, X / width] && Item != 'k' && Item != 'p') Item = 'P';
            Drawing = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drawing == false || Item == 'p' || Item == 'k') return;

            int X = e.X - e.X % width;
            int Y = e.Y - e.Y % height;

            if ((X == StartNode.IndexX * width && Y == StartNode.IndexY * height) || (X == EndNode.IndexX * width && Y == EndNode.IndexY * height)
                || X >= pictureBox1.Width - 1 || Y >= pictureBox1.Height - 1 || X < 0 || Y < 0) return;

            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush Cetka = new SolidBrush(Czid);

            if (Item == 'P')
            {
                Cetka.Color = Color.White;
                graph[(Y / height), (X / width)] = false;
            }
            else
            {
                Cetka.Color = Czid;
                graph[(Y / height), (X / width)] = true;
            }
            g.FillRectangle(Cetka, X + 1, Y + 1, height - 1, height - 1);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Drawing = false;
            if (Item == 'P') Item = 'z';
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void Povezi(int y, int x)
        {
            graph[y, x] = false;
            Graphics g = pictureBox1.CreateGraphics();
            Brush Cetka = new SolidBrush(Color.White);
            g.FillRectangle(Cetka, x * width + 1, y * height + 1, width - 1, height - 1);
            int[] smjer = new int[4] { 0, 1, 2, 3 };
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                int j = rnd.Next(i, 4);
                int temp = smjer[i];
                smjer[i] = smjer[j];
                smjer[j] = temp;
            }
            for (int i = 0; i < 4; i++)
            {
                int dx = 0, dy = 0;
                switch (smjer[i])
                {
                    case 0: dy = -1; break;
                    case 1: dy = 1; break;
                    case 2: dx = -1; break;
                    case 3: dx = 1; break;
                }
                int x2 = x + 2 * dx;
                int y2 = y + 2 * dy;
                if (x2 >= 0 && y2 >= 0 && x2 < 51 && y2 < 31 && graph[y2, x2] == true)
                {
                    graph[y2 - dy, x2 - dx] = false;
                    g.FillRectangle(Cetka, (x2 - dx) * width + 1, (y2 - dy) * height + 1, width - 1, height - 1);
                    System.Threading.Thread.Sleep(1);
                    Povezi(y2, x2);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
            timer1.Stop();
        }
    }
}
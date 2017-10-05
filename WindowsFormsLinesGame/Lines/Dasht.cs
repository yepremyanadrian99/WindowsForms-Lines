using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lines
{
    class Dasht
    {
        FormLimes fr;
        int x0, y0, w, n;
        int[,] mas;
        bool selected = false;
        int hi, hj, hc;

        public Dasht(FormLimes fr)
        {
            // TODO: Complete member initialization
            this.fr = fr;
            n = 10;
            x0 = 30;
            y0 = 30;
            w = 30;
            mas = new int[n, n];
            Skzb();
        }

        private void Skzb()
        {
            int t=3;
            int q = 0;
            for (int a = 0; a < n; a++)
            {
                for (int b = 0; b < n; b++)
                {
                    if (mas[a, b] == 0)
                    {
                        q++;  
                    }
                }
            }
            if (q == 2)
            {
                t = 2;
            }
            if (q == 1)
            {
                t = 1;
            }
            if (q == 0)
            {
                GameOver();
                return;
            }
            Random rr = new Random();
            int i, j;
            for (int k = 0; k < t; )
            {
                i = rr.Next(n);
                j = rr.Next(n);
                if (mas[i, j] != 0)
                {
                    continue;
                }
                mas[i, j] = rr.Next(1, 6);
                k++;
            }
        }

        public void New()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = 0;
                }
            }
            Skzb();
        }

        internal void GameOver()
        {
            int q = 0;
            for (int a = 0; a < n; a++)
            {
                for (int b = 0; b < n; b++)
                {
                    if (mas[a, b] == 0)
                    {
                        q++;
                    }
                }
            }
            if (q == 0)
            {
                MessageBox.Show("Game Over");
                return;
            }
        }

        internal void Paint(System.Drawing.Graphics g)
        {
            for (int i = 0; i <= n; i++)
            {
                g.DrawLine(Pens.Red, x0, y0 + i * w, x0 + n * w, y0 + i * w);
                g.DrawLine(Pens.Red, x0 + i * w, y0, x0 + i * w, y0 + n * w);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mas[i, j] == 1)
                    {
                        g.FillEllipse(Brushes.Red, x0 + i * w, y0 + j * w, w, w);
                    }
                    if (mas[i, j] == 2)
                    {
                        g.FillEllipse(Brushes.Yellow, x0 + i * w, y0 + j * w, w, w);
                    }
                    if (mas[i, j] == 3)
                    {
                        g.FillEllipse(Brushes.Purple, x0 + i * w, y0 + j * w, w, w);
                    }
                    if (mas[i, j] == 4)
                    {
                        g.FillEllipse(Brushes.Blue, x0 + i * w, y0 + j * w, w, w);
                    }
                    if (mas[i, j] == 5)
                    {
                        g.FillEllipse(Brushes.Green, x0 + i * w, y0 + j * w, w, w);
                    }
                    if (mas[i, j] == 6)
                    {
                        g.FillEllipse(Brushes.Black, x0 + i * w + w / 3, y0 + j * w + w / 3, w / 3, w / 3);
                    }
                }
            }
        }

        internal void Click(int mx, int my)
        {
            int i;
            int j;
            i = (mx - x0) / w;
            j = (my - y0) / w;
            try
            {
                if (!selected) ///Vercnel
                {
                    if (mas[i, j] == 0) return;
                    hi = i;
                    hj = j;
                    hc = mas[i, j];
                    mas[i, j] = 6;
                    selected = true;
                }
                else ///Dnel
                {
                    if (mas[i, j] == 6)
                    {
                        mas[i, j] = hc;
                        selected = false;
                        return;
                    }
                    if (mas[i, j] != 0) return;
                    mas[hi, hj] = 0;
                    mas[i, j] = hc;
                    selected = false;
                    Skzb();
                    Check();
                }
            }
            catch
            {
                MessageBox.Show("Mi ara");
            }
            GameOver();
        }

        private void Check()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + 4 < n && mas[i, j] == mas[i + 1, j] && mas[i + 1, j] == mas[i + 2, j] && mas[i + 2, j] == mas[i + 3, j] && mas[i + 3, j] == mas[i + 4, j])
                    {
                        mas[i, j] = 0;
                        mas[i + 1, j] = 0;
                        mas[i + 2, j] = 0;
                        mas[i + 3, j] = 0;
                        mas[i + 4, j] = 0;
                    }
                    if (j + 4 < n && mas[i, j] == mas[i, j + 1] && mas[i, j + 1] == mas[i, j + 2] && mas[i, j + 2] == mas[i, j + 3] && mas[i, j + 3] == mas[i, j + 4])
                    {
                        mas[i, j] = 0;
                        mas[i, j + 1] = 0;
                        mas[i, j + 2] = 0;
                        mas[i, j + 3] = 0;
                        mas[i, j + 4] = 0;
                    }
                    if (i + 4 < n && j + 4 < n && mas[i, j] == mas[i + 1, j + 1] && mas[i + 1, j + 1] == mas[i + 2, j + 2] && mas[i + 2, j + 2] == mas[i + 3, j + 3] && mas[i + 3, j + 3] == mas[i + 4, j + 4])
                    {
                        mas[i, j] = 0;
                        mas[i + 1, j + 1] = 0;
                        mas[i + 2, j + 2] = 0;
                        mas[i + 3, j + 3] = 0;
                        mas[i + 4, j + 4] = 0;
                    }
                    if (i + 4 < n && j - 4 >= 0 && mas[i, j] == mas[i + 1, j - 1] && mas[i + 1, j - 1] == mas[i + 2, j - 2] && mas[i + 2, j - 2] == mas[i + 3, j - 3] && mas[i + 3, j - 3] == mas[i + 4, j - 4])
                    {
                        mas[i, j] = 0;
                        mas[i + 1, j - 1] = 0;
                        mas[i + 2, j - 2] = 0;
                        mas[i + 3, j - 3] = 0;
                        mas[i + 4, j - 4] = 0;
                    }
                }
            }
        }
    }
}
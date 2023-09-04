using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std
{
    struct M
    {
        public int x;
        public int dQ;
    }
    class TMOFigure : Figure
    {

        //поля
        Figure first;
        Figure second;
        Graphics g;
        Pen pen;
        private List<ListsFromY> listsFigure;
        Point centerFigure;
        int[] SetQ = new int[2];

        //конструктор
        public TMOFigure(Figure first, Figure second, Graphics g, Pen pen, int operation)
        {
            this.first = first;
            this.second = second;
            this.g = g;
            this.pen = pen;

            setQ(operation);
            setListFigure();
        }

        public Point getCenter()
        {
            procBorder();
            return centerFigure;
        }


        //отрисовка
        public void DrawFigure()
        {
            for (int i = 0; i < listsFigure.Count; i++)
            {
                for (int j = 0; j < listsFigure[i].Lpl.Count; j++)
                {
                    g.DrawLine(pen, new Point(listsFigure[i].Lpl[j], listsFigure[i].Y), new Point(listsFigure[i].Lpr[j], listsFigure[i].Y));
                }
            }
            g.FillRectangle(Brushes.YellowGreen, getCenter().X, getCenter().Y, 4, 4);
        }
         

        //возвращает по заданному У массив левых точек
        public List<int> getLpL(int Y)
        {
            for (int i = 0; i < listsFigure.Count; i++)
            {
                if (listsFigure[i].Y == Y)
                {
                    return listsFigure[i].Lpl;
                }
            }
            return new List<int>();
        }

        //возвращает по заданному У массив правых точек
        public List<int> getLpR(int Y)
        {
            for (int i = 0; i < listsFigure.Count; i++)
            {
                if (listsFigure[i].Y == Y)
                {
                    return listsFigure[i].Lpr;
                }
            }
            return new List<int>();
        }

        //получить максимальную точку фигуры по У
        public int getMaxY()
        {
            return listsFigure[listsFigure.Count - 1].Y;
        }

        //получить минимальную точку фигуры по У
        public int getMinY()
        {
            return listsFigure[0].Y;
        }

        //проверяет попала ли точка в фигуру
        public bool pointInside(Point p)
        {
            for (int i = 0; i < listsFigure.Count; i++)
            {
                if (listsFigure[i].Y == p.Y)
                {
                    for (int k = 0; k < listsFigure[i].Lpl.Count; k++)
                    {
                        if (listsFigure[i].Lpl[k] < p.X && p.X < listsFigure[i].Lpr[k])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //выполняем непрерывную операцию
        public void runOperation(double[,] center, double[,] operation)
        {
            first.runOperation(center, operation);
            second.runOperation(center, operation);
            setListFigure();
        }

        //получение диапазона из кода операции
        public void setQ(int code)
        {
            switch (code)
            {
                //разность a - b
                case 1:
                    SetQ[0] = 2;
                    SetQ[1] = 2;
                    break;
                //пересечение
                case 2:
                    SetQ[0] = 3;
                    SetQ[1] = 3;
                    break;
            }
        }


        //заполняет список фигуры
        private void setListFigure()
        {
            listsFigure = new List<ListsFromY>();

            int start = first.getMinY();
            int end = first.getMaxY();
            if (start > second.getMinY())
            {
                start = second.getMinY();
            }
            if (start > second.getMaxY())
            {
                start = second.getMaxY();
            }
            if (end < second.getMinY())
            {
                end = second.getMinY();
            }
            if (end < second.getMaxY())
            {
                end = second.getMaxY();
            }

            List<int> Xal = new List<int>();
            List<int> Xar = new List<int>();

            List<int> Xbl = new List<int>();
            List<int> Xbr = new List<int>();

            List<M> m = new List<M>();
            List<int> Xrl = new List<int>();
            List<int> Xrr = new List<int>();

           
         

            for (int Y = start; Y <= end; Y++)
            {
                Xrl.Clear();
                Xrr.Clear();
                m.Clear();

                Xal = first.getLpL(Y);
                Xar = first.getLpR(Y);

                Xbl = second.getLpL(Y);
                Xbr = second.getLpR(Y);

                for (int i = 0; i < Xal.Count; i++)
                {
                    M temp;
                    temp.x = Xal[i];
                    temp.dQ = 2;
                    m.Add(temp);
                }


                for (int i = 0; i < Xar.Count; i++)
                {
                    M temp;
                    temp.x = Xar[i];
                    temp.dQ = -2;
                    m.Add(temp);
                }


                for (int i = 0; i < Xbl.Count; i++)
                {
                    M temp;
                    temp.x = Xbl[i];
                    temp.dQ = 1;
                    m.Add(temp);
                }


                for (int i = 0; i < Xbr.Count; i++)
                {
                    M temp;
                    temp.x = Xbr[i];
                    temp.dQ = -1;
                    m.Add(temp);
                }

                for (int h = 0; h < m.Count - 1; h++)
                {
                    for (int j = h + 1; j < m.Count; j++)
                    {
                        if (m[j].x < m[h].x)
                        {
                            M temp = m[h];
                            m[h] = m[j];
                            m[j] = temp;
                        }
                    }
                }

                int Q = 0;
                int Qnew;
                int x;

                if (m.Count == 0)
                {
                    continue;
                }

                if (m[0].x >= 0 && m[0].dQ < 0)
                {
                    Xrl.Add(0);
                    Q = -m[0].dQ;
                }

                for (int i = 0; i < m.Count; i++)
                {
                    x = m[i].x;
                    Qnew = Q + m[i].dQ;

                    if ((Q < SetQ[0] || Q > SetQ[1]) && (Qnew >= SetQ[0] && Qnew <= SetQ[1]))
                    {
                        Xrl.Add(x);
                    }
                    if ((Q >= SetQ[0] && Q <= SetQ[1]) && (Qnew < SetQ[0] || Qnew > SetQ[1]))
                    {
                        Xrr.Add(x);
                    }

                    Q = Qnew;
                }

                if (Q >= SetQ[0] && Q <= SetQ[1])
                {
                    Xrr.Add(1149);
                }

                SortList(Xrl);
                SortList(Xrr);
                ListsFromY l = new ListsFromY();
                l.Y = Y;
                l.Lpl = new List<int>(Xrl);
                l.Lpr = new List<int>(Xrr);

                listsFigure.Add(l);
                //удаляем верхние и нижние пустые строки
                while (listsFigure.Count > 0 && listsFigure[0].Lpl.Count == 0)
                {
                    listsFigure.RemoveAt(0);
                }
                while (listsFigure.Count > 0 && listsFigure[listsFigure.Count - 1].Lpl.Count == 0)
                {
                    listsFigure.RemoveAt(listsFigure.Count - 1);
                }

            }
        }

        //сортирует поданный список
        private void SortList(List<int> Lp)
        {
            for (int h = 0; h < Lp.Count - 1; h++)
            {
                for (int j = h + 1; j < Lp.Count; j++)
                {
                    if (Lp[j] < Lp[h])
                    {
                        int temp = Lp[h];
                        Lp[h] = Lp[j];
                        Lp[j] = temp;
                    }
                }
            }
        }

        private void procBorder()
        {

            int Y1 = getMaxY();
            int Y2 = getMinY();

            int X1 = getMinX();
            int X2 = getMaxX(); 
            centerFigure = new Point(((X2 + X1) / 2), (Y2 + Y1) / 2);
            //g.DrawLine(Pens.DarkBlue, new Point(X1, Y1), new Point(X2, Y1));
            //g.DrawLine(Pens.DarkBlue, new Point(X1, Y2), new Point(X2, Y2));

            //g.DrawLine(Pens.DarkBlue, new Point(X1, Y1), new Point(X1, Y2));
            //g.DrawLine(Pens.DarkBlue, new Point(X2, Y1), new Point(X2, Y2));
        }

        private int getMinX()
        {
            int x = int.MaxValue;

            for (int i = 0; i < listsFigure.Count; i++)
            {
                for (int j = 0; j < listsFigure[i].Lpl.Count; j++)
                {
                    if (x > listsFigure[i].Lpl[j])
                    {
                        x = listsFigure[i].Lpl[j];
                    }
                }
            }
            return x;

        }

        private int getMaxX()
        {
            int x = 0;

            for (int i = 0; i < listsFigure.Count; i++)
            {
                for (int j = 0; j < listsFigure[i].Lpr.Count; j++)
                {
                    if (x < listsFigure[i].Lpr[j])
                    {
                        x = listsFigure[i].Lpr[j];
                    }
                }
            }
            return x;
        }
    }
}


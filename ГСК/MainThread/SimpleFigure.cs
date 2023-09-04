using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std
{
    struct ListsFromY
    {
        public int Y;
        public List<int> Lpl;
        public List<int> Lpr;
    }

    //Класс простой фигуры - из массива точек
    class SimpleFigure : Figure
    {

        //поля
        private List<Point> pointsFigure;
        private double[,] W;
        private List<ListsFromY> listsFigure;
        Graphics g;
        Brush pen;
        Point centerFigure;

        //конструктор - угол 
        public SimpleFigure(int x, int y, int h, int h2, Graphics g, Pen pen)
        {
            this.g = g;
            this.pen = pen.Brush;
            W = new double[3, 3];
            W[0, 0] = 1;
            W[0, 1] = 0;
            W[0, 2] = 0;
            W[1, 0] = 0;
            W[1, 1] = 1;
            W[1, 2] = 0;
            W[2, 0] = 0;
            W[2, 1] = 0;
            W[2, 2] = 1;

            pointsFigure = new List<Point>();
            centerFigure = new Point(x, y);

            pointsFigure.Add(new Point(x, y));
            pointsFigure.Add(new Point(x + 2 * h, y));
            pointsFigure.Add(new Point(x + 2 * h, y + 2 * h2));
            pointsFigure.Add(new Point(x - 2 * h2, y + 2 * h2));
            pointsFigure.Add(new Point(x - 2 * h2, y - 2 * h));
            pointsFigure.Add(new Point(x, y - 2 * h));

            setLP();
        }


        //конструктор - параллелепипед
        public SimpleFigure(int x, int y, int h, int h2, int n, Graphics g, Pen pen)
        {
            this.g = g;
            this.pen = pen.Brush;
            W = new double[3, 3];
            W[0, 0] = 1;
            W[0, 1] = 0;
            W[0, 2] = 0;
            W[1, 0] = 0;
            W[1, 1] = 1;
            W[1, 2] = 0;
            W[2, 0] = 0;
            W[2, 1] = 0;
            W[2, 2] = 1;
            pointsFigure = new List<Point>();
            centerFigure = new Point(x, y);
            
            pointsFigure.Add(new Point(x + h2 + h2 / 3 + 30, y - h + 10));
            pointsFigure.Add(new Point(x + h2 - h2 / 3 + 30, y + h - 10));
            pointsFigure.Add(new Point(x - h2 - h2 / 3 - 30, y + h - 10));
            pointsFigure.Add(new Point(x - h2 + h2 / 3 - 30, y - h + 10));
            
            setLP();
        }

        public Point getCenter()
        {
            return new Point((int)(centerFigure.X * W[0, 0] + centerFigure.Y * W[1, 0] + W[2, 0]), (int)(centerFigure.X * W[0, 1] + centerFigure.Y * W[1, 1] + W[2, 1])); ;
        }

        /*Отрисовка фигуры*/
        public void DrawFigure()
        {
            g.FillPolygon(pen, outMonitor());
            g.FillRectangle(Brushes.Red, getCenter().X, getCenter().Y, 2, 2);
        }

        //Применение непрерывной операции 
        public Point[] outMonitor()
        {
            Point[] list = new Point[pointsFigure.Count];
            for (int i = 0; i < pointsFigure.Count; i++)
            {
                list[i] = new Point((int)(pointsFigure[i].X * W[0, 0] + pointsFigure[i].Y * W[1, 0] + W[2, 0]), (int)(pointsFigure[i].X * W[0, 1] + pointsFigure[i].Y * W[1, 1] + W[2, 1]));
            }
            setLP();
            return list;
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
            int max = (int)(pointsFigure[0].Y * W[1, 1] + W[2, 1] + pointsFigure[0].X * W[0, 1]);
            for (int i = 1; i < pointsFigure.Count; i++)
            {
                if (max < (int)(pointsFigure[i].Y * W[1, 1] + W[2, 1] + pointsFigure[i].X * W[0, 1]))
                {
                    max = (int)(pointsFigure[i].Y * W[1, 1] + W[2, 1] + pointsFigure[i].X * W[0, 1]);
                }
            }
            return max;
        }

        //получить минимальную точку фигуры по У
        public int getMinY()
        {
            int min = (int)(pointsFigure[0].Y * W[1, 1] + W[2, 1] + pointsFigure[0].X * W[0, 1]);
            for (int i = 1; i < pointsFigure.Count; i++)
            {
                if (min > (int)(pointsFigure[i].Y * W[1, 1] + W[2, 1] + pointsFigure[i].X * W[0, 1]))
                {
                    min = (int)(pointsFigure[i].Y * W[1, 1] + W[2, 1] + pointsFigure[i].X * W[0, 1]);
                }
            }
            return min;
        }

        //проверяет попала ли точка в фигуру
        public bool pointInside(Point p)
        {
            if (p.Y > getMinY() && p.Y < getMaxY())
            {
                int num = 0;

                for (int i = 0; i < listsFigure.Count; i++)
                {
                    if (listsFigure[i].Y == p.Y)
                    {
                        num = i;
                    }
                }
                for (int i = 0; i < listsFigure[num].Lpl.Count; i++)
                {
                    if (p.X > listsFigure[num].Lpl[i] && p.X < listsFigure[num].Lpr[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //выполнить операцию
        public void runOperation(double[,] center, double[,] operation)
        {
            W = MulMatrix(W, center);
            W = MulMatrix(W, operation);
            center[2, 0] = -center[2, 0];
            center[2, 1] = -center[2, 1];
            W = MulMatrix(W, center);
            center[2, 0] = -center[2, 0];
            center[2, 1] = -center[2, 1];
            setLP();
        }


        //заполняет списки фигуры
        private void setLP()
        {
            List<ListsFromY> tmpList = new List<ListsFromY>();
            int Y = getMinY();
            int maxY = getMaxY();
            for (; Y < maxY; Y++)
            {
                int k = 0;
                List<int> xl = new List<int>();
                List<int> xr = new List<int>();
                List<int> Xall = new List<int>();
                for (int i = 0; i < pointsFigure.Count; i++)
                {
                    if (i < pointsFigure.Count - 1)
                    {
                        k = i + 1;
                    }
                    else
                    {
                        k = 0;
                    }

                    int piy = (int)(pointsFigure[i].Y * W[1, 1] + W[2, 1] + pointsFigure[i].X * W[0, 1]);
                    int pky = (int)(pointsFigure[k].Y * W[1, 1] + W[2, 1] + pointsFigure[k].X * W[0, 1]);
                    int pix = (int)(pointsFigure[i].X * W[0, 0] + pointsFigure[i].Y * W[1, 0] + W[2, 0]);
                    int pkx = (int)(pointsFigure[k].X * W[0, 0] + pointsFigure[k].Y * W[1, 0] + W[2, 0]);

                    if (((piy < Y) && (pky >= Y)) || ((piy >= Y) && (pky < Y)))
                    {
                        double x = (((double)(Y - piy) / (pky - piy)) * (pkx - pix)) + pix;
                        Xall.Add((int)x);
                    }


                }
                SortList(Xall);
                for (int a = 0; a < Xall.Count - 1; a += 2)
                {
                    xl.Add(Xall[a]);
                    xr.Add(Xall[a + 1]);
                }

                SortList(xl);
                SortList(xr);
                ListsFromY l = new ListsFromY();
                l.Y = Y;
                l.Lpl = xl;
                l.Lpr = xr;

                tmpList.Add(l);
            }
            listsFigure = new List<ListsFromY>(tmpList);
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

        //метод для перемножения двух матриц
        private double[,] MulMatrix(double[,] W, double[,] P)
        {
            double[,] newW = new double[3, 3];
            for (int i = 0; i < W.GetLength(1); i++)
            {
                for (int j = 0; j < P.GetLength(0); j++)
                {
                    for (int k = 0; k < W.GetLength(1); k++)
                    {
                        newW[i, j] += W[i, k] * P[k, j];
                    }
                }
            }
            return newW;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Std
{
    //структура для хранения объекта вектора кубического сплайна
    public struct Vector
    {
        public Point begin;
        public Point end;
    }
    public class Spline
    {
        //начальный и конечный векторы для построения кубического сплайна
        public Vector beginVector, endVector;
        Boolean FirstVector = true;
        Graphics g;

        public void setVector(Vector v)
        {
            if (FirstVector)
            {
                beginVector = v;
                FirstVector = false;
                drawVector(v);
            }
            else
            {
                endVector = v;
                FirstVector = true;
                drawVector(v);
                ProcDrawSpline();
            }
        }

        public Spline(Graphics g)
        {
            this.g = g;
        }

        //метод рисования кубического сплайна
        public void ProcDrawSpline()
        {

            int[,] Gh = new int[4, 2];
            int[,] Mh = new int[4, 4] { { 2, -2, 1, 1 }, { -3, 3, -2, -1 }, { 0, 0, 1, 0 }, { 1, 0, 0, 0 } };
            int[,] L = new int[4, 2];



            Gh[0, 0] = (int)beginVector.begin.X;
            Gh[0, 1] = (int)beginVector.begin.Y;
            Gh[1, 0] = (int)endVector.begin.X;
            Gh[1, 1] = (int)endVector.begin.Y;
            Gh[2, 0] = (int)beginVector.end.X - (int)beginVector.begin.X;
            Gh[2, 1] = (int)beginVector.end.Y - (int)beginVector.begin.Y;
            Gh[3, 0] = (int)endVector.end.X - (int)endVector.begin.X;
            Gh[3, 1] = (int)endVector.end.Y - (int)endVector.begin.Y;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        L[i, j] += Mh[i, k] * Gh[k, j];
                    }
                }
            }

            Point p1 = new Point();
            Point p2 = new Point();
            p1.X = L[3, 0];
            p1.Y = L[3, 1];

            for (double t = 0.01; t <= (1 + 0.005); t += 0.01)
            {
                p2.X = (int)(t * (t * (L[0, 0] * t + L[1, 0]) + L[2, 0]) + L[3, 0]);
                p2.Y = (int)(t * (t * (L[0, 1] * t + L[1, 1]) + L[2, 1]) + L[3, 1]);

                g.DrawLine(Pens.Black, new Point(p1.X, p1.Y), new Point(p2.X, p2.Y));

                p1 = p2;
            }


        }

        //метод визуализации векторов
        public void drawVector(Vector v)
        {
            g.DrawLine(Pens.Red, new Point(v.begin.X, v.begin.Y), new Point(v.end.X, v.end.Y));

        }

        public void reset()
        {
            FirstVector = true;
        }
    }
}

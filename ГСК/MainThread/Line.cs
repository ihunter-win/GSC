using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std
{
    //класс прямой
    public class Line
    {
        //обьекты для рисования
        public Graphics g;
        public Pen DrawPen;

        public Line(Graphics g, Pen DrawPen)
        {
            this.g = g;
            this.DrawPen = DrawPen;

        }
        //данные для построения прямой
        Point P1, P2;
        Boolean FirstPoint = true;
        uint w = 1;
        // Визуализация отрезка
        public void ProcDrawLine(Pen DrPen, int x1, int y1, int x2, int y2)
        {
            int x, y, dx, dy, Sx = 0, Sy = 0;
            int F = 0, Fx = 0, dFx = 0, Fy = 0, dFy = 0;

            dx = x2 - x1;
            dy = y2 - y1;

            Sx = Math.Sign(dx);
            Sy = Math.Sign(dy);

            if (Sx > 0) dFx = dy; else dFx = -dy;
            if (Sy > 0) dFy = dx; else dFy = -dx;
            x = x1;
            y = y1;
            F = 0;
            if (Math.Abs(dx) >= Math.Abs(dy)) // угол наклона <= 45 градусов 
            {
                do
                {
                    //Вывести пиксель с координатами х, у
                    Draw(DrPen, x, y);
                    if (x == x2)
                        break;
                    Fx = F + dFx;
                    F = Fx - dFy;
                    x = x + Sx;
                    if (Math.Abs(Fx) < Math.Abs(F)) F = Fx;
                    else y = y + Sy;
                } while (true);

            }
            else // угол наклона > 45 градусов
            {
                do
                { //Вывести пиксель с координатами х, у 
                    Draw(DrPen, x, y);
                    if (y == y2)
                        break;
                    Fy = F + dFy;
                    F = Fy - dFx;
                    y = y + Sy;
                    if (Math.Abs(Fy) < Math.Abs(F)) F = Fy;
                    else x = x + Sx;
                } while (true);
            }
            FirstPoint = true;
        }
        // Вывод точки (квадрата)
        private void Draw(Pen Brush, int x, int y)
        {
            g.DrawRectangle(Brush, x, y, w, w);
        }
        public void SetP(int x, int y)
        {
            if (FirstPoint)
            {
                P1.X = x;
                P1.Y = y;
                FirstPoint = false;
            }
            else
            {
                P2.X = x;
                P2.Y = y;
                FirstPoint = false;
                ProcDrawLine(DrawPen, P1.X, P1.Y, P2.X, P2.Y);
            }

        }

        public uint getW()
        {
            return w;
        }
        public void setW(uint w)
        {
            this.w = w;
        }
        public void reset()
        {
            FirstPoint = true;
        }

    };
}

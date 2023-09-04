using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Std
{
    public partial class Form1 : Form
    {

        byte typeOperation;
        Point[] twoPoints = new Point[2];
        //матрица центра преобразования
        double[,] centerArray = new double[3, 3];

        //Для двойной буферизации, на этот объект отрисовывается изображение, а затем оно пекреносится на экран
        Bitmap btmBack;

        //массив для выбора фигур ТМО
        Figure[] twoFigure = new Figure[2];

        //массив точек для линии
        List<Point> twoPoint = new List<Point>();

        //количество фигур в массиве
        int count = 0;

        //предыдущее положение мыши
        Point position;

        //выделение первой точки линии
        private bool firstPoint = true;

        Line line;

        //выделенная фигура
        int numFigure;

        //угол поворота
        double alfa = 1;

        //параметры масштабирования
        double k = 1;

        //центр трансформации
        Point center;

        //Список фигур
        List<Figure> figures;
        Graphics g;

        //параметры для построения фигур
        int h = 80;
        int h2 = 70;
        //количество вершин звезды
        int n = 4;

        //данные для построения кривой Безье
        List<LineBezie> splines = new List<LineBezie>();
        List<Point> Lp = new List<Point>();

        double[] factorial = new double[50];

        Pen DrawPenCenter = new Pen(Color.Red, 1);
        Pen DrawPen = new Pen(Color.Black, 3);
        Pen beziePen = new Pen(Color.Gray, 1);

        public Form1()
        {
            InitializeComponent();
            g = pictureBox.CreateGraphics();
            btmBack = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(btmBack);
            figures = new List<Figure>();
            line = new Line(g, DrawPen);

            centerArray[0, 0] = 1;
            centerArray[0, 1] = 0;
            centerArray[0, 2] = 0;
            centerArray[1, 0] = 0;
            centerArray[1, 1] = 1;
            centerArray[1, 2] = 0;
            centerArray[2, 0] = 0;
            centerArray[2, 1] = 0;
            centerArray[2, 2] = 1;

            //подсчет факториалов до 50
            factorial[0] = 1.0;
            factorial[1] = 1.0;
            for (int j = 2; j < 50; j++)
            {
                factorial[j] = factorial[j - 1] * j;
            }

        }

        //Отрисовка всех обьектов
        public void DrawAll()
        {
            pictureBox.Image = btmBack;
            g.Clear(Color.White);
            for (int i = 0; i < twoPoint.Count - 1; i++)
            {
                line.ProcDrawLine(DrawPen, twoPoint[i].X, twoPoint[i].Y, twoPoint[i + 1].X, twoPoint[i + 1].Y);
                i++;
            }

            for (int i = 0; i < figures.Count; i++)
            {
                figures[i].DrawFigure();
            }

            for (int j = 0; j < Lp.Count; j++)
            {
                g.DrawRectangle(DrawPen, Lp[j].X, Lp[j].Y, 1, 1);
            }

            for (int j = 0; j < Lp.Count - 1; j++)
            {
                line.ProcDrawLine(beziePen, Lp[j].X, Lp[j].Y, Lp[j + 1].X, Lp[j + 1].Y);
            }

            for (int i = 0; i < splines.Count; i++)
            {
                splines[i].ProcDrawBezie();
                for (int j = 0; j < splines[i].getLp().Count; j++)
                {
                    g.DrawRectangle(DrawPen, splines[i].getLp()[j].X, splines[i].getLp()[j].Y, 1, 1);
                }

                for (int j = 0; j < splines[i].getLp().Count - 1; j++)
                {
                    line.ProcDrawLine(beziePen, splines[i].getLp()[j].X, splines[i].getLp()[j].Y, splines[i].getLp()[j + 1].X, splines[i].getLp()[j + 1].Y);
                }
            }

            //Рисуем центр преобразований 
            g.DrawLine(DrawPenCenter, center.X - 4, center.Y + 4, center.X + 4, center.Y - 4);
            g.DrawLine(DrawPenCenter, center.X - 4, center.Y - 4, center.X + 4, center.Y + 4);

            pictureBox.Refresh();

        }


        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox.Image = btmBack;
            //Операция в зависимости от типа 
            switch (typeOperation)
            {
                case 0: //сплайн
                    Lp.Add(new Point(e.X, e.Y));
                    DrawAll();
                    break;
                case 1: //задать фигуру - Ugl
                    figures.Add(new SimpleFigure(e.X, e.Y, h, h2, g, DrawPen));
                    DrawAll();
                    break;
                case 2: //задать фигуру - PAr
                    figures.Add(new SimpleFigure(e.X, e.Y, h, h2, n, g, DrawPen));
                    DrawAll();
                    break;
                case 3: //Выделение фигуры
                    for (int i = figures.Count - 1; i != -1; i--)
                    {
                        if (figures[i].pointInside(new Point(e.X, e.Y)))
                        {
                            numFigure = i;
                            break;
                        }
                    }
                    break;
                case 4: //перемещение
                    position.X = e.X;
                    position.Y = e.Y;
                    centerArray[2, 0] = -figures[numFigure].getCenter().X;
                    centerArray[2, 1] = -figures[numFigure].getCenter().Y;
                    break;
                case 5: //ТМО
                    addFigureForTMO(1, e.X, e.Y);
                    break;
                case 6: //ТМО
                    addFigureForTMO(2, e.X, e.Y);
                    break;
                case 7: //линия
                    if (firstPoint)
                    {
                        g.DrawRectangle(DrawPen, e.X, e.Y, 1, 1);
                        twoPoint.Add(new Point(e.X, e.Y));
                        firstPoint = false;
                    }
                    else
                    {
                        g.DrawRectangle(DrawPen, e.X, e.Y, 1, 1);
                        twoPoint.Add(new Point(e.X, e.Y));
                        line.ProcDrawLine(DrawPen, twoPoint[twoPoint.Count - 2].X, twoPoint[twoPoint.Count - 2].Y, twoPoint[twoPoint.Count - 1].X, twoPoint[twoPoint.Count - 1].Y);
                        firstPoint = true;
                    }
                    DrawAll();
                    return;
                case 8: //задать центр
                    center.X = e.X;
                    center.Y = e.Y;
                    centerArray[2, 0] = -e.X;
                    centerArray[2, 1] = -e.Y;
                    break;

                case 9:
                    if (figures.Count == 0)
                        return;

                    if (typeOperation == 9 && e.Button == MouseButtons.Left)
                    {
                        double[,] rcArray = new double[3, 3];
                        rcArray[0, 0] = Math.Cos(30 * Math.PI / 180);
                        rcArray[0, 1] = Math.Sin(30 * Math.PI / 180);
                        rcArray[0, 2] = 0;
                        rcArray[1, 0] = -Math.Sin(30 * Math.PI / 180);
                        rcArray[1, 1] = Math.Cos(30 * Math.PI / 180);
                        rcArray[1, 2] = 0;
                        rcArray[2, 0] = 0;
                        rcArray[2, 1] = 0;
                        rcArray[2, 2] = 1;

                        centerArray[2, 0] = -e.X;
                        centerArray[2, 1] = -e.Y;

                        figures[numFigure].runOperation(centerArray, rcArray);
                    }



                    DrawAll();
                    break;
            }
            pictureBox.Refresh();
            DrawAll();
        }

        //выбор операции Rc30
        //Поворот вокруг заданного центра на угол 30
        private void Rc30Button_Click(object sender, EventArgs e)
        {
           

        }

        //задается тип операции - Угол
        private void FlagButton_Click(object sender, EventArgs e)
        {
            typeOperation = 1;
        }

        //задается тип операции - выделение
        private void SelectFigure_Click(object sender, EventArgs e)
        {
            typeOperation = 3;
        }

        //задать тип операции - перемещение
        private void MoveButton_Click(object sender, EventArgs e)
        {
            typeOperation = 4;
        }

        //выбор режима ТМО (Разность)
        private void diff_Click(object sender, EventArgs e)
        {
            typeOperation = 5;
            count = 0;
        }

        //выбор режима ТМО (Объединение)
        private void cross_Click(object sender, EventArgs e)
        {
            typeOperation = 6;
            count = 0;
        }

        //очистка окна отрисовки
        private void ClearBox_Click(object sender, EventArgs e)
        {
            count = 0;
            firstPoint = true;
            twoFigure = new Figure[2];
            twoPoint = new List<Point>();
            figures.Clear();
            splines.Clear();
            g.Clear(Color.White);
            center = new Point(0, 0);
            pictureBox.Refresh();
            Lp = new List<Point>();
        }

        //выбор операции Sxyf
        //Пропорциональное масштабирование относительно центра фигуры
        private void SxyfButton_Click(object sender, EventArgs e)
        {
            if (figures.Count == 0)
                return;
            double[,] rcArray = new double[3, 3];

            try
            {
                k = Convert.ToDouble(kTextBox.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Задайте корректный параметр");
                k = 1;
            }

            rcArray[0, 0] = k;
            rcArray[0, 1] = 0;
            rcArray[0, 2] = 0;
            rcArray[1, 0] = 0;
            rcArray[1, 1] = k;
            rcArray[1, 2] = 0;
            rcArray[2, 0] = 0;
            rcArray[2, 1] = 0;
            rcArray[2, 2] = 1;

            centerArray[2, 0] = -figures[numFigure].getCenter().X;
            centerArray[2, 1] = -figures[numFigure].getCenter().Y;

            figures[numFigure].runOperation(centerArray, rcArray);

            centerArray[2, 0] = -figures[numFigure].getCenter().X;
            centerArray[2, 1] = -figures[numFigure].getCenter().Y;

            DrawAll();
        }

        //обработчик зажатой мыши(перемещение)
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (figures.Count == 0)
                return;

            if (typeOperation == 4 && e.Button == MouseButtons.Left)
            {
                double[,] moveArray = new double[3, 3];
                moveArray[0, 0] = 1;
                moveArray[0, 1] = 0;
                moveArray[0, 2] = 0;
                moveArray[1, 0] = 0;
                moveArray[1, 1] = 1;
                moveArray[1, 2] = 0;
                moveArray[2, 0] = e.X - position.X;
                moveArray[2, 1] = e.Y - position.Y;
                moveArray[2, 2] = 1;

                figures[numFigure].runOperation(centerArray, moveArray);

                position.X = e.X;
                position.Y = e.Y;
                DrawAll();
            }
        }

        //добавить результат ТМО
        public void addFigureForTMO(int type, int X, int Y)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].pointInside(new Point(X, Y)))
                {
                    if (count < 2)
                    {
                        twoFigure[count] = figures[i];
                        count++;
                        if (count == 2)
                        {
                            figures.Add(new TMOFigure(twoFigure[0], twoFigure[1], g, DrawPen, type));
                            figures.Remove(twoFigure[0]);
                            figures.Remove(twoFigure[1]);
                            DrawAll();
                        }
                    }
                }
            }
        }


        //выбор режима - Spline
        private void SplineButton_Click(object sender, EventArgs e)
        {
            typeOperation = 0;
            if (Lp.Count != 0)
            {
                splines.Add(new LineBezie(g, factorial, Lp));
                DrawAll();
            }
                Lp = new List<Point>();
        }

        //задание режима линии
        private void LineButton_Click(object sender, EventArgs e)
        {
            typeOperation = 7;
        }

        //удаление фигуры
        private void DelFigureButton_Click(object sender, EventArgs e)
        {
            if (figures.Count > 0)
            {
                figures.RemoveAt(numFigure);
                numFigure = 0;
                DrawAll();
            }
        }
        
        //выбор режима SPc
        //Зеркальное отражение относительно заданного центра
        private void SHButton_Click(object sender, EventArgs e)
        {
            if (figures.Count == 0)
                return;
            double[,] rcArray = new double[3, 3];

            rcArray[0, 0] = Math.Cos(15 * Math.PI / 180);
            rcArray[0, 1] = Math.Sin(15 * Math.PI / 180);
            rcArray[0, 2] = 0;
            rcArray[1, 0] = -Math.Sin(15 * Math.PI / 180);
            rcArray[1, 1] = Math.Cos(15 * Math.PI / 180);
            rcArray[1, 2] = 0;
            rcArray[2, 0] = 0;
            rcArray[2, 1] = 0;
            rcArray[2, 2] = 1;

            centerArray[2, 0] = -center.X;
            centerArray[2, 1] = -center.Y;

            figures[numFigure].runOperation(centerArray, rcArray);

            //начать поворот  
            figures[numFigure].runOperation(centerArray, rcArray);
            DrawAll();
        }
        
        //задание параметра h
        private void hTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                h = Int32.Parse(hTextBox.Text);
            }
            catch (Exception ee)
            {

            }
        }

        private void bTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void TgrButton_Click(object sender, EventArgs e)
        {
            typeOperation = 2;
        }

        //нажатие на кнопку Rс
        //Поворот вокруг центра фигуры на произвольный угол
        private void RfButton_Click(object sender, EventArgs e)
        {
            if (figures.Count == 0)
                return;
            double[,] rcArray = new double[3, 3];

           

            rcArray[0, 0] = Math.Cos(alfa * Math.PI / 180);
            rcArray[0, 1] = Math.Sin(alfa * Math.PI / 180);
            rcArray[0, 2] = 0;
            rcArray[1, 0] = -Math.Sin(alfa * Math.PI / 180);
            rcArray[1, 1] = Math.Cos(alfa * Math.PI / 180);
            rcArray[1, 2] = 0;
            rcArray[2, 0] = 0;
            rcArray[2, 1] = 0;
            rcArray[2, 2] = 1;

            

            centerArray[2, 0] = -center.X;
            centerArray[2, 1] = -center.Y;

            figures[numFigure].runOperation(centerArray, rcArray);

            
            DrawAll();
        }

        private void alfaTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                alfa = Convert.ToDouble(alfaTextBox.Text);
            }
            catch (Exception ee)
            {

            }
        }

        private void SetCenterButton_Click(object sender, EventArgs e)
        {
            typeOperation = 8;
        }

        private void ktextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxH2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                h2 = Convert.ToInt32(textBoxH2.Text);
            }
            catch (Exception ee)
            {

            }
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _184784Pong_Culminating
{
    /// <summary>
    /// Interaction logic for GameBoard.xaml
    /// </summary>
    public partial class GameBoard : Window
    {
        public Point Player1Point = new Point();
        public Point Player2Point = new Point();
        public enum Direction { UP1, DOWN1, UP2, DOWN2 };
        Direction direction;
        public DispatcherTimer timer = new DispatcherTimer();
        public static double Xspeed = -1;
        public static double Yspeed = 1;

        public GameBoard()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += update;
            timer.Tick += update2;
            timer.Start();
        }
        public void update(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                direction = Direction.UP1;
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                direction = Direction.DOWN1;
            }

            switch (direction)
            {
                case Direction.UP1:
                    Player1Point = new Point(Player1Point.X, Player1Point.Y - 1);
                    break;
                case Direction.DOWN1:
                    Player1Point = new Point(Player1Point.X, Player1Point.Y + 1);
                    break;
            }
            if (Player1Point.Y<=0)
            {
                direction = Direction.DOWN1;
            }
            if (Player1Point.Y>=240)
            {
                direction = Direction.UP1;
            
            }
            Canvas.SetTop(Player1, Player1Point.Y);
            Canvas.SetLeft(Player1, Player1Point.X);
        }
        public void update2(object sender, EventArgs e)
        {
            Player2Point.X = 485;
            if (Keyboard.IsKeyDown(Key.Down))
            {
                direction = Direction.DOWN2;
            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                direction = Direction.UP2;
            }
            switch (direction)
            {
                case Direction.DOWN2:
                    Player2Point = new Point(Player2Point.X, Player2Point.Y + 1);
                    break;
                case Direction.UP2:
                    Player2Point = new Point(Player2Point.X, Player2Point.Y - 1);
                    break;
            }
            if (Player2Point.Y <= 0)
            {
                direction = Direction.DOWN2;
            }
            if (Player2Point.Y >= 240)
            {
                direction = Direction.UP2;

            }
            Canvas.SetTop(Player2, Player2Point.Y);
            Canvas.SetLeft(Player2, Player2Point.X);
        }
    }
}
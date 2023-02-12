using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using System.Collections.Generic;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NumberRollGame
{
    public sealed partial class MainPage : Page
    {
        public int AmountQuintuples = 0;
        public int AmountQuadruples = 0;
        public int AmountTriples = 0;
        public int AmountDoubles = 0;
        public int[] Num = new int[5];
        public int Score = 0;
        public int round = 0;
        int m = 1;
        public object Pname;
        List<int> games = new List<int>();
        public Random RandomGenerator = new Random();
        Game game = new Game(0,0,0,0,0);
        public MainPage()
        {
            this.InitializeComponent();
            SetupGame();
        }
        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs a)
        {
            string Pname = a.Parameter.ToString();
            this.Frame.Navigate(typeof(ResultPage), Pname);
            txttitle.Text = $"Player: {Pname}";
        }

            private void SetupGame()
        {
            WinText.Text = "Click the Roll button to play";
            ScoreText.Text = $"Score: {Score}";
            RoundText.Text = $"Round {round}/15";
        }

        private async void RollButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Num.Length; i++)
            {
                int NumValue = RandomGenerator.Next(1, 10);
                Num[i] = NumValue;
            }

            Slot1.DisplayFace(Num[0]);
            Slot2.DisplayFace(Num[1]);
            Slot3.DisplayFace(Num[2]);
            Slot4.DisplayFace(Num[3]);
            Slot5.DisplayFace(Num[4]);

            if (m < 16)
            {
                ApplyGameRules();
            }
            else {

                bResult.Visibility = Visibility.Visible;
                bPagain.Visibility = Visibility.Visible;
                Slot1.DisplayQ();
                Slot2.DisplayQ();
                Slot3.DisplayQ();
                Slot4.DisplayQ();
                Slot5.DisplayQ();
                games.Add(AmountDoubles);
                games.Add(AmountTriples);
                games.Add(AmountQuadruples);
                games.Add(AmountQuintuples);
                games.Add(Score);               
                if (Score>250)
                {
                    MessageDialog dialog = new MessageDialog("Game Over "+" You Win!");
                    await dialog.ShowAsync();
                }else{
                    MessageDialog dialog = new MessageDialog("Game Over " + " You Lose!");
                    await dialog.ShowAsync();
                }
            }
            m += 1;

        }

        public void ApplyGameRules()
        {
            int NewScore = 0;
            string WinMessage = "";
            int newAmountQuintuples = 0;
            int newAmountQuadruples = 0;
            int newAmountTriples = 0;
            int newAmountDoubles = 0;
            if (Num[0] == Num[1] && Num[1] == Num[2] && Num[2] == Num[3] && Num[3] == Num[4])
            {
                //Quintuple
                NewScore = Num[0] * 10000;
                WinMessage = $"You rolled five {Num[1]} for {NewScore} points!!!!!!!!";
                newAmountQuintuples = 1;
            }

            else if (Num[0] == Num[1] && Num[1] == Num[2] && Num[2] == Num[3] || Num[0] == Num[2] && Num[2] == Num[3] && Num[3] == Num[4] || Num[1] == Num[2] && Num[2] == Num[3] && Num[3] == Num[4] || Num[0] == Num[1] && Num[1] == Num[2] && Num[2] == Num[4] || Num[0] == Num[1] && Num[1] == Num[3] && Num[3] == Num[4])
            {
                //Quadruple
                NewScore = 100;
                WinMessage = $"You scored quadruples for {NewScore} points.";
                newAmountQuadruples = 1;
            }


            else if (Num[0] == Num[1] && Num[0] == Num[2] || Num[0] == Num[1] && Num[0] == Num[3] || Num[0] == Num[1] && Num[0] == Num[4] || Num[0] == Num[2] && Num[0] == Num[4] || Num[0] == Num[3] && Num[0] == Num[4] || Num[1] == Num[2] && Num[1] == Num[3] || Num[1] == Num[2] && Num[1] == Num[4] || Num[1] == Num[3] && Num[1] == Num[4]|| Num[2] == Num[3] && Num[2] == Num[4])
            {
                // Triple
                NewScore = 50;
                WinMessage = $"You scored triples for {NewScore} points.";
                newAmountTriples = 1;

            }
            else if (Num[0] == Num[1] && Num[2] == Num[3] || Num[0] == Num[1] && Num[2] == Num[4] || Num[0] == Num[1] && Num[4] == Num[3] || Num[0] == Num[2] && Num[1] == Num[3] || Num[0] == Num[2] && Num[1] == Num[4] || Num[0] == Num[2] && Num[3] == Num[4] || Num[0] == Num[3] && Num[1] == Num[2] || Num[0] == Num[3] && Num[1] == Num[4] || Num[0] == Num[3] && Num[2] == Num[4] || Num[0] == Num[4] && Num[1] == Num[2] || Num[0] == Num[4] && Num[1] == Num[3] || Num[0] == Num[4] && Num[2] == Num[3] || Num[1] == Num[2] && Num[3] == Num[4] || Num[1] == Num[3] && Num[2] == Num[4])
            {
                //double double
                NewScore = 30;
                WinMessage = $"You scored double doubles for {NewScore} points.";
                newAmountDoubles = 2;
            }
            else if (Num[0] == Num[1] || Num[0] == Num[2] || Num[0] == Num[3] || Num[0] == Num[4] || Num[1] == Num[2] || Num[1] == Num[3] || Num[1] == Num[4] || Num[2] == Num[3] || Num[2] == Num[4] || Num[3] == Num[4])
            {
                // Double
                NewScore = 10;
                WinMessage = $"You scored doubles for {NewScore} points.";
                newAmountDoubles = 1;
            }
          
            else
            {
                // No matches
                newAmountQuintuples = 0;
                newAmountQuadruples = 0;
                newAmountTriples = 0;
                newAmountDoubles = 0;
                NewScore = 0;
                WinMessage = "No matches this roll.";
            }
            round++;
            RoundText.Text = $"Round {round}/15";
            Score = Score + NewScore;
            AmountDoubles = newAmountDoubles + AmountDoubles;
            AmountTriples = newAmountTriples + AmountTriples;
            AmountQuadruples = newAmountQuadruples + AmountQuadruples;
            AmountQuintuples = newAmountQuintuples + AmountQuintuples;
            ScoreText.Text = $"Score: {Score}";
            WinText.Text = WinMessage;          
           
        }
       
        private void BResult_Click(object sender, RoutedEventArgs e)
            {
           
            this.Frame.Navigate(typeof(ResultPage),games);
            }

            private void BPagain_Click(object sender, RoutedEventArgs e)
            {
                Score = 0;
                round = 0;
                m = 1;
                WinText.Text = "";
                ScoreText.Text = "";
                RoundText.Text = "";
                bResult.Visibility = Visibility.Collapsed;
                bPagain.Visibility = Visibility.Collapsed;
                AmountDoubles = 0;
                AmountTriples = 0;
                AmountQuadruples = 0;
                AmountQuintuples = 0;
                games.Clear();
            }

        }
    }


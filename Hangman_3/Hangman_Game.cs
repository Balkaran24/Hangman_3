using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman_3
{
    [Activity(Label = "Hangman Game")]
    public class Hangman_Game : Activity
    {


        // created Buttons A-Z 
        private Button btn_A;
        private Button btn_B;
        private Button btn_C;
        private Button btn_D;
        private Button btn_E;
        private Button btn_F;
        private Button btn_G;
        private Button btn_H;
        private Button btn_I;
        private Button btn_J;
        private Button btn_K;
        private Button btn_L;
        private Button btn_M;
        private Button btn_N;
        private Button btn_O;
        private Button btn_P;
        private Button btn_Q;
        private Button btn_R;
        private Button btn_S;
        private Button btn_T;
        private Button btn_U;
        private Button btn_V;
        private Button btn_W;
        private Button btn_X;
        private Button btn_Y;
        private Button btn_Z;



        private TextView txtWrdToGuess;
        private Button btngmMainMenu;
        private Button btnNewGame;
        private ImageView imgHngman;
        private TextView txtCrentScore;
        private TextView txtGusLeft;

        public static int Id;
        public static string PlyerName;
        public static int score;
        private string letter;
        private string rand;

        private int GusLeft = 8;

        private char[] wrdToGus;
        private char[] HdenWord;

        private bool GuessedCorrect;

        private List<string> wordList = new List<string>();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Hangman_Game_Screen_Layout);
            LoadWords();


            btnNewGame = FindViewById<Button>(Resource.Id.btnNewGame);
            txtWrdToGuess = FindViewById<TextView>(Resource.Id.txtWordToGuess);
            btngmMainMenu = FindViewById<Button>(Resource.Id.gamebtnMainMenu);
            btngmMainMenu.Click += btngameMainMenu_Click;
            btnNewGame.Click += btnNewGame_Click;
            txtCrentScore = FindViewById<TextView>(Resource.Id.txtCurrentScore);
            txtCrentScore.Text = score.ToString();
            txtGusLeft = FindViewById<TextView>(Resource.Id.txtGuessesLeft);
            txtGusLeft.Text = GusLeft.ToString();


            btn_A = FindViewById<Button>(Resource.Id.btn_A); btn_B = FindViewById<Button>(Resource.Id.btn_B);btn_C = FindViewById<Button>(Resource.Id.btn_C);
            btn_D = FindViewById<Button>(Resource.Id.btn_D); btn_E = FindViewById<Button>(Resource.Id.btn_E);btn_F = FindViewById<Button>(Resource.Id.btn_F);
            btn_G = FindViewById<Button>(Resource.Id.btn_G); btn_H = FindViewById<Button>(Resource.Id.btn_H); btn_I = FindViewById<Button>(Resource.Id.btn_I);
            btn_J = FindViewById<Button>(Resource.Id.btn_J);btn_K = FindViewById<Button>(Resource.Id.btn_K); btn_L = FindViewById<Button>(Resource.Id.btn_L);
            btn_M = FindViewById<Button>(Resource.Id.btn_M);   btn_N = FindViewById<Button>(Resource.Id.btn_N);
            btn_O = FindViewById<Button>(Resource.Id.btn_O);            btn_P = FindViewById<Button>(Resource.Id.btn_P);
            btn_Q = FindViewById<Button>(Resource.Id.btn_Q);            btn_R = FindViewById<Button>(Resource.Id.btn_R);
            btn_S = FindViewById<Button>(Resource.Id.btn_S);            btn_T = FindViewById<Button>(Resource.Id.btn_T);
            btn_U = FindViewById<Button>(Resource.Id.btn_U);            btn_V = FindViewById<Button>(Resource.Id.btn_V);
            btn_W = FindViewById<Button>(Resource.Id.btn_W);            btn_X = FindViewById<Button>(Resource.Id.btn_X);
            btn_Y = FindViewById<Button>(Resource.Id.btn_Y);            btn_Z = FindViewById<Button>(Resource.Id.btn_Z);
            //all  buttons Disable
            All_Disable_Buttons();
            imgHngman = FindViewById<ImageView>(Resource.Id.imgHangman);
            Load_blank_Image();

            // Create One Event Click for each button.
            btn_A.Click += Letter_Click;
            btn_B.Click += Letter_Click;
            btn_C.Click += Letter_Click;
            btn_D.Click += Letter_Click;
            btn_E.Click += Letter_Click;
            btn_F.Click += Letter_Click;
            btn_G.Click += Letter_Click;
            btn_H.Click += Letter_Click;
            btn_I.Click += Letter_Click;
            btn_J.Click += Letter_Click;
            btn_K.Click += Letter_Click;
            btn_L.Click += Letter_Click;
            btn_M.Click += Letter_Click;
            btn_N.Click += Letter_Click;
            btn_O.Click += Letter_Click;
            btn_P.Click += Letter_Click;
            btn_Q.Click += Letter_Click;
            btn_R.Click += Letter_Click;
            btn_S.Click += Letter_Click;
            btn_T.Click += Letter_Click;
            btn_U.Click += Letter_Click;
            btn_V.Click += Letter_Click;
            btn_W.Click += Letter_Click;
            btn_X.Click += Letter_Click;
            btn_Y.Click += Letter_Click;
            btn_Z.Click += Letter_Click;

        }


        private void btngameMainMenu_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }


        private void Letter_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(200);
            // Ref. the button that was clicked
            var clickedbutton = (Button)sender;
            //  clicked button disable
            clickedbutton.Enabled = false;
            // "letter" variable  holds  text property of button that was clicked
            letter = clickedbutton.Text;
            //Covert letter to upper case to comapre 
            letter = letter.ToUpper();
            // loop through the array of the hidden word and check  can we match the letter
            for (int i = 0; i < HdenWord.Length; i++)
            {
                // if the "letter" matchec to guess
                if (letter == wrdToGus[i].ToString())
                {
                    // // get the position of the letter(i) in the word .
                    HdenWord[i] = letter.ToCharArray()[0];
                    txtWrdToGuess.Text = string.Join(" ", HdenWord);


                    // Call  "LetterScore" method. Add to the score based upon the letter guessed
                    LetterScore();
                    ScoreUpdate();
                   
                    GuessedCorrect = true;

                }




            }
            // If the GuessedCorrect is false, decrease the "GuessesLeft" by 1
            if (GuessedCorrect == false)
            {
                GusLeft = GusLeft - 1;

                GuessFailed();
                GusdWrngTxtUpdte();
                ScoreUpdate();
            }
            else
            { // Set GuessedCorrect back to False for the next loop
                GuessedCorrect = false;
            }

            // If all "_" replaced then word completed and game won by player.
            if (!HdenWord.Contains('_'))

            {
                GameWon();
            }

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {// Agian Loads a random word from Hang_Dic.txt, disable the NewGame button and set the blank image


            btnNewGame.Enabled = false;
            LoadNewRandomWord();
            btnNewGame.Enabled = false;
            Load_blank_Image();
        }


        private void LoadNewRandomWord()
        {// All A-Z buttons are enabled and set the guesses left to eight (8) and choose next  random word from Hang_Dic.txt file and make the word uppercase and then change the word to an array.
            ButtonEnable();
            GusLeft = 8;
            Random randomGen = new Random();
            rand = wordList[randomGen.Next(wordList.Count)];
            rand = rand.ToUpper();
            wrdToGus = rand.ToArray();



            //  The HdenWord  array  set to the  Word length to Guess 
            HdenWord = new char[wrdToGus.Length];

            // Make every letter of the word to _ 
            for (int i = 0; i < HdenWord.Length; i++)
            {
                HdenWord[i] = '_';
                // seprate each word with blank space 
                txtWrdToGuess.Text = string.Join(" ", HdenWord);
            }

        }


        private void LoadWords()
        {

            // file open
            Stream myStream = Assets.Open("HangmanDic.txt");
            using (StreamReader sr = new StreamReader(myStream))
            {

                string line;
                // if there will not be null in the line to read, it can contain char
                while ((line = sr.ReadLine()) != null)
                { // Add  line to the wordlist
                    wordList.Add(line);
                }
            }
        }



        // This switch statement for guesses has left the player
        //All 7 to 0 display each different images and calls the "GuessedWrongText" method.
        private void GuessFailed()
        {
            switch (GusLeft)
            {
                case 7:

                    imgHngman.SetImageResource(Resource.Drawable.GuessFailed1);

                    break;
                case 6:
                    imgHngman.SetImageResource(Resource.Drawable.GuessFailed2);

                    break;
                case 5:
                    imgHngman.SetImageResource(Resource.Drawable.GuessFailed3);
                    break;

                case 4:
                    imgHngman.SetImageResource(Resource.Drawable.GuessFailed4);

                    break;

                case 3:
                    imgHngman.SetImageResource(Resource.Drawable.GuessFailed5);

                    break;

                case 2:
                    imgHngman.SetImageResource(Resource.Drawable.GuessFailed6);

                    break;

                case 1:
                    imgHngman.SetImageResource(Resource.Drawable.GuessFailed7);

                    break;

                // Case 0 no guess left, player has lost the game.  
                case 0:
                    imgHngman.SetImageResource(Resource.Drawable.GuessFailed8);

                    // For losing the game, the player incurs a 12 point penalty to their score. If it puts their score below 0, it will be set to 0
                    score = score - 12;
                    if (score < 0)
                    {
                        score = 0;
                    }
                    System.Threading.Thread.Sleep(200);
                    Toast.MakeText(this, " You LOSE. Your Score was " + score, ToastLength.Short).Show();
                    var cc = new MyConnection();
                    cc.UpdateScore(Id, PlyerName, score);
                    System.Threading.Thread.Sleep(500);


                    StartActivity(typeof(MainActivity));
                    break;

            }
        }

        // Scoring
        private void LetterScore()
        {


            // The score is increased by 4 if these option are correct
            switch (letter)
            {
                case "A":
                case "E":
                case "I":
                case "O":
                case "U":
                case "L":
                case "N":
                case "R":
                case "S":
                case "T":
                    score = score + 4;
                    // Letters increase the score by 5,6,8,10
                    break;
                case "D":
                case "G":
                case "B":
                case "C":
                case "M":
                case "P":
                    score = score + 5;

                    break;
                case "F":
                case "H":
                case "W":
                case "Y":
                case "V":
                    score = score + 6;

                    break;
                case "K":
                case "J":
                case "X":
                    score = score + 8;

                    break;
                case "Q":
                case "Z":
                    score = score + 10;

                    break;
            }



        }


        // Button enabled if the game is won by player
        private void ButtonEnable()
        {
            btn_A.Enabled = true;
            btn_B.Enabled = true;
            btn_C.Enabled = true;
            btn_D.Enabled = true;
            btn_E.Enabled = true;
            btn_F.Enabled = true;
            btn_G.Enabled = true;
            btn_H.Enabled = true;
            btn_I.Enabled = true;
            btn_J.Enabled = true;
            btn_K.Enabled = true;
            btn_L.Enabled = true;
            btn_M.Enabled = true;
            btn_N.Enabled = true;
            btn_O.Enabled = true;
            btn_P.Enabled = true;
            btn_Q.Enabled = true;
            btn_R.Enabled = true;
            btn_S.Enabled = true;
            btn_T.Enabled = true;
            btn_U.Enabled = true;
            btn_V.Enabled = true;
            btn_W.Enabled = true;
            btn_X.Enabled = true;
            btn_Y.Enabled = true;
            btn_Z.Enabled = true;
            btnNewGame.Enabled = true;
        }
        // disables buttons for not clicking.
        private void All_Disable_Buttons()
        {
            btn_A.Enabled = false;
            btn_B.Enabled = false;
            btn_C.Enabled = false;
            btn_D.Enabled = false;
            btn_E.Enabled = false;
            btn_F.Enabled = false;
            btn_G.Enabled = false;
            btn_H.Enabled = false;
            btn_I.Enabled = false;
            btn_J.Enabled = false;
            btn_K.Enabled = false;
            btn_L.Enabled = false;
            btn_M.Enabled = false;
            btn_N.Enabled = false;
            btn_O.Enabled = false;
            btn_P.Enabled = false;
            btn_Q.Enabled = false;
            btn_R.Enabled = false;
            btn_S.Enabled = false;
            btn_T.Enabled = false;
            btn_U.Enabled = false;
            btn_V.Enabled = false;
            btn_W.Enabled = false;
            btn_X.Enabled = false;
            btn_Y.Enabled = false;
            btn_Z.Enabled = false;

        }


        private void GameWon()
        {

            // default image
            Load_blank_Image();
            // Show text
            Toast.MakeText(this, "Correct Word Guessed", ToastLength.Short).
            Show();
            var cc = new MyConnection();
            cc.UpdateScore(Id, PlyerName, score);
            // And load a new random word from HandDic.text file
            LoadNewRandomWord();

        }


        // If player guess worg this method tells him option left 
        private void GusdWrngTxtUpdte()
        {
            txtGusLeft.Text = GusLeft.ToString();
        }



        private void ScoreUpdate()
        {
            txtCrentScore.Text = score.ToString();
        }


        private void Load_blank_Image()
        {

            imgHngman.SetImageResource(Resource.Drawable.blankscreen);
        }


    }
}














using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

    private static Highscores highscores;
    public Text score1;
    public Text questions1;
    public Text date1; 

    public Text score2;
    public Text questions2;
    public Text date2;

    public Text score3;
    public Text questions3;
    public Text date3;

    public Text score4;
    public Text questions4;
    public Text date4;

    public void Start(){
        loadScores();
        printScores();
    }

    public static void loadScores(){

        highscores = new Highscores();

        if (PlayerPrefs.HasKey("highScore1")){
            highscores.highScore1 = PlayerPrefs.GetInt("highScore1");
        }
        if (PlayerPrefs.HasKey("numberOfQuestionsAnswered1")){
            highscores.numberOfQuestionsAnswered1 = PlayerPrefs.GetInt("numberOfQuestionsAnswered1");
        }
        if (PlayerPrefs.HasKey("date1")){
            highscores.date1 = PlayerPrefs.GetString("date1");
        }


        if (PlayerPrefs.HasKey("highScore2")){
            highscores.highScore2 = PlayerPrefs.GetInt("highScore2");
        }
        if (PlayerPrefs.HasKey("numberOfQuestionsAnswered2")){
            highscores.numberOfQuestionsAnswered2 = PlayerPrefs.GetInt("numberOfQuestionsAnswered2");
        }
        if (PlayerPrefs.HasKey("date2")){
            highscores.date2 = PlayerPrefs.GetString("date2");
        }


        if (PlayerPrefs.HasKey("highScore3")){
            highscores.highScore3 = PlayerPrefs.GetInt("highScore3");
        }
        if (PlayerPrefs.HasKey("numberOfQuestionsAnswered3")){
            highscores.numberOfQuestionsAnswered3 = PlayerPrefs.GetInt("numberOfQuestionsAnswered3");
        }
        if (PlayerPrefs.HasKey("date3")){
            highscores.date3 = PlayerPrefs.GetString("date3");
        }


        if (PlayerPrefs.HasKey("highScore4")){
            highscores.highScore4 = PlayerPrefs.GetInt("highScore4");
        }
        if (PlayerPrefs.HasKey("numberOfQuestionsAnswered4")){
            highscores.numberOfQuestionsAnswered4 = PlayerPrefs.GetInt("numberOfQuestionsAnswered4");
        }
        if (PlayerPrefs.HasKey("date4")){
            highscores.date4 = PlayerPrefs.GetString("date4");
        }
    }

    public static void saveScores(){
        PlayerPrefs.SetInt("highScore1", highscores.highScore1);
        PlayerPrefs.SetInt("numberOfQuestionsAnswered1", highscores.numberOfQuestionsAnswered1);
        PlayerPrefs.SetString("date1", highscores.date1);

        PlayerPrefs.SetInt("highScore2", highscores.highScore2);
        PlayerPrefs.SetInt("numberOfQuestionsAnswered2", highscores.numberOfQuestionsAnswered2);
        PlayerPrefs.SetString("date2", highscores.date2);

        PlayerPrefs.SetInt("highScore3", highscores.highScore3);
        PlayerPrefs.SetInt("numberOfQuestionsAnswered3", highscores.numberOfQuestionsAnswered3);
        PlayerPrefs.SetString("date3", highscores.date3);

        PlayerPrefs.SetInt("highScore4", highscores.highScore4);
        PlayerPrefs.SetInt("numberOfQuestionsAnswered4", highscores.numberOfQuestionsAnswered4);
        PlayerPrefs.SetString("date4", highscores.date4);
    }

    public static void submitScore(int newScore, int questions, DateTime ddate) {
        Scores.loadScores();
        string date = "" + ddate;
        if (newScore > highscores.highScore1){

            highscores.highScore4 = highscores.highScore3;
            highscores.numberOfQuestionsAnswered4 = highscores.numberOfQuestionsAnswered3;
            highscores.date4 = highscores.date3;

            highscores.highScore3 = highscores.highScore2;
            highscores.numberOfQuestionsAnswered3 = highscores.numberOfQuestionsAnswered2;
            highscores.date3 = highscores.date2;

            highscores.highScore2 = highscores.highScore1;
            highscores.numberOfQuestionsAnswered2 = highscores.numberOfQuestionsAnswered1;
            highscores.date2 = highscores.date1;

            highscores.highScore1 = newScore;
            highscores.numberOfQuestionsAnswered1 = questions;
            highscores.date1 = date;

        } else if ((newScore <= highscores.highScore1) && (newScore > highscores.highScore2)){
            highscores.highScore4 = highscores.highScore3;
            highscores.numberOfQuestionsAnswered4 = highscores.numberOfQuestionsAnswered3;
            highscores.date4 = highscores.date3;

            highscores.highScore3 = highscores.highScore2;
            highscores.numberOfQuestionsAnswered3 = highscores.numberOfQuestionsAnswered2;
            highscores.date3 = highscores.date2;

            highscores.highScore2 = newScore;
            highscores.numberOfQuestionsAnswered2 = questions;
            highscores.date2 = date;

        } else if ((newScore <= highscores.highScore2) && (newScore > highscores.highScore3)){

            highscores.highScore4 = highscores.highScore3;
            highscores.numberOfQuestionsAnswered4 = highscores.numberOfQuestionsAnswered3;
            highscores.date4 = highscores.date3;

            highscores.highScore3 = newScore;
            highscores.numberOfQuestionsAnswered3 = questions;
            highscores.date3 = date;

        } else if((newScore <= highscores.highScore3) && (newScore > highscores.highScore4)){

            highscores.highScore4 = newScore;
            highscores.numberOfQuestionsAnswered4 = questions;
            highscores.date4 = date;
        }
        saveScores();
    }

    public void printScores(){
        score1.text = "1. Score " + highscores.highScore1;
        questions1.text = "" + highscores.numberOfQuestionsAnswered1 + " questions";
        date1.text = "On " + highscores.date1;

        score2.text = "2. Score " + highscores.highScore2;
        questions2.text = "" + highscores.numberOfQuestionsAnswered2 + " questions";
        date2.text = "On " + highscores.date2;

        score3.text = "3. Score " + highscores.highScore3;
        questions3.text = "" + highscores.numberOfQuestionsAnswered3 + " questions";
        date3.text = "On " + highscores.date3;

        score4.text = "4. Score " + highscores.highScore4;
        questions4.text = "" + highscores.numberOfQuestionsAnswered4 + " questions";
        date4.text = "On " + highscores.date4;
    }
}

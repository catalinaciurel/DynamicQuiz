using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System;

public class GameManager : MonoBehaviour {

    private string questionsFilePath= "Resources/Questions.txt";
    private List<int> usedQuestions = new List<int>();

    public Text questionLabel;
    private static string question;

    public Text answerALabel, answerBLabel, answerCLabel, answerDLabel;
    private static string answerA, answerB, answerC, answerD;
    private static string correctAnswer;
    private static string selectedAnswer;
    private static string numberOfQuestionInFile;

    public RawImage life1, life2, life3;
    private int lifes;
    private Texture redTxt = null;
    private Texture greenTxt = null;

    public Text timeLabel;
	private float time;

	public Text scoreLabel;
    private int score;
    private int numberOfQuestionsAnswered;

    private static Boolean hasAnswered;

    public GameObject sphere;
    public Transform spherePos;
    GameObject mySphere=null;

    // Use this for initialization
    void Start () {
        score = 0;
        numberOfQuestionsAnswered = 0;
        lifes = 3;
        play();
		timeLabel.text = "Time: " + time;
		scoreLabel.text = "Score: " + score;
        redTxt = Resources.Load("LastLife", typeof(Texture2D)) as Texture;
        greenTxt = Resources.Load("Life", typeof(Texture2D)) as Texture;
    }
	
	// Update is called once per frame
	void Update () {

		if(time>=0){
            time = time-Time.deltaTime;
		    timeLabel.text = "Time: "+ (int)time;
		    scoreLabel.text = "Score: " + score;

            if (hasAnswered) {
                if (selectedAnswer.Equals(correctAnswer)) {
                    score = score + (((int)time) * 10);
                    numberOfQuestionsAnswered++;
                    play();
                }
                else {
                    if (lifes > 1){
                        lifes -= 1;
                        switch (lifes){
                            case 2: life3.enabled = false;
                                break;
                            case 1: life2.enabled = false;
                                life1.texture = redTxt;
                                break;
                        }
                        play();
                    }
                    else{
                        wrongAnswer();
                    }
                }
            }
        }
        else {
            if (lifes > 1){
                lifes -= 1;
                switch (lifes){
                    case 2:
                        life3.enabled = false;
                        break;
                    case 1:
                        life2.enabled = false;
                        life1.texture = redTxt;
                        break;
                }
                Destroy(mySphere);
                play();
            }
            else{
                timeExpired();
            }
        }
	}

    public void play(){
        readQuestion("" + getQuestion());
        setQuestionAndAnswers();
        time = 15f;
        hasAnswered = false;
        mySphere = Instantiate(sphere, spherePos.position, spherePos.rotation);
    } 

    public void setQuestionAndAnswers(){
        questionLabel.text = "" + question;
        answerALabel.text = "A." + answerA;
        answerBLabel.text = "B." + answerB;
        answerCLabel.text = "C." + answerC;
        answerDLabel.text = "D." + answerD;
    }

    public int getQuestion(){
        int val = UnityEngine.Random.Range(1,30);

        while(usedQuestions.Contains(val)){
         val = UnityEngine.Random.Range(1, 30);
        }
        usedQuestions.Add(val);

        return val;
    }

	public void timeExpired(){
        Scores.submitScore(score, numberOfQuestionsAnswered, DateTime.Now);
        Gameover.setMessage("Ups...Game Over!\r\n Timeout");
        SceneLoader.gameOver();
        life1.texture = greenTxt;
    }

    public void wrongAnswer(){
        Scores.submitScore(score, numberOfQuestionsAnswered, DateTime.Now);
        Gameover.setMessage("Ups...Game Over!\r\n Wrong Answer");
        SceneLoader.gameOver();
        life1.texture = greenTxt;
    }

    public void parseQuestion(string questionLine){
        string[] entries = questionLine.Split(';');
        for (int i = 0; i < entries.Length; i++){
            switch (i){
                case 0: numberOfQuestionInFile = entries[0]; break;
                case 1: question = entries[1]; break;
                case 2: answerA = entries[2]; break;
                case 3: answerB = entries[3]; break;
                case 4: answerC = entries[4]; break;
                case 5: answerD = entries[5]; break;
                case 6: correctAnswer = entries[6].Trim(); break;
            }
        }
    }

    public void readQuestion(string numberOfQuestionInFile){
        try{
            TextAsset ta = Resources.Load("questions") as TextAsset;
            List<string> questions = textAssetToList(ta);
            foreach(string quest in questions){
                if (quest.StartsWith(numberOfQuestionInFile)){
                    parseQuestion(quest);
                }
            }
        }
        catch (Exception e){
            Console.WriteLine("{0}\n", e.Message);
        }
    }

    private List<string> textAssetToList(TextAsset ta){
        var listToReturn = new List<string>();
        var arrayString = ta.text.Split('\n');
        foreach (var line in arrayString){
            listToReturn.Add(line);
        }
        return listToReturn;
    }

    public static void setSelectedAnswer(String answer){
        switch (answer){
            case "A": selectedAnswer = answerA; break;
            case "B": selectedAnswer = answerB; break;
            case "C": selectedAnswer = answerC; break;
            case "D": selectedAnswer = answerD; break;
        }
        hasAnswered = true;
    }
}

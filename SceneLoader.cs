using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	private SceneLoader INSTANCE = null;
    private static string lastScene;
    private static string currentScene;
    private string mainScene = "MainMenu";

    private void Awake(){
        	if (INSTANCE == null){
            		INSTANCE = this;
        	}
        	else{
            		if (INSTANCE != this){
                		Destroy(gameObject);
            		}
        	}
        	DontDestroyOnLoad(gameObject);
    	}

	public void startGame(){
		Debug.Log("Start game");
        lastScene = mainScene;
        currentScene = "Game";
		 SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
	}

    public void showScores(){
        Debug.Log("See high scores");
        lastScene = mainScene;
        currentScene = "Scores";
        SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
    }

    public void goBackToMainMenu(){
        Debug.Log("Back to Main Menu");

        SceneManager.LoadScene(mainScene, LoadSceneMode.Single);
    }

    public void doExit(){
        Debug.Log("Exit game");
        Application.Quit();
    }

    public static void gameOver(){
        Debug.Log("game over");
        lastScene = "Game";
        currentScene = "GameOver";
        SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
    }
}

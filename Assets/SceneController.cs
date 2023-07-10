using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    protected const string GAME_SCENE = "ybotAnimationTesting";
	
    public void startGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool paused;
    public bool levelingUp;

    public GameObject character;
    public Canvas levelUpCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void LevelUpOn()
    {
        levelingUp = true;
        character.GetComponent<PlayerMovement>().canMove = false;
        Time.timeScale = 0;
        levelUpCanvas.gameObject.SetActive(true);
    }

    public void LevelUpOff()
    {
        levelingUp = false;
        levelUpCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        character.GetComponent<PlayerMovement>().canMove = true;
    }
}

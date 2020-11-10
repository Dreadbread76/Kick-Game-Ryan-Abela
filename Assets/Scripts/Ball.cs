using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    #region Variables
    public float ballForceX, ballForceY, ballForcePower;

    public Text powerText;
    public GameObject winScreen, loseScreen;

    Rigidbody2D rigi;

    bool win, lose;
    bool kicked;

    public float timer = 0;
    bool timerOn;
    float loseTime = 5f;

    public Animator anim;
    #endregion
    #region Start
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        ballForceX = 1f;
        ballForceY = 1f;

        win = false;
        lose = false;
        kicked = false;
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        

        
        
    }
    #endregion
    #region Update
    void Update()
    {
        //Power Display
        powerText.text = "Power: " + ballForcePower;
        
        //Kicking 
        if (!kicked)
        {
            if (!(win || lose))
            {
                
                if (Input.GetKey(KeyCode.Space))
                {
                    ballForcePower++;
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    //Animate Kick
                    anim.SetTrigger("Kick");
                    //Set Lose timer
                    timerOn=true;
                    kicked = true;
                    rigi.AddForce(new Vector2(ballForceX * ballForcePower, ballForceY * ballForcePower));
                }
                
            }
        }
        //Lose timer
        if (timerOn == true && !win)
        {
            timer += Time.deltaTime;
        }
        if (timer >= loseTime)
        {
            lose = true;
            WinOrLose();
        }
        //Restart on R
        if (Input.GetKeyDown(KeyCode.R))
        {
     
            Restart();
        }

        //Main Menu on Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }



    }
    #endregion
    #region Triggers
    //Win when in goal and lose when hit goalie or boundaries
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            win = true;
            WinOrLose();
        }
        if (other.gameObject.CompareTag("Boundaries"))
        {
            lose = true;
            WinOrLose();

        }
    }
    #endregion
    #region Restart
    //Reload scene
    void Restart()
    {
      
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    #endregion
    #region Win/Lose
    //Win/Lose Screens
    public void WinOrLose()
    {
        Time.timeScale = 0;
        if (win)
        {
            winScreen.SetActive(true);

        }
        else if (lose)
        {
            loseScreen.SetActive(true);
        }
        
    }
    #endregion
}

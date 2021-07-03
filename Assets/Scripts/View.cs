using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public States GameState;
    public GameObject DeadScreen, StartScreen;
    public GameManager managerGame;


    //we have 3 game states to manage. 
    public enum States
    {
        Waiting,
        Playing,
        Death
    }

    //set game state to waiting
    private void Start()
    {
        GameState = States.Waiting;
    }

    //get the click and change state to palying
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && GameState == States.Waiting)
        {
            GameState = States.Playing;
        }
    }


    //for jumping the bird when you get a click
    public void BirdJump(float velocity)
    {
        DeadScreen.SetActive(false);
        StartScreen.SetActive(false);
        rb2D.gravityScale = 1;
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = Vector2.up * velocity;
        }
    }


    //to set birds waiting position
    public void BirdWaiting(Vector3 BirdStartingPosition)
    {
        DeadScreen.SetActive(false);
        StartScreen.SetActive(true);
        rb2D.transform.position = BirdStartingPosition;
        rb2D.gravityScale = 0;
    }


    //thi is for mobing and spawning the pipes. hight is for spawn pipes in diffrent heights everytime they spawn. 
    public void PipeMove(Transform Pipes, Vector3[] PipesStartingPosition, float height)
    {
        height = Random.Range(-0.3f, 0.3f);
        Debug.Log(PipesStartingPosition[0].x);
        for(int i = 0; i < Pipes.childCount; i++)
        {
            Pipes.GetChild(i).position -= Pipes.right * Time.deltaTime;
            if(Pipes.GetChild(i).position.x <= -PipesStartingPosition[0].x)
            {
                Pipes.GetChild(i).position = PipesStartingPosition[0] + new Vector3(0, height, 0);
            }
        }
    }

    //when  you are dead show the DeadScreen
    public void GameOver()
    {
        DeadScreen.SetActive(true);
        StartScreen.SetActive(false);
    }


    //when game detact collicion change game state to death
    public void OnCollisionEnter2D(Collision2D collider)
    {
        GameState = States.Death;
    }


    //this assign to play button for change game state to waiting
    public void PlayAgain()
    {
        GameState = States.Waiting;
    }

    //we did this because we need starting positions of the pipes at very start to spawn them again according to their spawn position * height
    public void PipesStartingPosition(Transform Pipes, Vector3[] PipesStartingPosition)
    {
        for(int i=0; i<Pipes.childCount; i++)
        {
            Pipes.GetChild(i).position = PipesStartingPosition[i];
        }
    }


    //to set pipes waiting at their starting position until game starts 
    public void PipesWaiting(Transform Pipes, Vector3[] PipesStartingPosition)
    {
        for (int i=0; i<Pipes.childCount; i++)
        {
            PipesStartingPosition[i] = Pipes.GetChild(i).position;
        }
    }

    //to detact trigger event between up and down pipes and call update score function if you trigger them and update score.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ScoreArea")
        {
            managerGame.UpdateScore();
        }
    }
}

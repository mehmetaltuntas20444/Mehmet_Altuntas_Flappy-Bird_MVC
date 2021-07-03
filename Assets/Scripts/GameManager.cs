using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//There are some bugs in the game and i wanted to write them :) First one is if you played and get score after you die i couldn't show 0 in the beginning but when you start again actually the score is 0 and after you pass the first pipe it will start 1 again i just can't show 0
//Second one is not a bug but i think that my score increaser is not MVC but it works :D 
public class GameManager : MonoBehaviour
{
    public Model model;
    public View view;
    public Controller controller;
    public Text ScoreText;

    private void Start()
    {
        model = new Model();
        controller = new Controller(model, view);
    }
    private void Update()
    {
        controller.Unite();
    }
    public void UpdateScore()
    {
        model.score++;
        ScoreText.text = model.score.ToString();
    }
}

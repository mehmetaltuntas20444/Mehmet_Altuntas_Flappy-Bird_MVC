using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    public View view;
    public Model model;

    public Controller(Model model, View view)
    {
        this.model = model;
        this.view = view;
    }

    public void Unite()
    {
        //when you are playing call this functions
        if(view.GameState == View.States.Playing)
        {
            view.BirdJump(model.Velocity);
            view.PipeMove(model.Pipes.transform, model.PipesStartingPosition, model.height);
        }

        //when you are waiting call this functions
        else if(view.GameState == View.States.Waiting)
        {
            view.BirdWaiting(model.BirdStartingPosition);
            view.PipesWaiting(model.Pipes.transform, model.PipesStartingPosition);
            model.score = 0;
        }

        //when you are dead call this functions
        else if (view.GameState == View.States.Death)
        {
            view.PipesStartingPosition(model.Pipes.transform, model.PipesStartingPosition);
            view.GameOver();
            model.score = 0;
        }
    }
}

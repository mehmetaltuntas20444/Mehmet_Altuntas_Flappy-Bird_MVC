using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//for declaration
public class Model
{
    public float Velocity = 2;
    public float Speed = 1f;
    public Vector3 BirdStartingPosition;
    public GameObject Pipes = GameObject.Find("Pipes");
    public Vector3[] PipesStartingPosition = new Vector3[10];
    public float height;
    public int score = 0;

}

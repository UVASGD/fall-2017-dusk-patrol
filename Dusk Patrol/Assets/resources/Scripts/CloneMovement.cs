using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMovement : MonoBehaviour
{

    public TimeManager tm;
    public Stack<Vector2> path;
    public PlayerMovement pl;

    // Use this for initialization
    void Start()
    {
        path = new Stack<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveClone();
        
    }

    void MoveClone()
    {
        if (path.Count != 0)
        {
            gameObject.transform.position = path.Pop();
        }
        Debug.Log("does it get here");
    }

    public void TakeStack(Stack<Vector2> input)
    {
        path = input;
    }
}

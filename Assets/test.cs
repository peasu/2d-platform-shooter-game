using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public movement move;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            move.losehealth(10);
        }
    }
}

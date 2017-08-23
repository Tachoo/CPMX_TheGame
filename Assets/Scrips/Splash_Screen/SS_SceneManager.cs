using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_SceneManager : MonoBehaviour {

    // Use this for initialization
    SS_InterpolateColors test;  
    private void Awake()
    {
        test = FindObjectOfType<SS_InterpolateColors>().GetComponent<SS_InterpolateColors>();
        FadeDown();
    }
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (test.Done==true)
        {
            //Sabemos que termino y debemos de probarlo con el debug
            Debug.Log(test.Done);
            //Podemos hacer algo 
            FadeUp();
        }	
	}

    #region FadeDown
    private void FadeDown()
    {
        test.IsReverse = false;
        test.Done = false;
        test.speed = 0.7f;
    }
    #endregion
    #region FadeUp
    private void FadeUp()
    {
        test.IsReverse = true;
        test.Done = false;
        test.speed = 0.7f;
    }
    #endregion

}

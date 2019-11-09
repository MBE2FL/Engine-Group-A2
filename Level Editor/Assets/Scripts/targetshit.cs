using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetshit : MonoBehaviour
{
    GameObject _target1;
    GameObject _target2;
    tutorialWall obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = new tutorialWall();
        _target1 = GameObject.FindGameObjectWithTag("Target1");
        _target2 = GameObject.FindGameObjectWithTag("Target2");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!_target1.activeInHierarchy && !_target2.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        obj.Update();
    }
}

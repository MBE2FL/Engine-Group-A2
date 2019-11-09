using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBunny : MonoBehaviour
{
    tutorialDone obj;
    GameObject Bunny;
    // Start is called before the first frame update
    void Start()
    {
        obj = new tutorialDone();
        Bunny = GameObject.FindGameObjectWithTag("TBunny");
    }

    // Update is called once per frame
    void Update()
    {
        if(!Bunny.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        obj.Update();
    }
}

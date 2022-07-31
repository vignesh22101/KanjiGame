using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learnippet_popup : MonoBehaviour
{
    // Start is called before the first frame update
   public bool popup = false;
    public GameObject learnippet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        open_learnippet();
    }

    public void open_learnippet()
    {
        if (popup)
        {
            learnippet.SetActive(true);
        }
        else
        {
            //to check whether it is active to make sure we don't disable the object which is already
            if (learnippet.activeInHierarchy)
                learnippet.SetActive(false);
        }
    }
}

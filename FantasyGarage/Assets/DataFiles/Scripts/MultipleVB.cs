using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MultipleVB : MonoBehaviour
{

    
    public GameObject[] objects;
    public VirtualButtonBehaviour[] vrb;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {

        audioData = GetComponent<AudioSource>();

        if (objects == null)

        {

            objects = GameObject.FindGameObjectsWithTag("car");

        }

        objects[0].SetActive(true);

        for (int i = 1; i < objects.Length; i++)
        {
            objects[i].SetActive(false);

        }

        vrb = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < vrb.Length; i++)
        {

            vrb[i].RegisterOnButtonPressed(onButtonPressed);
            vrb[i].RegisterOnButtonReleased(onButtonReleased);

        }

    }


    public void onButtonPressed(VirtualButtonBehaviour vb)
    {

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].name.ToString() == vb.VirtualButtonName)
            {

                objects[i].SetActive(true);
                audioData.Play();

            }
            else
            {

                objects[i].SetActive(false);

            } 



        }

    }

    public void onButtonReleased(VirtualButtonBehaviour vb)
    {



    }

}



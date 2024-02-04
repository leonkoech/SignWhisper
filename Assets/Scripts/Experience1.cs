using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience1 : MonoBehaviour
{
 
    [SerializeField]
    public GameObject redDoor;
    public GameObject blueDoor;


    public GameObject wrongPanel;

    public float displayDelay = 3f;

    void Start()
    {
        // Invoke the DisplayObject method after the specified delay
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeInvisible(string animal){
        if(animal == "crocodile"){
            redDoor.SetActive(false);
        }
        else if(animal == "fish"){
            blueDoor.SetActive(false);
        }
        else{
            wrongInput();
        }

    }

    void wrongInput(){
         Invoke("DisplayObject", displayDelay);
    }

    
    void DisplayObject()
    {
        // Set the target object to be active (visible)
        if (wrongPanel != null)
        {
            wrongPanel.SetActive(true);

            // Invoke the HideObject method after another delay
            Invoke("HideObject", displayDelay);
        }
    }

    void HideObject()
    {
        // Set the target object to be inactive (hidden)
        if (wrongPanel != null)
        {
            wrongPanel.SetActive(false);
        }
    }
}

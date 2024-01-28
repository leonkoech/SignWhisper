using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public TMPro.TMP_Text multiplayer_explanation_speaker;
    [SerializeField]
    public TMPro.TMP_Text multiplayer_explanation_builder;
    [SerializeField]
    public GameObject speaker_dashboard;
    [SerializeField]
    public GameObject builder_dashboard;

    [SerializeField]
    private AssignLeap userType;
    void Start()
    {
        // if(userType.is_speaker){
        //     speaker_dashboard.SetActive(false);
        //     builder_dashboard.SetActive(false);
        //     multiplayer_explanation.text = "Hello Speaker :)";
        // }
        // else{
        //     multiplayer_explanation.text = "In this scene you try to understand the builder to perform a task. The builder will only communicate in sign language";
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

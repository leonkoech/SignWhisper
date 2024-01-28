using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public GameObject myXRRig;
    public Transform myXRCam;


    [SerializeField]
    private int speaker_step = 0;
    private int builder_step = 0;

    private List<string> speaker_guide = new List<string>{"step one", "step two", "step three"};
    private List<string> builder_guide = new List<string>{"step one", "step two", "step three"};

    public TMPro.TMP_Text speaker_step_button;
    public TMPro.TMP_Text builder_step_button;
[SerializeField]
    private GameObject leapPosition;
    // [SerializeField]
    // public  GameObject myXRRig;
    // public Transform myXRCam;
    void Start()
    {
        if(userType.is_speaker){
            speaker_dashboard.SetActive(true);
            builder_dashboard.SetActive(false);
            multiplayer_explanation_speaker.text = speaker_guide[speaker_step];
             // this is scene specific 
        if(userType.is_speaker){
            Vector3 initialSpeakerPosition = new Vector3(0f,0f,2.4f);
            Quaternion initialSpeakerRotation = Quaternion.Euler(0f, 180f, 0f); // Rotation of (90, 0, 0)

            myXRRig.transform.position = initialSpeakerPosition;
            myXRRig.transform.rotation = initialSpeakerRotation;

            //leapPosition.transform.position = initialSpeakerPosition;
            //leapPosition.transform.rotation = initialSpeakerRotation;
             // Rotation of (90, 0, 0)

            // myXRCam.position = initialSpeakerPosition;
            // myXRCam.rotation = initialSpeakerRotation;
        }

        }
        else{
            speaker_dashboard.SetActive(false);
            builder_dashboard.SetActive(true);
            multiplayer_explanation_builder.text = builder_guide[builder_step];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next(){
        if(userType.is_speaker){
            Onboarding(speaker_step,speaker_guide,multiplayer_explanation_speaker,speaker_dashboard,speaker_step_button);
        }
        else{
            Onboarding(builder_step,builder_guide,multiplayer_explanation_builder,builder_dashboard,builder_step_button);
        }
    }
    void Onboarding(int step_number, List<string> steps, TMPro.TMP_Text instructions, GameObject dashboard, TMPro.TMP_Text main_button){
    if(step_number < steps.Count - 1){
                    
                    instructions.text = steps[step_number];
                    step_number ++;
                }
                else{
                    main_button.text = "Start";
                    dashboard.SetActive(false);
                    step_number=0;
                }
        }
}

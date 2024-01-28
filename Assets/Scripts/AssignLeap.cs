
using Leap;
using Leap.Unity;
using Leap.Unity.Encoding;
using Unity.VisualScripting;
using UnityEngine;

public class AssignLeap : PostProcessProvider {

[SerializeField]
public bool is_speaker = false;
[SerializeField]
public LeapProvider builderProvider;
[SerializeField]
public LeapProvider speakerProvider;


 void Start(){
    inputLeapProvider = builderProvider;
    speakerProvider.gameObject.SetActive(false);
    SwapProviders();
 }

 public void SwapProviders(){
    if(is_speaker){
        inputLeapProvider = speakerProvider;
        // builderProvider.gameObject.SetActive(false);
        // speakerProvider.gameObject.SetActive(true);
    } else{
        inputLeapProvider = builderProvider;
        // speakerProvider.gameObject.SetActive(false);
        // builderProvider.gameObject.SetActive(true);
    }
 }

public override void ProcessFrame(ref Frame inputFrame){
    
 }

}
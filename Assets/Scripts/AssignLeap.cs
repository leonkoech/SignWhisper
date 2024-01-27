
using Leap;
using Leap.Unity;
using Leap.Unity.Encoding;
using UnityEngine;

public class AssignLeap : PostProcessProvider {

[SerializeField]
public string type;
[SerializeField]
public LeapProvider builderProvider;
[SerializeField]
public LeapProvider speakerProvider;


 void Start(){
    inputLeapProvider = builderProvider;
 }

 public bool IsSpeaker(){
    return type == "speaker";
 }

 public void SwapProviders(){
    if(IsSpeaker()){
        inputLeapProvider = speakerProvider;
    } else{
        inputLeapProvider = builderProvider;
    }
 }

public override void ProcessFrame(ref Frame inputFrame){
    
 }

}
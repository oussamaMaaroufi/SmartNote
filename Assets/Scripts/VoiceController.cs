using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextSpeech;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour{

    const string LANG_CODE = "en-US";

    [SerializeField]
    Text uiText;

  void Start(){
    Setup(LANG_CODE);

#if UNITY_ANDROID
    
    SpeechToText.instance.onPartialResultsCallback = onPartialSpeechResult;
     
#endif

    SpeechToText.instance.onResultCallback = onFinalSpeechResult;
    TextToSpeech.instance.onStartCallBack = onSpeakStart;
    TextToSpeech.instance.onDoneCallback = onSpeakStop;
    
    CheckPermission();

    }

    void CheckPermission(){
        #if UNITY_ANDROID

   if(!Permission.HasUserAuthorizedPermission(Permission.Microphone)){
       Permission.RequestUserPermission(Permission.Microphone);
   }

        #endif
    }

    #region  Text to Speech
     public void StartSpeaking( ){
         TextToSpeech.instance.StartSpeak(uiText.text);
     }

     public void StopSpeaking(){
         TextToSpeech.instance.StopSpeak();
     }
     void onSpeakStart(){
        
         Debug.Log("Tolking started...");
     }

     void onSpeakStop(){
         Debug.Log("Tolking stopped...");
     }
    #endregion


    #region Speech to Text

    public void StartListening(){
         SpeechToText.instance.StartRecording();
     }
     public void StopListening(){
         SpeechToText.instance.StopRecording();
     }

     void onFinalSpeechResult(string result){
         uiText.text = result;
     }

     void onPartialSpeechResult(string result){
         uiText.text = result;
     }

    #endregion

  void Setup(string code){
    //  TextToSpeech.instance.Setting(code,1,2);
      SpeechToText.instance.Setting(code);
  }
}

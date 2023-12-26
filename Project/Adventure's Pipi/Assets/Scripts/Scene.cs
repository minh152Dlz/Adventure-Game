using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Scene : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D conllision){
    if(conllision.CompareTag("Player")){
        Scenecontroller.instance.NextLevel();

    }}
    
}

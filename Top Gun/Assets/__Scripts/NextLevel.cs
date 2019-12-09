using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
   private int nextSceneLoad;

   private void Start(){
       nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
   }

   private void OnTriggerEnter2D(Collider2D collision )
   {
       SceneManager.LoadScene(nextSceneLoad);
   }
}

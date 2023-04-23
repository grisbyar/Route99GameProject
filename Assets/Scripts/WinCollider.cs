using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCollider : MonoBehaviour
{
    //if player colliders, user wins
    public string winScene = VictoryScreen;

  public void onTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player")){
        SceneManager.LoadScene(winScene);
    }
  }
}

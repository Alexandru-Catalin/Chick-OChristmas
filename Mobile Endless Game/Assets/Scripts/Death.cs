using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject deathMenuUI;
    public GameObject player;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Object")
        {
            player.SetActive(false);
            //ShowInterstitialAd();           
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   public GameObject pauseMenu;

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         Time.timeScale = 0;
         pauseMenu.SetActive(true);
      }
   }

   public void StartGame()
   {
      pauseMenu.SetActive(false);
      Time.timeScale = 1;
   }
}

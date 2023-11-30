using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   public GameObject pausemenu;

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         Time.timeScale = 0;
         pausemenu.SetActive(true);
      }
   }

   public void StartGame()
   {
      pausemenu.SetActive(false);
      Time.timeScale = 1;
   }
}

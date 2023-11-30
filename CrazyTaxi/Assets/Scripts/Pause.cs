using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   public GameObject pausemenu;

   public void PauseMenu()
   {
      Time.timeScale = 0;
      pausemenu.SetActive(true);
   }

   public void StartGame()
   {
      pausemenu.SetActive(false);
      Time.timeScale = 1;
   }
}

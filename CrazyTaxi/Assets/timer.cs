using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
   public Text timer1;
   public float tiempoGlobal;
   public GameObject endScreen;

   private void Start()
   {
      Time.timeScale = 1;
      tiempoGlobal = 60;
   }

   private void Update()
   {
      tiempoGlobal -= Time.deltaTime;
      GetComponent<Text>().text = tiempoGlobal.ToString();

      if (tiempoGlobal <= 0)
      {
         Time.timeScale = 0;
         endScreen.SetActive(true);
      }
   }
}

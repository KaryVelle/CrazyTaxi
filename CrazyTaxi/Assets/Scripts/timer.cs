using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
   public Text timer1;
   public float globalTime;
   public GameObject endScreen;

   private void Start()
   {
      Time.timeScale = 1;
      globalTime = 300;
   }

   private void Update()
   {
      globalTime -= Time.deltaTime;
      GetComponent<Text>().text = globalTime.ToString();

      if (globalTime <= 0)
      {
         GetComponent<Text>().text = "0";
         Time.timeScale = 0;
         endScreen.SetActive(true);
      }
   }
}

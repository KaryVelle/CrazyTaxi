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

   private void Start()
   {
      tiempoGlobal = 60;
   }

   private void Update()
   {
      tiempoGlobal -= Time.deltaTime;
      GetComponent<Text>().text = tiempoGlobal.ToString();
   }
}

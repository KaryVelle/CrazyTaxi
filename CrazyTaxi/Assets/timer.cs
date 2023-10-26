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

   private void Update()
   {
      tiempoGlobal = 60;
      tiempoGlobal -= Time.deltaTime;
      GetComponent<Text>().text = tiempoGlobal.ToString();
   }
}

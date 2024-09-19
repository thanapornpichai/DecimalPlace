using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class DecimalPlaceCalculator : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputX, inputY, inputPlace;
    [SerializeField]
    private TMP_Text result;
    private float x, y;
    private int place, decimalPlace;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void GetInput()
    {
        x = float.Parse(inputX.text);
        y = float.Parse(inputY.text);
        place = int.Parse(inputPlace.text);
    }

    public void ShowResult()
    {
        GetInput();
        if (y != 0)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            decimalPlace = (int)(place % (y - 1));
            stopwatch.Stop();
            UnityEngine.Debug.Log("Time for find number of place from repeat decimal: " + stopwatch.ElapsedMilliseconds + " milliseconds");

            stopwatch.Restart();
            string decimalResult = CalculateDecimalPlace(x, y, decimalPlace);
            stopwatch.Stop();
            UnityEngine.Debug.Log("Time for find decimal place from x/y: " + stopwatch.ElapsedMilliseconds + " milliseconds");

            result.text = "Decimal number from " + place + " place is " + decimalResult;
        }
        else
        {
            result.text = "Can't divide by 0";
        }
    }

    string CalculateDecimalPlace(float x, float y, int place)
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        double result = x / y;
        stopwatch.Stop();
        UnityEngine.Debug.Log("Time for divide x/y: " + stopwatch.ElapsedMilliseconds + " milliseconds");

        stopwatch.Restart();
        string resultString = result.ToString("F" + place);
        stopwatch.Stop();
        UnityEngine.Debug.Log("Time for translate double to string: " + stopwatch.ElapsedMilliseconds + " milliseconds");

        stopwatch.Restart();
        string[] resultArray = resultString.Split('.');
        stopwatch.Stop();
        UnityEngine.Debug.Log("Time for seperate string: " + stopwatch.ElapsedMilliseconds + " milliseconds");

        stopwatch.Restart();
        if (resultArray.Length > 1 && resultArray[1].Length >= place)
        {
            stopwatch.Stop();
            UnityEngine.Debug.Log("Time for go to decimal place: " + stopwatch.ElapsedMilliseconds + " milliseconds");
            return resultArray[1][place - 1].ToString();
        }
        else
        {
            stopwatch.Stop();
            UnityEngine.Debug.Log("Time for go to decimal place: " + stopwatch.ElapsedMilliseconds + " milliseconds");
            return "Don't have enough number for " + place;
        }
    }
}

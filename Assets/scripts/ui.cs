using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    public static bool isChoise = false;

    [SerializeField] private Text modeText;
    [SerializeField] private Text remainedText;

    public static int remainedButton = 20;

    public void onClick()
    {
        isChoise = !isChoise;
    }

    public void onClickNext()
    {
        Choice.step = false;
    }
}

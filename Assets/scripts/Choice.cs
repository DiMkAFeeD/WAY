using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    [SerializeField] private Text Title;

    private int ChoiceN = -1;

    public static bool isLose = false;
    public static bool isWin = false;

    public static bool step = true;

    private ColorBlock setColor(Color color){
        ColorBlock cb = new ColorBlock();
        cb.normalColor = color;
        cb.selectedColor = color;
        cb.disabledColor = color;
        cb.pressedColor = color;
        cb.highlightedColor = color;
        cb.colorMultiplier = 1;
        return cb;
    }

    public void onClick(Button clickedButton)
    {
        if (isWin || isLose || !step) return;

        if (ChoiceN == -1)
        {
            string buttonName = clickedButton.gameObject.name;
            if (int.TryParse(buttonName, out int result))
            {
                ChoiceN = result;
                Debug.Log($"User choice {result}");
            }
        }
        else
        {
            string buttonName = clickedButton.gameObject.name;
            if (int.TryParse(buttonName, out int result))
            {

                if (ChoiceN == result)
                {
                    if (!ui.isChoise)
                    {
                        clickedButton.colors = setColor(Color.red);
                        isLose = true;
                    }
                    else
                    {
                        clickedButton.colors = setColor(Color.green);
                        isWin = true;
                    }
                }
                else
                {
                    if (!ui.isChoise)
                    {

                        clickedButton.colors = setColor(Color.green);
                    }
                    else
                    {
                        clickedButton.colors = setColor(Color.red);
                        isLose = true;
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (ChoiceN > -1)
        {
            Title.text = $"������� ���� �������������. �� ������ {ChoiceN+1}";
            
        } else Title.text = "������ ��� �� ������";

        if (isLose) Title.text = "�� ��������";
        if (isWin) Title.text = "�� �������";

        if (isLose || isWin) step = false;

        if (Input.GetKey(KeyCode.S)) step = true; // DEBUG
    }
}

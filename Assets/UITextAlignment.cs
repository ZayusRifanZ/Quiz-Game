using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextAlignment : MonoBehaviour
{
    Text m_Text;

    void Start()
    {
        //Fetch the Text Component
        m_Text = GetComponent<Text>();
        //Switch the Text alignment to the middle
        m_Text.alignment = TextAnchor.MiddleCenter;
    }

    void OnGUI()
    {
        //Press this Button to change the Text alignment to the lower right
        if (GUI.Button(new Rect(0, 0, 100, 40), "Lower Right"))
        {
            m_Text.alignment = TextAnchor.LowerRight;
        }

        //Press this Button to change the Text alignment to the upper left
        if (GUI.Button(new Rect(150, 0, 100, 40), "Upper Left"))
        {
            m_Text.alignment = TextAnchor.UpperLeft;
        }
    }
}

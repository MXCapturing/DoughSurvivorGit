using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpText : MonoBehaviour
{
    public Text expBox;
    // Update is called once per frame
    void Update()
    {
        expBox.text = Character.instance.Exp.Value.ToString();
    }
}

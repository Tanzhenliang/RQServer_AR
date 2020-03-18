using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    private GameObject RQ750;
    private bool ShowOutPart = true;
    // Start is called before the first frame update
    void Start()
    {
        RQ750 = GameObject.Find("RQ750");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///显示外观；
    public void showAndHideOutPart() {
        if (ShowOutPart)
        {
            if (RQ750)
            {
                RQ750.transform.Find("jixiangke").gameObject.SetActive(false);
            }
            transform.GetComponentInChildren<Text>().text = "显示外部";
        }
        else {
            if (RQ750)
            {
                RQ750.transform.Find("jixiangke").gameObject.SetActive(true);
            }
            transform.GetComponentInChildren<Text>().text = "显示内部";

        }
        ShowOutPart = !ShowOutPart;


    }
}

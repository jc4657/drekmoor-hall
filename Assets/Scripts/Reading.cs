using System;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem;

public class Reading : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool bookOne;

    private bool bookTwo;

    private bool bookThree;
    private bool active;
    public GameObject bookOneUI;
    public GameObject readingRN;
    void Start()
    {
        bookOne = false;
        bookTwo = false;
        bookThree = false;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
            if (bookOne)
            {
                bookOneUI.SetActive(active);
                readingRN.SetActive(active);
                active = !active;
            }
    }

    public void setBookOneTrue()
    {
        bookOne = true;
    }

    public void setBookTwoTrue()
    {
        bookTwo = true;
    }

    public void setBookThreeTrue()
    {
        bookThree = true;
    }
}

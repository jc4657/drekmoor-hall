using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
//using System.Numerics;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject enemy;
    public GameObject dangerUI;

    public GameObject bookOne;
    public GameObject bookTwo;
    public GameObject bookThree;
    public Image image;

    public GameObject WinPad;

    public GameObject hallucinationOne;
    public GameObject hallucinationTwo;
    private int choice;
    private float timer;
    private GameObject hall;
    void Start()
    {
        timer = 1500.0f;
        image = GetComponent<Image>();
        choice = Random.Range(1, 3);
        hall = null;
    }

    // Update is called once per frame
    void Update()
    {


        if (timer > 0)
        {
            timer--;
        }
        else if (timer <= 0 && timer > -30)
        {
            timer--;

            if (choice <= 1)
            {
                hall = hallucinationOne;
            }
            else
            {
                hall = hallucinationTwo;
            }
            hall.SetActive(true);
        }
        else
        {
            //Debug.Log("We're here");
            hall.SetActive(false);
            hallucinationOne.SetActive(false);
            hallucinationTwo.SetActive(false);
            choice = Random.Range(1, 3);
            timer = Random.Range(1500.0f, 12000.0f);
        }

        Vector3 pos = enemy.transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 bookOnePos = bookOne.transform.position;
        Vector3 bookTwoPos = bookTwo.transform.position;
        Vector3 bookThreePos = bookThree.transform.position;
        Vector3 winPos = WinPad.transform.position;
        if ((pos - playerPos).magnitude <= 10)
        {
            dangerUI.SetActive(true);
        }
        else
        {
            dangerUI.SetActive(false);
        }

        if ((playerPos - winPos).magnitude <= 3)
        {
            Debug.Log("We WON");
            MySceneManager.LoadWin();
        }

        if (bookThree != null)
        { 
        if ((playerPos - bookThreePos).magnitude <= 5)
        {
            Debug.Log("We reach here");
            if (Keyboard.current.zKey.wasPressedThisFrame)
            {
                //Destroy(bookThree);
                bookThree.SetActive(false);
                Debug.Log("This is working");
                //bookThree = null;
                player.GetComponent<Reading>().setBookThreeTrue();
            }

        }
    }
        if (bookTwo != null)
        {
            if ((playerPos - bookTwoPos).magnitude <= 5)
            {
                Debug.Log("We reach here");
                if (Keyboard.current.zKey.wasPressedThisFrame)
                {
                    //Destroy(bookTwo);
                    bookTwo.SetActive(false);
                    Debug.Log("This is working");
                    //bookTwo = null;
                    player.GetComponent<Reading>().setBookTwoTrue();
                }

            }
        }
        if (bookOne != null)
        {
            if ((playerPos - bookOnePos).magnitude <= 5)
            {
                //Debug.Log("We reach here");
                if (Keyboard.current.zKey.wasPressedThisFrame)
                {
                    //Destroy(bookOne);
                    bookOne.SetActive(false);
                    //Debug.Log("This is working");
                    //bookOne = null;
                    player.GetComponent<Reading>().setBookOneTrue();
                }

            }
        }
    }
}

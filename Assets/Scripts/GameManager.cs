using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject enemy;
    public GameObject dangerUI;

    public GameObject bookOne;
    public Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = enemy.transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 bookOnePos = bookOne.transform.position;
        if ((pos - playerPos).magnitude <= 10)
        {
            dangerUI.SetActive(true);
        }
        else
        {
            dangerUI.SetActive(false);
        }

        if ((playerPos - bookOnePos).magnitude <= 5) 
        {
            Debug.Log("We reach here");
            if (Keyboard.current.zKey.wasPressedThisFrame)
            {
                Destroy(bookOne);
                Debug.Log("This is working");
                player.GetComponent<Reading>().setBookOneTrue();
            }
            
        }
    }
}

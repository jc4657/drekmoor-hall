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
            Debug.Log("We're here");
            hall.SetActive(false);
            hallucinationOne.SetActive(false);
            hallucinationTwo.SetActive(false);
            choice = Random.Range(1, 3);
            timer = Random.Range(1500.0f, 3000.0f);
        }
        
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

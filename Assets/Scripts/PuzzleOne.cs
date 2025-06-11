using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PuzzleOne : MonoBehaviour
{
    public GameObject leverOne;
    public GameObject leverTwo;
    public GameObject leverThree;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leverOne.GetComponent<AN_Button>().GetPosition() && (!leverTwo.GetComponent<AN_Button>().GetPosition()) && leverThree.GetComponent<AN_Button>().GetPosition())
        {
            Destroy(gameObject);
        }
    }
}

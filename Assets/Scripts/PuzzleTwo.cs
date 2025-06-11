using UnityEngine;

public class PuzzleTwo : MonoBehaviour
{
    public GameObject leverOne;
    public GameObject leverTwo;
    public GameObject leverThree;
    public GameObject leverFour;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leverOne.GetComponent<AN_Button>().GetPosition() && leverTwo.GetComponent<AN_Button>().GetPosition() && leverThree.GetComponent<AN_Button>().GetPosition() && (!leverFour.GetComponent<AN_Button>().GetPosition()))
        {
            Destroy(gameObject);
        }
    }
}


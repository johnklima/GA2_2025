using UnityEngine;
using UnityEngine.UI;
public class Story : MonoBehaviour
{

    public string[] thestory;
    public int curElement = 0;
    
    public GameObject storyContainer;
    public Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            //need to hide/show as you see fit
            storyContainer.SetActive(true);

            text.text = thestory[curElement];
            curElement++;

            if (curElement >= thestory.Length)
                curElement = 0;
        }
    }
}

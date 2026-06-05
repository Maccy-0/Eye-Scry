using UnityEngine;

public class KeyItems : MonoBehaviour
{
    public int thisKeyItem;

    public PuzzleScenesLogic PuzzleScenesLogic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        PuzzleScenesLogic.readCurrentMessage("Key" + thisKeyItem);
    }
}

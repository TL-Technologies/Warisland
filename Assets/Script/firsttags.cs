using UnityEngine;

public class firsttags : MonoBehaviour
{
    public Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tr.childCount; i++)
        {
            tr.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

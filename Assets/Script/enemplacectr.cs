using UnityEngine;

public class enemplacectr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount<=1)
        {
            Destroy(gameObject);
        }
    }
}

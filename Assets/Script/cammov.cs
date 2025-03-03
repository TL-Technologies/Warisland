using UnityEngine;

public class cammov : MonoBehaviour
{
    Vector3 v;
    float my;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        v = transform.position - FindObjectOfType<PlayerController>().transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(FindObjectOfType<PlayerController>() !=null)
        {
            transform.position = Vector3.Lerp(transform.position, FindObjectOfType<PlayerController>().transform.position + v, speed * Time.deltaTime);
        }
    }
}

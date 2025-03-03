using UnityEngine;

public class goldbug : MonoBehaviour
{
    public Transform grisbug;
    Vector3 v;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        v = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        y = 0.1f * (grisbug.childCount);
        v.y = 0.6f + y;
        transform.localPosition = Vector3.Lerp(transform.localPosition, v, 5 * Time.deltaTime);
    }
}

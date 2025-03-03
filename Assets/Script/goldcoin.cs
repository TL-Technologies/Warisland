using UnityEngine;

public class goldcoin : MonoBehaviour
{
    Vector3 v, r;
    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(0, 0, 0);
        r = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            if (transform.parent.name == "goldbug")
            {
                v.y = transform.GetSiblingIndex() * 0.1f;
                transform.localPosition = Vector3.Lerp(transform.localPosition, v, 5 * Time.deltaTime);
                transform.localRotation = Quaternion.Euler(0, -90, 0);
            }

            if (transform.parent.tag == "tagneeded")
            {
                v = new Vector3(0, 0, 0);
                v.y = transform.GetSiblingIndex() * 0f;
                transform.localPosition = Vector3.Lerp(transform.localPosition, v, 15 * Time.deltaTime);
                transform.localRotation = Quaternion.Euler(-90, 0, 0);
                if (Vector3.Distance(transform.localPosition, v) <= 0.1f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

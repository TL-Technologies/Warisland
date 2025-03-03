using UnityEngine;

public class materailctr : MonoBehaviour
{
    public Vector3 v,offset,c;
    public bool go;
    public Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - tr.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(go && transform.position.z<v.z)
        {
            c = v + offset;
            c.y = transform.position.y;
            c.z = v.z + offset.z + 8;
            transform.position = Vector3.Lerp(transform.position, c, 20 * Time.deltaTime);
        }

        if(v.z>0 && transform.position.z >= v.z - 0.3f)
        {
            go = false;
        }
    }
}

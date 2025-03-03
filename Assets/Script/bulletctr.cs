using UnityEngine;

public class bulletctr : MonoBehaviour
{
    public LayerMask layer;
    public GameObject g;
    public bool hited;
    public bool enemarmy;
    GameObject bg;
    // Start is called before the first frame update
    void Start()
    {
        bg = transform.GetChild(Random.Range(0, transform.childCount)).gameObject;
        bg.SetActive(true);
        foreach (Transform child in transform)
        {
            if(child.gameObject!=bg)
            {
                GameObject.Destroy(child.gameObject);
            }
            
        }
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        //layer.value = LayerMask.NameToLayer("enem");
        //print(layer.value);
    }

    // Update is called once per frame
    void Update()
    {
        if(g!=null && !hited)
        {
            Vector3 v = g.transform.position;
            v.y = 1;
            transform.LookAt(g.transform);
            transform.position = Vector3.MoveTowards(transform.position, v, 25 * Time.deltaTime);
            RaycastHit hit;
            hited = Physics.Raycast(transform.position, transform.forward,out hit, 0.5f, layer);
            if(hited)
            {
    
                hit.collider.gameObject.GetComponent<healthctr>().health--;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject,1f);
            }

            Destroy(gameObject, 2);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

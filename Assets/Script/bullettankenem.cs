using UnityEngine;

public class bullettankenem : MonoBehaviour
{
    public LayerMask layer;
    public GameObject g;
    public bool hited;
    public bool enemarmy;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(Random.Range(0, transform.childCount)).gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        //layer.value = LayerMask.NameToLayer("enem");
        //print(layer.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (g != null && !hited)
        {
            Vector3 v = g.transform.position;
            v.y = 1;
            transform.LookAt(g.transform);
            transform.position = Vector3.MoveTowards(transform.position, v, 25 * Time.deltaTime);
            RaycastHit hit;
            hited = Physics.Raycast(transform.position, transform.forward, out hit, 0.4f, layer);
            if (hited)
            {
                Collider[] c = Physics.OverlapSphere(transform.position, 6f, layer);
                for (int i = 1; i < c.Length; i++)
                {
                    c[i].gameObject.GetComponent<healthctr>().health -= 5;
                }
                //hit.collider.gameObject.GetComponent<healthctr>().health--;
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(1).parent = null;
                Destroy(gameObject);
            }
            

            Destroy(gameObject, 2);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

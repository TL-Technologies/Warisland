using UnityEngine;

public class bullettank : MonoBehaviour
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
            hited = Physics.Raycast(transform.position, transform.forward, out hit, 0.3f, layer);
            if (hited)
            {
                //Collider[] c = Physics.OverlapSphere(transform.position, 6f, layer);
                for (int i = 1; i < g.transform.parent.childCount; i++)
                {
                    g.transform.parent.GetChild(i).gameObject.GetComponent<healthctr>().health-=6;
                }
                //hit.collider.gameObject.GetComponent<healthctr>().health--;
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(1).parent=null;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject, 2);
            }
            Destroy(gameObject, 4f);
        }
        else
        {
            Destroy(gameObject, 4f);
        }
    }
}

using System.Collections;
using UnityEngine;

public class tankenem : MonoBehaviour
{
    public bool standby, startshot;
    Vector3 v;

    public GameObject enem;
    public GameObject bullet;
    public LayerMask lr;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<healthctr>().health = 30;

    }

    // Update is called once per frame
    void Update()
    {

        if (standby && !startshot)
        {
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }

        if (GetComponent<healthctr>().health <= 0)
        {

            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);

            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).parent = null;
            transform.GetChild(1).parent = null;
            Destroy(gameObject);
        }


        Collider[] c = Physics.OverlapSphere(transform.position, 8.5f, lr);
        if (c.Length > 0)
        {
            if (enem == null)
            {
                enem = c[Random.Range(0, c.Length)].gameObject;
            }
            //print("godray  :" + c.Length);
        }

        try
        {
            if (enem != null && !startshot)
            {
                //Destroy(enem, 1.5f);
                StartCoroutine(startshooting());
            }

            if (startshot && enem != null)
            {
                transform.LookAt(enem.transform);
            }

        }
        catch (System.Exception)
        {

            throw;
        }


        //if (startshot && enem != null)
        //{
        //    transform.GetChild(0).gameObject.GetComponent<Animator>().Play("fire");
        //    transform.LookAt(enem.transform);
        //}
        //else
        //{
        //    transform.GetChild(0).gameObject.GetComponent<Animator>().Play("idle");
        //}

    }



    IEnumerator startshooting()
    {
        startshot = true;
        while (enem != null)
        {
            if (Vector3.Distance(transform.position, enem.transform.position) <= 10f)
            {
                GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
                b.GetComponent<bullettankenem>().g = enem.gameObject;
            }
            else
            {
                enem = null;
            }

            yield return new WaitForSeconds(2f);
        }
        startshot = false;
    }




    
}

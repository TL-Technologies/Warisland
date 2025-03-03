using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class tankctr : MonoBehaviour
{
    
    public int armypos;
    public bool armyarea, standby;
    public Vector3 v;
    NavMeshAgent agent;
    public GameObject[] enmzon;
    public float a;
    public Transform enemplace;
    public LayerMask lr;
    public GameObject enem;
    public GameObject bullet;
    public bool startshot;
    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<healthctr>().health = 40;
        
        agent = GetComponent<NavMeshAgent>();
        enmzon = GameObject.FindGameObjectsWithTag("enemzone");
        a = Vector3.Distance(transform.position, enmzon[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (UiManager.instance.flagdown)
        {
            Destroy(gameObject);
        }
        else
        {
            if (!armyarea)
            {



                v.y = 0;
                agent.SetDestination(v);
                if (agent.remainingDistance < 0.2f && agent.velocity.sqrMagnitude > 0f)
                {
                    armyarea = true;
                    standby = true;
                    //print("wsaaaal");
                }
            }

            if (standby)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (UiManager.instance.fight && !UiManager.instance.flagdown)
            {
                standby = false;
                enmzon = GameObject.FindGameObjectsWithTag("enemzone");
                if (enmzon.Length > 0)
                {
                    a = Vector3.Distance(transform.position, enmzon[0].transform.position);
                    enemplace = enmzon[0].transform;
                    for (int i = 0; i < enmzon.Length; i++)
                    {

                        if (Vector3.Distance(transform.position, enmzon[i].transform.position) < a && enmzon[i].transform.childCount > 1)
                        {
                            a = Vector3.Distance(transform.position, enmzon[i].transform.position);
                            enemplace = enmzon[i].transform;
                            agent.SetDestination(enemplace.position);
                            agent.stoppingDistance = Random.Range(9f, 10f);
                        }
                    }
                }


                if (enemplace != null)
                {


                    agent.SetDestination(enemplace.position);
                    agent.stoppingDistance = Random.Range(9f, 10f);

                    if (enemplace.transform.childCount > 1)
                    {
                        if (enem == null)
                        {
                            enem = enemplace.transform.GetChild(Random.Range(1, enemplace.transform.childCount)).gameObject;
                        }
                        //print("godray  :" + c.Length);
                    }
                }




                if (enem != null && !startshot)
                {
                    //Destroy(enem, 1.5f);


                    StartCoroutine(startshooting());
                }


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
        }

        

    }

    IEnumerator startshooting()
    {
        startshot = true;
        while (enem != null)
        {
            transform.LookAt(enem.transform);
            GameObject b = Instantiate(bullet, pos.position, Quaternion.identity);
            b.GetComponent<bullettank>().g = enem.gameObject;
            yield return new WaitForSeconds(2f);
        }
        startshot = false;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 0, 0.5f);

        Gizmos.DrawSphere(transform.position, 7.5f);
    }
}

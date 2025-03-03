using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class armycontroller : MonoBehaviour
{
    public dotmanager dotm;
    public int armypos;
    public bool armyarea, standby;
    Vector3 v;
    NavMeshAgent agent;
    public GameObject[] enmzon;
    public float a;
    public Transform enemplace;
    public LayerMask lr;
    public GameObject enem;
    public GameObject bullet;
    public bool startshot;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<healthctr>().health = 20;
        dotm = FindObjectOfType<dotmanager>();
        agent = GetComponent<NavMeshAgent>();
        enmzon = GameObject.FindGameObjectsWithTag("enemzone");
        a = Vector3.Distance(transform.position, enmzon[0].transform.position);
        SoundManager.instance.Play("solid");
    }

    // Update is called once per frame
    void Update()
    {
        if(UiManager.instance.flagdown)
        {
            Destroy(gameObject);
        }
        else
        {

            if (!armyarea)
            {

                transform.GetChild(0).gameObject.GetComponent<Animator>().Play("run");
                v = dotm.transform.GetChild(armypos).position;
                v.y = 0;
                //transform.position = Vector3.MoveTowards(transform.position, v, 5 * Time.deltaTime);
                agent.SetDestination(v);
                if (agent.remainingDistance < 0.2f && agent.velocity.sqrMagnitude > 0f)
                {
                    armyarea = true;
                    standby = true;
                    transform.GetChild(0).gameObject.GetComponent<Animator>().Play("idle");
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
                armyarea = true;
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
                            agent.stoppingDistance = Random.Range(4f, 6f);
                        }
                    }
                }


                if (enemplace != null)
                {


                    agent.SetDestination(enemplace.position);
                    agent.stoppingDistance = Random.Range(4f, 6f);

                    if (enemplace.transform.childCount > 1 && Vector3.Distance(transform.position, enemplace.transform.position) <= 9)
                    {
                        if (enem == null)
                        {
                            enem = enemplace.transform.GetChild(Random.Range(1, enemplace.transform.childCount)).gameObject;
                        }
                        //print("godray  :" + c.Length);
                    }
                }
                else
                {
                    transform.GetChild(0).gameObject.GetComponent<Animator>().Play("idle");
                }


                //Collider[] c = Physics.OverlapSphere(transform.position, 8.5f, lr);
                //GameObject[] c = enemplace.transform.g
                //if (enemplace.transform.childCount>1 && Vector3.Distance(transform.position,enemplace.transform.position)<=9)
                //{
                //    if(enem==null)
                //    {
                //        enem = enemplace.transform.GetChild(Random.Range(1, enemplace.transform.childCount)).gameObject;
                //    }

                //}

                if (enem != null && !startshot)
                {
                    //Destroy(enem, 1.5f);


                    StartCoroutine(startshooting());
                }

                if (startshot)
                {

                    if (agent.velocity.x < 1f && agent.velocity.z < 1f)
                    {
                        transform.GetChild(0).gameObject.GetComponent<Animator>().Play("fire");
                    }
                    else
                    {
                        transform.GetChild(0).gameObject.GetComponent<Animator>().Play("firerun");
                    }

                }
                else if (!startshot && enemplace != null)
                {
                    transform.GetChild(0).gameObject.GetComponent<Animator>().Play("firerun");
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
        while (enem!=null)
        {
            transform.LookAt(enem.transform);
            GameObject b= Instantiate(bullet, transform.position, Quaternion.identity);
            b.GetComponent<bulletctr>().g = enem.gameObject;
            yield return new WaitForSeconds(Random.Range(0.45f,0.55f));
        }
        startshot = false;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 0, 0.5f);
        
        Gizmos.DrawSphere(transform.position, 7.5f);
    }
}

using UnityEngine;

public class instantarmy : MonoBehaviour
{
    public GameObject army;
    GameObject g;
    public float mytime = 1f;
    public armycontroller[] armyctr;
    public tankctr[] tanks;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = UiManager.instance.allmaterial.gameObject.transform;
        SoundManager.instance.Play("tent");
        if (gamemanager.instance.getLevel() == 0 && !UiManager.instance.tentg)
        {
            UiManager.instance.tentg = true;
            UiManager.instance.sahm2.SetActive(false);
            UiManager.instance.sahm3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<dotmanager>().dotvide< FindObjectOfType<dotmanager>().dotlvl && !UiManager.instance.fight && !UiManager.instance.flagdown)
        {       
            mytime -= Time.deltaTime;
            if(mytime<=0)
            {
                mytime = 2.5f;
                Vector3 v = transform.position;
                v.y = 1;
                g = Instantiate(army, v, Quaternion.identity);
                g.GetComponent<armycontroller>().armypos= FindObjectOfType<dotmanager>().dotvide;
                FindObjectOfType<dotmanager>().dotvide++;
            }
        }

        if(UiManager.instance.fight)
        {
            FindObjectOfType<dotmanager>().dotvide = 0;
        }

        armyctr = FindObjectsOfType<armycontroller>();
        tanks = FindObjectsOfType<tankctr>();
        if(armyctr.Length==0 && tanks.Length==0)
        {
            UiManager.instance.fight = false;
        }
    }
}

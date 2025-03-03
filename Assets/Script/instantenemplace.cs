using UnityEngine;

public class instantenemplace : MonoBehaviour
{
    public GameObject g1,g2;
    public GameObject[] enems;
    public bool lvl;
    // Start is called before the first frame update
    void Start()
    {
        if(lvl && gamemanager.instance.getLevel()<2)
        {
            if(gamemanager.instance.getLevel()==0)
            {
                Instantiate(g1, transform.position, Quaternion.identity);
            }

            if (gamemanager.instance.getLevel() == 1)
            {
                Instantiate(g2, transform.position, Quaternion.identity);
            }
        }

        if (gamemanager.instance.getLevel() >= 2 && lvl)
        {
            Instantiate(enems[Random.Range(0, enems.Length)], transform.position, Quaternion.identity);
        }

        if (gamemanager.instance.getLevel() >= 1 && !lvl)
        {
            Instantiate(enems[Random.Range(0,enems.Length)], transform.position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

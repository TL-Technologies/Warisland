using UnityEngine;

public class dotmanager : MonoBehaviour
{
    public int getlvlarmy;
    public int dotlvl, dotvide;
    // Start is called before the first frame update
    void Start()
    {
        //gamemanager.instance.setsolidlvl(0);
        editdot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void editdot()
    {
        dotlvl = 8 + (gamemanager.instance.getsolidlvl()*2);
        if(dotlvl>=40)
        {
            dotlvl = 40;
        }
        for (int i = 0; i < dotlvl; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

    }
}

using System.Collections;
using UnityEngine;

public class flagctr : MonoBehaviour
{
    bool flago;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.instance.getLevel()==0 && transform.parent.childCount==1)
        {
            UiManager.instance.sahm4.SetActive(true);
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        print("eeeen");
        if(other.gameObject.tag=="Player" && transform.parent.childCount == 1 && !flago)
        {
            flago = true;
            if(gamemanager.instance.getLevel()==0)
            {
                StartCoroutine(falgwin());
            }
            else
            {
                if (gamemanager.instance.getLevel()==UiManager.instance.flagcount)
                {
                    StartCoroutine(falgwin());

                }
                else if (gamemanager.instance.getLevel() > UiManager.instance.flagcount)
                {
                    if(UiManager.instance.flagcount>=7)
                    {
                        StartCoroutine(falgwin());
                    }
                    else if(UiManager.instance.flagcount<7)
                    {


                        StartCoroutine(flagupdown());
                    }
                }
            }
            
        }

        
    }

    public void wingm()
    {
        print("win");
        gamemanager.instance.setLevel(gamemanager.instance.getLevel()+1);
        UiManager.instance.btn_retry();
    }

    IEnumerator flagupdown()
    {
        
        transform.GetChild(0).gameObject.GetComponent<Animator>().Play("flaganim");
        SoundManager.instance.Play("flag");
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = UiManager.instance.green;
        yield return new WaitForSeconds(1f);
        gamemanager.instance.setflaglvl(gamemanager.instance.getflaglvl() + 1);
        UiManager.instance.flaglvl.text = gamemanager.instance.getflaglvl().ToString();
        SoundManager.instance.Play("win");
        yield return new WaitForSeconds(0.5f);
        UiManager.instance.allmaterial.v = transform.position;
        UiManager.instance.allmaterial.go = true;
        UiManager.instance.flapenempos[UiManager.instance.flagcount].SetActive(true);
        UiManager.instance.flagdown = true;
        UiManager.instance.flagcount++;
        yield return new WaitForSeconds(1.5f);
        //UiManager.instance.fight = true;
        UiManager.instance.flagdown = false;
        Destroy(gameObject);


    }

    IEnumerator falgwin()
    {
        transform.GetChild(0).gameObject.GetComponent<Animator>().Play("flaganim");
        SoundManager.instance.Play("flag");
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = UiManager.instance.green;
        UiManager.instance.wineffect.SetActive(true);
        SoundManager.instance.Play("wingame");
        gamemanager.instance.setflaglvl(gamemanager.instance.getflaglvl() + 1);
        UiManager.instance.flaglvl.text = gamemanager.instance.getflaglvl().ToString();
        yield return new WaitForSeconds(5f);
        gamemanager.instance.setLevel(gamemanager.instance.getLevel() + 1);
        UiManager.instance.btn_retry();
    }
}

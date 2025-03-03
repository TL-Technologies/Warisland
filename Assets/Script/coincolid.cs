using System.Collections;
using UnityEngine;

public class coincolid : MonoBehaviour
{
    public Transform grisbug, goldbug;
    int a;
    bool onetime,myexit;
    public bool startheal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startheal && GetComponent<healthctr>().health < 300)
        {
            GetComponent<healthctr>().health++;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="griscoin")
        {
            collision.gameObject.transform.parent = grisbug;
            UiManager.instance.griscount.text = grisbug.childCount.ToString();
            SoundManager.instance.Play("tag");
        }

        if (collision.gameObject.tag == "goldcoin")
        {
            collision.gameObject.transform.parent = goldbug;
            UiManager.instance.goldcount.text = goldbug.childCount.ToString();
            SoundManager.instance.Play("tag");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag=="instantbox")
        {
            
            if (other.gameObject.GetComponent<instantbox>().numbercointag>0)
            {
                myexit = false;
                if (grisbug.childCount>0 && other.gameObject.GetComponent<instantbox>().numbercointag>0)
                {
                    StartCoroutine(coingo(other.gameObject));
                }
            }

            
        }


        if (other.gameObject.tag == "solidlvl")
        {

            if (other.gameObject.GetComponent<solidlvlup>().numbercointag > 0)
            {
                myexit = false;
                if (goldbug.childCount > 0 && other.gameObject.GetComponent<solidlvlup>().numbercointag > 0)
                {
                    StartCoroutine(goldcoingo(other.gameObject));
                }
            }
        }


        if (other.gameObject.tag=="fight")
        {
            UiManager.instance.buttonfight.SetActive(true);
        }


        if (other.gameObject.tag == "griscoin")
        {
            other.gameObject.transform.parent = grisbug;
            UiManager.instance.griscount.text = grisbug.childCount.ToString();
            SoundManager.instance.Play("tag");
            if(gamemanager.instance.getLevel()==0 && !UiManager.instance.coing)
            {
                UiManager.instance.coing = true;
                UiManager.instance.sahm1.SetActive(false);
                UiManager.instance.sahm2.SetActive(true);
            }
        }

        if (other.gameObject.tag == "goldcoin")
        {
            other.gameObject.transform.parent = goldbug;
            UiManager.instance.goldcount.text = goldbug.childCount.ToString();
            SoundManager.instance.Play("tag");
        }


        if(other.gameObject.tag == "heal")
        {
            if(GetComponent<healthctr>().health<300)
            {
                startheal = true;
            }
        }
    }

    
    


    IEnumerator coingo(GameObject g)
    {
        while (!myexit)
        {
            grisbug.GetChild(0).gameObject.GetComponent<MeshCollider>().enabled = false;
            grisbug.GetChild(0).parent = g.GetComponent<instantbox>().tagbug;
            g.GetComponent<instantbox>().numbercointag--;
            g.GetComponent<instantbox>().numbertag.text = g.GetComponent<instantbox>().numbercointag.ToString();
            if (g.GetComponent<instantbox>().numbercointag == 0)
            {
                myexit = true;
                g.GetComponent<instantbox>().instantobject = true;
            }

            if(grisbug.childCount==0)
            {
                myexit = true;
            }
            UiManager.instance.griscount.text = grisbug.childCount.ToString();
            SoundManager.instance.Play("tagto");
            yield return new WaitForSeconds(0.2f);
        }
    }


    IEnumerator goldcoingo(GameObject g)
    {
        while (!myexit)
        {
            goldbug.GetChild(0).gameObject.GetComponent<MeshCollider>().enabled = false;
            goldbug.GetChild(0).parent = g.GetComponent<solidlvlup>().tagbug;
            g.GetComponent<solidlvlup>().numbercointag--;
            g.GetComponent<solidlvlup>().numbertag.text = g.GetComponent<solidlvlup>().numbercointag.ToString();
            if (g.GetComponent<solidlvlup>().numbercointag == 0)
            {
                myexit = true;
                gamemanager.instance.setsolidlvl(gamemanager.instance.getsolidlvl() + 1);
                g.GetComponent<solidlvlup>().numbercointag = gamemanager.instance.getsolidlvl() * 10 + 30;
                g.GetComponent<solidlvlup>().numbertag.text = g.GetComponent<solidlvlup>().numbercointag.ToString();
                FindObjectOfType<dotmanager>().editdot();
                g.GetComponent<solidlvlup>().instantobject = true;
            }

            if (goldbug.childCount == 0)
            {
                myexit = true;
            }
            UiManager.instance.goldcount.text = goldbug.childCount.ToString();
            SoundManager.instance.Play("tagto");
            yield return new WaitForSeconds(0.2f);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "instantbox")
        {
            myexit = true;
        }

        if (other.gameObject.tag == "solidlvl")
        {
            myexit = true;
        }

        if (other.gameObject.tag == "fight")
        {
            UiManager.instance.buttonfight.SetActive(false);
        }

        if (other.gameObject.tag == "heal")
        {
            startheal = false;
        }

    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public Text LevelText,flaglvl,secondmessage;
    public bool skinEnter;
    public GameObject ingamepanel;
    public GameObject playerSelectionPanel;
    public GameObject startpanel,gameplaypanel,losepanel,winpanel;

    public GameObject sahm1,sahm2, sahm3,sahm4;

    public bool fight;

    public GameObject buttonfight;
    public Text griscount, goldcount;

    public int flagcount;
    public GameObject[] flapenempos;
    public materailctr allmaterial;
    public Material green;
    public bool flagdown;
    public GameObject wineffect;

    public GameObject plr, effectlose;
    bool die;

    public bool coing, tentg, chargeg;
    public float adstim=60;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Advertisements.Instance.Initialize();
        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM);
        LevelText.text = "Level " + (gamemanager.instance.getLevel() + 1);
        flaglvl.text = (gamemanager.instance.getflaglvl()).ToString();

        if(gamemanager.instance.getLevel() > 0)
        {
            Destroy(sahm1);
            Destroy(sahm2);
            Destroy(sahm3);
            Destroy(sahm4);
        }


    }

    private void Update()
    {
        if(die)
        {
            die = false;
            StartCoroutine(diereld());
        }

        SoundManager.instance.adsmytim -= Time.deltaTime;

        if(SoundManager.instance.adsmytim <= 0)
        {
            SoundManager.instance.adsmytim = 60;
            Advertisements.Instance.ShowInterstitial();
        }
    }

    //void Update()
    //{
    //    if(flagdown)
    //    {
    //        fight = false;
    //    }
    //}


    //public void skinmenu()
    //{
    //    // sound
    //    SoundManager.instance.Play("click");
    //    skinEnter = true;
    //    playerSelectionPanel.SetActive(true);
    //    ingamepanel.SetActive(false);
    //}

    public void btn_retry()
    {
        // sound
        //SoundManager.instance.Play("click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextlvl()
    {
        gamemanager.instance.setLevel(gamemanager.instance.getLevel() + 1);
        if (gamemanager.instance.LevelsContenu.Length <= gamemanager.instance.getLevel())
            return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void fightstart()
    {
        if(!fight)
        {
            SoundManager.instance.Play("charge");
            SoundManager.instance.Play("alarm");
        }
        fight = true;
        if (gamemanager.instance.getLevel() == 0 && !chargeg)
        {
            chargeg = true;
            sahm3.SetActive(false);
        }
    }

    public void losegm()
    {
        SoundManager.instance.Play("hurt");
        effectlose.transform.parent = null;
        Destroy(plr);
        effectlose.SetActive(true);
        SoundManager.instance.Play("lose");
        
        die = true;
    }

    IEnumerator diereld()
    {
        yield return new WaitForSeconds(4f);
        btn_retry();
    }
}

using UnityEngine;
using TMPro;

public class solidlvlup : MonoBehaviour
{
    public TextMeshPro numbertag;
    public int numbercointag;
    public Transform tagbug;
    public bool instantobject;
    public GameObject gm;
    // Start is called before the first frame update
    void Start()
    {
        //print(numbertag.text);
        numbercointag = gamemanager.instance.getsolidlvl() * 10 + 30;
        numbertag.text = numbercointag.ToString();
        //numbercointag = int.Parse(numbertag.text);
    }

    // Update is called once per frame
    void Update()
    {
        //if (instantobject)
        //{
        //    instantobject = false;
        //    gm.SetActive(true);
        //    gm.transform.parent = null;
        //    Destroy(gameObject);
        //}
    }
}

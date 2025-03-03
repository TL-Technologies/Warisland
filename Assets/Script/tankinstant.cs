using UnityEngine;

public class tankinstant : MonoBehaviour
{
    public GameObject tank;
    public bool onetime;
    public Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.Play("tent");
        transform.parent = UiManager.instance.allmaterial.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!UiManager.instance.fight && !onetime && !UiManager.instance.flagdown)
        {
            onetime = true;
            GameObject g = Instantiate(tank, transform.position, Quaternion.identity);
            g.GetComponent<tankctr>().v = tr.position;
        }
        else if(UiManager.instance.fight)
        {
            onetime = false;
        }
    }
}

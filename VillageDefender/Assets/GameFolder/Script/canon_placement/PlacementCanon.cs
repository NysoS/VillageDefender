using UnityEngine;
using UnityEngine.UI;

public class PlacementCanon : MonoBehaviour
{
    public GameObject[] canon;
    public Camera cam;

    public UICoins coins;
    public int debitCoins;
    public Text coinsHUD;

    public int itemChose;

    private void Start()
    {
        cam = GetComponent<Camera>();
        coins = GetComponent<UICoins>();
    }

    private void Update()
    {
        getDebitCoins(canon[itemChose]);
        coinsHUD.text = coins.getCoins().ToString();

        Vector3 cam_pos = cam.WorldToScreenPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                print(hit.transform.name);
                if (coins.CanAdd(debitCoins))
                {
                    if (hit.transform.tag == "Node" && hit.transform.name == "node_g")
                    {
                        Vector3 pos = new Vector3(0, 0.2f, 0);
                        Instantiate(canon[itemChose], hit.transform.position - pos, hit.transform.rotation);
                        hit.transform.gameObject.SetActive(false);
                        coins.AddCanon(debitCoins);
                    }
                    if(hit.transform.tag == "canon_v1")
                    {
                        Vector3 pos = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                        Destroy(hit.transform.gameObject);
                        GameObject c = Instantiate(canon[1], hit.transform.position - pos, hit.transform.rotation);
                        c.transform.position = pos;
                        coins.AddCanon(50);
                    }
                    else if(hit.transform.tag == "canon_v2")
                    {
                        Vector3 pos = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                        Destroy(hit.transform.gameObject);
                        GameObject c = Instantiate(canon[2], hit.transform.position - pos, hit.transform.rotation);
                        c.transform.position = pos;
                        coins.AddCanon(50);
                    }
                }
            }
        }
    }

    public int getDebitCoins(GameObject g)
    {
        if(g.name == "canon_v3")
        {
            debitCoins = 150;
        }else if(g.name == "canon_v2")
        {
            debitCoins = 100;
        }else if(g.name == "canon_v1")
        {
            debitCoins = 50;
        }

        return debitCoins;
    }

    public void ItemChosen(int i)
    {
        itemChose = i;
    }

    public void UpGrade(int i)
    {

    }
}

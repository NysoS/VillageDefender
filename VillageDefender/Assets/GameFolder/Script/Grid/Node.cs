using UnityEngine;

public class Node : MonoBehaviour
{

    public Material g, r;

    private void Start()
    {
        gameObject.name = "node_g";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Props" || other.tag == "Target")
        {
            GetComponent<Renderer>().material = r;
            gameObject.name = "node_r";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Props" || other.tag == "Target")
        {
            GetComponent<Renderer>().material = r;
            gameObject.name = "node_r";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Props" || other.tag == "Target")
        {
            GetComponent<Renderer>().material = g;
            gameObject.name = "node_g";
        }
    }
}

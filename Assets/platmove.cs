using UnityEngine;

public class platmove : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public float speed = 5f;

    private Transform targetpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetpos = pos2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetpos.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetpos.position) < 0.05f)
        {
            targetpos = (targetpos == pos1) ? pos2 : pos1;
        }
    }
}

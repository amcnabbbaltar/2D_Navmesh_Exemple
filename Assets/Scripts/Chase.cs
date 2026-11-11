using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private bool stop;
    public bool showPath;
    public bool showAhead;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            agent.speed += 0.1f;
        }
        if (target == null)
            return;
            
        if ((transform.position - target.transform.position).magnitude < 1 && !stop)
        {
            stop = true;
            target.GetComponent<Navigate>().enabled = false;

            // You have reach your destination
            Destroy(target);
        }
        agent.SetDestination(target.transform.position);
    }

    private void OnDrawGizmos()
    {
        Navigate.DrawGizmos(agent, showPath, showAhead);
    }
}

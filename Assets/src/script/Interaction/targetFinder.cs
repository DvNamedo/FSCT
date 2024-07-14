using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class targetFinder : MonoBehaviour
{
    NavMeshAgent agent;
    public NavMeshSurface nms;

    public GameObject target;

    public float m_updateInterval;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        nms.CancelInvoke();
        nms.BuildNavMesh();
        StartCoroutine(targetSelect(m_updateInterval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


        IEnumerator targetSelect(float updateInterval)
    {
        while (true)
        {
            

            yield return new WaitForSeconds(updateInterval);

            Ray ray = new Ray(transform.position,  target.transform.position - transform.position );

            Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.red,0.5f);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                Debug.Log("Raycasting");

                // 유효한 경우(If valid)
                if (!agent.isPathStale)
                {
                    if (hit.transform.gameObject.Equals(target))
                    {
                        Debug.Log(" Seeing player");
                        agent.SetDestination(hit.point);
                    }
                    else
                    {
                        Debug.Log(" Unseeing player");
                        agent.SetDestination(target.transform.position);
                    }



                }
                else
                {

                }

            }

        }

    }

}

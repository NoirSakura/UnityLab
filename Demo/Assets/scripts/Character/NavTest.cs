using UnityEngine;

using UnityEngine.AI;

public class NavTest : MonoBehaviour{
    private NavMeshAgent agent;
    void Start(){

        agent = GetComponent<NavMeshAgent>();

    }

    void Update() {
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0)){

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo)){
                gameObject.GetComponent<Animator>().SetBool("Run", true);
                agent.SetDestination(hitInfo.point);
            }
        }
    }
}
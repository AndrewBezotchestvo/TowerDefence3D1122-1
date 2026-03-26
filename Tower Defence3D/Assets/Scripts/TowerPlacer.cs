using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;  
    public Vector3 towerOffset;
    
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.tag == "Platform")
                {

                    Instantiate(towerPrefab, hitObject.transform.position + towerOffset, hitObject.transform.rotation);

                }
            }
        }
    }
}

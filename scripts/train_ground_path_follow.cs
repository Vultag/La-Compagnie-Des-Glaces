using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class train_ground_path_follow : MonoBehaviour
{

    private List <Transform> routes = new List<Transform>();
    private List <GameObject> rails = new List<GameObject>();

    private int routeToGo;

    private float tParam;

    private Vector3 trainPosition;
    private Quaternion trainRotation;

    public float speedModifier;
    public bool is_blocked;

    public bool coroutineAllowed;

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        //speedModifier = 0f;
        coroutineAllowed = true;

        rails.AddRange(GameObject.FindGameObjectsWithTag("rail"));

        //rails.Sort(CompareListByName);
        rails.Sort(CompareListBy_z_pos);

        //print(rails[0].transform.GetChild(2).transform);

        for (int i = 0; i < rails.Count; i++)
        {
            rails[i].name = "rail_" + i.ToString();

            //print(rails[i].transform.position.z);

            routes.Add(rails[i].transform.GetChild(2).transform);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));

            //trainRotation.SetLookRotation(routes[routeToGo].GetChild(routeToGo).position);
           //trainRotation.SetLookRotation(new Vector3 (-1,0,0));
           // transform.rotation = trainRotation;

        }
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNum].GetChild(0).position;
        Vector3 p1 = routes[routeNum].GetChild(1).position;
        Vector3 p2 = routes[routeNum].GetChild(2).position;
        Vector3 p3 = routes[routeNum].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;


            //marche très mal ou pas ?
            //if (((Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3) - this.transform.position) != Vector3.zero)
            
            if (speedModifier !=0 && is_blocked == false)
            {
            //ajuste la rotation avec l'offset ET SMOOTH AVEC LERP
            trainRotation.SetLookRotation((Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3) - this.transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, trainRotation * Quaternion.Euler(0f, -90f, 0f), 0.04f);
            }


            trainPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.position = trainPosition;
            

            

            //print(transform.rotation);

            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        routeToGo += 1;

        if (routeToGo > routes.Count - 1)
        {
            routeToGo = 0;
        }

        coroutineAllowed = true;

    }

    private static int CompareListByName(GameObject i1, GameObject i2) //marche mais y faut trouver un moyen de bien tt renommer
    {
        return i1.name.CompareTo(i2.name);
    }
    private static int CompareListBy_z_pos(GameObject i1, GameObject i2)
    {
        //return i1.transform.position.z.CompareTo(i2.transform.position.z);

        var to_int = i1.transform.localPosition.z - i2.transform.localPosition.z;

        return (int)to_int;

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyScipt : MonoBehaviour
{
    [SerializeField] private float timeCoolDown;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distanceArmies;
    [SerializeField] private ArmyCheck[] point;
    [SerializeField] private GameObject[] amryObj;
    [SerializeField] private int[] rangeRandom = { 0, 0 };
    [SerializeField] private GameObject armyGroup;
    public List<GameObject> amryObjInGame;
    private void SetArmy()
    {
        int num = Random.Range(rangeRandom[0], rangeRandom[1]);
        for (int i = 0; i < num; i++)
        {
            int randomObj = Random.Range(0, amryObj.Length);
            Vector3 position = new Vector3(armyGroup.transform.position.x, armyGroup.transform.position.y, armyGroup.transform.position.z + (i * distanceArmies * -1));
            GameObject army = Instantiate(amryObj[randomObj], position, Quaternion.Euler(0,45f,0));
            amryObjInGame.Add(army);
            army.transform.parent = armyGroup.transform;
        }
        armyGroup.transform.position = point[0].gameObject.transform.position;
        point[1].haveArmy = true;
    }
    private void Start()
    {
        point[1].timeCooldown = timeCoolDown;
        point[1].timeCooldownMax = timeCoolDown;
        SetArmy();
    }
    private void Update()
    {
        armyGroup.transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        if (!point[1].haveArmy)
        {
            amryObjInGame.Clear();
            SetArmy();
        }
    }
}

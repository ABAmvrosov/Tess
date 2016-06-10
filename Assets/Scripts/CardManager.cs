using UnityEngine;

public class CardManager : MonoBehaviour {
    public GameObject[] groundCardPrefabs;
    public GameObject[] movementCardPrefabs;
    public Card ActiveCard { get; set; }
    [SerializeField] Transform _container;

    void Awake() {
        SetupTestCards();
    }

    public void SetupTestCards () {
        foreach (GameObject groundCard in groundCardPrefabs) {
            InstantiateCard(groundCard);
        }
        foreach (GameObject movementCard in movementCardPrefabs)
        {
            InstantiateCard(movementCard);
        }
    }

    private void InstantiateCard(GameObject prefab) {
        GameObject tmp = Instantiate(prefab);
        tmp.transform.SetParent(_container);
    }
}

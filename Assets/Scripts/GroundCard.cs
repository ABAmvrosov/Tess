using UnityEngine;

public class GroundCard : Card {

    [SerializeField] private GroundModels model;
    public GroundCardModel GroundModel;
    public GroundOperations groundOperation;

    void Start() {
        SetGroundCardModel();
    }

    private void SetGroundCardModel() {
        switch (model) {
            case GroundModels.Cube:
                GroundModel = new CubeModel();
                break;
            case GroundModels.J:
                GroundModel = new JModel();
                break;
            case GroundModels.L:
                GroundModel = new LModel();
                break;
            case GroundModels.S:
                GroundModel = new SModel();
                break;
            case GroundModels.T:
                GroundModel = new TModel();
                break;
            case GroundModels.Z:
                GroundModel = new ZModel();
                break;
        }
    }

    protected override void ActivateCard() {
        StateContext contex = new StateContext(this, StateMark.GroundCard);
        GameManager.GM.HandleActionByState(contex);
    } 
}

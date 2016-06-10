using System;

public class LModel : GroundCardModel {
    int[,] model = {{0,0},{1,0},{0,-1},{1,-1}};
    public override int[,] GetModel() {
        return model;
    }
}

using System;

public class TModel : GroundCardModel {
    int[,] model = {{0,0},{1,0},{-1,0},{0,-1}};
    public override int[,] GetModel() {
        return model;
    }
}

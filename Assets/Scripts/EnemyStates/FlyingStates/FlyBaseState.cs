using UnityEngine;

public abstract class FlyBaseState {
    public abstract void EnterState(Fly fly);
    public abstract void Update(Fly fly);
}
using System;
using UnityEngine;

[Serializable]
public abstract class BruxaBaseState
{
    public abstract void EnterState(Bruxa bruxa);

    public abstract void UpdateState(Bruxa bruxa);

    public abstract void FixedUpdateState(Bruxa bruxa);

    public abstract void OnCollisionEnter(Bruxa bruxa, Collision collsion);

    public abstract void OnCollisionExit(Bruxa bruxa, Collision collision);

    public abstract string GetStateName();

    public abstract void TakeDamage(Bruxa bruxa);
}

using UnityEngine;

interface IHittable
{
    public void Hitt(Hitt hitt);
}

interface IHoldable
{
    public void PutInHand();
    public void PutOutHand();
}
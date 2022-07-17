using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    int GetCount();
    void CanStart();
    void Finish();
    void Lose();
    bool IsOne();
}

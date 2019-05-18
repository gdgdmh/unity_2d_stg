using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerHealthObservable {

    public StgPlayerHealthObservable() {
        observers = new List<IStgPlayerHealthObserver>();
    }

    /// <summary>
    /// オブザーバーを追加
    /// </summary>
    /// <param name="observer">追加するオブザーバー</param>
    public void Add(IStgPlayerHealthObserver observer) {
        observers.Add(observer);
    }

    /// <summary>
    /// オブザーバーを解除
    /// </summary>
    /// <param name="observer">解除するオブザーバー</param>
    public void Remove(IStgPlayerHealthObserver observer) {
        observers.Remove(observer);
    }

    /// <summary>
    /// オブザーバーに通知
    /// </summary>
    public void NotifyObservers(int maxHealth, int currentHealth, int diffHealth) {
        observers.ForEach(observer => observer.UpdateHealth(maxHealth, currentHealth, diffHealth));
    }

    private List<IStgPlayerHealthObserver> observers;
}

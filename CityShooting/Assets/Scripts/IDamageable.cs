﻿using UnityEngine;

public interface IDamageable
{

    void TakeHit(float damage, RaycastHit hit);

	void TakeDamage(float damage);

}
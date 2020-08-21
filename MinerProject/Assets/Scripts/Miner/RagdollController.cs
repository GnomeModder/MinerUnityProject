using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
	// Token: 0x06001381 RID: 4993 RVA: 0x00052120 File Offset: 0x00050320
	private void Start()
	{
		this.animator = base.GetComponent<Animator>();
		foreach (Transform transform in this.bones)
		{
			Collider component = transform.GetComponent<Collider>();
			Rigidbody component2 = transform.GetComponent<Rigidbody>();
			if (!component)
			{
				Debug.LogWarningFormat("Bone {0} is missing a collider!", new object[]
				{
						transform
				});
			}
			else
			{
				component.enabled = false;
				component2.interpolation = RigidbodyInterpolation.None;
				component2.isKinematic = true;
			}
		}
	}

	// Token: 0x06001382 RID: 4994 RVA: 0x00052198 File Offset: 0x00050398
	public void BeginRagdoll(Vector3 force)
	{
		if (this.animator)
		{
			this.animator.enabled = false;
		}
		foreach (Transform transform in this.bones)
		{
			transform.parent = base.transform;
			Rigidbody component = transform.GetComponent<Rigidbody>();
			transform.GetComponent<Collider>().enabled = true;
			component.isKinematic = false;
			component.interpolation = RigidbodyInterpolation.Interpolate;
			component.collisionDetectionMode = CollisionDetectionMode.Continuous;
			component.AddForce(force * UnityEngine.Random.Range(0.9f, 1.2f), ForceMode.VelocityChange);
		}
		//MonoBehaviour[] array2 = this.componentsToDisableOnRagdoll;
		//for (int i = 0; i < array2.Length; i++)
		//{
		//	array2[i].enabled = false;
		//}
	}

	// Token: 0x040011C8 RID: 4552
	public Transform[] bones;

	// Token: 0x040011C9 RID: 4553
	//public MonoBehaviour[] componentsToDisableOnRagdoll;

	// Token: 0x040011CA RID: 4554
	private Animator animator;
}
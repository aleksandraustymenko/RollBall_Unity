using UnityEngine;
using Unity.Entities;
using Unity.Physics;
using Unity.Mathematics;
using Unity.Jobs;


[AlwaysSynchronizeSystem]
public class MovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        float2 cutInput = new float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Entities.ForEach((ref PhysicsVelocity vel, in SpeedData speedData) =>
        {
            float2 newvel = vel.Linear.xz;

            newvel += cutInput * speedData.speed * deltaTime;

            vel.Linear.xz = newvel;
        }).Run();

        return default;
    }
}
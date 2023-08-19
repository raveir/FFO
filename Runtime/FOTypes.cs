using System.Collections.Generic;
using FishNet.Broadcast;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.FloatingOrigin
{
    namespace Types
    {
        public class OffsetGroup
        {
            public Scene scene;
            public Vector3d offset;
            public HashSet<FOObserver> observers = new HashSet<FOObserver>();

            public OffsetGroup(Scene scene, Vector3d offset)
            {
                this.scene = scene;
                this.offset = offset;
            }
        }
        /// <summary>
        /// Interface used for communicating with an Offsetter. An Offsetter is responsible for correctly offsetting all scene objects when the origin is shifted. If you wish to write your own implementation, make sure it uses this interface.
        /// </summary>
        public interface IOffsetter
        {
            void Offset(Scene scene, Vector3 offset);
        }
        public struct OffsetSyncBroadcast : IBroadcast
        {
            public double offsetX, offsetY, offsetZ;
            public Vector3d offset => new Vector3d(offsetX, offsetY, offsetZ);

            public OffsetSyncBroadcast(Vector3d offset)
            {
                this.offsetX = offset.x;
                this.offsetY = offset.y;
                this.offsetZ = offset.z;
            }
            public override string ToString()
            {
                return $"Offset: {offset}";
            }
        }
    }
}

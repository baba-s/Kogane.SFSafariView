using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Kogane.Internal
{
    [DisallowMultipleComponent]
    internal sealed class SFSafariViewEventHandler : MonoBehaviour
    {
        public Action OnCompletedEvent { get; set; }

        [UsedImplicitly]
        private void OnCompleted()
        {
            OnCompletedEvent?.Invoke();
        }
    }
}
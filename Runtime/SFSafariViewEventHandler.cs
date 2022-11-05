#if UNITY_IOS
// .asmdef の defineConstraints を使うと
// RuntimeInitializeOnLoadMethod が呼び出されず
// SFSafariView が正常に動作しなくなる現象に遭遇したので #if を使う形式にしています

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

#endif
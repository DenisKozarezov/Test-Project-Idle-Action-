//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public AnyStoppedDraggingListenerComponent anyStoppedDraggingListener { get { return (AnyStoppedDraggingListenerComponent)GetComponent(InputComponentsLookup.AnyStoppedDraggingListener); } }
    public bool hasAnyStoppedDraggingListener { get { return HasComponent(InputComponentsLookup.AnyStoppedDraggingListener); } }

    public void AddAnyStoppedDraggingListener(System.Collections.Generic.List<IAnyStoppedDraggingListener> newValue) {
        var index = InputComponentsLookup.AnyStoppedDraggingListener;
        var component = (AnyStoppedDraggingListenerComponent)CreateComponent(index, typeof(AnyStoppedDraggingListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyStoppedDraggingListener(System.Collections.Generic.List<IAnyStoppedDraggingListener> newValue) {
        var index = InputComponentsLookup.AnyStoppedDraggingListener;
        var component = (AnyStoppedDraggingListenerComponent)CreateComponent(index, typeof(AnyStoppedDraggingListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyStoppedDraggingListener() {
        RemoveComponent(InputComponentsLookup.AnyStoppedDraggingListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherAnyStoppedDraggingListener;

    public static Entitas.IMatcher<InputEntity> AnyStoppedDraggingListener {
        get {
            if (_matcherAnyStoppedDraggingListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.AnyStoppedDraggingListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherAnyStoppedDraggingListener = matcher;
            }

            return _matcherAnyStoppedDraggingListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public void AddAnyStoppedDraggingListener(IAnyStoppedDraggingListener value) {
        var listeners = hasAnyStoppedDraggingListener
            ? anyStoppedDraggingListener.value
            : new System.Collections.Generic.List<IAnyStoppedDraggingListener>();
        listeners.Add(value);
        ReplaceAnyStoppedDraggingListener(listeners);
    }

    public void RemoveAnyStoppedDraggingListener(IAnyStoppedDraggingListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyStoppedDraggingListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyStoppedDraggingListener();
        } else {
            ReplaceAnyStoppedDraggingListener(listeners);
        }
    }
}

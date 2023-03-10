//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public AnyTouchClickListenerComponent anyTouchClickListener { get { return (AnyTouchClickListenerComponent)GetComponent(InputComponentsLookup.AnyTouchClickListener); } }
    public bool hasAnyTouchClickListener { get { return HasComponent(InputComponentsLookup.AnyTouchClickListener); } }

    public void AddAnyTouchClickListener(System.Collections.Generic.List<IAnyTouchClickListener> newValue) {
        var index = InputComponentsLookup.AnyTouchClickListener;
        var component = (AnyTouchClickListenerComponent)CreateComponent(index, typeof(AnyTouchClickListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyTouchClickListener(System.Collections.Generic.List<IAnyTouchClickListener> newValue) {
        var index = InputComponentsLookup.AnyTouchClickListener;
        var component = (AnyTouchClickListenerComponent)CreateComponent(index, typeof(AnyTouchClickListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyTouchClickListener() {
        RemoveComponent(InputComponentsLookup.AnyTouchClickListener);
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

    static Entitas.IMatcher<InputEntity> _matcherAnyTouchClickListener;

    public static Entitas.IMatcher<InputEntity> AnyTouchClickListener {
        get {
            if (_matcherAnyTouchClickListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.AnyTouchClickListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherAnyTouchClickListener = matcher;
            }

            return _matcherAnyTouchClickListener;
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

    public void AddAnyTouchClickListener(IAnyTouchClickListener value) {
        var listeners = hasAnyTouchClickListener
            ? anyTouchClickListener.value
            : new System.Collections.Generic.List<IAnyTouchClickListener>();
        listeners.Add(value);
        ReplaceAnyTouchClickListener(listeners);
    }

    public void RemoveAnyTouchClickListener(IAnyTouchClickListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyTouchClickListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyTouchClickListener();
        } else {
            ReplaceAnyTouchClickListener(listeners);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Unigine;
using UnigineApp.data.Timer;

[Component(PropertyGuid = "344776fc44448984936f8ce0319277530801c4b7")]
public class TimeController : Component
{
	[ShowInEditor]
	private List<Node> Objects;

    [ShowInEditor]
    private Curve2d Curve;

    private WidgetLabel AsyncL = new(), UpdateL = new(), PhysicsL = new();
	private WidgetSlider TimeSlider = new WidgetSlider(1, 5, 3);
	private float Time = 0;
	private List<dvec3> Start = new();
	private dvec3 End = dvec3.LEFT * -4;
	bool canAnimate = false;

	private WidgetButton StartAnim;

    private void Init()
	{
		// write here code to be called on component initialization
		Gui GUI = Gui.GetCurrent();

		AsyncL.FontSize = 16;
		AsyncL.SetPosition(50, 100);

		UpdateL.FontSize = 16;
		UpdateL.SetPosition(50, 125);

		PhysicsL.FontSize = 16;
		PhysicsL.SetPosition(50, 150);

		GUI.AddChild(AsyncL, Gui.ALIGN_EXPAND | Gui.ALIGN_OVERLAP);
		GUI.AddChild(UpdateL, Gui.ALIGN_EXPAND | Gui.ALIGN_OVERLAP);
		GUI.AddChild(PhysicsL, Gui.ALIGN_EXPAND | Gui.ALIGN_OVERLAP);

		TimeSlider.Width = 150;
		TimeSlider.SetPosition(100, 200);
		TimeSlider.EventChanged.Connect(() => { Time = 0; });
		GUI.AddChild(TimeSlider, Gui.ALIGN_EXPAND | Gui.ALIGN_OVERLAP);

		StartAnim = new WidgetButton("Play");
		StartAnim.SetPosition(100, 250);
		StartAnim.EventClicked.Connect(() => { canAnimate = true; });
		GUI.AddChild(StartAnim, Gui.ALIGN_EXPAND | Gui.ALIGN_OVERLAP);

		foreach (var item in Objects) Start.Add(item.WorldPosition);
    }

    private void UpdateAsyncThread() => AsyncL.Text = "Async Time: " + Game.Time.ToString("0.00") + " Seconds";
    private void UpdatePhysics() => PhysicsL.Text = "Physics: " + Physics.IFps + " Frames 1/60";
    private void Update()
	{
		UpdateL.Text = "Update: " + Game.IFps + " Frames";
		if(canAnimate) MoveObjects();
    }

    private void MoveObjects()
	{
		Time += Game.IFps;
		float t = Time / TimeSlider.Value;

		Objects[0].WorldPosition = Lerper.Lerp(Start[0], Start[0] + End, t, Lerper.LERP_TYPE.LINEAR);
		Objects[1].WorldPosition = Lerper.Lerp(Start[1], Start[1] + End, t, Lerper.LERP_TYPE.EASE_IN);
		Objects[2].WorldPosition = Lerper.Lerp(Start[2], Start[2] + End, t, Lerper.LERP_TYPE.EASE_OUT);
		Objects[3].WorldPosition = Lerper.Lerp(Start[3], Start[3] + End, t, Lerper.LERP_TYPE.EASE_IN_OUT);
		Objects[4].WorldPosition = Lerper.PingPong(Start[4], Start[4] + End, t, 1);

		float tCurve = Curve.Evaluate(t);
        Objects[5].WorldPosition = Lerper.Lerp(Start[5], Start[5] + End, tCurve, Lerper.LERP_TYPE.LINEAR);
		if (t > 1.0f) { Time = 0.0f; canAnimate = false; }
    }

	private void Shutdown()
	{
        Gui GUI = Gui.GetCurrent();
        
		if (GUI.IsChild(AsyncL) == 1) { GUI.RemoveChild(AsyncL); AsyncL.DeleteLater(); } 
		if (GUI.IsChild(UpdateL) == 1) { GUI.RemoveChild(UpdateL); UpdateL.DeleteLater(); } 
		if (GUI.IsChild(PhysicsL) == 1) { GUI.RemoveChild(PhysicsL); PhysicsL.DeleteLater(); } 
		if (GUI.IsChild(TimeSlider) == 1) { GUI.RemoveChild(TimeSlider); TimeSlider.DeleteLater(); }
		if (GUI.IsChild(StartAnim) == 1) { GUI.RemoveChild(StartAnim); StartAnim.DeleteLater(); }
    }

}
using System.Collections;
using System.Collections.Generic;
using Unigine;

struct UserAccount
{
    public int Id;
    public string UserName;
    [ShowInEditor] string Password;
}

[Component(PropertyGuid = "643786b4f5f25678138f61a23b3303386116904e")]
public class ComponentCheck : Component
{

    [ShowInEditor, ParameterSlider(Title = "ID Number", Tooltip = "ID Number", Min = 0, Max = 10, Group = "Basics")]
    private int IDNum;

    [ShowInEditor, ParameterSlider(Title = "Float Num", Tooltip = "Float Value", Min = 0, Max = 1000, Group = "Basics")]
    private float IDFloat;
    
    [ShowInEditor, Parameter(Title = "Check Box", Tooltip = "Boolean Value", Group = "Basics")]
    private bool IDBool;

    [ShowInEditor, Parameter(Title = "Date", Tooltip = "Date in DD MM YYYY", Group = "Basics")] 
    private dvec3 DateTime;

    [ShowInEditor, ParameterColor(Title = "Random Color", Tooltip = "Random Color", Group = "Basics")]
    private vec4 Color;

    [ShowInEditor, ParameterMask(MaskType = ParameterMaskAttribute.TYPE.INTERSECTION, Tooltip = "Intersection Mask Choice", Group = "Advanced")]
    private int IntMask;

    [ShowInEditor, ParameterMask(MaskType = ParameterMaskAttribute.TYPE.VIEWPORT, Tooltip = "Viewport Mask Choice", Group = "Advanced")]
    private int ViewMask;

    [ShowInEditor, ParameterSwitch(Items = "First, Second, Third", Tooltip = "This is a choice in NUM", Group = "Advanced")]
    private int Switch;

    enum ITEM { FIRST, SECOND, THIRD }
    [ShowInEditor, Parameter(Tooltip = "This is a choice in ENUM", Group = "Advanced")]
    private ITEM Items;

    [ShowInEditor, Parameter(Title = "Int Array", Group = "Advanced")]
    private int[] Numbers;

    [ShowInEditor, Parameter(Title = "Int List", Tooltip = "Using List For this Array", Group = "Advanced")]
    private List<int> ListNums;

    [ShowInEditor, ParameterProperty(ParentGUID = "d99ebc8ef5769d70b1e46992309cc3e7d1aa2faa", Tooltip = "Only GUID Inherited Property can be added here", Group = "Editor Specific")]
    private Property MProperty;

    [ShowInEditor, ParameterMaterial(ParentGUID = "4dfec30f491f753f6e89094db6d3d695e89f9d6f", Group = "Editor Specific")]
    private Material Mat;

    //[ShowInEditor, ParameterFile(Title ="File Add", Filter = ".png|.cs|.node", Tooltip ="Add Any File From the AssetBrowser", Group ="Editor Specific")]
    //private File AFile;

    [ShowInEditor, ParameterAsset(Filter = ".mat", Tooltip = "Can only Accept .mat Files from AssetBrowser", Group = "Editor Specific")]
    private AssetLink AssetLinks;

    [ShowInEditor, ParameterAsset(Tooltip = "Can only Accept NodeReferences from AssetBrowser", Group = "Editor Specific")]
    private AssetLinkNode AssetLinkNode;

    [ShowInEditor, Parameter(Title = "Component", Tooltip = "Add Node inside world which has this Component", Group = "Editor Specific")]
    private AnotherComponent Comp;

    [ShowInEditor, Parameter(Title = "Add Details?", Tooltip = "Advanced Items if Checked", Group = "HiddenGroup")]
    private bool isDetail;

    [ShowInEditor, ParameterCondition(nameof(isDetail), 1), Parameter(Group = "HiddenGroup")]
    private int ID, Amount;

    [ShowInEditor, ParameterCondition(nameof(isDetail), 1), Parameter(Group = "HiddenGroup")]
    private string Name;

    [ShowInEditor, Parameter(Title = "Administrator", Group = "Struct")]
    private UserAccount Admin;

    [ShowInEditor, Parameter(Title = "User List", Group = "Struct")]
    private List<UserAccount> Users;

    [MethodInit(Order = 1)]
    void Init() { Log.Message("Base Init\n"); }
    void UpdateAsyncThread() { }
    void UpdateSyncThread() { }
    void Update() { }
    void PostUpdate() { }
    void UpdatePhysics() { }
    void Swap() { }
    void Shutdown() { }
}
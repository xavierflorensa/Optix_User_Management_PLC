#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.WebUI;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.Core;
using FTOptix.RAEtherNetIP;
using FTOptix.CommunicationDriver;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        // Mostrar el usuari logat
        var usuario = Session.User;
        var user = Session.User.BrowseName;
        var mylabel = Project.Current.Get<Label>("UI/MainWindow/Label2");
        mylabel.Text = user.ToString();
        //Update PLC tag
        var PLC_user = Project.Current.GetVariable("Model/User");
        PLC_user.Value = user.ToString();
        //Mostra el grup del usuari
        var userGroups = usuario.Refs.GetObjects(FTOptix.Core.ReferenceTypes.HasGroup, false);
        foreach (var group in userGroups)
        {
            Log.Info("Group:",group.BrowseName);
            //Project.Current.GetVariable("Model/Locales/UserGroups").Value = group.BrowseName;
           
        }
            var PLC_group = Project.Current.GetVariable("Model/Group");
            PLC_group.Value = "hello";
       
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
    [ExportMethod]
    
    public void Update()
    {
       Actualitza();
       Log.Info("Updating: ");
    }
    
     private void Actualitza()
    {
       // Mostrar el usuari logat
       var usuario = Session.User;
       var user = Session.User.BrowseName;
       var mylabel = Project.Current.Get<Label>("UI/MainWindow/Label2");
       mylabel.Text = user.ToString();
       //Update PLC tag
        var PLC_user = Project.Current.GetVariable("Model/User");
        PLC_user.Value = user.ToString();
       //Mostra el grup del usuari
       var userGroups = usuario.Refs.GetObjects(FTOptix.Core.ReferenceTypes.HasGroup, false);
       foreach (var group in userGroups)
       {
            Log.Info("User Group: ",group.BrowseName);
            var mylabel_group = Project.Current.Get<Label>("UI/MainWindow/Label4");
            mylabel_group.Text = group.BrowseName.ToString();
            //Update PLC tag
            var PLC_group = Project.Current.GetVariable("Model/Group");
            PLC_group.Value = group.BrowseName.ToString();
       }
    }

}

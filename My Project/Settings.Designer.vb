﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\MTCEDATABASE.mdb")>  _
        Public ReadOnly Property MTCEDATABASEConnectionString() As String
            Get
                Return CType(Me("MTCEDATABASEConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SETLifeSpan() As Decimal
            Get
                Return CType(Me("SETLifeSpan"),Decimal)
            End Get
            Set
                Me("SETLifeSpan") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SETAge() As Decimal
            Get
                Return CType(Me("SETAge"),Decimal)
            End Get
            Set
                Me("SETAge") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SETAvCSI() As Decimal
            Get
                Return CType(Me("SETAvCSI"),Decimal)
            End Get
            Set
                Me("SETAvCSI") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SETFundAllo() As Decimal
            Get
                Return CType(Me("SETFundAllo"),Decimal)
            End Get
            Set
                Me("SETFundAllo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SETReplaceCost() As Decimal
            Get
                Return CType(Me("SETReplaceCost"),Decimal)
            End Get
            Set
                Me("SETReplaceCost") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SETRepairCost() As Decimal
            Get
                Return CType(Me("SETRepairCost"),Decimal)
            End Get
            Set
                Me("SETRepairCost") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEETLifeSpan() As Decimal
            Get
                Return CType(Me("SEETLifeSpan"),Decimal)
            End Get
            Set
                Me("SEETLifeSpan") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEETAge() As Decimal
            Get
                Return CType(Me("SEETAge"),Decimal)
            End Get
            Set
                Me("SEETAge") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEETAvCSI() As Decimal
            Get
                Return CType(Me("SEETAvCSI"),Decimal)
            End Get
            Set
                Me("SEETAvCSI") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEETFundAllo() As Decimal
            Get
                Return CType(Me("SEETFundAllo"),Decimal)
            End Get
            Set
                Me("SEETFundAllo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEETReplaceCost() As Decimal
            Get
                Return CType(Me("SEETReplaceCost"),Decimal)
            End Get
            Set
                Me("SEETReplaceCost") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEETRepairCost() As Decimal
            Get
                Return CType(Me("SEETRepairCost"),Decimal)
            End Get
            Set
                Me("SEETRepairCost") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEMTLifeSpan() As Decimal
            Get
                Return CType(Me("SEMTLifeSpan"),Decimal)
            End Get
            Set
                Me("SEMTLifeSpan") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEMTAge() As Decimal
            Get
                Return CType(Me("SEMTAge"),Decimal)
            End Get
            Set
                Me("SEMTAge") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEMTAvCSI() As Decimal
            Get
                Return CType(Me("SEMTAvCSI"),Decimal)
            End Get
            Set
                Me("SEMTAvCSI") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEMTFundAllo() As Decimal
            Get
                Return CType(Me("SEMTFundAllo"),Decimal)
            End Get
            Set
                Me("SEMTFundAllo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEMTReplaceCost() As Decimal
            Get
                Return CType(Me("SEMTReplaceCost"),Decimal)
            End Get
            Set
                Me("SEMTReplaceCost") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEMTRepairCost() As Decimal
            Get
                Return CType(Me("SEMTRepairCost"),Decimal)
            End Get
            Set
                Me("SEMTRepairCost") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SICTLifeSpan() As Decimal
            Get
                Return CType(Me("SICTLifeSpan"),Decimal)
            End Get
            Set
                Me("SICTLifeSpan") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SICTAge() As Decimal
            Get
                Return CType(Me("SICTAge"),Decimal)
            End Get
            Set
                Me("SICTAge") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SICTAvCSI() As Decimal
            Get
                Return CType(Me("SICTAvCSI"),Decimal)
            End Get
            Set
                Me("SICTAvCSI") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SICTFundAllo() As Decimal
            Get
                Return CType(Me("SICTFundAllo"),Decimal)
            End Get
            Set
                Me("SICTFundAllo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SICTReplaceCost() As Decimal
            Get
                Return CType(Me("SICTReplaceCost"),Decimal)
            End Get
            Set
                Me("SICTReplaceCost") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SICTRepairCost() As Decimal
            Get
                Return CType(Me("SICTRepairCost"),Decimal)
            End Get
            Set
                Me("SICTRepairCost") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SAATLifeSpan() As Decimal
            Get
                Return CType(Me("SAATLifeSpan"),Decimal)
            End Get
            Set
                Me("SAATLifeSpan") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SAATAge() As Decimal
            Get
                Return CType(Me("SAATAge"),Decimal)
            End Get
            Set
                Me("SAATAge") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SAATFundAllo() As Decimal
            Get
                Return CType(Me("SAATFundAllo"),Decimal)
            End Get
            Set
                Me("SAATFundAllo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SAATReplaceCost() As Decimal
            Get
                Return CType(Me("SAATReplaceCost"),Decimal)
            End Get
            Set
                Me("SAATReplaceCost") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SAATRepairCost() As Decimal
            Get
                Return CType(Me("SAATRepairCost"),Decimal)
            End Get
            Set
                Me("SAATRepairCost") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DSSAnalysis.mdb")>  _
        Public ReadOnly Property DSSAnalysisConnectionString() As String
            Get
                Return CType(Me("DSSAnalysisConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\AnalysisDSS.mdb")>  _
        Public ReadOnly Property AnalysisDSSConnectionString() As String
            Get
                Return CType(Me("AnalysisDSSConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\RankDataBase.mdb")>  _
        Public ReadOnly Property RankDataBaseConnectionString() As String
            Get
                Return CType(Me("RankDataBaseConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SAATRemainingLife() As Decimal
            Get
                Return CType(Me("SAATRemainingLife"),Decimal)
            End Get
            Set
                Me("SAATRemainingLife") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SAATAvCSI() As Decimal
            Get
                Return CType(Me("SAATAvCSI"),Decimal)
            End Get
            Set
                Me("SAATAvCSI") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEETRemainingLife() As Decimal
            Get
                Return CType(Me("SEETRemainingLife"),Decimal)
            End Get
            Set
                Me("SEETRemainingLife") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SEMTRemainingLife() As Decimal
            Get
                Return CType(Me("SEMTRemainingLife"),Decimal)
            End Get
            Set
                Me("SEMTRemainingLife") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SETRemainingLife() As Decimal
            Get
                Return CType(Me("SETRemainingLife"),Decimal)
            End Get
            Set
                Me("SETRemainingLife") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property SICTRemainingLife() As Decimal
            Get
                Return CType(Me("SICTRemainingLife"),Decimal)
            End Get
            Set
                Me("SICTRemainingLife") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property availableFund() As Decimal
            Get
                Return CType(Me("availableFund"),Decimal)
            End Get
            Set
                Me("availableFund") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.FUTMinnaMaintenanceDSS.My.MySettings
            Get
                Return Global.FUTMinnaMaintenanceDSS.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace

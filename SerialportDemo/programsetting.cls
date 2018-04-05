VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "programsetting"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Dim conn As New ADODB.Connection
Dim rst As New ADODB.Recordset

Public Function GetTableNma(FilePath As String)
  Dim tempSplit As String
  Dim GetDB As Database
  Set GetDB = DBEngine.OpenDatabase(FilePath)
  Dim Tables As TableDef, fld
  For Each Tables In GetDB.TableDefs
  If Left(Tables.Name, 4) <> "MSys" Then tempSplit = tempSplit & Tables.Name & " "
  Next Tables
  GetDB.Close
 Set GetDB = Nothing
 GetTableNma = Split(tempSplit, " ")
End Function

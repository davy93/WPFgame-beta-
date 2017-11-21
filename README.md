Debug Documentation:
Static Logging (Class)
+ void WriteLog(string) : Writes a Debug Message on DebugLog (on Default INFO type)
+ void WriteLog(string, LogType) : Writes a Debug Message on DebugLog with LogType
+ void CreateLogDir() : Creates 'logs' directory on current AppDomain
+ List<string> GetLog() : Fetches Log from DebugLog instance.
+ void ShowDebugLog() : Create DebugLog if not exists and shows
- void WriteLine(string) : Writes message on DebugLog, part of WriteLog

LogType (Enum(arator))
INFO : Basic information, use for basic debugging, value determination.
WARN : Something has failed, not intended work
ERROR : Not intended work, this means something went wrong in calc.
FATAL_ERROR : Use for Exception throws

DebugWindow (Class [Window])
Singleton Class
Only one instance can be accessed
All Methods are internal
Constructor is protected
- static DebugWindow debugWindowInstance
internal static DebugWindow GetInstance() : Gets DebugLog Current Instance
internal static bool CreateDebugInstance() : Creates new instance (if it's true), if it's exists return false

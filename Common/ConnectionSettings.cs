public class ConnectionSettings
{
    public string serverName;
    public string dbName;
    public bool integratedSecurity;
    public string login;
    public string pass;

    public ConnectionSettings(string serverName, string dbName, 
        bool integratedSecurity = true, string login = "", string pass = "")
    {
        this.dbName = dbName;
        this.integratedSecurity = integratedSecurity;
        this.login = login;
        this.pass = pass;
        this.serverName = serverName;
    }
    public ConnectionSettings() : this("", "")
    { }
}

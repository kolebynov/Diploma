using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public class Connection : IDisposable
{
    public string Server { get { return m_server; } }
    public string Database { get { return m_database; } }
    public string User { get { return m_user; } }
    public string Password { get { return m_password; } }
    public bool IntegratedSecurity { get { return m_integratedSecurity; } }
    public SqlConnection SqlConnection { get { return m_sqlConnection; } }

    public Connection() { }

    public Connection(string servername, string database = "", 
        bool trustedConnection = true, string user = "",  string password = "")
    {
        m_server = servername;
        m_database = database;
        m_user = user;
        m_password = password;
        m_integratedSecurity = trustedConnection;

        string ConnectionString =
            "Server=" + m_server +
            ";Database=" + m_database +
            ";Trusted_Connection=" + trustedConnection +
            ";User Id=" + m_user +
            ";Password=" + m_password;

        m_sqlConnection = new SqlConnection(ConnectionString);
    }
    public SqlDataReader SendQuery(string query)
    {
        SqlCommand command = new SqlCommand(query, m_sqlConnection);
        try
        {
            return command.ExecuteReader();
        }
        catch
        {
            MessageBox.Show("Wrong query.");
            return null;
        }
    }
    public void Open()
    {
        m_sqlConnection.Open();
    }
    public void Close()
    {
        m_sqlConnection.Close();
    }
    public void Dispose()
    {
        m_sqlConnection.Dispose();
    }

    private string m_server = "";
    private string m_database = "";
    private string m_user = "";
    private string m_password = "";
    private bool m_integratedSecurity;
    private SqlConnection m_sqlConnection;
}

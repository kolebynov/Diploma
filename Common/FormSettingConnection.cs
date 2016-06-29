using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class FormSettingConnection : Form
{
    public event EventHandler<ConnectionSettingEventArgs> ConnectionSettingsAccept;

    public FormSettingConnection(ConnectionSettings connSettings, bool isCheckConnection)
    {
        InitializeComponent();

        LoadConnectionSettings(connSettings);

        m_isCheckConnection = isCheckConnection;
    }
    public FormSettingConnection() : this(new ConnectionSettings(), false)
    { }

    private bool m_isCheckConnection = false;

    private void ComboServerNameDropDownHandler(object sender, EventArgs e)
    {
        m_comboServerName.Items.Clear();
        LoadSQLServers();
    }
    private void ComboDBNameDropDownHandler(object sender, EventArgs e)
    {
        if (m_comboServerName.Text != null && m_comboServerName.Text != 
            string.Empty)
        {
            m_comboDBName.Items.Clear();
            LoadDBs();
        }
    }
    private void ButtonOKClickHandler(object sender, EventArgs e)
    {
        if (m_isCheckConnection)
        {
            Close();
            ConnectionSettingsAccept?.Invoke(this, new ConnectionSettingEventArgs(
                new ConnectionSettings(m_comboServerName.Text,
                m_comboDBName.Text, m_checkIntegratedSecurity.Checked,
                m_textBoxLogin.Text, m_texBoxPass.Text)));
        }
        else
            MyMessageBox.ShowError("Для начала нажмите кнопку \"Проверить\".");
    }
    private void CheckIntegratedSecurityCheckedChangedHandler(object sender,
        EventArgs e)
    {
        m_texBoxPass.Text = string.Empty;
        m_textBoxLogin.Text = string.Empty;
        m_panel.Visible = !m_checkIntegratedSecurity.Checked;
    }
    private void ButtonCancelClickHandler(object sender, EventArgs e) =>
        Close();
    private void ButtonCheckConnectionClickHandler(object sender, EventArgs e) =>
        CheckConnetion();
    private void ValueChanged(object sender, EventArgs e) =>
        m_isCheckConnection = false;

    private void LoadSQLServers()
    {
        DataTable serversInfo = SqlDataSourceEnumerator.Instance.GetDataSources();
        foreach (DataRow row in serversInfo.Rows)
            m_comboServerName.Items.Add(row["ServerName"]);
    }
    private void LoadDBs()
    {
        SqlConnection connection = null;
        try
        {
            SqlConnectionStringBuilder connStringBuilder =
                new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = m_comboServerName.Text;
            connStringBuilder.IntegratedSecurity = true;
            connStringBuilder.ConnectTimeout = 10;
            connection = new SqlConnection(connStringBuilder.ConnectionString);
            connection.Open();

            DataTable dbsInfo = connection.GetSchema("Databases");
            foreach (DataRow row in dbsInfo.Rows)
                m_comboDBName.Items.Add(row["database_name"]);
        }
        catch (SqlException exc)
        {
            if (exc.Number != 53 && exc.Number != 18456)
                throw exc;
        }
        finally
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
    private void LoadConnectionSettings(ConnectionSettings connSettings)
    {
        m_comboServerName.Text = connSettings.serverName;
        m_comboDBName.Text = connSettings.dbName;
        m_checkIntegratedSecurity.Checked = connSettings.integratedSecurity;
        m_textBoxLogin.Text = connSettings.login;
        m_texBoxPass.Text = connSettings.pass;
    }
    private void CheckConnetion()
    {
        try
        {
            Connection conn = new Connection(m_comboServerName.Text,
                m_comboDBName.Text, m_checkIntegratedSecurity.Checked,
                m_textBoxLogin.Text, m_texBoxPass.Text);
            conn.Open();
            conn.Close();

            m_isCheckConnection = true;
            MessageBox.Show("Соединение установлено.", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (SqlException)
        {
            MyMessageBox.ShowError("Не удалось соединиться с сервером.");
            m_isCheckConnection = false;
        }
    }
}

public class ConnectionSettingEventArgs : EventArgs
{
    public ConnectionSettings ConnectionSettings { get; }

    public ConnectionSettingEventArgs(ConnectionSettings connectionSettings)
    {
        ConnectionSettings = connectionSettings;
    }
}


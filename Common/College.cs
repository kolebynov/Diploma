using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

/// <summary>
/// Класс для работы с базой данных College.
/// </summary>
public class College : IDisposable
{
    public TableAdapterManager AdapterManager { get { return m_adapterManager; } }
    public Connection Connection { get; }

    public College(Connection connection)
    {
        Connection = connection;
        m_connection = connection.SqlConnection;
        InitAdapterManager();       
    }
    public College() : this(null)
    { }

    /// <summary>
    /// Получить данные о студентах в конкретной группе.
    /// </summary>
    /// <param name="groupId">Код группы.</param>
    /// <returns>Возвращает таблицу с данными о студентах.</returns>
    public CollegeDataSet.StudentsDataTable GetStudentsByGroup(int groupId)
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(
            GetCommandForStoredProc("GetStudentsByGroup", new ParameterDescr[]
            {
                new ParameterDescr("@groupId", groupId)
            })))
        {
            CollegeDataSet.StudentsDataTable temp = 
                new CollegeDataSet.StudentsDataTable();
            adapter.Fill(temp);

            return temp;
        }
    }
    /// <summary>
    /// Получение семестровой ведомости успеваемости.
    /// </summary>
    /// <param name="groupId">Код группы.</param>
    /// <param name="semester">Номер семестра.</param>
    /// <returns>Возвращает ведомость успеваемости.</returns>
    public DataTable GetProgressSheet(int groupId, short semester)
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(
            GetCommandForStoredProc("GetProgressSheet", new ParameterDescr[]
            {
                new ParameterDescr("@Group_id", groupId),
                new ParameterDescr("@Semester", semester)
            })))
        {
            DataTable temp = new DataTable();
            adapter.Fill(temp);

            return temp;
        }
    }
    /// <summary>
    /// Получить список семестров, в которых не стоит оценка у студента по
    /// заданному предмету.
    /// </summary>
    /// <param name="planId">Код записи плана с нужным предметом.</param>
    /// <param name="studentId">Код студента.</param>
    /// <returns>Возвращает массив номеров семестров.</returns>
    public short[] GetFreeSemestersForMark(int planId, int studentId)
    {
        using (DataTable table = GetDataFromStoredProc("GetFreeSemestersForMark",
            new ParameterDescr[]
            {
                new ParameterDescr("@planId", planId),
                new ParameterDescr("@studentId", studentId)
            }))
        {
            return table.Select().Select(row => (short)row.ItemArray[0]).ToArray();
        }
    }
    public void DeleteGroup(int groupId)
    {
        using (SqlCommand command = GetCommandForStoredProc("DeleteGroup",
            new ParameterDescr[]
            {
                new ParameterDescr("@groupId", groupId)
            }))
        {
            m_connection.Open();
            command.ExecuteNonQuery();
            m_connection.Close();
        }
    }
    /// <summary>
    /// Получить количество студентов в группе.
    /// </summary>
    /// <param name="groupId">Код группы.</param>
    /// <returns>Возвращает количество студентов в группе.</returns>
    public int GetCountStudentsInGroup(int groupId)
    {
        if (m_connection.State != ConnectionState.Open)
            m_connection.Open();
        int result = (int)GetCommandForStoredProc("GetCountStudentsInGroup",
            new ParameterDescr[]
            {
                new ParameterDescr("@groupId", groupId)
            }).ExecuteScalar();
        m_connection.Close();

        return result;
    }
    /// <summary>
    /// Получить список групп определенного отделения.
    /// </summary>
    /// <param name="groupTypeId">Код отделения.</param>
    /// <returns>Возвращает список групп в виде таблицы.</returns>
    public CollegeDataSet.GroupsDataTable GetGroupsByGroupTypeId(short groupTypeId)
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(
            GetCommandForStoredProc("GetGroupsByGroupTypeId",
            new ParameterDescr[]
            {
                new ParameterDescr("@groupTypeId", groupTypeId)
            })))
        {
            CollegeDataSet.GroupsDataTable temp = new CollegeDataSet.GroupsDataTable();
            adapter.Fill(temp);

            return temp;
        }
    }
    public CollegeDataSet.GroupsDataTable GetPlanNamesByGroupTypeId(short groupTypeId)
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(
            GetCommandForStoredProc("GetPlanNamesByGroupTypeId",
            new ParameterDescr[]
            {
                new ParameterDescr("@groupTypeId", groupTypeId)
            })))
        {
            CollegeDataSet.GroupsDataTable temp = new CollegeDataSet.GroupsDataTable();
            adapter.Fill(temp);

            return temp;
        }
    }
    /// <summary>
    /// Возвращает код записи в таблице, определяемой по некоторым значениям.
    /// </summary>
    /// <param name="tableName">Имя таблицы, для которой возвращается код записи.</param>
    /// <param name="idName">Имя столбца кода в таблице.</param>
    /// <param name="values">Массив значений, по которым ищется код записи.</param>
    /// <returns>Возвращает код записи.</returns>
    public object GetIdByValues(string tableName, string idName, ParameterDescr[] values)
    {
        if (m_connection.State != ConnectionState.Open)
            m_connection.Open();

        object result = GetCommandForSelect(new string[] { tableName },
            new string[] { idName }, values).ExecuteScalar();

        m_connection.Close();

        if (result == null)
            throw new EmptyResultException("Запрос ничего не вернул.");

        return result;
    }
    /// <summary>
    /// Возвращает план по конкретной группе.
    /// </summary>
    /// <param name="groupId">Код группы.</param>
    /// <returns>Возвращает таблицу с записями плана.</returns>
    public CollegeDataSet.PlansDataTable GetPlansByGroup(int groupId)
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(
            GetCommandForStoredProc("GetPlansByGroup", new ParameterDescr[] 
            {
                new ParameterDescr("@groupId", groupId)
            })))
        {
            CollegeDataSet.PlansDataTable temp = 
                new CollegeDataSet.PlansDataTable();
            adapter.Fill(temp);

            return temp;
        }
    }
    public CollegeDataSet.MarksDataTable GetMarksInSemester(int groupId, short semester)
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(GetCommandForStoredProc(
            "GetMarksInSemester", new ParameterDescr[]
            {
                new ParameterDescr("@groupId", groupId),
                new ParameterDescr("@semester", semester)
            })))
        {
            var temp = new CollegeDataSet.MarksDataTable();
            adapter.Fill(temp);

            return temp;
        }
    }
    public CollegeDataSet.SkipsDataTable GetSkipsInSemester(int groupId, short semester)
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(GetCommandForStoredProc(
            "GetSkipsInSemester", new ParameterDescr[]
            {
                new ParameterDescr("@groupId", groupId),
                new ParameterDescr("@semester", semester)
            })))
        {
            var temp = new CollegeDataSet.SkipsDataTable();
            adapter.Fill(temp);

            return temp;
        }
    }
    public CollegeDataSet.SubjectsDataTable GetSubjectsInSemester(int groupId, short semester)
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(
            GetCommandForStoredProc("GetSubjectsInSemester", new ParameterDescr[]
            {
                new ParameterDescr("@groupId", groupId),
                new ParameterDescr("@semester", semester),
            })))
        {
            var temp = new CollegeDataSet.SubjectsDataTable();
            adapter.Fill(temp);
            
            return temp;
        }
    }
    public CollegeDataSet.SemestersLengthDataTable GetSemestersLengthByGroup(int groupId)
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(
            GetCommandForStoredProc("GetSemestersLengthByGroup", new ParameterDescr[]
            {
                new ParameterDescr("@groupId", groupId)
            })))
        {
            CollegeDataSet.SemestersLengthDataTable temp =
                new CollegeDataSet.SemestersLengthDataTable();
            adapter.Fill(temp);

            return temp;
        }
    }
    public object IdentCurrent(string tableName)
    {
        using (SqlCommand comm = GetCommandForSQL(string.Format(
            "select IDENT_CURRENT('{0}')", tableName)))
        {
            if (m_connection.State != ConnectionState.Open)
                m_connection.Open();
            object result = comm.ExecuteScalar();
            m_connection.Close();

            return result;
        }
    }
    public CollegeDataSet.SemestersDataTable GetSemestersByPlan(int planId)
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(
            GetCommandForStoredProc("GetSemestersByPlan", new ParameterDescr[]
            {
                new ParameterDescr("@planId", planId)
            })))
        {
            CollegeDataSet.SemestersDataTable temp =
                new CollegeDataSet.SemestersDataTable();
            adapter.Fill(temp);

            return temp;
        }
    }
    public SqlCommand GetCommandForStoredProc(string procName,
        ParameterDescr[] parameters)
    {
        SqlCommand cmd = new SqlCommand(procName, m_connection);
        cmd.CommandType = CommandType.StoredProcedure;
        foreach (ParameterDescr param in parameters)
            cmd.Parameters.AddWithValue(param.name, param.value);

        return cmd;
    }
    public DataTable GetDataFromStoredProc(string procName,
        ParameterDescr[] parameters)
    {
        DataTable temp = new DataTable();
        new SqlDataAdapter(GetCommandForStoredProc(procName, parameters)).Fill(temp);

        return temp;
    }
    public SqlCommand GetCommandForSelect(string[] tableNames, string[] columnNames,
        ParameterDescr[] values)
    {
        StringBuilder sb = new StringBuilder("select ");
        for (int i = 0; i < columnNames.Length; i++)
        {
            sb.Append(columnNames[i]);
            if (i < columnNames.Length - 1)
                sb.Append(',');
        }
        sb.Append(" from ");
        for (int i = 0; i < tableNames.Length; i++)
        {
            sb.Append(tableNames[i]);
            if (i < tableNames.Length - 1)
                sb.Append(',');
        }
        if (values != null && values.Length > 0)
        {
            sb.Append(" where ");
            foreach (ParameterDescr paramDescr in values)
            {
                sb.Append(string.Format("{0}={1}", paramDescr.name,
                    "@" + paramDescr.name));
            }
        }

        SqlCommand cmd = new SqlCommand(sb.ToString(), m_connection);
        cmd.CommandType = CommandType.Text;
        foreach (ParameterDescr paramDescr in values)
            cmd.Parameters.AddWithValue("@" + paramDescr.name, paramDescr.value);

        return cmd;
    }
    public SqlCommand GetCommandForSQL(string query)
    {
        return new SqlCommand(query, m_connection) { CommandType = CommandType.Text };
    }
    public void Dispose()
    {
        m_adapterManager.Dispose();
    }

    private TableAdapterManager m_adapterManager;
    private SqlConnection m_connection;

    private void InitAdapterManager()
    {
        m_adapterManager = new TableAdapterManager();
        m_adapterManager.Connection = m_connection;
        m_adapterManager.GroupsTableAdapter = new GroupsTableAdapter();
        m_adapterManager.GroupsTableAdapter.Connection = m_connection;
        m_adapterManager.GroupTypesTableAdapter = new GroupTypesTableAdapter();
        m_adapterManager.GroupTypesTableAdapter.Connection = m_connection;
        m_adapterManager.MarksTableAdapter = new MarksTableAdapter();
        m_adapterManager.MarksTableAdapter.Connection = m_connection;
        m_adapterManager.MarkTypesTableAdapter = new MarkTypesTableAdapter();
        m_adapterManager.MarkTypesTableAdapter.Connection = m_connection;
        m_adapterManager.PlansTableAdapter = new PlansTableAdapter();
        m_adapterManager.PlansTableAdapter.Connection = m_connection;
        m_adapterManager.SemestersLengthTableAdapter = new SemestersLengthTableAdapter();
        m_adapterManager.SemestersLengthTableAdapter.Connection = m_connection;
        m_adapterManager.SemestersTableAdapter = new SemestersTableAdapter();
        m_adapterManager.SemestersTableAdapter.Connection = m_connection;
        m_adapterManager.SkipsTableAdapter = new SkipsTableAdapter();
        m_adapterManager.SkipsTableAdapter.Connection = m_connection;
        m_adapterManager.StudentsTableAdapter = new StudentsTableAdapter();
        m_adapterManager.StudentsTableAdapter.Connection = m_connection;
        m_adapterManager.SubjectsTableAdapter = new SubjectsTableAdapter();
        m_adapterManager.SubjectsTableAdapter.Connection = m_connection;
        m_adapterManager.SubjectTypesTableAdapter = new SubjectTypesTableAdapter();
        m_adapterManager.SubjectTypesTableAdapter.Connection = m_connection;
    }
}

public struct ParameterDescr
{
    public string name;
    public object value;

    public ParameterDescr(string name, object value)
    {
        this.name = name;
        this.value = value;
    }
}

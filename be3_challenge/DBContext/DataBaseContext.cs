using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace be3_challenge.DBContext
{
    public class DataBaseContext
    {
        /// <summary>
        /// Propriedade que armazena a string de conexão.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Método que monta a conexão e devolve para uso dos métodos de chamada.
        /// </summary>
        /// <returns>Devolve um objeto do tipo SqlConnection.</returns>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(this.ConnectionString);
        }

        /// <summary>
        /// Método que faz a busca de um objeto do banco.
        /// <para>Deve ser informado os parâmetros para filtrar o objeto. Ex.: Chave primária.</para>
        /// </summary>
        /// <param name="objParm">Objeto contendo os atributos(colunas) que vão ser recuperados do banco.</param>
        /// <param name="objName">Nome da tabela que vai ser recuperada do banco.</param>
        /// <param name="whereParm">Filtro informando chave/valor do que deve ser recuperado.</param>
        /// <param name="columnFilter">Filtros com os nomes das colunas separados por vírgula ou "*" caso queira o objeto completo.</param>
        /// <returns>Retorna um objeto dinamicamente.</returns>
        public dynamic GetSingleData(object objParm, string objName, string whereParm, string columnFilter)
        {
            try
            {
                PropertyInfo[] properties = objParm.GetType().GetProperties();
                dynamic objRet = new ExpandoObject();
                IDictionary<string, object> iDic = objRet;

                string sql = "select ";

                if (!string.IsNullOrEmpty(columnFilter))
                    sql += $"{columnFilter} from {objName} ";

                if (!string.IsNullOrEmpty(whereParm))
                    sql += $"{whereParm} ";

                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                foreach (PropertyInfo property in properties)
                                {
                                    if (property.PropertyType == typeof(int))
                                    {
                                        iDic.Add(property.Name, Convert.ToInt32(reader[property.Name])); // Adding dynamically named property
                                        continue;
                                    }

                                    if (property.PropertyType == typeof(string))
                                    {
                                        iDic.Add(property.Name, reader[property.Name].ToString());
                                        continue;
                                    }

                                    if (property.PropertyType == typeof(DateTime))
                                    {
                                        iDic.Add(property.Name, Convert.ToDateTime(reader[property.Name]));
                                        continue;
                                    }

                                    iDic.Add(property.Name, reader[property.Name]);
                                }
                            }
                            catch (Exception) { }
                        }
                    }
                }

                return objRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que faz a busca de uma lista de objetos do banco.
        /// </summary>
        /// <param name="objParm">Objeto contendo os atributos(colunas) que vão ser recuperados do banco.</param>
        /// <param name="objName">Nome da tabela que vai ser recuperada do banco.</param>
        /// <returns>Retorna uma lista de objetos dinamicamente.</returns>
        public dynamic GetData(object objParm, string objName)
        {
            try
            {
                PropertyInfo[] properties = objParm.GetType().GetProperties();
                dynamic objRet = new ExpandoObject();
                IDictionary<string, object> iDic = objRet;

                string sql = $"select * from {objName}";

                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                foreach (PropertyInfo property in properties)
                                {
                                    if (property.PropertyType == typeof(int))
                                    {
                                        iDic.Add(property.Name, Convert.ToInt32(reader[property.Name])); // Adding dynamically named property
                                        continue;
                                    }

                                    if (property.PropertyType == typeof(string))
                                    {
                                        iDic.Add(property.Name, reader[property.Name].ToString());
                                        continue;
                                    }

                                    if (property.PropertyType == typeof(DateTime))
                                    {
                                        iDic.Add(property.Name, Convert.ToDateTime(reader[property.Name]));
                                        continue;
                                    }

                                    iDic.Add(property.Name, reader[property.Name]);
                                }
                            }
                            catch (Exception) { }
                        }
                    }
                }

                return objRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que insere uma linha por vez no banco.
        /// <para>Na classe deve ser informado quais atributos são chave primária e quais devem ser ignorados.</para>
        /// </summary>
        /// <param name="objParm">Objeto/Classe com os dados para serem inseridos no banco.</param>
        /// <param name="objName">Nome da tabela que vai ser recuperada do banco.</param>
        public void InsertData(object objParm, string objName)
        {
            try
            {
                PropertyInfo[] properties = objParm.GetType().GetProperties();
                dynamic objRet = new ExpandoObject();
                IDictionary<string, object> iDic = objRet;

                string sql = $"INSERT INTO {objName} ";
                StringBuilder tblColumns = new StringBuilder();
                StringBuilder tblValues = new StringBuilder();
                try
                {
                    foreach (PropertyInfo property in properties)
                    {
                        object[] attributeDescription = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
                        DescriptionAttribute description = attributeDescription.Length > 0 ? (DescriptionAttribute)attributeDescription[0] : null;
                        string validateText = description != null ? description.Description : string.Empty;

                        if (validateText.Equals("PRIMARYKEY") || validateText.Equals("IGNORE"))
                            continue;

                        if(property.GetValue(objParm) == null)
                        {
                            tblColumns.Append($"{property.Name.ToUpper()}, ");
                            tblValues.Append($"null, ");
                            continue;
                        }

                        if (property.PropertyType == typeof(int))
                        {
                            tblColumns.Append($"{property.Name.ToUpper()}, ");
                            tblValues.Append($"{property.GetValue(objParm)}, ");
                            continue;
                        }

                        if (property.PropertyType == typeof(DateTime))
                        {
                            tblColumns.Append($"{property.Name.ToUpper()}, ");
                            tblValues.Append($"CONVERT(DATETIME, '{((DateTime)property.GetValue(objParm)).ToString("yyyy-MM-dd")}', 102), ");
                            continue;
                        }

                        tblColumns.Append($"{property.Name.ToUpper()}, ");
                        tblValues.Append($"'{property.GetValue(objParm)}', ");
                    }

                    if (tblColumns.Length > 0)
                        tblColumns.Length -= 2;
                    if (tblValues.Length > 0)
                        tblValues.Length -= 2;

                    sql += $"({tblColumns}) VALUES({tblValues})";
                }
                catch (Exception) { }

                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    SqlTransaction transaction;

                    transaction = conn.BeginTransaction("ObjectTransaction");

                    command.Connection = conn;
                    command.Transaction = transaction;

                    try
                    {
                        command.CommandText = sql;
                        int rowAfected = command.ExecuteNonQuery();

                        if (rowAfected > 0)
                            transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception) { }
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que insere uma linha por vez no banco.
        /// <para>Na classe deve ser informado quais atributos são chave primária e quais devem ser ignorados.</para>
        /// </summary>
        /// <param name="objParm">Objeto/Classe com os dados para serem inseridos no banco.</param>
        /// <param name="objName">Nome da tabela que vai ser recuperada do banco.</param>
        public dynamic InsertDataAlignReturn(object objParm, string objName)
        {
            try
            {
                PropertyInfo[] properties = objParm.GetType().GetProperties();
                dynamic objRet = new ExpandoObject();
                IDictionary<string, object> iDic = objRet;
                StringBuilder tblColumns = new StringBuilder();
                StringBuilder tblValues = new StringBuilder();
                string sql = $"INSERT INTO {objName} ";

                try
                {
                    foreach (PropertyInfo property in properties)
                    {
                        object[] attributeDescription = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
                        DescriptionAttribute description = attributeDescription.Length > 0 ? (DescriptionAttribute)attributeDescription[0] : null;
                        string validateText = description != null ? description.Description : string.Empty;

                        if (validateText.Equals("PRIMARYKEY") || validateText.Equals("IGNORE"))
                            continue;
                        
                        if (property.GetValue(objParm) == null)
                        {
                            tblColumns.Append($"{property.Name.ToUpper()}, ");
                            tblValues.Append($"null, ");
                            continue;
                        }

                        if (property.PropertyType == typeof(int))
                        {
                            tblColumns.Append($"{property.Name.ToUpper()}, ");
                            tblValues.Append($"{property.GetValue(objParm)}, ");
                            continue;
                        }

                        if (property.PropertyType == typeof(DateTime))
                        {
                            tblColumns.Append($"{property.Name.ToUpper()}, ");
                            tblValues.Append($"CONVERT(DATETIME, '{((DateTime)property.GetValue(objParm)).ToString("yyyy-MM-dd")}', 102), ");
                            continue;
                        }

                        tblColumns.Append($"{property.Name.ToUpper()}, ");
                        tblValues.Append($"'{property.GetValue(objParm)}', ");
                    }

                    if (tblColumns.Length > 0)
                        tblColumns.Length -= 2;
                    if (tblValues.Length > 0)
                        tblValues.Length -= 2;

                    sql += $"({tblColumns}) VALUES({tblValues})";
                }
                catch (Exception) { }

                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    SqlTransaction transaction;

                    transaction = conn.BeginTransaction("ObjectTransaction");

                    command.Connection = conn;
                    command.Transaction = transaction;

                    try
                    {
                        command.CommandText = sql;
                        int rowAfected = command.ExecuteNonQuery();

                        if (rowAfected > 0)
                        {
                            transaction.Commit();
                            objRet = QueryReadable($"select * from {objName} where id = (select max(ID) from {objName})").FirstOrDefault();
                            return objRet;
                        }
                        return null;
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception) { }
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Método que insere uma linha por vez no banco.
        /// <para>Na classe deve ser informado quais atributos são chave primária e quais devem ser ignorados se necessário.</para>
        /// </summary>
        /// <param name="objParm">Objeto/Classe com os dados para serem inseridos no banco.</param>
        /// <param name="objName">Nome da tabela que vai ser recuperada do banco.</param>
        public void UpdateData(object objParm, string objName)
        {
            try
            {
                PropertyInfo[] properties = objParm.GetType().GetProperties();
                dynamic objRet = new ExpandoObject();
                IDictionary<string, object> iDic = objRet;
                StringBuilder whereParam = null;

                string sql = $"UPDATE {objName} SET ";
                StringBuilder tblColumns = new StringBuilder();
                try
                {
                    foreach (PropertyInfo property in properties)
                    {
                        object[] attributeDescription = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
                        DescriptionAttribute description = attributeDescription.Length > 0 ? (DescriptionAttribute)attributeDescription[0] : null;
                        string validateText = description != null ? description.Description : string.Empty;

                        if (validateText.Equals("PRIMARYKEY"))
                        {
                            if (whereParam == null)
                            {
                                whereParam = new StringBuilder();
                                whereParam.Append($" WHERE {property.Name.ToUpper()} = {property.GetValue(objParm)} ");
                            }
                            else
                                whereParam.Append($" AND {property.Name.ToUpper()} = {property.GetValue(objParm)} ");

                            continue;
                        }

                        if (validateText.Equals("IGNORE"))
                            continue;
                        
                        if (property.GetValue(objParm) == null)
                        {
                            tblColumns.Append($"{property.Name.ToUpper()} = null, ");
                            continue;
                        }

                        if (property.PropertyType == typeof(int))
                        {
                            tblColumns.Append($"{property.Name.ToUpper()} = {property.GetValue(objParm)}, ");
                            continue;
                        }

                        if (property.PropertyType == typeof(DateTime))
                        {
                            tblColumns.Append($"{property.Name.ToUpper()} = CONVERT(DATETIME, '{((DateTime)property.GetValue(objParm)).ToString("yyyy-MM-dd")}', 102), ");
                            continue;
                        }

                        tblColumns.Append($"{property.Name.ToUpper()} = '{property.GetValue(objParm)}', ");
                    }

                    if (tblColumns.Length > 0)
                        tblColumns.Length -= 2;

                    sql += $"{tblColumns}{whereParam}";
                }
                catch (Exception) { }

                if (string.IsNullOrEmpty(whereParam.ToString()))
                    throw new Exception("Chaves primárias não localizadas.");

                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    SqlTransaction transaction;

                    transaction = conn.BeginTransaction("ObjectTransaction");

                    command.Connection = conn;
                    command.Transaction = transaction;

                    try
                    {
                        command.CommandText = sql;
                        int rowAfected = command.ExecuteNonQuery();

                        if (rowAfected > 0)
                            transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception) { }
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que recebe como parâmetro uma query do tipo seleção e devolve uma lista dinâmica com os objetos obtidos.
        /// </summary>
        /// <param name="sql">Query parâmetro de entrada do tipo Select</param>
        /// <returns>Retorna uma lista de objetos dinâmicos com base na query parâmetro de entrada.</returns>
        public List<dynamic> QueryReadable(string sql)
        {
            if (sql.Contains("CREATE") || sql.Contains("UPDATE") || sql.Contains("ALTER") || sql.Contains("DELETE"))
                return null;

            try
            {
                List<dynamic> objRet = new List<dynamic>();

                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                dynamic dynamicObject = new ExpandoObject();
                                IDictionary<string, object> iDic = dynamicObject;

                                for (int i = 0; i < reader.FieldCount; i++)
                                {

                                    if (reader.GetFieldType(i) == typeof(string))
                                        iDic.Add(reader.GetName(i), reader.GetString(i));

                                    if (reader.GetFieldType(i) == typeof(Int64))
                                        iDic.Add(reader.GetName(i), reader.GetInt64(i));

                                    if (reader.GetFieldType(i) == typeof(DateTime))
                                        iDic.Add(reader.GetName(i), reader.GetDateTime(i));

                                    if (reader.GetFieldType(i) == typeof(Int32))
                                        iDic.Add(reader.GetName(i), reader.GetInt32(i));

                                }
                                objRet.Add(dynamicObject);
                            }
                            catch (Exception) { }
                        }
                    }
                }

                return objRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CheckSchema()
        {
            string sql = @"
            IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'DBDB4009' 
                 AND  TABLE_NAME = 'REGISTRO_PACIENTE'))
            BEGIN
                CREATE TABLE [REGISTRO_PACIENTE] (
                    ID bigint NOT NULL IDENTITY(1,1),
                    PRONTUARIO bigint,
                    NOME varchar(255),
                    DATANASCIMENTO DATETIME,
                    GENERO varchar(20),
                    CPF bigint,
                    RG varchar(255),
                    UFEXPEDICAORG varchar(2),
                    EMAIL varchar(255),
                    CELULARNUMERO bigint,
                    TELEFONEFIXONUMERO bigint,
                    PRIMARY KEY (ID));
            END
            IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'DBDB4009' 
                 AND  TABLE_NAME = 'CONVENIO'))
            BEGIN
                CREATE TABLE [CONVENIO] (
                    ID bigint NOT NULL IDENTITY(1,1),
                    CONVENIO varchar(255),
                    CARTEIRACONVENIO varchar(255),
                    VALIDADEMESANO varchar(255),
                    PACIENTEID bigint,
                    PRIMARY KEY (ID));
            END";

            //string sql = @"DROP TABLE [REGISTRO_PACIENTE]; DROP TABLE [CONVENIO]";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.Connection = conn;

                try
                {
                    command.CommandText = sql;
                    int rowAfected = command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    //throw ex;
                }
            }
        }

        /// <summary>
        /// Construtor que possibilita criar uma instância única recebendo a connection string por parâmetro.
        /// </summary>
        /// <param name="connectionString">Connection string paramatrizável.</param>
        public DataBaseContext(string connectionString)
        {
            this.ConnectionString = connectionString;
            //CheckSchema();
        }

        /// <summary>
        /// Construtor que define a connection string padrão.
        /// </summary>
        public DataBaseContext()
        {
            this.ConnectionString = "Server=db_sql.be3.co,1515;Database=DB4009;User Id=raythan.machado;Password=ProcSeletivo#2020;";
            //CheckSchema();
        }
    }
}
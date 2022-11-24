using Microsoft.Data.SqlClient;

namespace PatientDoctorApp.Models;

/// <summary>
/// This is the model class for the Document table.
/// </summary>
public class Document
{
    public string? DocumentId { get; set; }
    public string? DoctorId { get; set; }
    /*
    public enum DocumentType { TestReport, Note, Diagnosis }
    */
    public string? PatientId { get; set; }
    public string? AppointmentId { get; set; }
    public DateTime Date { get; set; }

    public int Type { get; set; }
    
    public string? Note { get; set; }
    
    public string? TestName { get; set; }
    
    public DateTime TestDate { get; set; }
    
    public string? TestResult { get; set; }
    
    public string? FilePathTestReport { get; set; }
    
    public string? ConditionStatus { get; set; }
    
    public string? Prescriptions { get; set; }
    
    public string? Remarks { get; set; }
    
    /// <summary>
    /// This function saves the document to the database.
    /// </summary>
    /// <returns>an integer</returns>
    public int SaveDocument()
    {
        SqlConnection con = new SqlConnection(GetConnection.GetSqlConnection());
        string query = "INSERT INTO Document (DocumentId, DoctorId, PatientId, AppointmentId, Date, type, Note,  TestName, TestDate, TestResult, FilePathTestReport, ConditionStatus, Prescriptions, Remarks) VALUES (@DocumentId, @DoctorId, @PatientId, @AppointmentId, @Date, @type, @Note, @TestName, @TestDate, @TestResult, @FilePathTestReport, @ConditionStatus, @Prescriptions, @Remarks)";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlParameter DocumentId =  cmd.Parameters.AddWithValue("@DocumentId", this.DocumentId);
        if (DocumentId.Value == null)
        {
            DocumentId.Value = DBNull.Value;
        }
        SqlParameter DoctorId =  cmd.Parameters.AddWithValue("@DoctorId", this.DoctorId);
        if (DoctorId.Value == null)
        {
            DoctorId.Value = DBNull.Value;
        }
        SqlParameter PatientId =  cmd.Parameters.AddWithValue("@PatientId", this.PatientId);
        if (PatientId.Value == null)
        {
            PatientId.Value = DBNull.Value;
        }
        SqlParameter AppointmentId =  cmd.Parameters.AddWithValue("@AppointmentId", this.AppointmentId);
        if (AppointmentId.Value == null)
        {
            AppointmentId.Value = DBNull.Value;
        }
        SqlParameter Date =  cmd.Parameters.AddWithValue("@Date", this.Date);
        if (Date.Value == null)
        {
            Date.Value = DateTime.Now;
        }
        SqlParameter type =  cmd.Parameters.AddWithValue("@type", this.Type);
        if (type.Value == null)
        {
            type.Value = DBNull.Value;
        }
        SqlParameter TestName =  cmd.Parameters.AddWithValue("@TestName", this.TestName);
        if (TestName.Value == null)
        {
            TestName.Value = DBNull.Value;
        }
        SqlParameter TestDate =  cmd.Parameters.AddWithValue("@TestDate", this.TestDate);
        if (TestDate.Value == null)
        {
            TestDate.Value = DateTime.Now;
        }
        SqlParameter TestResult =  cmd.Parameters.AddWithValue("@TestResult", this.TestResult);
        if (TestResult.Value == null)
        {
            TestResult.Value = DBNull.Value;
        }
        SqlParameter FilePathTestReport =  cmd.Parameters.AddWithValue("@FilePathTestReport", this.FilePathTestReport);
        if (FilePathTestReport.Value == null)
        {
            FilePathTestReport.Value = DBNull.Value;
        }
        SqlParameter ConditionStatus =  cmd.Parameters.AddWithValue("@ConditionStatus", this.ConditionStatus);
        if (ConditionStatus.Value == null)
        {
            ConditionStatus.Value = DBNull.Value;
        }
        SqlParameter Prescriptions =  cmd.Parameters.AddWithValue("@Prescriptions", this.Prescriptions);
        if (Prescriptions.Value == null)
        {
            Prescriptions.Value = DBNull.Value;
        }
        SqlParameter Remarks =  cmd.Parameters.AddWithValue("@Remarks", this.Remarks);
        if (Remarks.Value == null)
        {
            Remarks.Value = DBNull.Value;
        }
        SqlParameter Note =  cmd.Parameters.AddWithValue("@Note", this.Note);
        if (Note.Value == null)
        {
            Note.Value = DBNull.Value;
        }
        
        con.Open();
        var i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    
}


/// <summary>
/// This static class is used to get the connection string.
/// </summary>
public static class GetConnection
{
    /// <summary>
    /// This function returns the connection string.
    /// </summary>
    /// <returns>The connection String</returns>
    public static string GetSqlConnection()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        var configuration = builder.Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        return connectionString;
    }
}

/// <summary>
/// This enum is used to define the type of document.
/// </summary>
public enum type
{
    TestReport = 1,
    Note = 2,
    Diagnosis = 3
}


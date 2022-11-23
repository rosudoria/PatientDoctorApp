using Microsoft.Data.SqlClient;

namespace PatientDoctorApp.Models;

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

    public type Type { get; set; }
    
    public string? Note { get; set; }
    
    public string? TestName { get; set; }
    
    public DateTime TestDate { get; set; }
    
    public string? TestResult { get; set; }
    
    public string? FilePathTestReport { get; set; }
    
    public string? ConditionStatus { get; set; }
    
    public string? Presciptions { get; set; }
    
    public string? Remarks { get; set; }
    
    public int SaveTestReport()
    {
        SqlConnection con = new SqlConnection(GetConnection.GetSqlConnection()); 
        string query = ("INSERT INTO Documents (DocumentId, DoctorId, PatientId, AppointmentId, Date, Type, TestName, TestDate, TestResult, FilePathTestReport) VALUES (@DocumentId, @DoctorId, @PatientId, @AppointmentId, @Date, @Type, @TestName, @TestDate, @TestResult, @FilePathTestReport)");
        SqlCommand cmd = new SqlCommand(query, con);
        con.Open();
        var i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    
}

public static class GetConnection
{
    public static string GetSqlConnection()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        var configuration = builder.Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        return connectionString;
    }
}

public enum type
{ 
    TestReport,
    Note,
    Diagnosis
}


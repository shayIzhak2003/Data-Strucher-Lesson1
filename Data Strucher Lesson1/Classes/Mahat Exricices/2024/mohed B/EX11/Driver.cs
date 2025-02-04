using System;

public class Driver
{
    private string id;               // מספר תעודת זהות
    private string name;             // שם הנהג
    private string licenseNumber;     // מספר רישיון
    private string dateOfBirth;       // תאריך לידה
    private int trafficOffenses;      // מספר עבירות תנועה
    private bool isActive;            // סטטוס רישיון (פעיל/מושבת)

    // **Constructor**
    public Driver(string id, string name, string licenseNumber, string dateOfBirth, int trafficOffenses, bool isActive)
    {
        this.id = id;
        this.name = name;
        this.licenseNumber = licenseNumber;
        this.dateOfBirth = dateOfBirth;
        this.trafficOffenses = trafficOffenses;
        this.isActive = isActive;
    }

    // **Get & Set Methods**
    public string GetId() { return id; }
    public void SetId(string id) { this.id = id; }

    public string GetName() { return name; }
    public void SetName(string name) { this.name = name; }

    public string GetLicenseNumber() { return licenseNumber; }
    public void SetLicenseNumber(string licenseNumber) { this.licenseNumber = licenseNumber; }

    public string GetDateOfBirth() { return dateOfBirth; }
    public void SetDateOfBirth(string dateOfBirth) { this.dateOfBirth = dateOfBirth; }

    public int GetTrafficOffenses() { return trafficOffenses; }
    public void SetTrafficOffenses(int trafficOffenses) { this.trafficOffenses = trafficOffenses; }

    public bool IsActive() { return isActive; }
    public void SetActive(bool isActive) { this.isActive = isActive; }

    // **Method to Calculate Age**
    public int GetAge()
    {
        DateTime birthDate = DateTime.Parse(dateOfBirth);
        int age = DateTime.Now.Year - birthDate.Year;
        if (DateTime.Now < birthDate.AddYears(age))
            age--;
        return age;
    }

    // **ToString Method**
    public override string ToString()
    {
        return $"Driver ID: {id}, Name: {name}, License: {licenseNumber}, DOB: {dateOfBirth}, Age: {GetAge()}, Offenses: {trafficOffenses}, Active: {isActive}";
    }
}

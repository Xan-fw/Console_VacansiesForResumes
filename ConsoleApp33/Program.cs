using System.Text;

namespace ConsoleApp33
{//ctrl + A + M
    // Validator class for validation methods
    public static partial class Validator
    {
        public static void CheckPassword(in string _password)
        {
        }

        public static bool IsValidGmail(in string _gmail)
        {
            return false;
        }

        public static bool CheckEmployerIsSummaryListToFolder(in string _folderPath)
        {
            return false;
        }
    }

    public class Person
    {

        public string _Name = "Empty";
        public string _Surname = "Empty";
        public string _FatherName = "Empty";


        public DateTime _DateOfBirth;


        public Person() { }


        public Person(in string name, in string surname, in string fatherName, in DateTime dateOfBirth)
        {
            _Name = name;
            _Surname = surname;
            _FatherName = fatherName;
            // Create a DateTime object from the provided day, month, and year
            _DateOfBirth = dateOfBirth;
        }


        public Person(in Person person)
        {
            _Name = person._Name;
            _Surname = person._Surname;
            _FatherName = person._FatherName;
            _DateOfBirth = person._DateOfBirth;
        }


        public string GetInfo()
        {
            return $"{_Name} {_Surname} {_FatherName}\n{_DateOfBirth.ToString("dd/MM/yyyy")}\n";
        }
    }

    #region ----------- Interface ------------
    // IComputerVision interface
    public interface IComputerVision
    {
        abstract bool AnalyzeJobPosting();
    }

    // AccountInterface interface for account-related methods
    public interface IEmployerInterface
    {
        public void DeleteVacancy(byte index);
        public void DeleteAccount();
        public void SavingAccount();
        public void CreateVacancy(in string title, in string description, in float salary, byte experienceRequired);
    }

    // AccountInterface interface for account-related methods
    public interface IApplicantInterface
    {
        public void DeleteSummary(byte index);
        public void DeleteAccount();
        public void SavingAccount();
        public void CreateSummary(in string summary, in string post, byte experience);
    }

    #endregion

    // IdentifyingInformation class to store Gmail and phone number information
    public class IdentifyingInformation
    {
        public string _Gmail = "Empty";
        public string _PhoneNumber = "Empty";

        private const byte _PhoneNumberSize = 20;

        public IdentifyingInformation() { }

        public IdentifyingInformation(in IdentifyingInformation identifInfo)
        {
            _Gmail = identifInfo._Gmail;
            _PhoneNumber = identifInfo._PhoneNumber;
        }

        public IdentifyingInformation(in string phoneNumber, in string gmail)
        {
            _PhoneNumber = phoneNumber;
            _Gmail = gmail;
        }

        public string GetInfo()
        {
            return _PhoneNumber + "\n" + _Gmail + "\n";
        }
    }

    // Summary class to store a summary of a person's information
    public class Summary
    {
        public string _SummaryText = "Empty";
        public string _Post = "Empty";
        public byte _Experience = 0;

        public List<Vacancy>? _VacansyList { get; set; }
        public List<Vacancy>? _MyApplications { get; set; } = new List<Vacancy>();

        public string? SummaryPath = null;

        private const Int16 _SummarySymbolSize = 2000;
        private const byte _PostSymbolSize = 20;

        public Summary() { }

        public Summary(in Summary other)
        {
            _Post = other._Post;
            _SummaryText = other._SummaryText;
            _Experience = other._Experience;
            _VacansyList = new List<Vacancy>(other._VacansyList);
            _MyApplications = new List<Vacancy>(other._MyApplications);
        }

        public Summary(in string post, byte experience, in string summary)
        {
            _Post = post;
            _Experience = experience;
            _SummaryText = summary;
        }

        public string GetSummaryInfo()
        {
            return $"Position: {_Post}\nExperience: {_Experience} year(s)\nSummary Text: {_SummaryText}\n";
        }

    }

    // Vacancy class to store information about a job vacancy
    public class Vacancy
    {
        public string _Title = "Empty"; //progrsammer C#
        public string _Description = "Empty";
        public float _Salary = 0.0f;
        public byte _ExperienceRequired = 0;
        public IdentifyingInformation _identiinfo;
        public List<Summary>? _ResumeList { get; set; }
        public List<Summary>? _QualifiedApplicants { get; set; } = new List<Summary>();

        public string? VacansyPath = null;
        // Default constructor
        public Vacancy() { }

        public Vacancy(in Vacancy other)
        {
            _Title = other._Title;
            _Description = other._Description;
            _Salary = other._Salary;
            _ExperienceRequired = other._ExperienceRequired;
            _identiinfo = other._identiinfo;
            _ResumeList = new List<Summary>(other._ResumeList);
            _QualifiedApplicants = new List<Summary>(other._QualifiedApplicants);
        }

        // Parameterized constructor to initialize a Vacancy object with provided information
        public Vacancy(in string title, in string description, in float salary,
            byte experienceRequired, in IdentifyingInformation identiInfo)
        {
            _Title = title;
            _Description = description;
            _Salary = salary;
            _ExperienceRequired = experienceRequired;
            _identiinfo = identiInfo;
        }

        // Method to get formatted information about the job vacancy
        public string GetVacancyInfo()
        {
            return $"Title: {_Title}\nDescription: {_Description}\nSalary: {_Salary}" +
                $"\nExperience Required: {_ExperienceRequired} years\nEmail: {_identiinfo._Gmail}\nPhone Number: {_identiinfo._PhoneNumber}";
        }
    }

    // LoginAndPassword class to store login and password information
    public class LoginAndPassword
    {
        public string _Login = "Empty";
        public string _Password = "Empty";
        private const byte _LoginSize = 20;
        private const byte _PasswordSize = 20;

        public LoginAndPassword() { }

        public LoginAndPassword(in LoginAndPassword logPaswrd)
        {
            _Login = logPaswrd._Login;
            _Password = logPaswrd._Password;
        }

        public LoginAndPassword(in string login, in string password)
        {
            _Login = login;
            _Password = password;
        }
    }

    #region ---------------- File Menagers ----------------

    // FileManager class to manage the file directories for different account types
    public class ServerFileManager
    {
        private static string _Server { get; } = Path.Combine("C:", "Server");
        private static string _Accounts { get; } = Path.Combine(_Server, "AccountsInformation");
        private static string _Summaries { get; } = Path.Combine(_Server, "SummariesAndVacancies");
        public static string _EmployerAccounts { get; } = Path.Combine(_Accounts, "EmployerAccounts");
        public static string _ApplicantAccounts { get; } = Path.Combine(_Accounts, "ApplicantAccounts");
        public static string _EmployerAccountsVakancies { get; } = Path.Combine(_Summaries, "EmployerVakancies");
        public static string _ApplicantAccountsSummaries { get; } = Path.Combine(_Summaries, "ApplicantSummaries");

        public ServerFileManager()
        {
            if (Directory.Exists(_Server) && Directory.Exists(_Accounts) && Directory.Exists(_Summaries) &&
                Directory.Exists(_EmployerAccounts) && Directory.Exists(_ApplicantAccounts) &&
                Directory.Exists(_EmployerAccountsVakancies) && Directory.Exists(_ApplicantAccountsSummaries))
            {
                return;
            }
            Directory.CreateDirectory(_Server);
            Directory.CreateDirectory(_Accounts);
            Directory.CreateDirectory(_Summaries);
            Directory.CreateDirectory(_EmployerAccounts);
            Directory.CreateDirectory(_ApplicantAccounts);
            Directory.CreateDirectory(_EmployerAccountsVakancies);
            Directory.CreateDirectory(_ApplicantAccountsSummaries);
        }
    }

    public static class AccountFileUtils
    {
        public const string LoginAndPasswordFolderName = "LoginAndPassword";
        public static string GetAccountFolderName(in Account account)
        {
            return $"{account._LoginPassword._Login} {account._LoginPassword._Password} {account._IdentifyingInfo._Gmail}";
        }

        public static void WriteAccountToFile(in Account account, in string accountFilePath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(accountFilePath, FileMode.Create)))
            {
                writer.Write(account._AccountID);
                writer.Write(account._Person._Name);
                writer.Write(account._Person._Surname);
                writer.Write(account._Person._FatherName);
                writer.Write(account._Person._DateOfBirth.Ticks);
                writer.Write(account._IdentifyingInfo._PhoneNumber);
                writer.Write(account._IdentifyingInfo._Gmail);
            }
        }

        // Метод для чтения Account из файла
        public static Account ReadAccountFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new Account();
            }

            Account account = new Account();

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                account._AccountID = reader.ReadString();
                account._Person._Name = reader.ReadString();
                account._Person._Surname = reader.ReadString();
                account._Person._FatherName = reader.ReadString();
                account._Person._DateOfBirth = new DateTime(reader.ReadInt64());
                account._IdentifyingInfo._PhoneNumber = reader.ReadString();
                account._IdentifyingInfo._Gmail = reader.ReadString();
            }

            return account;
        }


        // Метод для чтения LoginAndPassword из папки
        public static LoginAndPassword ReadLoginAndPasswordFromFolder(string folderPath)
        {
            string filePath = Path.Combine(folderPath, $"{LoginAndPasswordFolderName}.bin");

            if (!File.Exists(filePath))
            {
                return null;
            }

            LoginAndPassword loginAndPassword = new LoginAndPassword();

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                loginAndPassword._Login = reader.ReadString();
                loginAndPassword._Password = reader.ReadString();
            }

            return loginAndPassword;
        }

        // Метод для записи LoginAndPassword в папку
        public static void WriteLoginAndPasswordToFolder(LoginAndPassword loginAndPassword, string folderPath)
        {
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"{LoginAndPasswordFolderName}.bin");

            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(loginAndPassword._Login);
                writer.Write(loginAndPassword._Password);
            }
        }
    }

    #region Work To Applicant
    // Class for working with Applicant resumes
    public static class ApplicantSummaryFileManagerUtils
    {
        // Write Summary To File
        public static void WriteSummaryToFile(in Summary summary, in string path)
        {
            if (summary == null || Directory.Exists(path)) { return; }
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(summary._SummaryText);
                writer.Write(summary._Post);
                writer.Write(summary._Experience);
            }
        }

        // Read Summary From File
        public static Summary ReadSummaryFromFile(in string path)
        {
            if (!Directory.Exists(path)) { return new Summary(); }
            Summary summary = new Summary();

            string PathName = Path.GetFileName(path);

            summary.SummaryPath = path;

            using (BinaryReader reader = new BinaryReader(File.Open(
                Path.Combine(path, $"{Path.GetFileName(path)}.bin"), FileMode.Open)))
            {
                summary._SummaryText = reader.ReadString();
                summary._Post = reader.ReadString();
                summary._Experience = reader.ReadByte();
            }

            return summary;
        }

        public static List<Vacancy> ReadVakansiesToFolder(in string folderPath)
        {
            List<Vacancy> vacansies = new List<Vacancy>();

            string[] fileEntries = Directory.GetFiles(folderPath);

            foreach (string filePath in fileEntries)
            {
                if (Path.GetExtension(filePath).ToLower() == ".bin")
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                    {
                        vacansies.Add(VacancyFileManagerUtils.ReadVacancyFromFile(
                            reader.ReadString()
                            ));
                    }
                }
            }
            return vacansies;
        }

        public static void AddSummaryToVacansy_AddVacancyToMyApplications(in string FolderPathSummary, in string FolderPathVacancy)
        {
            using (BinaryWriter writer = new BinaryWriter(
                File.Open(Path.Combine(FolderPathVacancy,
                EmployerAccountFileManagerUtils.SummariesFolderName, $"{Path.GetFileName(FolderPathSummary)}.bin"),
                FileMode.Create)))
            {
                writer.Write(FolderPathSummary);
            }
            using (BinaryWriter writer = new BinaryWriter(
             File.Open(Path.Combine(FolderPathSummary,
             ApplicantAccountFileManagerUtils.MyApplicationsFolderName, $"{Path.GetFileName(FolderPathVacancy)}.bin"),
             FileMode.Create)))
            {
                writer.Write(FolderPathVacancy);
            }
        }

    }

    // Class for working with Applicant accounts
    public static class ApplicantAccountFileManagerUtils
    {
        private const string LoginAndPasswordFolderName = "LoginAndPassword";
        public const string VacancyesFolderName = "Accepted Job Offers";
        public static string SummaryFolderName = "Symmary";
        public static string MyApplicationsFolderName = "My Applications";

        public static string ConvertToFileNameApplicantWithPrefix(in string login, in string password, in string email)
        {
            return Path.Combine(ServerFileManager._ApplicantAccounts, $"{login} {password} {email}");
        }

        // Write Account To File
        public static void WriteApplicantAccountToFile(in Applicant applicant, in string path)
        {

            if (applicant == null)
            {
                return;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Запись информации об учетной записи
            string accountFilePath = Path.Combine(path, "Account.bin");
            AccountFileUtils.WriteAccountToFile(
                applicant._ApplicantAccount, accountFilePath);

            // Запись логина и пароля
            string loginAndPasswordFolderPath = Path.Combine(path, LoginAndPasswordFolderName);
            AccountFileUtils.WriteLoginAndPasswordToFolder(applicant._ApplicantAccount._LoginPassword, loginAndPasswordFolderPath);

            if (applicant._HasSummary)
            {
                string summariesFolderPath = Path.Combine(path, SummaryFolderName);

                Directory.CreateDirectory(summariesFolderPath);

                summariesFolderPath = $"{Path.Combine(summariesFolderPath, SummaryFolderName)}.bin";

                using (BinaryWriter writer = new BinaryWriter(File.Open(summariesFolderPath, FileMode.Create)))
                {
                    for (int i = 0; i < applicant._Summarylist.Count; i++)
                    {
                        if (applicant._Summarylist[i].SummaryPath != null)
                        {
                            writer.Write(Path.Combine(paths: applicant._Summarylist[i].SummaryPath));
                        }
                        else
                        {
                            string uncode6 = new string(
                                    Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 6).Select(s => s[new Random().Next(s.Length)]).ToArray()
                                    );

                            writer.Write(applicant._Summarylist[i].SummaryPath =
                                Path.Combine(ServerFileManager._ApplicantAccountsSummaries, $"{applicant._ApplicantAccount._AccountID}-{uncode6}"
                            ));

                        }

                    }
                }
                WriteSummaryToFile(applicant, summariesFolderPath);

            }


        }

        // Read Account From File
        public static Applicant? ReadApplicantAccountFromFile(in string path)
        {
            if (!Directory.Exists(path))
            {
                return null;
            }

            Applicant applicant = new Applicant();

            Account account = AccountFileUtils.ReadAccountFromFile(Path.Combine(path, "Account.bin"));

            if (account == null)
            {
                return applicant;
            }

            applicant._ApplicantAccount = account;

            string loginAndPasswordFolder = Path.Combine(path, LoginAndPasswordFolderName);
            account._LoginPassword = AccountFileUtils.ReadLoginAndPasswordFromFolder(loginAndPasswordFolder);

            string ID_Folder_path = Path.Combine(path, SummaryFolderName, $"{SummaryFolderName}.bin");

            if (File.Exists(ID_Folder_path))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(ID_Folder_path, FileMode.Open)))
                {
                    for (byte i = 0; ; i++)
                    {
                        try
                        {
                            ID_Folder_path = reader.ReadString();

                            applicant._Summarylist.Add(
                                ApplicantSummaryFileManagerUtils.ReadSummaryFromFile(ID_Folder_path)
                                );

                            applicant._Summarylist[i]._VacansyList = ApplicantSummaryFileManagerUtils.ReadVakansiesToFolder(
                                Path.Combine(ID_Folder_path, VacancyesFolderName));

                            applicant._Summarylist[i]._MyApplications = ApplicantSummaryFileManagerUtils.ReadVakansiesToFolder(
                                Path.Combine(ID_Folder_path, MyApplicationsFolderName)
                                );

                        }
                        catch (EndOfStreamException)
                        {
                            break;
                        }
                    }
                }
                applicant._HasSummary = true;
            }

            return applicant;
        }

        private static void WriteSummaryToFile(in Applicant applicant, in string path)
        {
            //Write vacancy information
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                for (byte i = 0; i < applicant._Summarylist.Count; i++)
                {
                    string ID_Folder_path = reader.ReadString();
                    Directory.CreateDirectory(ID_Folder_path);

                    Directory.CreateDirectory(Path.Combine(ID_Folder_path, VacancyesFolderName));

                    Directory.CreateDirectory(Path.Combine(ID_Folder_path, MyApplicationsFolderName));

                    for (int j = 0; j < applicant._Summarylist[i]._MyApplications.Count; j++)
                    {

                        using (BinaryWriter writer = new BinaryWriter(
                           File.Open(Path.Combine(applicant._Summarylist[i].SummaryPath,
                           ApplicantAccountFileManagerUtils.MyApplicationsFolderName,
                           $"{Path.GetFileName(applicant._Summarylist[i]._MyApplications[j].VacansyPath)}.bin"),
                           FileMode.Create)))
                        {
                            writer.Write(applicant._Summarylist[i]._MyApplications[j].VacansyPath);
                        }

                    }


                    ApplicantSummaryFileManagerUtils.WriteSummaryToFile(applicant._Summarylist[i],
                        $"{Path.Combine(ID_Folder_path, Path.GetFileName(ID_Folder_path))}.bin"
                    );
                }
            }
        }


    }

    #endregion

    #region Work To Employer
    // Class for working with job vacancies
    public static class VacancyFileManagerUtils
    {
        // Write Vacancy To File
        public static void WriteVacancyToFile(in Vacancy vacancy, in string path)
        {
            if (vacancy == null || Directory.Exists(path)) { return; }

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(vacancy._Title);
                writer.Write(vacancy._Description);
                writer.Write(vacancy._Salary);
                writer.Write(vacancy._ExperienceRequired);
                writer.Write(vacancy._identiinfo._Gmail);
                writer.Write(vacancy._identiinfo._PhoneNumber);
            }
        }

        // Read Vacancy From File
        public static Vacancy ReadVacancyFromFile(in string path)
        {
            if (!Directory.Exists(path)) { return new Vacancy(); }
            Vacancy vacancy = new Vacancy();
            IdentifyingInformation identifyingInformation = new IdentifyingInformation();

            vacancy.VacansyPath = path;

            using (BinaryReader reader = new BinaryReader(File.Open(
                Path.Combine(path, $"{Path.GetFileName(path)}.bin")
                , FileMode.Open)))
            {

                vacancy._Title = reader.ReadString();
                vacancy._Description = reader.ReadString();
                vacancy._Salary = reader.ReadSingle();
                vacancy._ExperienceRequired = reader.ReadByte();
                identifyingInformation._Gmail = reader.ReadString();
                identifyingInformation._PhoneNumber = reader.ReadString();
            }
            vacancy._identiinfo = identifyingInformation;

            return vacancy;
        }

        public static List<Summary> ReadSummariesToFolder(in string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                return new List<Summary>();
            }
            List<Summary> summaries = new List<Summary>();

            string[] fileEntries = Directory.GetFiles(folderPath);

            foreach (string filePath in fileEntries)
            {
                if (Path.GetExtension(filePath).ToLower() == ".bin")
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                    {
                        summaries.Add(
                            ApplicantSummaryFileManagerUtils.ReadSummaryFromFile(reader.ReadString())
                            );
                    }
                }
            }
            return summaries;
        }

        public static void AddVacansyToSummaries_AddSummaryToQualifiedApplicants(in string FolderPathVacancy, in string FolderPathSummary)
        {
            using (BinaryWriter writer = new BinaryWriter(
              File.Open(Path.Combine(FolderPathSummary,
              ApplicantAccountFileManagerUtils.VacancyesFolderName, $"{Path.GetFileName(FolderPathVacancy)}.bin"),
              FileMode.Create)))
            {
                writer.Write(FolderPathVacancy);
            }
            using (BinaryWriter writer = new BinaryWriter(
              File.Open(Path.Combine(FolderPathVacancy,
              EmployerAccountFileManagerUtils.QualifiedApplicantsFolderName, $"{Path.GetFileName(FolderPathSummary)}.bin"),
              FileMode.Create)))
            {
                writer.Write(FolderPathSummary);
            }

        }

    }

    // Class for working with Employer accounts
    public static class EmployerAccountFileManagerUtils
    {
        public const string QualifiedApplicantsFolderName = "Qualified Applicants";
        private const string LoginAndPasswordFolderName = "LoginAndPassword";
        public const string VacancyFolderName = "Vacancy";
        public const string SummariesFolderName = "Applicants";
        public static string ConvertToFileNameEmployerWithPrefix(in string login, in string password, in string email)
        {
            return Path.Combine(ServerFileManager._EmployerAccounts, $"{login} {password} {email}");
        }

        // Write Employer Account To File
        public static void WriteEmployerAccountToFile(in Employer employer, in string path)
        {
            if (employer == null)
            {
                return;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Запись информации об учетной записи
            string accountFilePath = Path.Combine(path, "Account.bin");
            AccountFileUtils.WriteAccountToFile(
                employer._EmployerAccount, accountFilePath);

            // Запись логина и пароля
            string loginAndPasswordFolderPath = Path.Combine(path, LoginAndPasswordFolderName);
            AccountFileUtils.WriteLoginAndPasswordToFolder(employer._EmployerAccount._LoginPassword, loginAndPasswordFolderPath);
            if (employer._HasVacancy)
            {
                string summariesFolderPath = Path.Combine(path, VacancyFolderName);

                Directory.CreateDirectory(summariesFolderPath);

                summariesFolderPath = $"{Path.Combine(summariesFolderPath, VacancyFolderName)}.bin";

                using (BinaryWriter writer = new BinaryWriter(File.Open(summariesFolderPath, FileMode.Create)))
                {
                    for (int i = 0; i < employer._VacancyList.Count; i++)
                    {
                        if (employer._VacancyList[i].VacansyPath != null)
                        {
                            writer.Write(Path.Combine(employer._VacancyList[i].VacansyPath));
                        }
                        else
                        {
                            string uncode6 = new string(
                                    Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 6).Select(s => s[new Random().Next(s.Length)]).ToArray()
                                    );

                            writer.Write(employer._VacancyList[i].VacansyPath =
                                Path.Combine(ServerFileManager._EmployerAccountsVakancies, $"{employer._EmployerAccount._AccountID}-{uncode6}"
                            ));

                        }

                    }
                }
                WriteVacancyToFile(employer, summariesFolderPath);

            }

        }

        // Read Employer Account From File
        public static Employer? ReadEmployerAccountFromFile(in string path)
        {
            if (!Directory.Exists(path))
            {
                return null;
            }

            Employer employer = new Employer();

            Account account = AccountFileUtils.ReadAccountFromFile(Path.Combine(path, "Account.bin"));

            if (account == null)
            {
                return employer;
            }

            employer._EmployerAccount = account;

            string loginAndPasswordFolder = Path.Combine(path, LoginAndPasswordFolderName);
            account._LoginPassword = AccountFileUtils.ReadLoginAndPasswordFromFolder(loginAndPasswordFolder);

            string ID_Folder_path = Path.Combine(path, VacancyFolderName, $"{VacancyFolderName}.bin");

            if (File.Exists(ID_Folder_path))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(ID_Folder_path, FileMode.Open)))
                {
                    for (byte i = 0; ; i++)
                    {
                        try
                        {
                            ID_Folder_path = reader.ReadString();

                            employer._VacancyList.Add(VacancyFileManagerUtils.ReadVacancyFromFile(ID_Folder_path));

                            employer._VacancyList[i]._ResumeList = VacancyFileManagerUtils.ReadSummariesToFolder(
                                Path.Combine(ID_Folder_path, SummariesFolderName)
                                );

                            employer._VacancyList[i]._QualifiedApplicants = VacancyFileManagerUtils.ReadSummariesToFolder(
                                Path.Combine(ID_Folder_path, QualifiedApplicantsFolderName)
                                );


                        }
                        catch (EndOfStreamException)
                        {
                            break;
                        }
                    }
                }

                employer._HasVacancy = true;
            }

            return employer;
        }

        // Метод для записи Vacancy из папки
        private static void WriteVacancyToFile(in Employer employer, in string path)
        {
            // Write vacancy information
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                for (byte i = 0; i < employer._VacancyList.Count; i++)
                {
                    string ID_Folder_path = reader.ReadString();
                    Directory.CreateDirectory(ID_Folder_path);

                    Directory.CreateDirectory(Path.Combine(ID_Folder_path, SummariesFolderName));

                    Directory.CreateDirectory(Path.Combine(ID_Folder_path, QualifiedApplicantsFolderName));

                    for (int j = 0; j < employer._VacancyList[i]._QualifiedApplicants.Count; j++)
                    {

                        using (BinaryWriter writer = new BinaryWriter(
                           File.Open(Path.Combine(employer._VacancyList[i].VacansyPath,
                           EmployerAccountFileManagerUtils.QualifiedApplicantsFolderName,
                           $"{Path.GetFileName(employer._VacancyList[i]._QualifiedApplicants[j].SummaryPath)}.bin"),
                           FileMode.Create)))
                        {
                            writer.Write(employer._VacancyList[i]._QualifiedApplicants[j].SummaryPath);
                        }

                    }

                    VacancyFileManagerUtils.WriteVacancyToFile(employer._VacancyList[i],
                        $"{Path.Combine(ID_Folder_path, Path.GetFileName(ID_Folder_path))}.bin"
                    );

                }
            }

        }

    }
    #endregion

    #endregion

    // Account class to represent an account
    public class Account
    {
        public string _AccountID;
        public LoginAndPassword _LoginPassword;
        public Person _Person;
        public IdentifyingInformation _IdentifyingInfo;

        private static byte _Unicode16 = 16;

        private string IDGenerate(Int16 length)
        {
            Random random = new Random();
            const string chars = "0123456789abcdef";
            char[] idArray = new char[16];

            for (int i = 0; i < 16; i++)
            {
                idArray[i] = chars[random.Next(chars.Length)];
            }

            return new string(idArray);
        }

        public Account()
        {
            _AccountID = "";
            _Person = new Person();
            _LoginPassword = new LoginAndPassword();
            _IdentifyingInfo = new IdentifyingInformation();
        }


        // Constructor to copy information from an existing Account object
        public Account(in Account other)
        {
            if (other != null)
            {
                _AccountID = other._AccountID;
                _Person = new Person(other._Person);
                _LoginPassword = new LoginAndPassword(other._LoginPassword);
                _IdentifyingInfo = new IdentifyingInformation(other._IdentifyingInfo);
            }
        }

        // Constructor to set account information
        public Account(string name, string surname, string fatherName, in DateTime dateOfBirth,
            string phoneNumber, string gmail, string login, string password)
        {
            _Person = new Person(name, surname, fatherName, dateOfBirth);
            _LoginPassword = new LoginAndPassword(login, password);
            _IdentifyingInfo = new IdentifyingInformation(phoneNumber, gmail);
            _AccountID = IDGenerate(_Unicode16);
        }

        // Method to show information about the account
        public void ShowInfo()
        {
            Console.WriteLine($"Account ID: {_AccountID}");
            Console.WriteLine();
            Console.WriteLine($"Person Information:");
            Console.WriteLine($"Name: {_Person._Name}");
            Console.WriteLine($"Surname: {_Person._Surname}");
            Console.WriteLine($"Father's Name: {_Person._FatherName}");
            Console.WriteLine($"Date of Birth: {_Person._DateOfBirth.ToString("dd/MM/yyyy")}");
            Console.WriteLine();
            Console.WriteLine($"Identifying Information:");
            Console.WriteLine($"Phone Number: {_IdentifyingInfo._PhoneNumber}");
            Console.WriteLine($"Gmail: {_IdentifyingInfo._Gmail}");
        }
    }

    // JobSeeker class to represent a Applicant with an account
    public class Applicant : IApplicantInterface
    {
        public List<Summary> _Summarylist;

        public bool _HasSummary = false;

        public Account? _ApplicantAccount;

        public Applicant()
        {
            _Summarylist = new List<Summary>();
        }

        public Applicant(in Applicant other)
        {
            _ApplicantAccount = (other._ApplicantAccount != null)
                ? new Account(other._ApplicantAccount) : null;


            _Summarylist = (other._Summarylist != null) ?
                new List<Summary>(other._Summarylist) : null;

            _HasSummary = other._HasSummary;
            SavingAccount();
        }
        public Applicant(Account other)
        {
            _ApplicantAccount = other;
            _Summarylist = new List<Summary>();
            SavingAccount();
        }

        ~Applicant()
        {
            SavingAccount();
        }
        public void CreateSummary(in string summary, in string post, byte experience)
        {
            _Summarylist.Add(new Summary(post, experience, summary));
            _HasSummary = true;
            SavingAccount();
        }

        public void DeleteSummary(byte index)
        {
            if (_HasSummary)
            {
                string folderNAme = ApplicantAccountFileManagerUtils.SummaryFolderName;
                string path = Path.Combine(DirectoryOrFilePath(), folderNAme, folderNAme);
                using (BinaryReader reader = new BinaryReader(File.Open($"{path}.bin", FileMode.Open)))
                {
                    for (byte i = 0; i <= _Summarylist.Count; i++)
                    {
                        string pathFolder = reader.ReadString();
                        if (i == index)
                        {
                            Directory.Delete(pathFolder, true);
                            _Summarylist.RemoveAt(i);
                            SavingAccount();
                            return;
                        }
                    }
                }
            }

        }

        public void DeleteAccount()
        {
            if (_ApplicantAccount != null)
            {
                if (_HasSummary)
                {
                    for (int i = _Summarylist.Count - 1; i >= 0; i--)
                    {
                        DeleteSummary((byte)i);
                    }
                    _HasSummary = false;
                }
                Directory.Delete(DirectoryOrFilePath(), true);
                _ApplicantAccount = null;
            }
        }

        public void QualifiedApplicantsClear(byte index)
        {
            if (_Summarylist[index]._MyApplications.Count == 0) { return; }
            _Summarylist[index]._MyApplications.Clear();
            Directory.Delete(Path.Combine(_Summarylist[index].SummaryPath,
                ApplicantAccountFileManagerUtils.MyApplicationsFolderName), true);

            Directory.CreateDirectory(Path.Combine(_Summarylist[index].SummaryPath,
                ApplicantAccountFileManagerUtils.MyApplicationsFolderName));
        }

        public void SavingAccount()
        {
            if (_ApplicantAccount != null)
            {
                ApplicantAccountFileManagerUtils.WriteApplicantAccountToFile(this, DirectoryOrFilePath());
            }
        }

        public string DirectoryOrFilePath()
        {
            if (_ApplicantAccount != null)
            {
                return Path.Combine(
                    ServerFileManager._ApplicantAccounts, AccountFileUtils.GetAccountFolderName(_ApplicantAccount)
                    );
            }
            return "";
        }
    }

    // Employer class to represent an employer with an account
    public class Employer : IEmployerInterface
    {
        public Account? _EmployerAccount;

        public List<Vacancy> _VacancyList;

        public bool _HasVacancy = false;
        public Employer()
        {
            _VacancyList = new List<Vacancy>();

        }
        public Employer(in Account other)
        {
            _EmployerAccount = other;
            _VacancyList = new List<Vacancy>();
            SavingAccount();
        }

        public Employer(in Employer other)
        {
            _EmployerAccount = (other._EmployerAccount != null)
                ? new Account(other._EmployerAccount) : null;

            _VacancyList = (other._VacancyList != null) ?
                new List<Vacancy>(other._VacancyList) : null;

            _HasVacancy = other._HasVacancy;
            SavingAccount();
        }

        ~Employer()
        {
            SavingAccount();
        }

        public void DeleteVacancy(byte index)
        {
            if (_HasVacancy)
            {
                string folderName = EmployerAccountFileManagerUtils.VacancyFolderName;
                string path = Path.Combine(DirectoryOrFilePath(), folderName, folderName);
                using (BinaryReader reader = new BinaryReader(File.Open($"{path}.bin", FileMode.Open)))
                {
                    for (byte i = 0; i <= _VacancyList.Count; i++)
                    {
                        string pathFolder = reader.ReadString();
                        if (i == index)
                        {
                            Directory.Delete(pathFolder, true);
                            _VacancyList.RemoveAt(i);
                            reader.Close();
                            SavingAccount();
                            return;
                        }
                    }
                }
            }
        }
        public void CreateVacancy(
            in string title, in string description,
            in float salary, byte experienceRequired)
        {
            _VacancyList.Add(new Vacancy(title, description, salary, experienceRequired, _EmployerAccount._IdentifyingInfo));
            _HasVacancy = true;
            SavingAccount();
        }

        public void DeleteAccount()
        {
            if (_EmployerAccount != null)
            {
                if (_HasVacancy)
                {
                    for (int i = _VacancyList.Count - 1; i >= 0; i--)
                    {
                        DeleteVacancy((byte)i);
                    }
                    _HasVacancy = false;
                }
                Directory.Delete(DirectoryOrFilePath(), true);
                _EmployerAccount = null;
            }
        }

        public string DirectoryOrFilePath()
        {
            if (_EmployerAccount != null)
            {
                return Path.Combine(
                    ServerFileManager._EmployerAccounts, AccountFileUtils.GetAccountFolderName(_EmployerAccount)
                    );
            }
            return "";
        }

        public void QualifiedApplicantsClear(byte index)
        {
            _VacancyList[index]._QualifiedApplicants.Clear();
            Directory.Delete(Path.Combine(_VacancyList[index].VacansyPath,
                EmployerAccountFileManagerUtils.QualifiedApplicantsFolderName), true);

            Directory.CreateDirectory(Path.Combine(_VacancyList[index].VacansyPath,
                EmployerAccountFileManagerUtils.QualifiedApplicantsFolderName));
        }

        public void SavingAccount()
        {
            if (_EmployerAccount != null)
            {
                EmployerAccountFileManagerUtils.WriteEmployerAccountToFile(this, DirectoryOrFilePath());

            }
        }

    }
    public static class Class_IO
    {
        public static void loginOrRegister()
        {
            Console.WriteLine("\n\n\t\t\tLog in\n");
            Console.WriteLine("\t--------------------------------------\n");
            Console.WriteLine("\tLog in\t\t\t\t[ 1 ]\n");
            Console.WriteLine("\tSign up\t\t\t\t[ 2 ]\n");
            Console.WriteLine("\tExit\t\t\t\t[ 3 ]\n");
            Console.Write("Input:\t");


        }
        public static void LogInInSystem()
        {
            Console.WriteLine("\n\t       Log into the system as\n");
            Console.WriteLine("       -----------------------------------------\n");
            Console.WriteLine("\tEmployee\t\t\t[ 1 ]\n");
            Console.WriteLine("\tEmployer\t\t\t[ 2 ]\n");
            Console.WriteLine("\tBack\t\t\t\t[ 3 ]\n");
            Console.Write("Input:\t");
        }
        public static void CreateAnAccout()
        {
            Console.WriteLine("\n\t        Sign up\n");
            Console.WriteLine("       -----------------------------------------\n");
            Console.WriteLine("\tEmployee\t\t\t[ 1 ]\n");
            Console.WriteLine("\tEmployer\t\t\t[ 2 ]\n");
            Console.WriteLine("\tBack\t\t\t\t[ 3 ]\n");
            Console.Write("Input:\t");
        }
        public static void EmployeeMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("MENU:\tEMPLOYEE");
            Console.WriteLine("-----------------------------------------\n\n");
            Console.WriteLine("1.\tMy profile\n");
            Console.WriteLine("2.\tResume\n");
            Console.WriteLine("3.\tVacancies\n");
            Console.WriteLine("4.\tBack\n");
            Console.Write("Input:\t");
        }
        public static void MyProfileMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("MENU:\tEDIT DATA\n");
            Console.WriteLine("-----------------------------------------\n\n");
            Console.WriteLine("1.\tname\n");
            Console.WriteLine("2.\tsurname\n");
            Console.WriteLine("3.\tfathername\n");
            Console.WriteLine("4.\tbirthday\n");
            Console.WriteLine("5.\tphone\n");
            Console.WriteLine("6.\tgmail\n");
            Console.WriteLine("7.\tlogin\n");
            Console.WriteLine("8.\tpassword\n");
            Console.WriteLine("8.\tpassword\n");
            Console.WriteLine("9.\tShow My Profil\n");
            Console.WriteLine("10.\tBack\n");
            Console.Write("Input:\t");
        }

        public static void EmployeeMenuResume()
        {
            Console.WriteLine("\n-----------------------------------------");
            Console.WriteLine("MENU:\tRESUME");
            Console.WriteLine("-----------------------------------------\n\n");
            Console.WriteLine("1.\tCreate a resume;\n");
            Console.WriteLine("2.\tEdit Summary text;\n");
            Console.WriteLine("3.\tEdit Post;\n");
            Console.WriteLine("4.\tEdit Experience;\n");
            Console.WriteLine("5.\tShow Resume\n;");
            Console.WriteLine("6.\tDelete Resume;\n");
            Console.WriteLine("7.\tBack;\n");
            Console.Write("Input:\t");
        }
        public static void EmployerMenuVacancies()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("MENU:\\VACANCIES");
            Console.WriteLine("-----------------------------------------\n\n");
            Console.WriteLine("1.\tAdd a job vacancy;\n");
            Console.WriteLine("2.\tShow vacancy;\n");
            Console.WriteLine("3.\tEdit 'Title' in resume;\n");
            Console.WriteLine("4.\tEdit 'Descriotion' in resume;\n");
            Console.WriteLine("5.\tEdit 'Salary' in resume;\n");
            Console.WriteLine("6.\tEdit 'Experience' in resume;\n");
            Console.WriteLine("7.\tDelete Vacancy;\n");
            Console.WriteLine("8.\tBack;\n");
            Console.Write("Input:\t");
        }
        public static void EmployerMenuApplicants()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("MENU:\\APPROVED");
            Console.WriteLine("-----------------------------------------\n\n");
            Console.WriteLine("1.\tПосмотреть список кандидатов;\n");
            Console.WriteLine("2.\tПросмотреть одобренные вакансии;\n");
            Console.WriteLine("3.\tУдалить одобренный список;\n");
            Console.WriteLine("4.\tBack;\n");
            Console.Write("Input:\t");
        }
        public static void EmployeeVacanciesMain()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("MENU:\tVacancies\n");
            Console.WriteLine("-----------------------------------------\n\n");
            Console.WriteLine("1.\tПоиск вакансий;\n");
            Console.WriteLine("2.\tОдобренные;\n");
            Console.WriteLine("3.\tВакансии на которые ты откликнулся;\n");
            Console.WriteLine("4.\tУдалить у себя вакансии на которых ты откликнулся;\n");
            Console.WriteLine("5.\tНазад;\n");
            Console.Write("Input:\t");
        }
        public static void EmployerMainMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("MENU:\tEMPLOYER\n");
            Console.WriteLine("-----------------------------------------\n\n");
            Console.WriteLine("1.\tMy profile\n");
            Console.WriteLine("2.\tVacancies\n");
            Console.WriteLine("3.\tApplicants\n");
            Console.WriteLine("4.\tBack\n");
            Console.Write("Input:\t");
        }
    }
    internal class Program
    {
        //Not finis

        static Applicant applicant = null;
        static Employer employer = null;
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int UserInput = 0;

            ServerFileManager fileManager = new ServerFileManager();
            bool isValid = false;
            while (true)
            {
                Class_IO.loginOrRegister();
                UserInput = int.Parse(Console.ReadLine());
                Console.Clear();
                if (UserInput < 0 || UserInput > 3) { Console.Clear(); continue; }
                string? login = null, password = null, gmail = null;
                if (UserInput == 1)
                {
                    Class_IO.LogInInSystem();
                    UserInput = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (UserInput < 0 || UserInput > 2) { Console.Clear(); continue; }
                    Console.WriteLine("\n\n");
                    Console.Write("\n\tGmail:\t\t");
                    gmail = Console.ReadLine();
                    Console.Write("\n\tLogin:\t\t");
                    login = Console.ReadLine();
                    Console.Write("\n\tPassword:\t");
                    password = Console.ReadLine();
                    Console.Clear();
                    if (UserInput == 1) //Работник.
                    {
                        if (Directory.Exists(
                           ApplicantAccountFileManagerUtils.ConvertToFileNameApplicantWithPrefix(login, password, gmail)
                           ))
                        {
                            applicant = ApplicantAccountFileManagerUtils.ReadApplicantAccountFromFile(
                               ApplicantAccountFileManagerUtils.ConvertToFileNameApplicantWithPrefix(login, password, gmail)
                           );
                            isValid = true;
                        }
                    }
                    if (UserInput == 2) //Работадатель.
                    {
                        if (Directory.Exists(
                            EmployerAccountFileManagerUtils.ConvertToFileNameEmployerWithPrefix(login, password, gmail)
                            ))
                        {
                            employer = EmployerAccountFileManagerUtils.ReadEmployerAccountFromFile(
                              EmployerAccountFileManagerUtils.ConvertToFileNameEmployerWithPrefix(login, password, gmail)
                           );
                            isValid = true;
                        }

                    }
                }
                else if (UserInput == 2)
                {
                    string name, surname, fathername, phone;
                    DateTime date;
                    Class_IO.CreateAnAccout();
                    UserInput = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (UserInput < 0 || UserInput > 2) { Console.Clear(); continue; }
                    Console.WriteLine("\n\n");
                    Console.Write("\n\tName:\t\t");
                    name = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("\n\tSurname:\t\t");
                    surname = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("\n\tFathername:\t");
                    fathername = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("\n\tBirthday:\t\t");
                    date = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("\n\tPhone:\t\t");
                    phone = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("\n\tGmail:\t");
                    gmail = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("\n\tLogin:\t\t");
                    login = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("\n\tPassword:\t");
                    password = Console.ReadLine();
                    Console.Clear();
                    if (UserInput == 1) // Работник
                    {
                        applicant = new Applicant(
                           new Account(name, surname, fathername, date, phone, gmail, login, password)
                       );
                        applicant.SavingAccount();
                    }
                    if (UserInput == 2) // Работадатель.
                    {
                        employer = new Employer(
                        new Account(name, surname, fathername, date, phone, gmail, login, password)
                        );
                        employer.SavingAccount();
                    }
                    isValid = true;
                }
                else
                {
                    if (applicant != null)
                    {
                        applicant.SavingAccount();
                    }
                    if (employer != null)
                    {
                        employer.SavingAccount();
                    }
                    break;
                }
                if (isValid == false)
                {
                    Console.WriteLine("\n\n\n\t\tAccount not found!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                if (UserInput == 1) // Работник.
                {
                    bool isValid1 = true;
                    while (isValid1)
                    {
                        Class_IO.EmployeeMenu(); // Общее мeню для работника
                        UserInput = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (UserInput < 0 || UserInput > 4) { Console.Clear(); continue; }
                        if (UserInput == 1)
                        {
                            bool isValid2 = true;
                            while (isValid2)
                            {
                                Class_IO.MyProfileMenu(); //Меню внести изменения в профиль.
                                UserInput = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (UserInput)
                                {
                                    case 1:
                                        Console.Write("Enter new name: ");
                                        string newName = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newName))
                                        {
                                            applicant._ApplicantAccount._Person._Name = newName;
                                            Console.WriteLine("Name updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Name cannot be empty.");
                                        }
                                        break;
                                    case 2:
                                        Console.Write("Enter new surname: ");
                                        string newSurname = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newSurname))
                                        {
                                            applicant._ApplicantAccount._Person._Surname = newSurname;
                                            Console.WriteLine("Surname updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Surname cannot be empty.");
                                        }
                                        break;
                                    case 3:
                                        Console.Write("Enter new father's name: ");
                                        string newFatherName = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newFatherName))
                                        {
                                            applicant._ApplicantAccount._Person._FatherName = newFatherName;
                                            Console.WriteLine("Father's name updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Father's name cannot be empty.");
                                        }
                                        break;
                                    case 4:
                                        Console.Write("Enter new date of birth (yyyy-MM-dd): ");
                                        if (DateTime.TryParse(Console.ReadLine(), out DateTime newDateOfBirth))
                                        {
                                            applicant._ApplicantAccount._Person._DateOfBirth = newDateOfBirth;
                                            Console.WriteLine("Date of birth updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd).");
                                        }
                                        break;
                                    case 5:
                                        Console.Write("Enter new phone number: ");
                                        string newPhoneNumber = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newPhoneNumber))
                                        {
                                            applicant._ApplicantAccount._IdentifyingInfo._PhoneNumber = newPhoneNumber;
                                            Console.WriteLine("Phone number updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Phone number cannot be empty.");
                                        }
                                        break;
                                    case 6:
                                        Console.Write("Enter new email: ");
                                        string newEmail = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newEmail))
                                        {
                                            applicant._ApplicantAccount._IdentifyingInfo._Gmail = newEmail;
                                            Console.WriteLine("Email updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Email cannot be empty.");
                                        }
                                        break;
                                    case 7:
                                        Console.Write("Enter new login: ");
                                        string newLogin = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newLogin))
                                        {
                                            applicant._ApplicantAccount._LoginPassword._Login = newLogin;
                                            Console.WriteLine("Login updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Login cannot be empty.");
                                        }
                                        break;
                                    case 8:
                                        Console.Write("Enter new password: ");
                                        string newPassword = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newPassword))
                                        {
                                            applicant._ApplicantAccount._LoginPassword._Password = newPassword;
                                            Console.WriteLine("Password updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Password cannot be empty.");
                                        }
                                        break;
                                    case 9:
                                        applicant._ApplicantAccount.ShowInfo();
                                        Console.ReadKey();
                                        break;
                                    case 10:
                                        isValid2 = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice. Please enter a valid menu option.");
                                        continue;
                                }
                                Console.Clear();
                            }
                        }
                        else if (UserInput == 2) //вход в раздел Резюме.
                        {
                            bool isValid2 = true;
                            while (isValid2)
                            {
                                for (int i = 0; i < applicant._Summarylist.Count; i++)
                                {
                                    Console.WriteLine("----------------------------------------------");
                                    Console.WriteLine($"Number: {i}\n" + applicant._Summarylist[i].GetSummaryInfo());
                                }
                                Class_IO.EmployeeMenuResume(); // Мэню Резюме у РАБОТНИКА
                                UserInput = int.Parse(Console.ReadLine());
                                Console.Clear();

                                switch (UserInput)
                                {
                                    case 1:
                                        {
                                            // Добавить резюме РАБОТНИКА.
                                            Console.WriteLine("Введите текст нового резюме: ");
                                            string newSummaryText = Console.ReadLine();

                                            Console.WriteLine("Введите должность работника: ");
                                            string newPost = Console.ReadLine();

                                            Console.WriteLine("Введите опыт работы: ");
                                            byte newExperience;
                                            if (byte.TryParse(Console.ReadLine(), out newExperience))
                                            {
                                                applicant.CreateSummary(newSummaryText, newPost, newExperience);

                                                Console.WriteLine("Резюме РАБОТНИКА успешно добавлено.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Неверный формат опыта работы. Введите целое число.");
                                            }
                                            break;
                                        }
                                    case 2:
                                        {// Изменить текст Summary text.
                                            Console.WriteLine("Количество имеющихся: " + applicant._Summarylist.Count);
                                            Console.WriteLine("Введите номер резюме: ");
                                            int summaryIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (!(summaryIndex >= 0 && summaryIndex < applicant._Summarylist.Count))
                                            {
                                                Console.WriteLine("Неверный номер резюме.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                continue;
                                            }
                                            Console.WriteLine("Введите новый текст резюме: ");
                                            string newSummaryText = Console.ReadLine();
                                            applicant._Summarylist[summaryIndex]._SummaryText = newSummaryText;
                                            Console.WriteLine("Текст резюме успешно изменен.");
                                            break;
                                        }
                                    case 3:
                                        {// Изменить Post.
                                            Console.WriteLine("Количество имеющихся: " + applicant._Summarylist.Count);
                                            Console.WriteLine("Введите номер резюме: ");
                                            int summaryIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (!(summaryIndex >= 0 && summaryIndex < applicant._Summarylist.Count))
                                            {
                                                Console.WriteLine("Неверный номер резюме.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                continue;
                                            }

                                            Console.WriteLine("Введите новую должность: ");
                                            string newPost = Console.ReadLine();
                                            applicant._Summarylist[summaryIndex]._Post = newPost;
                                            Console.WriteLine("Должность успешно изменена.");

                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Количество имеющихся: " + applicant._Summarylist.Count);
                                            Console.WriteLine("Введите номер резюме: ");
                                            int summaryIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (!(summaryIndex >= 0 && summaryIndex < applicant._Summarylist.Count))
                                            {
                                                Console.WriteLine("Неверный номер резюме.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                continue;
                                            }
                                            // Изменить Experience.
                                            Console.WriteLine("Введите новый опыт работы: ");
                                            byte newExperience;
                                            if (byte.TryParse(Console.ReadLine(), out newExperience))
                                            {
                                                applicant._Summarylist[summaryIndex]._Experience = newExperience;
                                                Console.WriteLine("Опыт работы успешно изменен.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Неверный формат опыта работы. Введите целое число.");
                                            }

                                            break;

                                        }
                                    case 5:
                                        {
                                            if (applicant._Summarylist.Count == 0)
                                            {
                                                Console.WriteLine("Пусто");
                                                break;
                                            }
                                            Console.WriteLine("Количество имеющихся: " + applicant._Summarylist.Count);
                                            foreach (var summary in applicant._Summarylist)
                                            {
                                                Console.WriteLine(summary.GetSummaryInfo());
                                                Console.WriteLine();
                                                Console.WriteLine("----------------------");
                                                Console.WriteLine();
                                            }
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 6:
                                        { // Удалить Это резюме
                                            Console.WriteLine("Количество имеющихся: " + applicant._Summarylist.Count);
                                            Console.WriteLine("Введите номер резюме: ");
                                            int summaryIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (!(summaryIndex >= 0 && summaryIndex < applicant._Summarylist.Count))
                                            {
                                                Console.WriteLine("Неверный номер резюме.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                continue;
                                            }
                                            applicant.DeleteSummary((byte)summaryIndex);
                                            break;
                                        }
                                    case 7:
                                        {// Выйти.
                                            isValid2 = false;
                                            break;
                                        }
                                    default:
                                        {
                                            continue;
                                        }
                                };
                                Console.Clear();
                            }
                        }
                        else if (UserInput == 3) // Раздел вакансии у РАБОТНИКА
                        {
                            bool isValid2 = true;
                            while (isValid2)
                            {
                                Class_IO.EmployeeVacanciesMain();
                                UserInput = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (UserInput)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Количество имеющихся: " + applicant._Summarylist.Count);
                                            Console.Write("Введите номер резюме с которым вы будете просматривать: ");
                                            int summaryIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (!(summaryIndex >= 0 && summaryIndex < applicant._Summarylist.Count))
                                            {
                                                Console.WriteLine("Неверный номер резюме.");
                                                Console.Clear();
                                                continue;
                                            }

                                            if (applicant._Summarylist.Count == 0)
                                            {
                                                Console.WriteLine("Пусто");
                                                Console.ReadKey();
                                                break;

                                            }

                                            Console.Write("Введите должность которую ищите: ");
                                            string title = Console.ReadLine();
                                            string[] subdirectories = Directory.GetDirectories(ServerFileManager._EmployerAccountsVakancies);

                                            List<Vacancy> list = new List<Vacancy>();
                                            foreach (var item in subdirectories)
                                            {
                                                list.Add(VacancyFileManagerUtils.ReadVacancyFromFile(item));
                                            }
                                            List<Vacancy> vacancies = list
                                                .Where(word => word._Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                                                .ToList();

                                            int pageSize = 10; // Количество вакансий на одной странице
                                            int currentPage = 0; // Текущая страница

                                            bool isBool = true;
                                            while (isBool)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Список вакансий:");

                                                for (int i = currentPage * pageSize; i < Math.Min((currentPage + 1) * pageSize, vacancies.Count); i++)
                                                {
                                                    Console.WriteLine($"{i + 1}. {vacancies[i]._Title}");
                                                }

                                                Console.WriteLine("\nДействия:");
                                                Console.WriteLine("1 - Показать следующие 10 вакансий");
                                                Console.WriteLine("2 - Показать предыдущие 10 вакансий");
                                                Console.WriteLine("3 - Посмотреть вакансию под номером");
                                                Console.WriteLine("0 - Выйти");

                                                Console.Write("Выберите действие: ");
                                                string choice = Console.ReadLine();

                                                switch (choice)
                                                {
                                                    case "1":
                                                        if (currentPage * pageSize + 1 < vacancies.Count)
                                                        {
                                                            currentPage++; // Переход на следующую страницу

                                                        }
                                                        break;
                                                    case "2":
                                                        if (currentPage > 0)
                                                        {
                                                            currentPage--; // Переход на предыдущую страницу
                                                        }
                                                        break;
                                                    case "3":
                                                        ViewVacancy(vacancies, applicant._Summarylist[summaryIndex]);
                                                        break;
                                                    case "0":
                                                        isBool = false;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                                                        break;
                                                }
                                            }
                                            break;
                                        }
                                    case 2:
                                        { // Одобренные.
                                            Console.WriteLine("Количество имеющихся: " + applicant._Summarylist.Count);
                                            Console.WriteLine("Введите номер резюме: ");
                                            int summaryIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (!(summaryIndex >= 0 && summaryIndex < applicant._Summarylist.Count))
                                            {
                                                Console.WriteLine("Неверный номер резюме.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                continue;
                                            }

                                            if (applicant._Summarylist[summaryIndex]._VacansyList.Count == 0)
                                            {
                                                Console.WriteLine("Пусто");
                                                break;
                                            }

                                            foreach (var item in applicant._Summarylist[summaryIndex]._VacansyList)
                                            {
                                                Console.WriteLine(item.GetVacancyInfo() + "\n");
                                                Console.WriteLine("-------------------------------------\n");
                                            }
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Количество имеющихся: " + applicant._Summarylist.Count);
                                            Console.WriteLine("Введите номер резюме с которым вы будете просматривать: ");
                                            int summaryIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (!(summaryIndex >= 0 && summaryIndex < applicant._Summarylist.Count))
                                            {
                                                Console.WriteLine("Неверный номер резюме.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                continue;
                                            }

                                            int pageSize = 5;
                                            int currentPage = 0;

                                            bool isBool = true;
                                            while (isBool)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Список вакансий:");
                                                for (int i = currentPage * pageSize; i < Math.Min((currentPage + 1) * pageSize,
                                                    applicant._Summarylist[summaryIndex]._MyApplications.Count); i++)
                                                {
                                                    Console.WriteLine(
                                                        $"{i + 1}.\n {applicant._Summarylist[summaryIndex]._MyApplications[i].GetVacancyInfo()}"
                                                        );
                                                }
                                                if (applicant._Summarylist[summaryIndex]._MyApplications.Count == 0)
                                                {
                                                    Console.WriteLine("\nПусто");
                                                }
                                                Console.WriteLine("\nДействия:");
                                                Console.WriteLine($"1 - Показать следующие {pageSize} вакансии на которые откликнулись");
                                                Console.WriteLine($"2 - Показать предыдущие {pageSize} вакансии на которые откликнулись");
                                                Console.WriteLine("0 - Выйти");

                                                Console.Write("Выберите действие: ");
                                                string choice = Console.ReadLine();

                                                switch (choice)
                                                {
                                                    case "1":
                                                        if (currentPage * pageSize + 1 < applicant._Summarylist[summaryIndex]._MyApplications.Count)
                                                        {
                                                            currentPage++; // Переход на следующую страницу

                                                        }
                                                        break;
                                                    case "2":
                                                        if (currentPage > 0)
                                                        {
                                                            currentPage--; // Переход на предыдущую страницу
                                                        }
                                                        break;
                                                    case "0":
                                                        isBool = false;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                                                        break;
                                                }

                                            }

                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Количество имеющихся: " + applicant._Summarylist.Count);
                                            Console.WriteLine("Введите номер резюме: ");
                                            int summaryIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (!(summaryIndex >= 0 && summaryIndex < applicant._Summarylist.Count))
                                            {
                                                Console.WriteLine("Неверный номер резюме.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                continue;
                                            }
                                            applicant.QualifiedApplicantsClear((byte)summaryIndex);
                                            Console.WriteLine("Успешно удалено!");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 5:
                                        {// Выход
                                            isValid2 = false;
                                            break;
                                        }
                                    default:
                                        {
                                            continue;
                                        }
                                }
                                Console.Clear();
                            }
                        }
                        if (UserInput == 4)
                        {
                            isValid1 = false;
                            break;
                        }

                    }
                }
                else if (UserInput == 2) // РАБОТАДАТЕЛЬ.
                {
                    bool isValid2 = true;
                    while (isValid2)
                    {
                        Class_IO.EmployerMainMenu();
                        UserInput = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (UserInput < 0 || UserInput > 4) { Console.Clear(); continue; }
                        if (UserInput == 1)
                        {
                            bool isVali = true;
                            while (isVali)
                            {
                                Class_IO.MyProfileMenu(); //Меню внести изменения в профиль.
                                UserInput = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (UserInput)
                                {
                                    case 1:
                                        Console.Write("Enter new name: ");
                                        string newName = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newName))
                                        {
                                            employer._EmployerAccount._Person._Name = newName;
                                            Console.WriteLine("Name updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Name cannot be empty.");
                                        }
                                        break;
                                    case 2:
                                        Console.Write("Enter new surname: ");
                                        string newSurname = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newSurname))
                                        {
                                            employer._EmployerAccount._Person._Surname = newSurname;
                                            Console.WriteLine("Surname updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Surname cannot be empty.");
                                        }
                                        break;
                                    case 3:
                                        Console.Write("Enter new father's name: ");
                                        string newFatherName = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newFatherName))
                                        {
                                            employer._EmployerAccount._Person._FatherName = newFatherName;
                                            Console.WriteLine("Father's name updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Father's name cannot be empty.");
                                        }
                                        break;
                                    case 4:
                                        Console.Write("Enter new date of birth (yyyy-MM-dd): ");
                                        if (DateTime.TryParse(Console.ReadLine(), out DateTime newDateOfBirth))
                                        {
                                            employer._EmployerAccount._Person._DateOfBirth = newDateOfBirth;
                                            Console.WriteLine("Date of birth updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd).");
                                        }
                                        break;
                                    case 5:
                                        Console.Write("Enter new phone number: ");
                                        string newPhoneNumber = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newPhoneNumber))
                                        {
                                            employer._EmployerAccount._IdentifyingInfo._PhoneNumber = newPhoneNumber;
                                            Console.WriteLine("Phone number updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Phone number cannot be empty.");
                                        }
                                        break;
                                    case 6:
                                        Console.Write("Enter new email: ");
                                        string newEmail = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newEmail))
                                        {
                                            employer._EmployerAccount._IdentifyingInfo._Gmail = newEmail;
                                            Console.WriteLine("Email updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Email cannot be empty.");
                                        }
                                        break;
                                    case 7:
                                        Console.Write("Enter new login: ");
                                        string newLogin = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newLogin))
                                        {
                                            employer._EmployerAccount._LoginPassword._Login = newLogin;
                                            Console.WriteLine("Login updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Login cannot be empty.");
                                        }
                                        break;
                                    case 8:
                                        Console.Write("Enter new password: ");
                                        string newPassword = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newPassword))
                                        {
                                            employer._EmployerAccount._LoginPassword._Password = newPassword;
                                            Console.WriteLine("Password updated successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input. Password cannot be empty.");
                                        }
                                        break;
                                    case 9:
                                        employer._EmployerAccount.ShowInfo();
                                        break;
                                    case 10:
                                        isVali = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice. Please enter a valid menu option.");
                                        continue;
                                }
                                if (isVali)
                                {
                                    Console.ReadKey();
                                }
                                Console.Clear();
                            }
                        }
                        else if (UserInput == 2) //вход в раздел Вакансии у Работадателя.
                        {
                            bool isbool = true;
                            while (isbool)
                            {
                                Class_IO.EmployerMenuVacancies(); // Мэню Vacancy
                                UserInput = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (UserInput)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Введите название вакансии:");
                                            string title = Console.ReadLine();

                                            Console.WriteLine("Введите описание вакансии:");
                                            string description = Console.ReadLine();

                                            Console.WriteLine("Введите зарплату:");
                                            float salary;
                                            if (float.TryParse(Console.ReadLine(), out salary) == false)
                                            {
                                                Console.WriteLine("Ошибка ввода зарплаты.");
                                                break;
                                            }

                                            Console.WriteLine("Введите требуемый опыт (в годах):");
                                            byte experienceRequired;
                                            if (byte.TryParse(Console.ReadLine(), out experienceRequired) == false)
                                            {
                                                Console.WriteLine("Ошибка ввода опыта.");
                                                break;
                                            }
                                            employer.CreateVacancy(title, description, salary, experienceRequired);
                                            Console.WriteLine("Успешно задано!");
                                            break;
                                        }
                                    case 2:
                                        {

                                            if (employer._VacancyList.Count == 0)
                                            {
                                                Console.WriteLine("Пусто");
                                                break;
                                            }
                                            foreach (var vacancy in employer._VacancyList)
                                            {
                                                Console.WriteLine(vacancy.GetVacancyInfo());
                                                Console.WriteLine();
                                                Console.WriteLine("----------------------");
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case 3:
                                        {// Изменить 'title'.
                                            Console.WriteLine("Количество имеющихся: " + employer._VacancyList.Count);
                                            Console.WriteLine("Введите номер вакансии: ");
                                            int vacancyIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (vacancyIndex >= 0 && vacancyIndex < employer._VacancyList.Count)
                                            {
                                                Console.WriteLine("Введите новый заголовок: ");
                                                string newTitle = Console.ReadLine();
                                                employer._VacancyList[vacancyIndex]._Title = newTitle;

                                                Console.WriteLine("Заголовок успешно изменен.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Неверный номер вакансии.");
                                            }

                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Количество имеющихся: " + employer._VacancyList.Count);
                                            Console.WriteLine("Введите номер вакансии: ");
                                            int vacancyIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (vacancyIndex >= 0 && vacancyIndex < employer._VacancyList.Count)
                                            {
                                                Console.WriteLine("Введите новое описание: ");
                                                string newDescription = Console.ReadLine();
                                                employer._VacancyList[vacancyIndex]._Description = newDescription;
                                                Console.WriteLine("Описание успешно изменено.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Неверный номер вакансии.");
                                            }
                                            break;

                                        }
                                    case 5:
                                        {
                                            //Salary
                                            Console.WriteLine("Количество имеющихся: " + employer._VacancyList.Count);
                                            Console.WriteLine("Введите номер вакансии: ");
                                            int vacancyIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (vacancyIndex >= 0 && vacancyIndex < employer._VacancyList.Count)
                                            {
                                                Console.WriteLine("Введите новую зарплату: ");
                                                float newSalary;
                                                if (float.TryParse(Console.ReadLine(), out newSalary))
                                                {
                                                    employer._VacancyList[vacancyIndex]._Salary = newSalary;
                                                    Console.WriteLine("Зарплата успешно изменена.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Неверный формат зарплаты. Введите число.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Неверный номер вакансии.");
                                            }
                                            break;


                                        }
                                    case 6:
                                        {

                                            // Изменить 'Experience'.
                                            Console.WriteLine("Количество имеющихся: " + employer._VacancyList.Count);
                                            Console.WriteLine("Введите номер вакансии: ");
                                            int vacancyIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (vacancyIndex >= 0 && vacancyIndex < employer._VacancyList.Count)
                                            {
                                                Console.WriteLine("Введите новый опыт: ");
                                                byte newExperience;
                                                if (byte.TryParse(Console.ReadLine(), out newExperience))
                                                {
                                                    employer._VacancyList[vacancyIndex]._ExperienceRequired = newExperience;
                                                    Console.WriteLine("Опыт успешно изменен.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Неверный формат опыта. Введите целое число.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Неверный номер вакансии.");
                                            }
                                            break;
                                        }
                                    case 7:
                                        {//  удалить вакансию.
                                            Console.WriteLine("Количество имеющихся: " + employer._VacancyList.Count);
                                            Console.WriteLine("Введите номер вакансии: ");
                                            int vacancyIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                            if (!(vacancyIndex >= 0 && vacancyIndex < employer._VacancyList.Count))
                                            {
                                                Console.WriteLine("Неверный номер вакансии.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                continue;
                                            }
                                            employer.DeleteVacancy((byte)vacancyIndex);
                                            Console.WriteLine("Успешно удалено!");
                                            break;
                                        }
                                    case 8:
                                        {// Выйти.
                                            isbool = false;
                                            break;
                                        }
                                    default:
                                        {
                                            continue;
                                        }
                                }
                                if (isbool)
                                {
                                    Console.ReadKey();
                                }
                                Console.Clear();
                            }
                        }
                        else if (UserInput == 3) //вход в раздел Откликнувшиеся
                        {
                            bool isbool2 = true;
                            while (isbool2)
                            {
                                Class_IO.EmployerMenuApplicants(); // Мэню Откликнувшиеся
                                UserInput = int.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("Количество имеющихся: " + employer._VacancyList.Count);
                                Console.WriteLine("Введите номер вакансии: ");

                                int vacancyIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                if (!(vacancyIndex >= 0 && vacancyIndex < employer._VacancyList.Count))
                                {
                                    Console.WriteLine("Неверный номер вакансии.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }
                                Console.Clear();
                                switch (UserInput)
                                {
                                    case 1:
                                        {// Проверить лист откликнувшихся.
                                            int currentSummaryIndex = 0; // Индекс текущего резюме
                                            int totalResumes = employer._VacancyList[vacancyIndex]._ResumeList.Count;

                                            bool isBool = true;
                                            while (isBool)
                                            {
                                                Console.Clear();
                                                if (employer._VacancyList[vacancyIndex]._ResumeList.Count == 0)
                                                {
                                                    Console.WriteLine("\nПусто");
                                                    isBool = false;
                                                    break;
                                                }

                                                Console.WriteLine($"Просмотр резюме ({currentSummaryIndex + 1} из {totalResumes}):");
                                                Summary summary = employer._VacancyList[vacancyIndex]._ResumeList[currentSummaryIndex];
                                                Console.WriteLine(summary.GetSummaryInfo());
                                                Console.WriteLine();

                                                Console.WriteLine("Выберите действие:");
                                                Console.WriteLine("1. Одобрить резюме");
                                                Console.WriteLine("2. Отклонить резюме");
                                                Console.WriteLine("3. Перейти к следующему резюме");
                                                Console.WriteLine("4. Вернуться к предыдущему резюме");
                                                Console.WriteLine("5. Завершить просмотр");


                                                string choice = Console.ReadLine();

                                                switch (choice)
                                                {
                                                    case "1":
                                                        if (currentSummaryIndex < totalResumes - 1)
                                                        {
                                                            currentSummaryIndex++;
                                                        }
                                                        VacancyFileManagerUtils.AddVacansyToSummaries_AddSummaryToQualifiedApplicants(
                                                            employer._VacancyList[vacancyIndex].VacansyPath, summary.SummaryPath
                                                            );
                                                        Console.WriteLine("Резюме одобрено!");
                                                        Console.ReadKey();
                                                        break;
                                                    case "2":
                                                        if (currentSummaryIndex < totalResumes - 1)
                                                        {
                                                            currentSummaryIndex++;
                                                        }
                                                        Console.WriteLine("Резюме отклонено.");
                                                        Console.ReadKey();
                                                        break;
                                                    case "3":
                                                        if (currentSummaryIndex < totalResumes - 1)
                                                        {
                                                            currentSummaryIndex++;
                                                        }
                                                        break;
                                                    case "4":
                                                        if (currentSummaryIndex > 0)
                                                        {
                                                            currentSummaryIndex--;
                                                        }
                                                        break;
                                                    case "5":
                                                        isBool = false;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                                                        break;
                                                }
                                            }
                                            break;
                                        }
                                    case 2:
                                        {// Проверить лист одобренных
                                            int pageSize = 5;
                                            int currentPage = 0;

                                            bool isBool = true;
                                            while (isBool)
                                            {
                                                Console.Clear();

                                                Console.WriteLine("Список вакансий:");
                                                for (int i = currentPage * pageSize; i < Math.Min((currentPage + 1) * pageSize,
                                                    employer._VacancyList[vacancyIndex]._QualifiedApplicants.Count); i++)
                                                {
                                                    Console.WriteLine($"{i + 1}.\n {employer._VacancyList[0]._QualifiedApplicants[i].GetSummaryInfo()}");
                                                }
                                                if (employer._VacancyList[vacancyIndex]._QualifiedApplicants.Count == 0)
                                                {
                                                    Console.WriteLine("\nПусто");
                                                }
                                                Console.WriteLine("\nДействия:");
                                                Console.WriteLine($"1 - Показать следующие {pageSize} одобренных резюме");
                                                Console.WriteLine($"2 - Показать предыдущие {pageSize} одобренных резюме");
                                                Console.WriteLine("0 - Выйти");

                                                Console.Write("Выберите действие: ");
                                                string choice = Console.ReadLine();

                                                switch (choice)
                                                {
                                                    case "1":
                                                        if (currentPage * pageSize + 1 < employer._VacancyList[0]._QualifiedApplicants.Count)
                                                        {
                                                            currentPage++; // Переход на следующую страницу

                                                        }
                                                        break;
                                                    case "2":
                                                        if (currentPage > 0)
                                                        {
                                                            currentPage--; // Переход на предыдущую страницу
                                                        }
                                                        break;
                                                    case "0":
                                                        isBool = false;
                                                        isbool2 = false;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                                                        break;
                                                }

                                            }
                                            break;
                                        }
                                    case 3:
                                        {// Удалить лист одобренных.

                                            employer.QualifiedApplicantsClear((byte)vacancyIndex);
                                            Console.WriteLine("Успешно удалено!");
                                            break;
                                        }
                                    case 4:
                                        { // Выйти.
                                            isbool2 = false;
                                            break;
                                        }
                                    default:
                                        {
                                            continue;
                                        }
                                }
                                if (isbool2)
                                {
                                    Console.ReadKey();

                                }
                                Console.Clear();
                            }
                        }
                        else if (UserInput == 4)
                        {
                            isValid2 = false;
                            break;
                        }

                    }
                }
            }

        }
        static void ViewVacancy(in List<Vacancy> vacancies, in Summary summary)
        {
            Console.Clear();
            Console.WriteLine("Введите номер вакансии для просмотра (или 0 для возврата):");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int vacancyNumber) && vacancyNumber >= 1 && vacancyNumber <= vacancies.Count)
            {
                Vacancy selectedVacancy = vacancies[vacancyNumber - 1];
                Console.WriteLine($"Просмотр вакансии:\n{selectedVacancy.GetVacancyInfo()}");

                Console.WriteLine("\nДействия:");
                Console.WriteLine("1 - Откликнуться на вакансию");
                Console.WriteLine("0 - Вернуться к списку вакансий");

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ApplicantSummaryFileManagerUtils.AddSummaryToVacansy_AddVacancyToMyApplications(
                             summary.SummaryPath, selectedVacancy.VacansyPath
                        );
                        applicant.SavingAccount();

                        Console.WriteLine("Вы откликнулись на вакансию.");
                        Console.ReadLine();
                        break;
                    case "0":

                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Возврат к списку вакансий.");
                        Console.ReadLine();
                        break;
                }
            }
            else if (vacancyNumber == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine("Неверный номер вакансии. Возврат к списку вакансий.");
                Console.ReadLine();
            }
        }
    }

}
